using WebApiLearning.Data;
using WebApiLearning.Interfaces;

namespace WebApiLearning.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T>
        where T : class
    {
        protected readonly LibraryContext _context;

        public GenericRepository(LibraryContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Delete(int id)
        {
            var item = Get(id);

            if (item != null)
                _context.Set<T>().Remove(item);
        }

        public T Get(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public void Update(T entity)
        {
             _context.Update(entity);
        }

        public bool Exist(int id)
        {
            if(_context.Set<T>().Find(id) == null)
            {
                return false;
            }

            return true;
        }
    }
}
