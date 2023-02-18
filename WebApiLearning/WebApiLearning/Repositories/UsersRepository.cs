using WebApiLearning.Data;
using WebApiLearning.Interfaces;
using WebApiLearning.Models;

namespace WebApiLearning.Repositories
{
    public class UsersRepository : GenericRepository<Users>, IUsersRepository
    {
        public UsersRepository(LibraryContext context) : base(context)
        {
        }
    }
}
