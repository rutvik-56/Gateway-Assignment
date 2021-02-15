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
    using System.ComponentModel.DataAnnotations;

    public class Address
    {
  
        public int address_id { get; set; }
        public int mix_id { get; set; }
        public string address1 { get; set; }
        public int city_id { get; set; }
        public int state_id { get; set; }

        [Required(ErrorMessage = "Please Enter ZipCode")]
        public string zipcode { get; set; }
        public bool role { get; set; }
    
        public virtual City City { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Dealer Dealer { get; set; }
        public virtual State State { get; set; }
    }
}
