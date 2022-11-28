using System;
using System.Collections.Generic;
using Scheduling.Dtos;

namespace Scheduling
{
    public interface IPlanningDal
    {
        public List<PlanningDto> GetAll();
        public PlanningDto GetById(int planningId);
        public List<PlanningDto> GetAllFromThisWeek(DateTime dateTime);
        public List<PlanningDto> GetAllFromWorkerThisWeek(int accountId, DateTime date);
        public void CreatePlanning(PlanningDto planningDto, int accountId);
        public void UpdatePlanning(PlanningDto planningDto, int accountId);
        public void DeletePlanning(int planningId);
    }
}