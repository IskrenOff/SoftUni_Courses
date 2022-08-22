using BookingApp.Models.Bookings.Contracts;
using BookingApp.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BookingApp.Repositories
{
    public class BookingRepository : IRepository<IBooking>
    {
        private readonly List<IBooking> bookings;

        public BookingRepository()
        {
            bookings = new List<IBooking>();
        }

        public void AddNew(IBooking model)
        {
            bookings.Add(model);
        }

        public IReadOnlyCollection<IBooking> All()
        {
            return bookings.AsReadOnly();
        }

        public IBooking Select(string criteria)
        {

            return bookings.Find(x => x.BookingNumber == int.Parse(criteria));
        }
    }
}
