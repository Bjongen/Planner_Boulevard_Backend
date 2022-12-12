using Microsoft.VisualStudio.TestTools.UnitTesting;
using Schedule.Dtos;

namespace Tests.PerformanceTests;

[TestClass]
public class PlanningLoadTest
{
    [TestMethod]
    public void CreateLoadTest10()
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
        var AccountId = 1;
        //act
        for (var i = 0; i < 10; i++)
        {
            mock.CreatePlanning(planningDto, AccountId);
        }

        //assert
        //the +2 is for the 2 planning that are already in the mock
        Assert.IsTrue(mock.PlanningList.Count == 10 + 2);
    }

    [TestMethod]
    public void CreateLoadTest50()
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
        var AccountId = 1;
        //act
        for (var i = 0; i < 50; i++)
        {
            mock.CreatePlanning(planningDto, AccountId);
        }

        //assert
        //the +2 is for the 2 planning that are already in the mock
        Assert.IsTrue(mock.PlanningList.Count == 50 + 2);
    }

    [TestMethod]
    public void GetLoadTest10()
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
        var AccountId = 1;
        for (var i = 0; i < 10; i++)
        {
            mock.CreatePlanning(planningDto, AccountId);
        }
        //act
        var GetList = mock.GetAll();
        //assert
        Assert.IsTrue(GetList.Count == 10 + 2);
    }

    [TestMethod]
    public void GetLoadTest50()
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
        var AccountId = 1;
        for (var i = 0; i < 50; i++)
        {
            mock.CreatePlanning(planningDto, AccountId);
        }
        //act
        var GetList = mock.GetAll();
        //assert
        Assert.IsTrue(GetList.Count == 50 + 2);
    }

    [TestMethod]
    public void GetTestLoad100()
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
        var AccountId = 1;
        for (var i = 0; i < 100; i++)
        {
            mock.CreatePlanning(planningDto, AccountId);
        }
        //act
        var GetList = mock.GetAll();
        //assert
        Assert.IsTrue(GetList.Count == 100 + 2);
    }

    [TestMethod]
    public void GetTestLoad250()
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
        var AccountId = 1;
        for (var i = 0; i < 250; i++)
        {
            mock.CreatePlanning(planningDto, AccountId);
        }
        //act
        var GetList = mock.GetAll();
        //assert
        Assert.IsTrue(GetList.Count == 250 + 2);
    }
}