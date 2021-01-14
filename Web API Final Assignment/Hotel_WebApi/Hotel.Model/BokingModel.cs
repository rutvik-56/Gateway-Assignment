﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Models
{
    using System;
    using System.Collections.Generic;

    public class BookingModel
    {
        public int Booking_Id { get; set; }
        public Nullable<int> Hotel_Id { get; set; }
        public Nullable<int> Room_Id { get; set; }
        public string StatusOfBooking { get; set; }
        public Nullable<System.DateTime> BookingDate { get; set; }
        public string IsActive { get; set; }

        public virtual HotelModel Hotel { get; set; }
        public virtual RoomBokkingModel Room { get; set; }
    }
}
