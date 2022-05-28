using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RWAProject.Models.DataTransferObjects
{
    public class CustomerDto
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

        public string City { get; set; }

        public string Country { get; set; }
    }
}