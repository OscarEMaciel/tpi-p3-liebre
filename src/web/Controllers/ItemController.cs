using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;

        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet("[action]")]
        public IActionResult GetAll()
        {
            return Ok(_itemService.GetItems());
        }

        [HttpGet("[action]/{id}")]
        public IActionResult GetItemById(int id)
        {
            var item = _itemService.GetItemById(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPost("[action]")]
        public IActionResult AddItem(Item item)
        {
            _itemService.AddItem(item);
            return Ok();
        }

        [HttpPut("[action]/{id}")]
        public IActionResult UpdateItem(int id, [FromBody] Item item)
        {
            var existingItem = _itemService.GetItemById(id);
            if (existingItem == null)
            {
                return NotFound();
            }

            _itemService.UpdateItem(id, item);
            return Ok();
        }

        [HttpDelete("[action]/{id}")]
        public IActionResult DeleteItem(int id)
        {
            var item = _itemService.GetItemById(id);
            if (item == null)
            {
                return NotFound();
            }

            _itemService.DeleteItem(id);
            return Ok();
        }
    }
}
