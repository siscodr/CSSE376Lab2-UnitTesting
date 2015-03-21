using System;
using Expedia;
using NUnit.Framework;

namespace ExpediaTest
{
	[TestFixture()]
	public class FlightTest
	{
        private readonly int MilesToFly = 5;

        [Test()]
        public void TestThatFlightInitializes()
        {
            var target = new Flight(new DateTime(2009, 11, 1), new DateTime(2009, 11, 30), 5);
            Assert.IsNotNull(target);
        }

        [Test()]
        public void TestThatFlightHasCorrectBasePriceForOneDayStay()
        {
            var target = new Flight(new DateTime(2009, 11, 1), new DateTime(2009, 11, 2), MilesToFly);
            Assert.AreEqual(220, target.getBasePrice());
        }
        [Test()]
        public void TestThatFlightHasCorrectBasePriceForTwoDayStay()
        {
            var target = new Flight(new DateTime(2009, 11, 1), new DateTime(2009, 11, 3), MilesToFly);
            Assert.AreEqual(240, target.getBasePrice());
        }
        [Test()]
        public void TestThatFlightHasCorrectBasePriceForTenDaysStay()
        {
            var target = new Flight(new DateTime(2009, 11, 1), new DateTime(2009, 11, 11), MilesToFly);
            Assert.AreEqual(400, target.getBasePrice());
        }

        [Test()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestThatFlightThrowsOnBadLength()
        {
            new Flight(new DateTime(2009, 11, 1), new DateTime(2009, 11, 3), -5);
        }

        [Test()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestThatFlightThrowsOnBadDates()
        {
            new Flight(new DateTime(2009, 11, 30), new DateTime(2009, 11, 1), 5);
        }
	}
}
