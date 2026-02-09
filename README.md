using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq; // Не забудьте этот using для фильтрации

namespace SimpleCalendar.Pages
{
    public enum CalendarViewType { Month, Week }

    public class IndexModel : PageModel
    {
        // 1. Модель События
        public class CalendarEvent
        {
            public string Title { get; set; }
            public string Description { get; set; } // Это покажем при наведении
            public DateTime Date { get; set; }
            public string Color { get; set; } = "#3788d8"; // Цвет плашки
        }

        public class CalendarDay
        {
            public DateTime Date { get; set; }
            public bool IsToday { get; set; }
            public bool IsCurrentMonth { get; set; }
            // 2. Список событий для конкретного дня
            public List<CalendarEvent> Events { get; set; } = new List<CalendarEvent>();
        }

        public DateTime CurrentDate { get; set; }
        public CalendarViewType ViewType { get; set; }
        public List<CalendarDay> Days { get; set; } = new List<CalendarDay>();

        public void OnGet(string view = "Month", string date = null)
        {
            // ... (парсинг ViewType и CurrentDate оставляем как было) ...
            if (!Enum.TryParse(view, true, out CalendarViewType parsedView)) ViewType = CalendarViewType.Month;
            else ViewType = parsedView;

            if (!DateTime.TryParse(date, out DateTime parsedDate)) CurrentDate = DateTime.Today;
            else CurrentDate = parsedDate;

            // Получаем "базу данных" событий
            var allEvents = GetMockEvents();

            GenerateGrid(allEvents);
        }

        // Имитация базы данных
        private List<CalendarEvent> GetMockEvents()
        {
            return new List<CalendarEvent>
            {
                new CalendarEvent { Title = "Сдача отчета", Description = "Нужно отправить отчет бухгалтеру до 18:00", Date = DateTime.Today, Color = "#d9534f" },
                new CalendarEvent { Title = "Встреча с клиентом", Description = "Обсуждение проекта Razor Pages", Date = DateTime.Today.AddDays(2), Color = "#5cb85c" },
                new CalendarEvent { Title = "День рождения", Description = "Купить подарок", Date = DateTime.Today.AddDays(-3), Color = "#f0ad4e" },
                new CalendarEvent { Title = "Спортзал", Description = "День ног", Date = DateTime.Today.AddDays(5) }
            };
        }

        private void GenerateGrid(List<CalendarEvent> allEvents)
        {
            Days.Clear();
            DateTime startOfGrid, endOfGrid;

            // ... (Логика определения startOfGrid и endOfGrid остается прежней) ...
            if (ViewType == CalendarViewType.Month)
            {
                var firstDayOfMonth = new DateTime(CurrentDate.Year, CurrentDate.Month, 1);
                int daysToSubtract = (int)firstDayOfMonth.DayOfWeek - (int)DayOfWeek.Monday;
                if (daysToSubtract < 0) daysToSubtract += 7;
                startOfGrid = firstDayOfMonth.AddDays(-daysToSubtract);
                endOfGrid = startOfGrid.AddDays(42);
            }
            else
            {
                int daysToSubtract = (int)CurrentDate.DayOfWeek - (int)DayOfWeek.Monday;
                if (daysToSubtract < 0) daysToSubtract += 7;
                startOfGrid = CurrentDate.AddDays(-daysToSubtract);
                endOfGrid = startOfGrid.AddDays(7);
            }

            for (var dt = startOfGrid; dt < endOfGrid; dt = dt.AddDays(1))
            {
                var day = new CalendarDay
                {
                    Date = dt,
                    IsToday = dt.Date == DateTime.Today,
                    IsCurrentMonth = ViewType == CalendarViewType.Week || dt.Month == CurrentDate.Month,
                    // 3. Фильтруем события для этого дня
                    Events = allEvents.Where(e => e.Date.Date == dt.Date).ToList()
                };
                Days.Add(day);
            }
        }
        
        // ... (GetNextDate и GetPrevDate оставляем как было) ...
        public string GetNextDate() => ViewType == CalendarViewType.Month ? CurrentDate.AddMonths(1).ToString("yyyy-MM-dd") : CurrentDate.AddDays(7).ToString("yyyy-MM-dd");
        public string GetPrevDate() => ViewType == CalendarViewType.Month ? CurrentDate.AddMonths(-1).ToString("yyyy-MM-dd") : CurrentDate.AddDays(-7).ToString("yyyy-MM-dd");
    }
}
