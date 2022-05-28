using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RWAProject.Models.ViewModels
{
    public class SubcategoryCreateEditVm
    {
        public Subcategory Subcategory { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}