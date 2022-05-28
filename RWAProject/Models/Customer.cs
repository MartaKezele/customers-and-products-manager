using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RWAProject.Models
{
    public class Customer
    {
        public int ID { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [EmailAddress]
        [MaxLength(50)]
        public string Email { get; set; }

        [MinLength(8)]
        [MaxLength(25)]
        public string Phone { get; set; }

        public City City { get; set; }
    }
}