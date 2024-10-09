using Microsoft.EntityFrameworkCore;
using oai_poc_backend.Database;

namespace oai_poc_backend.Repositories
{
    public class GenericRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<List<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T?> GetModelById(int id)
        {
            var model = await _dbSet.FindAsync(id);
            if (model == null)
            {
                throw new Exception();
            }
            return model;
        }

        public async Task Add(T entity)
        {
            try
            {
                await _dbSet.AddAsync(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task Delete(int id)
        {
            T? entityToDelete = await GetModelById(id);

            if (entityToDelete != null)
            {
                if (!_context.Set<T>().Local.Contains(entityToDelete))
                {
                    _context.Set<T>().Attach(entityToDelete);
                }
                try
                {
                    _context.Set<T>().Remove(entityToDelete);
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }


            }
            else
            {
                throw new ArgumentException($"{typeof(T).Name} with id {id} does not exist and could not be deleted");
            }
        }

        public void Update(T entity)
        {
            // Attach the entity to the _context if it's not already being tracked
            if (!_dbSet.Local.Any(e => e.Equals(entity)))
            {
                _dbSet.Attach(entity);
            }
            try
            {

                _context.Entry(entity).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

    }
}
