using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RWAProject.Models.DataTransferObjects
{
    public class ReceiptDto
    {
        public int ID { get; set; }

        [Display(Name = "Date of purchase")]
        public string DateOfPurchase { get; set; }

        [Display(Name = "Receipt number")]
        public string ReceiptNumber { get; set; }

        public string Comment { get; set; }

        public string Customer { get; set; }

        public string Commercialist { get; set; }

        [Display(Name = "Credit card type")]
        public string CreditCardType { get; set; }

        [Display(Name = "Credit card number")]
        public string CreditCardNumber { get; set; }
    }
}