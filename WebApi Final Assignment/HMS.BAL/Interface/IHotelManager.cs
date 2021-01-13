using HMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.BAL.Interface
{
    public interface IHotelManager
    {
        Hotel GetHotel(int Id);
        List<Hotel> GetAllHotels();
        string CreateHotel(Hotel model);
        string CreateRoom(Room model);
        string BookRoom(Booking model);
        List<Booking> CheckBooking(Booking model);
        IQueryable GetRoomsByParameter(Hotel model);
        string DeleteBooking(int Id);
        string UpdateBookingDate(Booking model);
        string UpdateBookingStatus(Booking model);
    }
}
