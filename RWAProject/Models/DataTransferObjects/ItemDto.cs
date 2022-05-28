using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RWAProject.Models.DataTransferObjects
{
    public class ItemDto
    {
        public int ID { get; set; }

        [Display(Name = "Receipt number")]
        public string ReceiptNumber { get; set; }

        public int Quantity { get; set; }

        public string Product { get; set; }

        [Display(Name = "Price by piece")]
        public double PriceByPiece { get; set; }

        public double Discount { get; set; }

        [Display(Name = "Total price")]
        public double TotalPrice { get; set; }

        public string Category { get; set; }

        public string Subcategory { get; set; }
    }
}