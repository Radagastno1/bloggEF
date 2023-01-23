using CORE;
namespace LOGIC;
public interface IRepository<T>
{
    IEnumerable<T> GetAll();
    T GetById(int id);
    int Insert(T obj);
    void Update(T obj);
    void Delete(T obj);
    IEnumerable<T> GetBySearch(string search);
}
