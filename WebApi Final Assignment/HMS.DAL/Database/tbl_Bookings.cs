//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HMS.DAL.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_Bookings
    {
        public int BookingId { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public string Status { get; set; }
        public Nullable<int> RoomId { get; set; }
    
        public virtual tbl_Rooms tbl_Rooms { get; set; }
    }
}
