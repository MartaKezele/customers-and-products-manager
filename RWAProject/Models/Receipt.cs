using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RWAProject.Models
{
    public class Receipt
    {
        public int ID { get; set; }

        [Display(Name = "Date of purchase")]
        public DateTime DateOfPurchase { get; set; }

        [Display(Name = "Receipt number")]
        public string ReceiptNumber { get; set; }

        public string Comment { get; set; }

        public Customer Customer { get; set; }

        public Commercialist Commercialist { get; set; }

        public CreditCard CreditCard { get; set; }
    }
}