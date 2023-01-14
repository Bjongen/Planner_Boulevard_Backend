using Microsoft.VisualBasic.CompilerServices;
using Schedule.Classes;
using Schedule.Dtos;
using Schedule.Interfaces;

namespace Schedule;

public class PlanningContainer : IPlanningContainer

{
    public List<PlanningDto> _plannings;
    private IPlanningDal _planningDal;

    public PlanningContainer(IPlanningDal planningDal)
    {
        _plannings = new List<PlanningDto>();
        _planningDal = planningDal;
    }

    public List<PlanningDto> GetPlannings()
    {
        return _plannings;
    }

    public List<PlanningDto> GetAllPlannings()
    {
        return _planningDal.GetAll();
    }

    public PlanningDto GetById(int planningId)
    {
        return _planningDal.GetById(planningId);
    }

    public List<PlanningDto> GetAllFromThisWeek(DateTime date)
    {
        return _planningDal.GetAllFromThisWeek(date);
    }

    public List<PlanningDto> GetAllFromWorkerThisWeek(int accountId)
    {
        var planning = new Planning();
        var dateEnd = planning.GetLastDateOfThisWeek();
        var dateBegin = dateEnd.Subtract(new TimeSpan(6, 0, 0, 0));
        List<PlanningDto> planningDtos = _planningDal.GetAllFromWorkerThisWeek(accountId, dateBegin, dateEnd);
        foreach (var dto in planningDtos)
        {
            planning.Weekday = planning.GetWeekDay(dto.Date.Value);
            dto.Weekday = planning.Weekday;
        }
        return planningDtos;
    }

    public int CreatePlanning(PlanningDto planningDto, int accountId)
    {
        _planningDal.CreatePlanning(planningDto, accountId);
        return 1;
    }

    public void UpdatePlanning(PlanningDto planningDto, int accountId)
    {
        _planningDal.UpdatePlanning(planningDto, accountId);
    }

    public void DeletePlanning(int planningId)
    {
        _planningDal.DeletePlanning(planningId);
    }
}