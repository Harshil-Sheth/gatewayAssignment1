using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HMS.BAL.Interface;
using HMS.DAL.Repository;
using HMS.Models;



namespace HMS.BAL
{
    public class HotelManager : IHotelManager
    {
        private readonly IHotelRepository _hotelRepository;

        public HotelManager(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        public string BookRoom(Booking model)
        {
            return _hotelRepository.BookRoom(model);
        }

        public List<Booking> CheckBooking(Booking model)
        {
            return _hotelRepository.CheckBooking(model);
        }

        public string CreateHotel(Hotel model)
        {
            return _hotelRepository.CreateHotel(model);
        }

        public string CreateRoom(Room model)
        {
            return _hotelRepository.CreateRoom(model);
        }

        public string DeleteBooking(int Id)
        {
            return _hotelRepository.DeleteBooking(Id);
        }


        public List<Hotel> GetAllHotels()
        {
            return _hotelRepository.GetAllHotels();
        }


        public Hotel GetHotel(int Id)
        {
            return _hotelRepository.GetHotel(Id);
        }

        public IQueryable GetRoomsByParameter(Hotel model)
        {
            return _hotelRepository.GetRoomsByParameter(model);
        }

        public string UpdateBookingDate(Booking model)
        {
            return _hotelRepository.UpdateBookingDate(model);
        }

        public string UpdateBookingStatus(Booking model)
        {
            return _hotelRepository.UpdateBookingStatus(model);
        }
    }
}
