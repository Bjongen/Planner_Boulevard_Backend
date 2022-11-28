using System;
using System.Globalization;
using Scheduling.Dtos;

namespace Scheduling.Classes;

public class Planning
{
    public int PlanningId { get; set; }
    public DateTime Date { get; set; }
    public DateTime Time { get; set; }
    public string Weekday { get; set; }
    public int WeekNumber { get; set; }

    public Planning(int planningId, DateTime date, DateTime time, string dayOfWeek, int weekNumber)
    {
        PlanningId = planningId;
        Date = date;
        Time = time;
        Weekday = dayOfWeek;
        WeekNumber = weekNumber;
    }

    public string GetWeekDay(DateTime date)
    {
        DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(date);
        return day.ToString();
    }

    private static int GetIso8601WeekOfYear(DateTime date)
    {
        DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(date);
        if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
        {
            date = date.AddDays(3);
        }

        return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(date, CalendarWeekRule.FirstFourDayWeek,
            DayOfWeek.Monday);
    }

    private DateTime GetLastDateOfThisWeek()
    {
        DateTime date = DateTime.Now;
        DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(date);
        while (day != DayOfWeek.Sunday)
        {
            date = date.AddDays(1);
            day++;
        }

        return date;
    }

    public DateTime GetEndDateFromWeekNumber(int Selectedweek)
    {
        int weekNumber = GetIso8601WeekOfYear(GetLastDateOfThisWeek());
        int difference = 0;
        if (weekNumber != Selectedweek)
        {
            difference = Selectedweek - weekNumber;
        }

        DateTime endDate = GetLastDateOfThisWeek().AddDays(difference * 7);
        return endDate;
    }

    public Planning(DateTime date, DateTime time, string dayOfWeek, int weekNumber)
    {
        Date = date;
        Time = time;
        Weekday = dayOfWeek;
        WeekNumber = weekNumber;
    }

    public Planning(PlanningDto planningDto)
    {
        PlanningId = planningDto.PlanningId;
        Date = planningDto.Date;
        Time = planningDto.Time;
        Weekday = planningDto.DayOfWeek;
        WeekNumber = planningDto.WeekNumber;
    }

    public PlanningDto ToDto()
    {
        return new PlanningDto
        {
            PlanningId = PlanningId,
            Date = Date,
            Time = Time,
            DayOfWeek = Weekday,
            WeekNumber = WeekNumber
        };
    }
}