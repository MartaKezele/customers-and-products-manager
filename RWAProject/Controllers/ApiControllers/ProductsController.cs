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
    public class ProductsController : ApiController
    {
        // GET      /api/products         - get all products
        [HttpGet]
        public IHttpActionResult GetProducts()
        {
            var products = Repo.RetrieveAllProducts();
            var productDto = AutoMapperConfig.Mapper.Map<IEnumerable<ProductDto>>(products);
            return Ok(productDto);
        }

        // GET      /api/products/id      - get product with id
        [HttpGet]
        public IHttpActionResult GetProduct(int id)
        {
            var products = Repo.RetrieveProductByID(id);
            if (products != null)
            {
                var productDto = AutoMapperConfig.Mapper.Map<ProductDto>(products);
                return Ok(productDto);

            }
            else
            {
                return NotFound();
            }
        }

        // POST     /api/products         - create product
        [HttpPost]
        public IHttpActionResult CreateProduct(ProductDbm productDbm)
        {
            if (ModelState.IsValid)
            {
                Repo.CreateProduct(productDbm);
                var productDto = AutoMapperConfig.Mapper.Map<ProductDto>(productDbm);
                return Ok(productDto);
            }
            else
            {
                return BadRequest();
            }
        }

        //// POST     /api/products         - create product
        //[HttpPost]
        //public IHttpActionResult CreateProduct(Product product)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        Repo.CreateProduct(product);
        //        var productDto = AutoMapperConfig.Mapper.Map<ProductDto>(product);
        //        return Ok(productDto);
        //    }
        //    else
        //    {
        //        return BadRequest();
        //    }
        //}

        // PUT      /api/products/id      - update product with id

        [HttpPut]
        public IHttpActionResult UpdateProduct(int id, ProductDbm productDbm)
        {
            if (ModelState.IsValid)
            {
                var productfromDB = Repo.RetrieveProductByID(id);
                if (productfromDB != null)
                {
                    productDbm.ID = id;
                    Repo.UpdateProductByID(productDbm);
                    return Ok("Product successfully updated.");
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

        //[HttpPut]
        //public IHttpActionResult UpdateProduct(int id, Product product)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var productfromDB = Repo.RetrieveProductByID(id);
        //        if (productfromDB != null)
        //        {
        //            product.ID = id;
        //            Repo.UpdateProductByID(product);
        //            return Ok("Product successfully updated.");
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


        // DELETE   /api/products/id      - delete product with id 

        [HttpDelete]
        public IHttpActionResult DeleteProduct(int id)
        {
            var product = Repo.RetrieveProductByID(id);
            if (product != null)
            {
                Repo.DeleteProductByID(id);
                return Ok("Product successfully deleted.");
            }
            else
            {
                return NotFound();
            }
        }
    }
}
