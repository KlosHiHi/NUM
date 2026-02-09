using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;

namespace SimpleCalendar.Pages
{
    // Тип отображения
    public enum CalendarViewType { Month, Week }

    public class IndexModel : PageModel
    {
        // Данные для одного дня в календаре
        public class CalendarDay
        {
            public DateTime Date { get; set; }
            public bool IsToday { get; set; }
            public bool IsCurrentMonth { get; set; } // Чтобы "заглушать" дни соседних месяцев
        }

        // Свойства, доступные на странице
        public DateTime CurrentDate { get; set; }
        public CalendarViewType ViewType { get; set; }
        public List<CalendarDay> Days { get; set; } = new List<CalendarDay>();

        public void OnGet(string view = "Month", string date = null)
        {
            // 1. Парсинг типа отображения
            if (!Enum.TryParse(view, true, out CalendarViewType parsedView))
            {
                ViewType = CalendarViewType.Month;
            }
            else
            {
                ViewType = parsedView;
            }

            // 2. Парсинг текущей даты
            if (!DateTime.TryParse(date, out DateTime parsedDate))
            {
                CurrentDate = DateTime.Today;
            }
            else
            {
                CurrentDate = parsedDate;
            }

            // 3. Генерация сетки
            GenerateGrid();
        }

        private void GenerateGrid()
        {
            Days.Clear();
            DateTime startOfGrid;
            DateTime endOfGrid;

            if (ViewType == CalendarViewType.Month)
            {
                // Находим первое число месяца
                var firstDayOfMonth = new DateTime(CurrentDate.Year, CurrentDate.Month, 1);
                
                // Находим начало календарной сетки (ищем понедельник)
                // DayOfWeek.Sunday = 0, Monday = 1. C# считает воскресенье началом недели по умолчанию в некоторых культурах,
                // поэтому корректируем логику для Понедельника как начала недели.
                int daysToSubtract = (int)firstDayOfMonth.DayOfWeek - (int)DayOfWeek.Monday;
                if (daysToSubtract < 0) daysToSubtract += 7;

                startOfGrid = firstDayOfMonth.AddDays(-daysToSubtract);
                // Рисуем 6 недель (стандартный размер сетки месяца)
                endOfGrid = startOfGrid.AddDays(42); 
            }
            else // Week View
            {
                // Ищем понедельник текущей недели
                int daysToSubtract = (int)CurrentDate.DayOfWeek - (int)DayOfWeek.Monday;
                if (daysToSubtract < 0) daysToSubtract += 7;
                
                startOfGrid = CurrentDate.AddDays(-daysToSubtract);
                endOfGrid = startOfGrid.AddDays(7);
            }

            // Заполняем список дней
            for (var dt = startOfGrid; dt < endOfGrid; dt = dt.AddDays(1))
            {
                Days.Add(new CalendarDay
                {
                    Date = dt,
                    IsToday = dt.Date == DateTime.Today,
                    // Для вида недели все дни "текущие", для месяца проверяем месяц
                    IsCurrentMonth = ViewType == CalendarViewType.Week || dt.Month == CurrentDate.Month
                });
            }
        }

        // Хелпер для кнопок "Вперед/Назад"
        public string GetNextDate()
        {
            return ViewType == CalendarViewType.Month 
                ? CurrentDate.AddMonths(1).ToString("yyyy-MM-dd") 
                : CurrentDate.AddDays(7).ToString("yyyy-MM-dd");
        }

        public string GetPrevDate()
        {
            return ViewType == CalendarViewType.Month 
                ? CurrentDate.AddMonths(-1).ToString("yyyy-MM-dd") 
                : CurrentDate.AddDays(-7).ToString("yyyy-MM-dd");
        }
    }
}
