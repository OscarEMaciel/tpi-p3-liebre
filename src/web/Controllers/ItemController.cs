using Microsoft.AspNetCore.Mvc;
using Application.Models.Request;
using Application.Services;
using Application.Interfaces;
using Domain.Exceptions;
using System;
using Microsoft.AspNetCore.Authorization;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;

        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet]
        [Authorize(Roles = "Client, SysAdmin, Admin")]
        public IActionResult GetAllItems()
        {
            try
            {
                var items = _itemService.GetAllItems();
                return Ok(items);
            }
            catch (Exception ex)
            {

                return StatusCode(500, "An unexpected error occurred.");
            }
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Client, SysAdmin, Admin")]
        public IActionResult GetProductById(int id)
        {
            try
            {
                var item = _itemService.GetItemById(id);
                if (item == null)
                {
                    throw new NotFoundException("Item", id);
                }
                return Ok(item);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {

                return StatusCode(500, "An unexpected error occurred.");
            }
        }

        [HttpPost]
        [Authorize(Roles = "SysAdmin, Admin")]
        public IActionResult CreateItem([FromBody] ItemCreateRequest itemCreateRequest)
        {
            try
            {
                _itemService.CreateItem(itemCreateRequest);
                return Ok();
            }
            catch (Exception ex)
            {

                return StatusCode(500, "An unexpected error occurred.");
            }
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "SysAdmin, Admin")]
        public IActionResult UpdateItem(int id, [FromBody] ItemUpdateRequest itemUpdateRequest)
        {
            try
            {
                _itemService.UpdateItem(id, itemUpdateRequest);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {

                return StatusCode(500, "An unexpected error occurred.");
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "SysAdmin, Admin")]
        public IActionResult DeleteItem(int id)
        {
            try
            {
                _itemService.DeleteItem(id);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {

                return StatusCode(500, "An unexpected error occurred.");
            }
        }
    }
}