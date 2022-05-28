using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RWAProject.Models
{
    public class Commercialist
    {
        public int ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool PermanentEmployee { get; set; }
    }
}