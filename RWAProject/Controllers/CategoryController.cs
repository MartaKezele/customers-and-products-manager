using RWAProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RWAProject.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = Repo.RetrieveCategoryByID(id);
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
    }
}