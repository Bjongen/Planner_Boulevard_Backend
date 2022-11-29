using System.Globalization;
using Schedule.Dtos;

namespace Schedule.Classes;

public class Planning
{
    public int PlanningId { get; set; }
    public DateTime Date { get; set; }
    public DateTime Time { get; set; }
    public string Weekday { get; set; }
    public int Weeknumber { get; set; }
    
    //create constructor
    public Planning(int planningId, DateTime date, DateTime time, string weekday, int weeknumber)
    {
        PlanningId = PlanningId;
        Date = date;
        Time = time;
        Weekday = weekday;
        Weeknumber = weeknumber;
    }
    
    public string GetWeekday(DateTime date)
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
        
        return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(date, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
    }

    private DateTime GetLastDateOfThisWeek()
    {
        DateTime date = DateTime.Now;
        DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(date);
        while (day != DayOfWeek.Sunday)
        {
            date.AddDays(1);
            day++;
        }

        return date;
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
        Weeknumber = weekNumber;
    }
    
    //create constructor from dto
    public Planning(PlanningDto dto)
    {
        PlanningId = dto.PlanningId;
        Date = dto.Date;
        Time = dto.Time;
        Weekday = dto.Weekday;
        Weeknumber = dto.WeekNumber;
    }
    
    public PlanningDto ToDto()
    {
        return new PlanningDto
        {
            PlanningId = PlanningId,
            Date = Date,
            Time = Time,
            Weekday = Weekday,
            WeekNumber = Weeknumber
        };
    }
}