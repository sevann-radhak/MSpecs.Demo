using System;

namespace TimeManagement.Booking
{
    public interface ITimeBookingProcessor
    {
        bool BookTime(Employee employee, DateTime date, decimal duration);
    }
}
