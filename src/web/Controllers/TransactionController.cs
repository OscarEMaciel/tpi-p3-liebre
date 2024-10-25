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
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpGet]
        [Authorize(Roles = "Client, SysAdmin, Admin")]
        public IActionResult GetAllTransaction()
        {
            try
            {
                var transactions = _transactionService.GetAllTransaction();
                return Ok(transactions);
            }
            catch (Exception ex)
            {

                return StatusCode(500, "An unexpected error occurred.");
            }
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Client, SysAdmin, Admin")]
        public IActionResult GetTransactionById(int id)
        {
            try
            {
                var transaction = _transactionService.GetTransactionById(id);
                if (transaction == null)
                {
                    throw new NotFoundException("Transaction", id);
                }
                return Ok(transaction);
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
        [Authorize(Roles = "Client, SysAdmin, Admin")]
        public IActionResult CreateTransaction(TransactionCreateRequest transactionCreateRequest)
        {
            try
            {
                _transactionService.CreateTransaction(transactionCreateRequest);
                return Ok();
            }
            catch (Exception ex)
            {

                return StatusCode(500, "An unexpected error occurred.");
            }
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Client, SysAdmin, Admin")]
        public IActionResult UpdateTransaction(int id, [FromBody] TransactionUpdateRequest transactionUpdateRequest)
        {
            try
            {
                _transactionService.UpdateTransaction(id, transactionUpdateRequest);
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
        [Authorize(Roles = "Client, SysAdmin, Admin")]
        public IActionResult DeleteTransaction(int id)
        {
            try
            {
                _transactionService.DeleteTransaction(id);
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