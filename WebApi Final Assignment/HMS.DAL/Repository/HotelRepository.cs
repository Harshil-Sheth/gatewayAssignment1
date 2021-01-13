using HMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.DAL.Repository
{
    public class HotelRepository : IHotelRepository
    {
        private readonly Database.HotelManagementSystemEntities _dbContext;

        public HotelRepository()
        {
            _dbContext = new Database.HotelManagementSystemEntities();
        }

        // POST Booked the room of hotel for particular date with (optional status)
        public string BookRoom(Booking model)
        {
            try
            {
                if (model != null)
                {
                    var entity = _dbContext.tbl_Rooms.Find(model.RoomId);
                    Database.tbl_Rooms room = new Database.tbl_Rooms();
                    Database.tbl_Bookings booking = new Database.tbl_Bookings();

                    booking.Date = model.Date;
                    booking.Status = model.Status;
                    booking.RoomId = model.RoomId;

                    entity.IsActive = true;

                    _dbContext.tbl_Bookings.Add(booking);
                    _dbContext.SaveChanges();
                    return "Room Booked Successfully!";
                }
                return "No Data Found!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        // GET availability of room on some particular date
        public List<Booking> CheckBooking(Booking model)
        {
            List<Booking> booking = new List<Booking>();
            var room = _dbContext.tbl_Rooms.ToList();

            if (room != null)
            {
                foreach (var item in room)
                {
                    var entity = _dbContext.tbl_Bookings.Where(x => x.RoomId == item.RoomId && x.Date == model.Date);
                    if (entity.Count() != 0)
                    {
                        foreach (var data in entity)
                        {
                            Room rm = new Room();
                            if (data.Status == "Deleted")
                            {
                                rm.IsActive = true;
                            }
                            else
                            {
                                rm.IsActive = false;
                            }
                        }
                    }
                }
            }
            return booking;
        }

        //POST 5-10 hotels with details of hotel and 3-5 rooms in each hotel with different price and different category.
        public string CreateHotel(Hotel model)
        {
            try
            {
                if (model != null)
                {
                    Database.tbl_Hotels entity = new Database.tbl_Hotels();

                    entity.HotelName = model.HotelName;
                    entity.Address = model.Address;
                    entity.City = model.City;
                    entity.Pincode = model.Pincode;
                    entity.ContactNumber = model.ContactNumber;
                    entity.ContactPerson = model.ContactPerson;
                    entity.Website = model.Website;
                    entity.Facebook = model.Facebook;
                    entity.Twitter = model.Twitter;
                    entity.IsActive = model.IsActive;
                    entity.CreatedDate = model.CreatedDate;
                    entity.CreatedBy = model.CreatedBy;
                    entity.UpdatedDate = model.UpdatedDate;
                    entity.UpdatedBy = model.UpdatedBy;

                    _dbContext.tbl_Hotels.Add(entity);
                    _dbContext.SaveChanges();

                    return "Data Added Successfully!";
                }
                return "Model is Null";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        //Post 3-5 rooms in each hotel with different price and different category.
        public string CreateRoom(Room model)
        {
            try
            {
                if (model != null)
                {
                    Database.tbl_Rooms rooms = new Database.tbl_Rooms();
                    rooms.HotelId = model.HotelId;
                    rooms.RoomName = model.RoomName;
                    rooms.Category = model.Category;
                    rooms.Price = (decimal?)model.Price;
                    rooms.IsActive = model.IsActive;
                    rooms.CreatedDate = model.CreatedDate;
                    rooms.CreatedBy = model.CreatedBy;
                    rooms.UpdatedDate = model.UpdatedDate;
                    rooms.UpdatedBy = model.UpdatedBy;

                    _dbContext.tbl_Rooms.Add(rooms);
                    _dbContext.SaveChanges();
                    return "Rooms Added Successfully!";
                }
                return "Model is Null!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        //DELETE delete booking by booking Id (change status Deleted – soft delete)
        public string DeleteBooking(int Id)
        {
            try
            {
                var booking = _dbContext.tbl_Bookings.Find(Id);
                var rooms = _dbContext.tbl_Rooms.Find(booking.RoomId);

                if (booking != null)
                {
                    booking.Status = "Deleted";
                    rooms.IsActive = false;
                    _dbContext.SaveChanges();

                    return "Booking Deleted Successfully!";
                }
                return "No Data Found!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }


        //GET all hotels sort by alphabetic order. Response: List of hotels 
        public List<Hotel> GetAllHotels()
        {
            List<Hotel> list = new List<Hotel>();

            var entities = _dbContext.tbl_Hotels.OrderBy(x => x.HotelName).ToList();

            if (entities != null)
            {
                foreach (var item in entities)
                {
                    Hotel hotel = new Hotel();

                    hotel.HotelId = item.HotelId;
                    hotel.HotelName = item.HotelName;
                    hotel.Address = item.Address;
                    hotel.City = item.City;
                    hotel.Pincode = (int)item.Pincode;
                    hotel.ContactNumber = item.ContactNumber;
                    hotel.ContactPerson = item.ContactPerson;
                    hotel.Website = item.Website;
                    hotel.Facebook = item.Facebook;
                    hotel.Twitter = item.Twitter;
                    hotel.IsActive = (bool)item.IsActive;
                    hotel.CreatedDate = (DateTime)item.CreatedDate;
                    hotel.CreatedBy = item.CreatedBy;
                    hotel.UpdatedDate = (DateTime)item.UpdatedDate;
                    hotel.UpdatedBy = item.UpdatedBy;

                    list.Add(hotel);
                }
            }
            return list;
        }

        //Get Hotel by ID
        public Hotel GetHotel(int Id)
        {
            var entity = _dbContext.tbl_Hotels.Find(Id);

            Hotel hotel = new Hotel();
            if (entity != null)
            {
                hotel.HotelId = entity.HotelId;
                hotel.HotelName = entity.HotelName;
                hotel.Address = entity.Address;
                hotel.City = entity.City;
                hotel.Pincode = (int)entity.Pincode;
                hotel.ContactNumber = entity.ContactNumber;
                hotel.ContactPerson = entity.ContactPerson;
                hotel.Website = entity.Website;
                hotel.Facebook = entity.Facebook;
                hotel.Twitter = entity.Twitter;
                hotel.IsActive = (bool)entity.IsActive;
                hotel.CreatedDate = (DateTime)entity.CreatedDate;
                hotel.CreatedBy = entity.CreatedBy;
                hotel.UpdatedDate = (DateTime)entity.UpdatedDate;
                hotel.UpdatedBy = entity.UpdatedBy;
            }

            return hotel;
        }

        //GET all rooms of hotels with optional parameter by hotel city, pin code, Price, Category.
        public IQueryable GetRoomsByParameter(Hotel model)
        {
            var roomInfo = from hotels in _dbContext.tbl_Hotels
                           join rooms in _dbContext.tbl_Rooms on hotels.HotelId equals rooms.HotelId
                           where hotels.City == model.City || hotels.Pincode == model.Pincode
                           orderby rooms.Price
                           select new
                           {
                               hotels.HotelId,
                               rooms.RoomId,
                               rooms.RoomName,
                               hotels.HotelName,
                               rooms.Category,
                               rooms.Price,
                               hotels.Pincode,
                               hotels.City,
                           };
            return roomInfo;
        }

        // PUT update booking date for any room by Id
        public string UpdateBookingDate(Booking model)
        {
            try
            {
                var entity = _dbContext.tbl_Bookings.Find(model.BookingId);
                if (entity != null)
                {
                    entity.Date = model.Date;
                    _dbContext.SaveChanges();
                    return "Data Updated Successfully!";
                }
                return "No Data Found!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        //PUT update booking status by booking Id(optional status to Definitive or Cancelled)
        public string UpdateBookingStatus(Booking model)
        {
            try
            {
                var entity = _dbContext.tbl_Bookings.Find(model.BookingId);
                if (entity != null)
                {
                    entity.Status = model.Status;
                    _dbContext.SaveChanges();
                    return "Record Updated Successfully!";
                }
                return "No Data Found!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
