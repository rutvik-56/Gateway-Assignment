//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Booking.BE.model
{
    using System;
    using System.Collections.Generic;
    
    public class Booking
    {
        public int booking_id { get; set; }
        public int vehicle_id { get; set; }
        public int service_id { get; set; }
        public int mechanic_id { get; set; }
        public System.DateTime booking_date { get; set; }
    
        public virtual Service Service { get; set; }
        public virtual Mechanic Mechanic { get; set; }
        public virtual Vehicle Vehicle { get; set; }
    }
}
