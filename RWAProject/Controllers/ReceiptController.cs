using RWAProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RWAProject.Controllers
{
    [Authorize]
    public class ReceiptController : Controller
    {
        public ActionResult Details(int id)
        {
            var receipt = Repo.RetrieveReceiptByID(id);
            ViewBag.customer = Repo.RetrieveCustomerByID(receipt.Customer.ID);
            ViewBag.receipt = receipt;
            return View();
        }
    }
}