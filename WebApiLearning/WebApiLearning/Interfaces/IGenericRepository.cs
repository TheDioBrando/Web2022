using Microsoft.AspNetCore.Mvc;

namespace WebApiLearning.Interfaces
{
    public interface IGenericRepository<T>
        where T : class
    {
        T Get(int id);
        IEnumerable<T> GetAll();
        void Update(T entity);
        void Add(T entity);
        void Delete(int id);
        bool Exist(int id);
    }
}
