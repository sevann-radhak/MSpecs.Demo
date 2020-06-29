using System;
using System.Collections.Generic;
using System.Text;

namespace TimeManagement.Booking
{
    public class TimeBookingProcessor : ITimeBookingProcessor
    {
        private readonly IBookingProcessor _bookingProcessor;

        public TimeBookingProcessor(IBookingProcessor bookingProcessor)
        {
            _bookingProcessor = bookingProcessor;
        }

        public bool BookTime(Employee employee, DateTime date, decimal duration)
        {
            if (employee.Id <= 0) 
                throw new ArgumentOutOfRangeException("Employee ID is not valid.");
            
            if (date.Date > DateTime.Today) 
                throw new ArgumentOutOfRangeException("Booking date can not be greated than today.");

            if (duration > 9)
                throw new ArgumentOutOfRangeException("You are working too hard. Let's talk!");

            return _bookingProcessor.Create(employee.Id, date, duration);
        }
    }
}
