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

    public class Vehicle
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Vehicle()
        {
            this.Booking = new HashSet<Booking>();
        }
    
        public int vehicle_id { get; set; }
        public int customer_id { get; set; }

        public string owner_name { get; set; }

        [Required(ErrorMessage = "Please Enter Chassis Number")]
        public string chassis_no { get; set; }
        public System.DateTime reg_date { get; set; }
        [Required(ErrorMessage = "Please Enter Plate Number")]
        public string plate_no { get; set; }
        [Required(ErrorMessage = "Please Enter Make")]
        public string make { get; set; }
        [Required(ErrorMessage = "Please Enter Model Name")]
        public string model { get; set; }
    
        public virtual Customer Customer { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Booking> Booking { get; set; }
    }
}
