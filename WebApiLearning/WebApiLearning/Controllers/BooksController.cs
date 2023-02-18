using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiLearning.Data;
using WebApiLearning.Interfaces;
using WebApiLearning.Models;
using WebApiLearning.UnitsOfWork;

namespace WebApiLearning.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        //private readonly UnitOfWork _unit;
        private IGenericRepository<Books> _repo;

        public BooksController(IGenericRepository<Books> repo)
        {
            _repo = repo;
        }

        // GET: api/Books
        [HttpGet]
        public IEnumerable<BooksDTO> GetBooks()
        {
            return _repo.GetAll().Select(b=>BookToDTO(b)).ToList();
        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        public ActionResult<BooksDTO> GetBooks(int id)
        {
            var books = _repo.Get(id);

            if (books == null)
            {
                return NotFound();
            }

            return BookToDTO(books);
        }

        // PUT: api/Books/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutBooks(int id, BooksDTO bookDTO)
        {
            if (id != bookDTO.Id)
            {
                return BadRequest();
            }

            var book = _repo.Get(id);

            if (book==null)
            {
                return NotFound();
            }

            book.Author=bookDTO.Author;
            book.Title = bookDTO.Title;

            _repo.Update(book);

            return NoContent();
        }

        // POST: api/Books
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BooksDTO>> PostBooks(BooksDTO bookDTO)
        {
            var book = new Books
            {
                Id = bookDTO.Id,
                Title = bookDTO.Title,
                Author = bookDTO.Author
            };

            _repo.Add(book);

            return CreatedAtAction("GetBooks", new { id = book.Id }, BookToDTO(book));
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooks(int id)
        {
            var books = _repo.Get(id);
            if (books == null)
            {
                return NotFound();
            }

            _repo.Delete(id);

            return NoContent();
        }

        private bool BooksExists(int id)
        {
            return _repo.Exist(id);
        }

        private static BooksDTO BookToDTO(Books book) =>
            new BooksDTO
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author
            };
    }
}
