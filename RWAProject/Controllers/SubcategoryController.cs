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
    public class SubcategoryController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var subcategory = Repo.RetrieveSubcategoryByID(id);
            var model = new SubcategoryCreateEditVm
            {
                Subcategory = subcategory,
                Categories = Repo.RetrieveAllCategories()
            };

            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult Create()
        {
            var model = new SubcategoryCreateEditVm
            {
                Categories = Repo.RetrieveAllCategories()
            };
            return View(model);
        }
    }
}