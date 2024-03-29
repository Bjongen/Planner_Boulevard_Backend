using System.Data;
using System.Data.SqlClient;
using Dapper;
using Schedule.Dtos;
using Schedule.Interfaces;

namespace Schedule;

public class PlanningDal : IPlanningDal
{
    private IDbConnection _dbConnection =
        new SqlConnection("Server=mssqlstud.fhict.local;Uid=dbi488751;Database=dbi488751;Pwd=Bjongen2003;");
        
    
    public List<PlanningDto> GetAll()
    {
        const string sql = "Select * From Planning;";
        try
        {
            using (_dbConnection)
            {
                return _dbConnection.Query<PlanningDto>(sql).ToList();
            }
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public PlanningDto GetById(int planningId)
    {
        const string sql = "Select * From Planning Where PlanningId = @PlanningId;";
        try
        {
            using (_dbConnection)
            {
                return _dbConnection.QuerySingle<PlanningDto>(sql, new
                {
                    planningId
                });
            }
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public List<PlanningDto> GetAllFromThisWeek(DateTime date)
    {
        const string sql = "Select * From Planning " +
                           "Where Date Between @date And @date-6;";
        try
        {
            using (_dbConnection)
            {
                return _dbConnection.Query<PlanningDto>(sql, new
                {
                    date
                }).ToList();
            }
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public List<PlanningDto> GetAllFromWorkerThisWeek(int accountId, DateTime dateBegin, DateTime dateEnd)
    {
        const string sql = "Select * From Planning Where AccountId = @accountId " +
                           "And Date between @dateBegin And @dateEnd;";
        try
        {
            using (_dbConnection)
            {
                
                return _dbConnection.Query<PlanningDto>(sql, new
                {
                    accountId,
                    dateBegin,
                    dateEnd
                }).ToList();
            }
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public void CreatePlanning(PlanningDto planningDto, int accountId)
    {
        const string sql = "Insert Into Planning values (@Date, @Time, @AccountId);";
        try
        {
            using (_dbConnection)
            {
                _dbConnection.Execute(sql, new
                {
                    planningDto.Date,
                    planningDto.Time,
                    accountId
                });
            }
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public void UpdatePlanning(PlanningDto planningDto, int accountId)
    {
        const string sql =
            "Update Planning Set Date = @Date, Time = @Time, AccountId = @AccountId where PlanningId = @PlanningId;";
        try
        {
            using (_dbConnection)
            {
                _dbConnection.Execute(sql, new
                {
                    planningDto.Date,
                    planningDto.Time,
                    accountId,
                    planningDto.PlanningId
                });
            }
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public void DeletePlanning(int planningId)
    {
        const string sql = "Delete From Planning Where PlanningId = @PlanningId;";
        try
        {
            using (_dbConnection)
            {
                _dbConnection.Execute(sql, new
                {
                    planningId
                });
            }
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}