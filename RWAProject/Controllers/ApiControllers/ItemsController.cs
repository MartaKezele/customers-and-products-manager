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
    public class ItemsController : ApiController
    {
        // GET      /api/items/id      - get items for receipt with id
        [HttpGet]
        public IHttpActionResult GetItemsByReceiptID(int id)
        {
            var items = Repo.RetrieveItemsByReceiptID(id);
            var itemDto = AutoMapperConfig.Mapper.Map<IEnumerable<ItemDto>>(items);
            return Ok(itemDto);
        }

        // DELETE   /api/items/id      - delete item with id 
        [HttpDelete]
        public IHttpActionResult DeleteItem(int id)
        {
            var item = Repo.RetrieveItemByID(id);
            if (item != null)
            {
                Repo.DeleteItemByID(id);
                return Ok("Item successfully deleted.");
            }
            else
            {
                return NotFound();
            }
        }
    }
}
