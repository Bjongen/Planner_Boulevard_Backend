namespace Schedule.Dtos;

public class PlanningDto
{
    public int? PlanningId { get; set; }
    public DateTime? Date { get; set; }
    public DateTime? Time { get; set; }
    public string? Weekday { get; set; }
    public int? WeekNumber { get; set; }
}