using Microsoft.VisualStudio.TestTools.UnitTesting;
using Schedule;
using Schedule.Dtos;
using Schedule.Interfaces;

namespace Tests;

[TestClass]
public class PlanningContainer
{
    [TestMethod]
    public void GetAll()
    {
        //arrange
        var mock = new PlanningMock();
        List<PlanningDto> list = new List<PlanningDto>();
        //act
        list = mock.GetAll();
        //assert
        Assert.AreEqual(list.Count(), mock.PlanningList.Count());
    }

    [TestMethod]
    public void GetById()
    {
        //arrange
        var mock = new PlanningMock();
        //act
        var planningDto = mock.GetById((int)mock.PlanningList[^1].PlanningId);
        //assert
        Assert.AreEqual(planningDto.PlanningId, mock.PlanningList[^1].PlanningId);
        Assert.AreEqual(planningDto.Date, mock.PlanningList[^1].Date);
        Assert.AreEqual(planningDto.Time, mock.PlanningList[^1].Time);
        Assert.AreEqual(planningDto.Weekday, mock.PlanningList[^1].Weekday);
        Assert.AreEqual(planningDto.WeekNumber, mock.PlanningList[^1].WeekNumber);
    }

    [TestMethod]
    public void GetAllFromThisWeek()
    {
        //arrange
        var mock = new PlanningMock();
        //act
        var dtos = mock.GetAllFromThisWeek((DateTime)mock.PlanningList[^1].Date);
        //assert
        foreach (var dto in dtos)
        {
            Assert.AreEqual(dto.PlanningId, mock.PlanningList[(int)(dto.PlanningId - 1)].PlanningId);
            Assert.AreEqual(dto.Date, mock.PlanningList[(int)(dto.PlanningId - 1)].Date);
            Assert.AreEqual(dto.Time, mock.PlanningList[(int)(dto.PlanningId - 1)].Time);
            Assert.AreEqual(dto.Weekday, mock.PlanningList[(int)(dto.PlanningId - 1)].Weekday);
            Assert.AreEqual(dto.WeekNumber, mock.PlanningList[(int)(dto.PlanningId - 1)].WeekNumber);
        }
    }

    [TestMethod]
    public void GetAllFromWorkerThisWeek()
    {
        //arrange
        var mock = new PlanningMock();
        //act
        var dtos = mock.GetAllFromWorkerThisWeek(mock.PlanningList[^1].PlanningId, mock.PlanningList[^1].Date);
        //assert
        foreach (var dto in dtos)
        {
            Assert.AreEqual(dto.PlanningId, mock.PlanningList[dto.PlanningId - 1].PlanningId);
            Assert.AreEqual(dto.Date, mock.PlanningList[dto.PlanningId - 1].Date);
            Assert.AreEqual(dto.Time, mock.PlanningList[dto.PlanningId - 1].Time);
            Assert.AreEqual(dto.Weekday, mock.PlanningList[dto.PlanningId - 1].Weekday);
            Assert.AreEqual(dto.WeekNumber, mock.PlanningList[dto.PlanningId - 1].WeekNumber);
        }
    }

    [TestMethod]
    public void CreatePlanning()
    {
        //arrange
        var mock = new PlanningMock();
        var planningDto = new PlanningDto
        {
            PlanningId = 3,
            Date = new DateTime(2021, 10, 10),
            Time = new DateTime(10, 10, 10, 10, 10, 10),
            Weekday = "Monday",
            WeekNumber = 1
        };
        int AccountId = 1;
        //act
        mock.CreatePlanning(planningDto, AccountId);
        //assert
        Assert.AreEqual(planningDto.PlanningId, mock.PlanningList[^1].PlanningId);
        Assert.AreEqual(planningDto.Date, mock.PlanningList[^1].Date);
        Assert.AreEqual(planningDto.Time, mock.PlanningList[^1].Time);
        Assert.AreEqual(planningDto.Weekday, mock.PlanningList[^1].Weekday);
        Assert.AreEqual(planningDto.WeekNumber, mock.PlanningList[^1].WeekNumber);
        Assert.IsTrue(mock.PlanningList.Contains(planningDto));
    }

    [TestMethod]
    public void UpdatePlanning()
    {
        //arrange
        var mock = new PlanningMock();
        var planningDto = new PlanningDto
        {
            PlanningId = 1,
            Date = new DateTime(2021, 10, 10),
            Time = new DateTime(10, 10, 10, 10, 10, 10),
            Weekday = "Monday",
            WeekNumber = 1
        };
        int AccountId = 1;
        //act
        mock.UpdatePlanning(planningDto, AccountId);
        //assert
        Assert.AreEqual(planningDto.PlanningId, mock.PlanningList[^1].PlanningId);
        Assert.AreEqual(planningDto.Date, mock.PlanningList[^1].Date);
        Assert.AreEqual(planningDto.Time, mock.PlanningList[^1].Time);
        Assert.AreEqual(planningDto.Weekday, mock.PlanningList[^1].Weekday);
        Assert.AreEqual(planningDto.WeekNumber, mock.PlanningList[^1].WeekNumber);
        Assert.IsTrue(mock.PlanningList.Contains(planningDto));
    }

    [TestMethod]
    public void DeletePlanning()
    {
        //arrange
        var mock = new PlanningMock();
        int id = mock.PlanningList[^1].PlanningId;
        var planningDto = mock.PlanningList[^1];
        //act
        mock.DeletePlanning(id);
        //assert
        Assert.IsFalse(mock.PlanningList.Contains(planningDto));
    }
}