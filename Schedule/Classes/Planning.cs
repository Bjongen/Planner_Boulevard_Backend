using System.Globalization;
using Schedule.Dtos;

namespace Schedule.Classes;

public class Planning
{
    public int? PlanningId { get; set; }
    public DateTime? Date { get; set; }
    public DateTime? Time { get; set; }
    public string? Weekday { get; set; }
    public int? WeekNumber { get; set; }

    public Planning()
    {
        
    }
    public Planning(int planningId, DateTime date, DateTime time, string weekday, int weekNumber)
    {
        PlanningId = planningId;
        Date = date;
        Time = time;
        Weekday = weekday;
        WeekNumber = weekNumber;
    }
    
    public string GetWeekDay(DateTime date)
    {
        DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(date);
        Weekday = day.ToString();
        return day.ToString();
    }
    
    public int GetIso8601WeekOfYear(DateTime date)
    {
        DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(date);
        if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
        {
            date = date.AddDays(3);
        }
        
        return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(date, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
    }

    public DateTime GetLastDateOfThisWeek()
    {
        DateTime date = DateTime.Now;
        DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(date);
        int x = 0;
        while (day != DayOfWeek.Sunday)
        {
            x++;
            if (day == DayOfWeek.Saturday)
            {
                day = DayOfWeek.Sunday;
            }
            else
            {
                day++;
            }
        }

        return date.AddDays(x);
    }

    public DateTime GetEndDateFromWeekNumber(int selectedWeek)
    {
        int weeknumber = GetIso8601WeekOfYear(GetLastDateOfThisWeek());
        int difference = 0;
        if (weeknumber > selectedWeek)
        {
            difference = weeknumber - selectedWeek;
        }
        
        DateTime endDate = GetLastDateOfThisWeek().AddDays(-difference * 7);
        return endDate;
    }

    public Planning(DateTime date, DateTime time, string weekday, int weekNumber)
    {
        Date = date;
        Time = time;
        Weekday = weekday;
        WeekNumber = weekNumber;
    }
    
    public Planning(PlanningDto dto)
    {
        PlanningId = dto.PlanningId;
        Date = dto.Date;
        Time = dto.Time;
        Weekday = dto.Weekday;
        WeekNumber = dto.WeekNumber;
    }
    
    public PlanningDto ToDto()
    {
        return new PlanningDto
        {
            PlanningId = PlanningId,
            Date = Date,
            Time = Time,
            Weekday = Weekday,
            WeekNumber = WeekNumber
        };
    }
}