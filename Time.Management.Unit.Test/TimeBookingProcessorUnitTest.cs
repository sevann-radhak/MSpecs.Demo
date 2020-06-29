using Moq;
using System;
using TimeManagement.Booking;
using Xunit;

namespace Time.Management.Unit.Test
{
    public class TimeBookingProcessorUnitTest
    {
        [Fact]
        public void Test_Invalid_Employee_Id()
        {
            var bookingProcessor = new Mock<IBookingProcessor>();
            var timeBookingProcessor = new TimeBookingProcessor(bookingProcessor.Object);

            Assert.Throws<ArgumentOutOfRangeException>(() 
                => timeBookingProcessor.BookTime(new Employee { }, DateTime.Today, 8));
        }

        [Fact]
        public void Test_Invalid_DateTime()
        {
            var bookingProcessor = new Mock<IBookingProcessor>();
            var timeBookingProcessor = new TimeBookingProcessor(bookingProcessor.Object);

            Assert.Throws<ArgumentOutOfRangeException>(()
                => timeBookingProcessor.BookTime(new Employee { Id = 1 }, DateTime.Today.AddDays(1), 8));
        }

        [Fact]
        public void Test_Invalid_Duration()
        {
            var bookingProcessor = new Mock<IBookingProcessor>();
            var timeBookingProcessor = new TimeBookingProcessor(bookingProcessor.Object);

            Assert.Throws<ArgumentOutOfRangeException>(()
                => timeBookingProcessor.BookTime(new Employee { Id = 1 }, DateTime.Today, 10));
        }

        [Fact]
        public void Test_Valid_Arguments()
        {
            var bookingProcessor = new Mock<IBookingProcessor>();
            
            bookingProcessor
                .Setup(p => p.Create(It.IsAny<int>(), It.IsAny<DateTime>(), It.IsAny<decimal>()))
                .Returns(true);

            var timeBookingProcessor = new TimeBookingProcessor(bookingProcessor.Object);

            Assert.True(timeBookingProcessor.BookTime(new Employee { Id = 1 }, DateTime.Today, 9));
        }
    }
}
