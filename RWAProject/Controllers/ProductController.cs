using RWAProject.Models;
using RWAProject.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RWAProject.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = new ProductCreateEditVm
            {
                Product = Repo.RetrieveProductByID(id),
                Categories = Repo.RetrieveAllCategories(),
            };

            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult Create()
        {
            var model = new ProductCreateEditVm
            {
                Categories = Repo.RetrieveAllCategories(),
            };
            return View(model);
        }
    }
}