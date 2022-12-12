using Microsoft.VisualStudio.TestTools.UnitTesting;
using Schedule.Dtos;

namespace Tests.PerformanceTests;

[TestClass]
public class PlanningStressTest
{
    [TestMethod]
    public void CreateStressTest1000()
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
        for (int i = 0; i < 1000; i++)
        {
            mock.CreatePlanning(planningDto, AccountId);
        }
        //assert
        Assert.AreEqual(1000 + 2, mock.PlanningList.Count);
    }
    
    [TestMethod]
    public void CreateStressTest10000()
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
        for (int i = 0; i < 10000; i++)
        {
            mock.CreatePlanning(planningDto, AccountId);
        }
        //assert
        Assert.AreEqual(10000 + 2, mock.PlanningList.Count);
    }
    
    [TestMethod]
    public void CreateStressTest100000()
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
        for (int i = 0; i < 100000; i++)
        {
            mock.CreatePlanning(planningDto, AccountId);
        }
        //assert
        Assert.AreEqual(100000 + 2, mock.PlanningList.Count);
    }

    [TestMethod]
    public void GetStressTest100000()
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
        for (var i = 0; i < 100000; i++)
        {
            mock.CreatePlanning(planningDto, AccountId);
        }
        //act
        var GetList = mock.GetAll();
        //assert
        Assert.AreEqual(100000 + 2, GetList.Count);
    }
}