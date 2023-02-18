using WebApiLearning.Data;
using WebApiLearning.Interfaces;
using WebApiLearning.Models;

namespace WebApiLearning.Repositories
{
    public class OrdersRepository : GenericRepository<Orders>, IOrdersRepository
    {
        public OrdersRepository(LibraryContext context) : base(context)
        {
        }
    }
}
