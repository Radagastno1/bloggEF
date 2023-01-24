using CORE;
namespace LOGIC;
public interface IRepository<T>
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id);
    Task<int> InsertAsync(T obj);
    Task UpdateAsync(T obj);
    Task DeleteAsync(T obj);
    Task<IEnumerable<T>> GetBySearchAsync(string search);
}
