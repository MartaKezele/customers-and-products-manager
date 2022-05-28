using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RWAProject.Models.DataTransferObjects
{
    public class ProductDto
    {
        public int ID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(25)]
        public string Number { get; set; }

        [MaxLength(15)]
        public string Color { get; set; }

        [Required]
        [Display(Name = "Minimal quantity in stock")]
        public int MinimalQuantityInStock { get; set; }

        [Required]
        [Display(Name = "Price without tax")]
        public double PriceWithoutTax { get; set; }

        public string Subcategory { get; set; }

        public string Category { get; set; }
    }
}