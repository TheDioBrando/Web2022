namespace WebApiLearning.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IBooksRepository Books { get; }
        IUsersRepository Users { get; }
        IOrdersRepository Orders { get; }

        Task<int> Save();
    }
}
