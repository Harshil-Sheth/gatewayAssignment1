using HMS.BAL.Interface;
using HMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HMS.WebApi.Controllers
{
    public class HotelController : ApiController
    {
        private readonly IHotelManager _hotelManager;

        public HotelController(IHotelManager hotelManager)
        {
            _hotelManager = hotelManager;
        }

        // GET: api/Hotel
        public List<Hotel> GetAllHotels()
        {
            //TODO : Call Hotel

            var hotel = _hotelManager.GetAllHotels();
            return hotel;
        }

        public IQueryable GetRoomsByParameter(Hotel model)
        {
            return _hotelManager.GetRoomsByParameter(model);
        }

        // GET: api/Hotel/5
        public Hotel Get(int id)
        {
            return _hotelManager.GetHotel(id);
        }

        // POST: api/Hotel
        //Create Hotel
        public string CreateHotel([FromBody] Hotel model)
        {
            return _hotelManager.CreateHotel(model);
        }

        // POST: api/Hotel
        //Create Room
        public string CreateRoom([FromBody] Room model)
        {
            return _hotelManager.CreateRoom(model);
        }

        // POST: api/Hotel
        //Book Room

        public string BookRoom([FromBody] Booking model)
        {
            return _hotelManager.BookRoom(model);
        }

        // PUT: api/Hotel/5
        //Update Booking Date
        [HttpPut]
        public string UpdateBookingDate([FromBody] Booking model)
        {
            return _hotelManager.UpdateBookingDate(model);
        }


        //Update Booking Status
        //[HttpPut]
        public string UpdateBookingStatus([FromBody] Booking model)
        {
            return _hotelManager.UpdateBookingStatus(model);
        }

        //Check Room Availability
        [HttpGet]
        public List<Booking> CheckBooking([FromBody] Booking model)
        {
            return _hotelManager.CheckBooking(model);
        }

        // DELETE: api/Hotel/5
        public string DeleteBooking(int id)
        {
            return _hotelManager.DeleteBooking(id);
        }
    }
}
