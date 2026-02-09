@page
@model IndexModel
@{ ViewData["Title"] = "Календарь событий"; }

<div class="calendar-container">
     <div class="calendar-grid-header">
        <div>Пн</div><div>Вт</div><div>Ср</div><div>Чт</div><div>Пт</div><div class="weekend">Сб</div><div class="weekend">Вс</div>
    </div>

    <div class="calendar-grid">
        @foreach (var day in Model.Days)
        {
            <div class="day-cell @(day.IsToday ? "today" : "") @(day.IsCurrentMonth ? "" : "other-month")">
                <div class="day-number">@day.Date.Day</div>
                
                <div class="events-list">
                    @foreach (var evt in day.Events)
                    {
                        <div class="event-item" style="background-color: @evt.Color;">
                            @evt.Title
                            
                            <div class="event-tooltip">
                                <strong>@evt.Title</strong><br/>
                                <small>@evt.Date.ToShortDateString()</small>
                                <hr style="margin: 5px 0; border-color: #ffffff50;" />
                                @evt.Description
                            </div>
                        </div>
                    }
                </div>
            </div>
        }
    </div>
</div>

<style>
    /* ... (Старые стили контейнера и сетки оставляем) ... */
    .calendar-container { max-width: 900px; margin: 0 auto; font-family: sans-serif; }
    .calendar-grid { display: grid; grid-template-columns: repeat(7, 1fr); gap: 5px; }
    .day-cell { border: 1px solid #eee; min-height: 120px; padding: 5px; background: #fff; position: relative; } /* min-height чтобы влезли события */
    .day-number { font-weight: bold; margin-bottom: 5px; }
    .day-cell.today { background-color: #eaf4ff; border: 2px solid #007bff; }
    .day-cell.other-month { background-color: #fafafa; color: #ccc; }

    /* Стили для событий */
    .events-list {
        display: flex;
        flex-direction: column;
        gap: 2px;
    }

    .event-item {
        color: white;
        padding: 2px 5px;
        border-radius: 3px;
        font-size: 0.75em;
        cursor: pointer;
        white-space: nowrap;      /* Не переносить текст */
        overflow: hidden;         /* Скрывать хвост */
        text-overflow: ellipsis;  /* Добавлять троеточие ... */
        position: relative;       /* Важно для позиционирования тултипа */
    }

    .event-item:hover {
        opacity: 0.9;
        /* z-index не поможет родительскому overflow, но выделит элемент */
        z-index: 10; 
        overflow: visible; /* Чтобы тултип не обрезался */
    }

    /* Стили всплывающей подсказки */
    .event-tooltip {
        display: none; /* Скрыто по умолчанию */
        position: absolute;
        bottom: 100%; /* Появляется над событием */
        left: 50%;
        transform: translateX(-50%); /* Центрируем */
        background-color: #333;
        color: #fff;
        padding: 10px;
        border-radius: 5px;
        width: 200px;
        z-index: 1000;
        box-shadow: 0 4px 8px rgba(0,0,0,0.2);
        white-space: normal; /* Текст внутри тултипа переносится нормально */
        text-align: left;
        pointer-events: none; /* Чтобы мышка не "спотыкалась" об тултип */
    }

    /* Стрелочка у тултипа */
    .event-tooltip::after {
        content: "";
        position: absolute;
        top: 100%;
        left: 50%;
        margin-left: -5px;
        border-width: 5px;
        border-style: solid;
        border-color: #333 transparent transparent transparent;
    }

    /* Показываем тултип при наведении на .event-item */
    .event-item:hover .event-tooltip {
        display: block;
    }
</style>
