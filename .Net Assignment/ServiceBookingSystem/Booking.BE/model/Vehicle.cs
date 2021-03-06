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
    using System.ComponentModel;
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

        [DisplayName("Owner Name")]
        public string owner_name { get; set; }

        [DisplayName("Chassis Number")]
        [Required(ErrorMessage = "Please Enter Chassis Number")]
        public string chassis_no { get; set; }

        [DisplayName("Registration Date")]
        public System.DateTime reg_date { get; set; }
        [Required(ErrorMessage = "Please Enter Plate Number")]

        [DisplayName("Vehicle Plate Number")]
        public string plate_no { get; set; }
        [Required(ErrorMessage = "Please Enter Make")]

        
        [DisplayName("Make")]
        public string make { get; set; }
        [Required(ErrorMessage = "Please Enter Model Name")]
        [DisplayName("Model")]
        public string model { get; set; }
    
        public virtual Customer Customer { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Booking> Booking { get; set; }
    }
}
