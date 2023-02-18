using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiLearning.Data;
using WebApiLearning.Models;

namespace WebApiLearning.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly LibraryContext _context;

        public OrdersController(LibraryContext context)
        {
            _context = context;
        }

        // GET: api/Orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrdersDTO>>> GetOrders()
        {
            return await _context.Orders.Select(o=>OrderToDTO(o)).ToListAsync();
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrdersDTO>> GetOrders(int id)
        {
            var orders = await _context.Orders.FindAsync(id);

            if (orders == null)
            {
                return NotFound();
            }

            return OrderToDTO(orders);
        }

        // PUT: api/Orders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrders(int id, OrdersDTO orderDTO)
        {
            if (id != orderDTO.Id)
            {
                return BadRequest();
            }

            var order = await _context.Orders.FindAsync(id);
            if(order == null)
            {
                return NotFound();
            }

            order.BookId = orderDTO.BookId;
            order.UserId = orderDTO.UserId;

            //_context.Entry(orderDTO).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrdersExists(id))
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

        // POST: api/Orders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrdersDTO>> PostOrders(OrdersDTO orderDTO)
        {
            var order = new Orders
            {
                Id = orderDTO.Id,
                UserId = orderDTO.UserId,
                BookId = orderDTO.BookId
            };

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrders", new { id = order.Id }, OrderToDTO(order));
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrders(int id)
        {
            var orders = await _context.Orders.FindAsync(id);
            if (orders == null)
            {
                return NotFound();
            }

            _context.Orders.Remove(orders);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrdersExists(int id)
        {
            return _context.Orders.Any(e => e.Id == id);
        }

        private static OrdersDTO OrderToDTO(Orders order) =>
            new OrdersDTO
            {
                Id = order.Id,
                UserId = order.UserId,
                BookId = order.BookId,
            };
    }
}
