using BookingApp.Core.Contracts;
using BookingApp.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using BookingApp.Utilities.Messages;
using BookingApp.Models.Hotels;
using BookingApp.Models.Rooms;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Models.Hotels.Contacts;
using BookingApp.Models.Bookings;

namespace BookingApp.Core
{
    public class Controller : IController
    {
        private HotelRepository hotels;

        public Controller()
        {
            hotels = new HotelRepository();
        }

        public string AddHotel(string hotelName, int category)
        {

            if (hotels.Select(hotelName) != null)
            {
                return String.Format(OutputMessages.HotelAlreadyRegistered, hotelName);
            }

            IHotel hotel = new Hotel(hotelName, category);
            hotels.AddNew(hotel);

            return String.Format(OutputMessages.HotelSuccessfullyRegistered, category, hotelName);
        }

        public string BookAvailableRoom(int adults, int children, int duration, int category)
        {
            List<IHotel> hotels = new List<IHotel>();

            foreach (var hotel in this.hotels.All())
            {
                hotels.Add(hotel);
            }

            List<IHotel> orderedHotels = hotels.OrderBy(x => x.FullName).ToList();

            bool flag = true;

            foreach (var hotel1 in orderedHotels)
            {
                if (hotel1.Category == category)
                {
                    flag = false;
                }
            }

            if (flag)
            {
                return string.Format(OutputMessages.CategoryInvalid, category);
            }

            List<IRoom> rooms = new List<IRoom>();

            foreach (var hotel in orderedHotels)
            {
                foreach (var room in hotel.Rooms.All())
                {
                    if (room.PricePerNight > 0)
                    {
                        rooms.Add(room);
                    }
                }
            }

            rooms = rooms.OrderBy(x => x.BedCapacity).ToList();
            List<IRoom> fitRooms = new List<IRoom>();
            bool flag2 = true;

            foreach (var room in rooms)
            {
                int sum = adults + children;

                if (room.BedCapacity >= sum)
                {
                    flag2 = false;
                    fitRooms.Add(room);
                }
            }

            if (flag2)
            {
                return string.Format(OutputMessages.RoomNotAppropriate);
            }

            IRoom bestRoom = fitRooms[0];
            string hotelName = string.Empty;

            foreach (var hotel in this.hotels.All())
            {
                foreach (var room in hotel.Rooms.All())
                {
                    if (room.Equals(bestRoom))
                    {
                        hotelName = hotel.FullName;
                    }
                }
            }

            int number = this.hotels.Select(hotelName).Bookings.All().Count + 1;

            this.hotels.Select(hotelName).Bookings.AddNew(new Booking(bestRoom, duration, adults, children, number));

            return String.Format(OutputMessages.BookingSuccessful, number, hotelName);           
        }

        public string HotelReport(string hotelName)
        {
            StringBuilder sb = new StringBuilder();

            var hotel = this.hotels.Select(hotelName);

            if (hotel == null)
            {
                return string.Format(OutputMessages.HotelNameInvalid, hotelName);
            }

            sb.AppendLine($"Hotel name: {hotelName}");
            sb.AppendLine($"--{hotel.Category} star hotel");
            sb.AppendLine($"--Turnover: {hotel.Turnover:F2} $");
            sb.AppendLine($"--Bookings:");
            sb.AppendLine();

            if (hotel.Bookings.All().Any())
            {
                foreach (var booking in hotels.Select(hotelName).Bookings.All())
                {
                    sb.AppendLine(booking.BookingSummary());
                }
            }

            else
            {
                sb.AppendLine($"none");
            }           

            return sb.ToString().Trim();
        }

        public string SetRoomPrices(string hotelName, string roomTypeName, double price)
        {
            if (hotels.Select(hotelName) == null)
            {
                return string.Format(OutputMessages.HotelNameInvalid, hotelName);
            }
            if (roomTypeName != "DoubleBed" && roomTypeName != "Studio" && roomTypeName != "Apartment")
            {
                throw new ArgumentException(ExceptionMessages.RoomTypeIncorrect);
            }
            if (hotels.Select(hotelName).Rooms.Select(roomTypeName) == null)
            {
                return string.Format(OutputMessages.RoomTypeNotCreated);
            }
            if (hotels.Select(hotelName).Rooms.Select(roomTypeName).PricePerNight != 0)
            {
                throw new InvalidOperationException(ExceptionMessages.PriceAlreadySet);
            }

            hotels.Select(hotelName).Rooms.Select(roomTypeName).SetPrice(price);
            return string.Format(OutputMessages.PriceSetSuccessfully, roomTypeName, hotelName);
        }

        public string UploadRoomTypes(string hotelName, string roomTypeName)
        {
            var hotel = hotels.Select(hotelName);

            if (hotels.Select(hotelName) == null)
            {
                return string.Format(OutputMessages.HotelNameInvalid, hotelName);
            }
            if (hotel.Rooms.All().Any(r => r.GetType().Name == roomTypeName))
            {
                return string.Format(OutputMessages.RoomTypeAlreadyCreated);
            }

            switch (roomTypeName)
            {
                case nameof (Apartment):
                    hotels.Select(hotelName).Rooms.AddNew(new Apartment());
                    break;
                case nameof(DoubleBed):
                    hotels.Select(hotelName).Rooms.AddNew(new DoubleBed());
                    break;
                case nameof(Studio):
                    hotels.Select(hotelName).Rooms.AddNew(new Studio());
                    break;
                    default:
                    throw new ArgumentException(string.Format(ExceptionMessages.RoomTypeIncorrect));
            }

            return string.Format(OutputMessages.RoomTypeAdded, roomTypeName, hotelName);
        }
    }
}
