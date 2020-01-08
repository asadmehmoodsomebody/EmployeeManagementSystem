using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace website_emp.Models
{
    public class user
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required(ErrorMessage ="Fill the Name Field")]
        [StringLength(50,ErrorMessage ="Minimum 3 characters",MinimumLength =3)]
        public string Name { get; set; }
        [Required]
        [DataType (DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType (DataType.Password)]
        public string Password { get; set; }
        [Required]
        public string Role { get; set; }
        public virtual designation Designation { get; set; }
        public virtual department Department { get; set; }

        public virtual status Status { get; set; }



    }
}