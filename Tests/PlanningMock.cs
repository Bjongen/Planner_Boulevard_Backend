using Schedule.Classes;
using Schedule.Dtos;
using Schedule.Interfaces;

namespace Tests;

public class PlanningMock : IPlanningDal
{
    public List<PlanningDto> PlanningList = new();

    public PlanningMock()
    {
        var Date = new DateTime(2021, 1, 1, 8, 0, 0);
        var Hour = Date.Hour;
        var minute = Date.Minute;
        var year = Date.Year;
        var month = Date.Month;
        var day = Date.Day;
        var Date2 = DateTime.Parse(year + "-" + month + "-" + day);
        var Time = DateTime.Parse(Hour + ":" + minute);
        PlanningList.Add(new Planning()
        {
            PlanningId = 1,
            Date = Date2,
            Time = Time,
            Weekday = "Wednesday",
            WeekNumber = 1
        }.ToDto());
        PlanningList.Add(new Planning()
            { PlanningId = 2, Date = Date2, Time = Time, Weekday = "Friday", WeekNumber = 2 }.ToDto());
    }

    public List<PlanningDto> GetAll()
    {
        return PlanningList;
    }

    public PlanningDto GetById(int Id)
    {
        var returnDto = new PlanningDto();
        foreach (var dto in PlanningList)
        {
            if (dto.PlanningId == Id)
            {
                returnDto = dto;
            }
        }

        return returnDto;
    }

    public List<PlanningDto> GetAllFromThisWeek(DateTime dateTime)
    {
        var returnList = new List<PlanningDto>();
        Planning planning = new Planning();
        var weeknumber = planning.GetIso8601WeekOfYear(dateTime);
        foreach (var dto in PlanningList)
        {
            if (dto.WeekNumber == weeknumber)
            {
                returnList.Add(dto);
            }
        }

        return returnList;
    }

    //todo implement accountId
    public List<PlanningDto> GetAllFromWorkerThisWeek(int AccountId, DateTime date)
    {
        var returnList = new List<PlanningDto>();
        Planning planning = new Planning();
        var weeknumber = planning.GetIso8601WeekOfYear(date);
        foreach (var dto in PlanningList)
        {
            if (dto.WeekNumber == weeknumber && dto.PlanningId == AccountId)
            {
                returnList.Add(dto);
            }
        }

        return returnList;
    }

    //todo implement accountId
    public void CreatePlanning(PlanningDto planningDto, int AccountId)
    {
        var id = PlanningList.Count + 1;
        planningDto.PlanningId = id;
        PlanningList.Add(planningDto);
    }

    //todo implement accountId
    public void UpdatePlanning(PlanningDto planningDto, int AccountId)
    {
        var removeDto = new PlanningDto();
        foreach (var dto in PlanningList)
        {
            if (dto.PlanningId == planningDto.PlanningId)
            {
                removeDto = dto;
            }
        }

        PlanningList.Remove(removeDto);
        PlanningList.Add(planningDto);
    }

    public void DeletePlanning(int Id)
    {
        var removeDto = new PlanningDto();
        foreach (var dto in PlanningList)
        {
            if (dto.PlanningId == Id)
            {
                removeDto = dto;
            }
        }

        PlanningList.Remove(removeDto);
    }
}