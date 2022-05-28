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
    public class ReceiptsController : ApiController
    {
        // GET      /api/receipts/id      - get receipts for customer with id
        [HttpGet]
        public IHttpActionResult GetReceiptsByCustomerID(int id)
        {
            var receipts = Repo.RetrieveReceiptsByCustomerID(id);
            var receiptDto = AutoMapperConfig.Mapper.Map<IEnumerable<ReceiptDto>>(receipts);
            return Ok(receiptDto);
        }

        // DELETE   /api/receipts/id      - delete receipt with id 
        [HttpDelete]
        public IHttpActionResult DeleteReceipt(int id)
        {
            var receipt = Repo.RetrieveReceiptByID(id);
            if (receipt != null)
            {
                Repo.DeleteReceiptByID(id);
                return Ok("Receipt successfully deleted.");
            }
            else
            {
                return NotFound();
            }
        }
    }
}
