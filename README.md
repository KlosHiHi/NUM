@page
@model IndexModel
@{
    ViewData["Title"] = "Календарь";
    // Форматирование заголовка
    string headerText = Model.ViewType == SimpleCalendar.Pages.CalendarViewType.Month 
        ? Model.CurrentDate.ToString("MMMM yyyy") 
        : $"Неделя: {Model.Days[0].Date:dd.MM} - {Model.Days[6].Date:dd.MM}";
}

<div class="calendar-container">
    
    <div class="calendar-header">
        <div class="nav-buttons">
            <a asp-page="./Index" asp-route-view="@Model.ViewType" asp-route-date="@Model.GetPrevDate()" class="btn">❮ Назад</a>
            <a asp-page="./Index" asp-route-view="@Model.ViewType" asp-route-date="@DateTime.Today.ToString("yyyy-MM-dd")" class="btn">Сегодня</a>
            <a asp-page="./Index" asp-route-view="@Model.ViewType" asp-route-date="@Model.GetNextDate()" class="btn">Вперед ❯</a>
        </div>
        
        <h2>@headerText</h2>

        <div class="view-switch">
            <a asp-page="./Index" asp-route-view="Month" asp-route-date="@Model.CurrentDate.ToString("yyyy-MM-dd")" 
               class="btn @(Model.ViewType == SimpleCalendar.Pages.CalendarViewType.Month ? "active" : "")">Месяц</a>
            <a asp-page="./Index" asp-route-view="Week" asp-route-date="@Model.CurrentDate.ToString("yyyy-MM-dd")" 
               class="btn @(Model.ViewType == SimpleCalendar.Pages.CalendarViewType.Week ? "active" : "")">Неделя</a>
        </div>
    </div>

    <div class="calendar-grid-header">
        <div>Пн</div><div>Вт</div><div>Ср</div><div>Чт</div><div>Пт</div><div class="weekend">Сб</div><div class="weekend">Вс</div>
    </div>

    <div class="calendar-grid">
        @foreach (var day in Model.Days)
        {
            <div class="day-cell @(day.IsToday ? "today" : "") @(day.IsCurrentMonth ? "" : "other-month")">
                <span class="day-number">@day.Date.Day</span>
                </div>
        }
    </div>
</div>

<style>
    /* Базовые стили */
    .calendar-container { max-width: 800px; margin: 0 auto; font-family: sans-serif; }
    
    /* Шапка */
    .calendar-header { display: flex; justify-content: space-between; align-items: center; margin-bottom: 20px; }
    .btn { text-decoration: none; padding: 5px 10px; border: 1px solid #ccc; color: #333; border-radius: 4px; }
    .btn:hover { background-color: #f0f0f0; }
    .btn.active { background-color: #007bff; color: white; border-color: #007bff; }
    
    /* Сетка */
    .calendar-grid-header, .calendar-grid {
        display: grid;
        grid-template-columns: repeat(7, 1fr); /* 7 колонок */
        gap: 5px;
    }
    .calendar-grid-header { font-weight: bold; text-align: center; margin-bottom: 5px; }
    .calendar-grid-header .weekend { color: #d9534f; }

    /* Ячейки */
    .day-cell {
        border: 1px solid #eee;
        height: 100px; /* Фиксированная высота */
        padding: 5px;
        background-color: #fff;
        position: relative;
    }
    
    /* Стили состояний */
    .day-cell.other-month { background-color: #f9f9f9; color: #ccc; }
    .day-cell.today { border: 2px solid #007bff; background-color: #eaf4ff; }
    .day-number { font-weight: bold; }
</style>
