using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DotNetCoreCustomerRepo.Models;

namespace DotNetCoreCustomerRepo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerDetailController : ControllerBase
    {
        private readonly CustomerDetailContext _context;

        public CustomerDetailController(CustomerDetailContext context)
        {
            _context = context;
        }

        // GET: api/CustomerDetail
        [HttpGet]
        public IEnumerable<CustomerDetail> GetCustomerDetails()
        {
            return _context.CustomerDetails;
        }

        // GET: api/CustomerDetail/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerDetail([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var customerDetail = await _context.CustomerDetails.FindAsync(id);

            if (customerDetail == null)
            {
                return NotFound();
            }

            return Ok(customerDetail);
        }

        // PUT: api/CustomerDetail/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomerDetail([FromRoute] int id, [FromBody] CustomerDetail customerDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != customerDetail.CustomerId)
            {
                return BadRequest();
            }

            _context.Entry(customerDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerDetailExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/CustomerDetail
        [HttpPost]
        public async Task<IActionResult> PostCustomerDetail([FromBody] CustomerDetail customerDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.CustomerDetails.Add(customerDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomerDetail", new { id = customerDetail.CustomerId }, customerDetail);
        }

        // DELETE: api/CustomerDetail/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomerDetail([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var customerDetail = await _context.CustomerDetails.FindAsync(id);
            if (customerDetail == null)
            {
                return NotFound();
            }

            _context.CustomerDetails.Remove(customerDetail);
            await _context.SaveChangesAsync();

            return Ok(customerDetail);
        }

        private bool CustomerDetailExists(int id)
        {
            return _context.CustomerDetails.Any(e => e.CustomerId == id);
        }
    }
}