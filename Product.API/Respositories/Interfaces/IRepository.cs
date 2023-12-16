namespace Repositories
{
  public interface IRepository<T>
  {
    IQueryable<T> GetAll();
    List<T> Get();
    T Get(int id);
    T Add(T t);
    /// <summary>
    /// this method updates existing entity
    /// </summary>
    /// <param name="user">existing entity with updated details</param>
    T Update(int id, T t);
    T Delete(T t);
  }
}