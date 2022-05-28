using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RWAProject.Models
{
    public class Item
    {
        public int ID { get; set; }

        public Receipt Receipt { get; set; }

        public int Quantity { get; set; }

        public Product Product { get; set; }

        [Display(Name = "Price by piece")]
        public double PriceByPiece { get; set; }

        public double Discount { get; set; }

        [Display(Name = "Total price")]
        public double TotalPrice { get; set; }
    }
}