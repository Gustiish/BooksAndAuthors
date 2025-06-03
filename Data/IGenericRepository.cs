namespace BooksAndAuthors.Data
{
    public interface IGenericRepository<T> where T : class, IEntity
    {
        IEnumerable<T> GetAll();

        T Get(int Id);

        void Update(T entity);

        void Delete(T entity);
        void Add(T entity);
    }
}
