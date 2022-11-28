using System;
using System.Collections.Generic;
using Scheduling.Dtos;

namespace Scheduling
{
    public interface IPlanningContainer
    {
        public List<PlanningDto> GetPlannings();
        public List<PlanningDto> GetAllPlannings();
        public PlanningDto GetById(int planningId);
        public List<PlanningDto> GetAllFromThisWeek(DateTime date);
        public List<PlanningDto> GetAllFromWorkerThisWeek(int accountId, DateTime date);
        public int CreatePlanning(PlanningDto planningDto, int accountId);
        public void UpdatePlanning(PlanningDto planningDto, int accountId);
        public void DeletePlanning(int planningId);
    }
}