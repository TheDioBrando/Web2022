using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using WebApiLearning.Data;
using WebApiLearning.Interfaces;
using WebApiLearning.Models;

namespace WebApiLearning.Repositories
{
    public class BooksRepository : IGenericRepository<Books>
    {
        private LibraryContext _context;

        public BooksRepository(LibraryContext context)
        {
            _context = context;
        }

        public void Add(Books entity)
        {
            _context.Books.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var item = Get(id);

            if (item != null)
                _context.Books.Remove(item);
            _context.SaveChanges();
        }

        public bool Exist(int id)
        {
            if (_context.Books.Find(id) == null)
            {
                return false;
            }

            return true;
        }

        public Books Get(int id)
        {
            return _context.Books.Find(id);
        }

        public IEnumerable<Books> GetAll()
        {
            return _context.Books.ToList();
        }

        public void Update(Books entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
        }
    }
}
