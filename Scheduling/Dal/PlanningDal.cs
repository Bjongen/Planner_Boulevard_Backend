using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Scheduling.Dtos;
using Dapper;

namespace Scheduling.Dal
{
    public class PlanningDal : IPlanningDal
    {
        private IDbConnection _dbConnection;

        public PlanningDal(IDbConnection dbConnecion)
        {
            _dbConnection = dbConnecion;
        }

        public List<PlanningDto> GetAll()
        {
            var sql = "Select * From Planning;";
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
            var sql = "Select * From Planning Where PlanningId = @PlanningId;";
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
            var sql = "Select * From Planning " +
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

        public List<PlanningDto> GetAllFromWorkerThisWeek(int accountId, DateTime date)
        {
            var sql = "Select * From Planning Where AccountId = @accountId" +
                      "And Date between @date And @date-6";
            try
            {
                using (_dbConnection)
                {
                    return _dbConnection.Query<PlanningDto>(sql, new
                    {
                        accountId,
                        date
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
            var sql =
                "Insert Into Planning values (@Date, @Time, @AccountId);";
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
            var sql =
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
            var sql = "Delete From Planning Where PlanningId = @PlanningId;";
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
}