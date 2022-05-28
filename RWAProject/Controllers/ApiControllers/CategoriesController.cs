using RWAProject.App_Start;
using RWAProject.Models;
using RWAProject.Models.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RWAProject.Controllers.ApiControllers
{
    public class CategoriesController : ApiController
    {
        // GET      /api/categories         - get all categories
        [HttpGet]
        public IHttpActionResult GetCategories()
        {
            var categories = Repo.RetrieveAllCategories();
            var categoryDto = AutoMapperConfig.Mapper.Map<IEnumerable<CategoryDto>>(categories);
            return Ok(categoryDto);
        }

        // GET      /api/categories/id      - get category with id
        [HttpGet]
        public IHttpActionResult GetCategory(int id)
        {
            var category = Repo.RetrieveCategoryByID(id);
            if (category != null)
            {
                var categoryDto = AutoMapperConfig.Mapper.Map<CategoryDto>(category);
                return Ok(categoryDto);

            }
            else
            {
                return NotFound();
            }
        }

        // POST     /api/categories         - create category
        [HttpPost]
        public IHttpActionResult CreateCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                Repo.CreateCategory(category);
                var categoryDto = AutoMapperConfig.Mapper.Map<CategoryDto>(category);
                return Ok(categoryDto);
            }
            else
            {
                return BadRequest();
            }
        }

        // PUT      /api/categories/id      - update category with id
        [HttpPut]
        public IHttpActionResult UpdateCategory(int id, Category category)
        {
            if (ModelState.IsValid)
            {
                var categoryfromDB = Repo.RetrieveCategoryByID(id);
                if (categoryfromDB != null)
                {
                    category.ID = id;
                    Repo.UpdateCategoryByID(category);
                    return Ok("Category successfully updated.");
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


        // DELETE   /api/categories/id      - delete category with id 
        [HttpDelete]
        public IHttpActionResult DeleteCategory(int id)
        {
            var category = Repo.RetrieveCategoryByID(id);
            if (category != null)
            {
                Repo.DeleteCategoryByID(id);
                return Ok("Category successfully deleted.");
            }
            else
            {
                return NotFound();
            }
        }
    }
}
