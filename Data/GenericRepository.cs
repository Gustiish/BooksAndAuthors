
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BooksAndAuthors.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, IEntity
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;
        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public void Add(T entity)
        {
            try
            {
                _dbSet.Add(entity);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public void Delete(T entity)
        {
            try
            {
                _dbSet.Remove(entity);
                _context.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public T Get(int Id)
        {
            try
            {
                return _dbSet.Find(Id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }

        public IEnumerable<T> GetAll()
        {
            try
            {
                return _dbSet.OrderBy(x => x.Id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }

        public void Update(T entity)
        {
            try
            {
                _dbSet.Update(entity);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
               
            }
        }

        public IEnumerable<T> GetAllIncluding(params Expression<Func<T, object>>[] includeProperty)
        {
            IQueryable<T> query = _dbSet;

            foreach (var prop in includeProperty)
            {
                query = query.Include(prop);
            }

            return query.ToList();
        }

        public T GetIncluding(int id, params Expression<Func<T, object>>[] includeProperty)
        {
            IQueryable<T> query = _dbSet;

            foreach (var prop in includeProperty)
            {
                query = query.Include(prop);
            }

            return query.FirstOrDefault(q => q.Id == id);
        }

      


    }
}

