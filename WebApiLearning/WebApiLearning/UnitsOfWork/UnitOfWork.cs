using WebApiLearning.Data;
using WebApiLearning.Interfaces;
using WebApiLearning.Repositories;

namespace WebApiLearning.UnitsOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private LibraryContext _context;

        public UnitOfWork(LibraryContext context)
        {
            _context = context;
            Users = new UsersRepository(_context);
            //Books = new BooksRepository(_context);
            Orders = new OrdersRepository(_context);
        }

        public IUsersRepository Users { get; private set; }
        public IBooksRepository Books { get; private set; }
        public IOrdersRepository Orders { get; private set; }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<int> Save()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
