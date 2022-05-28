using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RWAProject.Models.ViewModels
{
    public class ProductCreateEditVm
    {
        public Product Product { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}