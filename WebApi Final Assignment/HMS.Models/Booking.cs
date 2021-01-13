using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Models
{
    public class Booking
    {
        public int BookingId { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public Nullable<int> RoomId { get; set; }
    }
}
