using BookingApp.Models.Hotels.Contacts;
using BookingApp.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BookingApp.Repositories
{
    public class HotelRepository : IRepository<IHotel>
    {
        private readonly List<IHotel> hotels;

        public HotelRepository()
        {
            hotels = new List<IHotel>();
        }

        public void AddNew(IHotel model)
        {
            hotels.Add(model);
        }

        public IReadOnlyCollection<IHotel> All()
        {
            return hotels.AsReadOnly();
        }

        public IHotel Select(string criteria)
        {
            return hotels.FirstOrDefault(x => x.FullName == criteria);
        }
    }
}
