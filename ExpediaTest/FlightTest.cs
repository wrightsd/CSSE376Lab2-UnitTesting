using System;
using Expedia;
using NUnit.Framework;

namespace ExpediaTest
{
	[TestFixture()]
	public class FlightTest
	{
        private readonly DateTime StartDate = new DateTime(2015, 12, 2);
        private readonly DateTime EndDate=new DateTime(2015,12,7);
        private readonly int NumberOfMiles = 10;

        [Test()]
        public void TestThatFlightInitializes()
        {
            var newFlight = new Flight(StartDate, EndDate, NumberOfMiles);
            Assert.IsNotNull(newFlight);
        }

        [Test()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestExceptionForStartDateAfterEndDate()
        {
            new Flight(StartDate,new DateTime(2015,12,1),NumberOfMiles);
        }

        [Test()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestExeptionForNegativeMiles()
        {
            new Flight(StartDate, EndDate, -4);
        }

        [Test()]
        public void TestBasePrice()
        {
            var newFlight = new Flight(StartDate,EndDate,NumberOfMiles);
            Assert.AreEqual(300,newFlight.getBasePrice());
        }

        [Test()]
        public void TestEqualsIsSame()
        {
            var newFlight1 = new Flight(StartDate, EndDate, NumberOfMiles);
            var newFlight2 = new Flight(StartDate,EndDate,NumberOfMiles);
            Assert.True(newFlight1.Equals(newFlight2));

        }

        [Test()]
        public void TestEqualsIsNotSameInDate()
        {
            var newFlight1 = new Flight(StartDate, EndDate, NumberOfMiles);
            var newFlight2 = new Flight(new DateTime(2015,12,1), EndDate, NumberOfMiles);
            Assert.False(newFlight1.Equals(newFlight2));
        }

        [Test()]
        public void TestEqualsIsNotSameInMiles()
        {
            var newFlight1 = new Flight(StartDate, EndDate, NumberOfMiles);
            var newFlight2 = new Flight(StartDate, EndDate, 12);
            Assert.False(newFlight1.Equals(newFlight2));
        }

	}
}
