using Microsoft.VisualStudio.TestTools.UnitTesting;
using Schedule.Classes;
using Schedule.Dtos;

namespace Tests;

[TestClass]
public class PlanningTest
{
    [TestMethod]
    public void PlanningConstructor()
    {
        //Arrange
        var PlanningId = 1;
        DateTime today = DateTime.Now;
        var Date = today;
        var Time = today;
        var Weekday = "Monday";
        var WeekNumber = 50;
        //Act
        var planning = new Planning(PlanningId, Date, Time, Weekday, WeekNumber);
        //Assert
        Assert.AreEqual(PlanningId, planning.PlanningId);
        Assert.AreEqual(Date, planning.Date);
        Assert.AreEqual(Time, planning.Time);
        Assert.AreEqual(Weekday, planning.Weekday);
        Assert.AreEqual(WeekNumber, planning.WeekNumber);
    }

    [TestMethod]
    public void PlanningConstructorNoId()
    {
        //Arrange
        DateTime today = DateTime.Now;
        var Date = today;
        var Time = today;
        var Weekday = "Monday";
        var WeekNumber = 50;
        //Act
        var planning = new Planning(Date, Time, Weekday, WeekNumber);
        //Assert
        Assert.AreEqual(null, planning.PlanningId);
        Assert.AreEqual(Date, planning.Date);
        Assert.AreEqual(Time, planning.Time);
        Assert.AreEqual(Weekday, planning.Weekday);
        Assert.AreEqual(WeekNumber, planning.WeekNumber);
    }
    
    [TestMethod]
    public void PlanningConstructorDto()
    {
        //Arrange
        var planningDto = new PlanningDto()
        {
            PlanningId = 1,
            Date = DateTime.Now,
            Time = DateTime.Now,
            Weekday = "Monday",
            WeekNumber = 50
        };
        //Act
        var planning = new Planning(planningDto);
        //Assert
        Assert.AreEqual(planningDto.PlanningId, planning.PlanningId);
        Assert.AreEqual(planningDto.Date, planning.Date);
        Assert.AreEqual(planningDto.Time, planning.Time);
        Assert.AreEqual(planningDto.Weekday, planning.Weekday);
        Assert.AreEqual(planningDto.WeekNumber, planning.WeekNumber);
    }

    [TestMethod]
    public void PlanningToDto()
    {
        //Arrange
        var PlanningId = 1;
        DateTime today = DateTime.Now;
        var Date = today;
        var Time = today;
        var Weekday = "Monday";
        var WeekNumber = 50;
        var planning = new Planning(PlanningId, Date, Time, Weekday, WeekNumber);
        //Act
        var planningDto = planning.ToDto();
        //Assert
        Assert.AreEqual(planning.PlanningId, planningDto.PlanningId);
        Assert.AreEqual(planning.Date, planningDto.Date);
        Assert.AreEqual(planning.Time, planningDto.Time);
        Assert.AreEqual(planning.Weekday, planningDto.Weekday);
        Assert.AreEqual(planning.WeekNumber, planningDto.WeekNumber);
    }

    [TestMethod]
    public void GetWeekDay()
    {
        //Arrange
        DateTime today = DateTime.Now;
        var Date = today;
        var Time = today;
        var Weekday = "Monday";
        var WeekNumber = 50;
        var planning = new Planning(1, Date, Time, Weekday, WeekNumber);
        //Act
        var weekday = planning.GetWeekDay(Date);
        //Assert
        Assert.AreEqual(weekday, planning.Weekday);
    }

    [TestMethod]
    public void GetWeekOfYear()
    {
        //Arrange
        DateTime today = DateTime.Now;
        var Date = today;
        var Time = today;
        var Weekday = "Monday";
        var WeekNumber = 50;
        var planning = new Planning(1, Date, Time, Weekday, WeekNumber);
        //Act
        var weeknumber = planning.GetIso8601WeekOfYear(Date);
        //Assert
        Assert.IsTrue(weeknumber > 0 && weeknumber < 53);
    }

    [TestMethod]
    public void GetLastDateOfThisWeek()
    {
        //Arrange
        DateTime today = DateTime.Now;
        var Date = today;
        var Time = today;
        var Weekday = "Monday";
        var WeekNumber = 50;
        var planning = new Planning(1, Date, Time, Weekday, WeekNumber);
        //Act
        var lastdate = planning.GetLastDateOfThisWeek();
        //Assert
        Assert.IsTrue(lastdate >= DateTime.Now);
    }

    [TestMethod]
    public void GetEndDateFromWeekNumber()
    {
            //Arrange
        DateTime today = DateTime.Now;
        var Date = today;
        var Time = today;
        var Weekday = "Monday";
        var WeekNumber = 1;
        var selectedWeek = 3;
        var planning = new Planning(1, Date, Time, Weekday, WeekNumber);
        //Act
        var lastdate1 = planning.GetEndDateFromWeekNumber(WeekNumber);
        var lastdate2 = planning.GetEndDateFromWeekNumber(selectedWeek);
        //Assert
        Assert.IsTrue(lastdate1 < lastdate2);
    }
    
}