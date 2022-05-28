using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RWAProject.Models.DatabaseModels
{
    public class SubcategoryDbm
    {
        public int ID { get; set; }

        [Required]
        public int CategoryID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}