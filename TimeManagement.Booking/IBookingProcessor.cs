using System;

namespace TimeManagement.Booking
{
    public interface IBookingProcessor
    {
        bool Create(int id, DateTime date, decimal duration);
    }
}
