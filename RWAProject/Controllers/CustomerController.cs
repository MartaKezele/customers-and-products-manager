using RWAProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RWAProject.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
        [OutputCache(Duration = 600, VaryByParam = "none")]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Receipts(int id)
        {
            ViewBag.customer = Repo.RetrieveCustomerByID(id);
            return View();
        }
    }
}