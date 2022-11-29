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

    public List<PlanningDto> GetAllFromWorkerThisWeek(int accountId, DateTime date)
    {
        return _planningDal.GetAllFromWorkerThisWeek(accountId, date);
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