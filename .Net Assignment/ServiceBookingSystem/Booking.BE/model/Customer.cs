using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Booking.BE.model
{
    public class Customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Customer()
        {
            this.Address = new HashSet<Address>();
            this.Vehicle = new HashSet<Vehicle>();
        }

        public int customer_id { get; set; }

        [DisplayName("Name")]
        [Required(ErrorMessage = "Please Enter Your Name")]
        public string name { get; set; }

        [Required(ErrorMessage = "Please Enter Your EmailAddress")]
        [DisplayName("Email")]
        [EmailAddress]
        public string email { get; set; }

        [Required(ErrorMessage = "Please Enter Password")]
        [DisplayName("Password")]
        [StringLength(20, MinimumLength = 8,ErrorMessage = "Minimum 8 length and Maximum 20 legth password Required")]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [Required(ErrorMessage = "Please Enter Your Phone Number")]
        [DisplayName("Phone")]
        [StringLength(10,ErrorMessage ="Please Enter Valid Phone Number")]
        public string phone { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Address> Address { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Vehicle> Vehicle { get; set; }
    
    }
}
