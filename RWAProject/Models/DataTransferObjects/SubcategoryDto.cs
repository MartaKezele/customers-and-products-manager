using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RWAProject.Models.DataTransferObjects
{
    public class SubcategoryDto
    {
        public int ID { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}