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
    public class CustomersController : ApiController
    {
        // GET      /api/customers      - get all customers
        [HttpGet]
        public IHttpActionResult GetCustomers()
        {
            var customers = Repo.RetrieveAllCustomers();
            var customersDto = AutoMapperConfig.Mapper.Map<IEnumerable<CustomerDto>>(customers);
            return Ok(customersDto);
        }

        // GET      /api/customers/id   - get customer with id
        [HttpGet]
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = Repo.RetrieveCustomerByID(id);
            if (customer != null)
            {
                var customerDto = AutoMapperConfig.Mapper.Map<CustomerDto>(customer);
                return Ok(customerDto);

            }
            else
            {
                return NotFound();
            }
        }

        // POST     /api/customers      - create customer
        [HttpPost]
        public IHttpActionResult CreateCustomer(Customer customer)
        {
            if (ModelState.IsValid)
            {
                Repo.CreateCustomer(customer);
                var customerDto = AutoMapperConfig.Mapper.Map<CustomerDto>(customer);
                return Ok(customerDto);
            }
            else
            {
                return BadRequest();
            }
        }

        // PUT      /api/customers/id   - update customer with id
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id, Customer customer)
        {
            if (ModelState.IsValid)
            {
                var customerfromDB = Repo.RetrieveCustomerByID(id);
                if (customerfromDB != null)
                {
                    customer.ID = id;
                    Repo.UpdateCustomerByID(customer);
                    return Ok("Customer successfully updated.");
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


        // DELETE   /api/customers/id   - delete customer with id 
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customer = Repo.RetrieveCustomerByID(id);
            if (customer != null)
            {
                Repo.DeleteCustomerByID(id);
                return Ok("Customer successfully deleted.");
            }
            else
            {
                return NotFound();
            }
        }
    }
}
