using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Linq.Expressions;

namespace BooksAndAuthors.Data
{
    public interface IGenericRepository<T> where T : class, IEntity
    {
        IEnumerable<T> GetAll();

        T Get(int Id);

        void Update(T entity);

        void Delete(T entity);
        void Add(T entity);

        IEnumerable<T> GetAllIncluding(params Expression<Func<T, object>>[] includeProperty);

        T GetIncluding(int Id, params Expression<Func<T, object>>[] includeProperty);

     


    }
}
