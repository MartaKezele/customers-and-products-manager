using RWAProject.App_Start;
using RWAProject.Models;
using RWAProject.Models.DatabaseModels;
using RWAProject.Models.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RWAProject.Controllers.ApiControllers
{
    public class SubcategoriesController : ApiController
    {
        // GET      /api/subcategories         - get all subcategories
        [HttpGet]
        public IHttpActionResult GetSubcategories()
        {
            var subcategories = Repo.RetrieveAllSubcategories();
            var subcategoryDto = AutoMapperConfig.Mapper.Map<IEnumerable<SubcategoryDto>>(subcategories);
            return Ok(subcategoryDto);
        }

        // GET      /api/subcategories/id      - get subcategory with id
        [HttpGet]
        public IHttpActionResult GetSubcategory(int id)
        {
            var subcategory = Repo.RetrieveSubcategoryByID(id);
            if (subcategory != null)
            {
                var subcategoryDto = AutoMapperConfig.Mapper.Map<SubcategoryDto>(subcategory);
                return Ok(subcategoryDto);

            }
            else
            {
                return NotFound();
            }
        }

        // POST     /api/subcategories         - create subcategory
        [HttpPost]
        public IHttpActionResult CreateSubcategory(SubcategoryDbm subcategoryDbm)
        {
            if (ModelState.IsValid)
            {
                Repo.CreateSubcategory(subcategoryDbm);
                var subcategoryDto = AutoMapperConfig.Mapper.Map<SubcategoryDto>(subcategoryDbm);
                return Ok(subcategoryDto);
            }
            else
            {
                return BadRequest();
            }
        }

        //// POST     /api/subcategories         - create subcategory
        //[HttpPost]
        //public IHttpActionResult CreateSubcategory(Subcategory subcategory)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        Repo.CreateSubcategory(subcategory);
        //        var subcategoryDto = AutoMapperConfig.Mapper.Map<SubcategoryDto>(subcategory);
        //        return Ok(subcategoryDto);
        //    }
        //    else
        //    {
        //        return BadRequest();
        //    }
        //}


        // PUT      /api/subcategories/id      - update subcategory with id
        [HttpPut]
        public IHttpActionResult UpdateSubcategory(int id, SubcategoryDbm subcategoryDbm)
        {
            if (ModelState.IsValid)
            {
                var subcategoryfromDB = Repo.RetrieveSubcategoryByID(id);
                if (subcategoryfromDB != null)
                {
                    subcategoryDbm.ID = id;
                    Repo.UpdateSubcategoryByID(subcategoryDbm);
                    return Ok("Subcategory successfully updated.");
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                return BadRequest();
            }
        }

        //// PUT      /api/subcategories/id      - update subcategory with id
        //[HttpPut]
        //public IHttpActionResult UpdateSubcategory(int id, Subcategory subcategory)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var subcategoryfromDB = Repo.RetrieveSubcategoryByID(id);
        //        if (subcategoryfromDB != null)
        //        {
        //            subcategory.ID = id;
        //            Repo.UpdateSubcategoryByID(subcategory);
        //            return Ok("Subcategory successfully updated.");
        //        }
        //        else
        //        {
        //            return NotFound();
        //        }
        //    }
        //    else
        //    {
        //        return BadRequest();
        //    }
        //}


        // DELETE   /api/subcategories/id      - delete subcategory with id 

        [HttpDelete]
        public IHttpActionResult DeleteSubcategory(int id)
        {
            var subcategory = Repo.RetrieveSubcategoryByID(id);
            if (subcategory != null)
            {
                Repo.DeleteSubcategoryByID(id);
                return Ok("Subcategory successfully deleted.");
            }
            else
            {
                return NotFound();
            }
        }
    }
}
