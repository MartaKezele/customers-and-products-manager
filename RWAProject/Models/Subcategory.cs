using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RWAProject.Models
{
    public class Subcategory
    {
        public int ID { get; set; }

        [Required]
        public Category Category { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}