using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using Schedule;
using Schedule.Dtos;
using Schedule.Interfaces;

namespace Planner_Boulevard_Backend.Controller;

[ApiController]
[Route("[action]")]
public class PlanningController : ControllerBase
{
    private readonly ILogger<PlanningController> _logger;
    private IPlanningContainer _planningContainer = new PlanningContainer(new PlanningDal());

    public PlanningController(ILogger<PlanningController> logger)
    {
        _logger = logger;
    }
    
    [HttpGet]
    [ActionName("PlanningsGet")]
    public List<PlanningDto> Get([FromQuery] int accountId)
    {
        try
        {
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            return _planningContainer.GetAllFromWorkerThisWeek(accountId);
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            return null;
        }
    }

    [HttpPost]
    [ActionName("PlanningPost")]
    public int Post(PlanningDto planningDto, int accountId)
    {
        try
        {
            return _planningContainer.CreatePlanning(planningDto, accountId);
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            return 0;
        }
    }

    [HttpPut]
    [ActionName("PlanningPut")]
    public bool Put(PlanningDto planningDto, int accountId)
    {
        try
        {
            _planningContainer.UpdatePlanning(planningDto, accountId);
            return true;
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            return false;
        }
    }

    [HttpDelete]
    [ActionName("PlanningDelete")]
    public bool Delete([FromQuery] int planningId)
    {
        try
        {
            _planningContainer.DeletePlanning(planningId);
            return true;
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            return false;
        }
    }
}