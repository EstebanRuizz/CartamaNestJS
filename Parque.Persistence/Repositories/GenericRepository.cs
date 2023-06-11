using Microsoft.EntityFrameworkCore;
using Parque.Application.Interfaces;
using Parque.Persistence.DBcontext;
using System.Linq.Expressions;

namespace Parque.Persistence.Repositories
{
    public class GenericRepository<T> : IRepositoryAsync<T> where T : class
    {
        private readonly ParqueDbContext _context;

        public GenericRepository(ParqueDbContext context)
        {
            _context = context;
        }

        public async Task<T> CreateAsync(T entity)
        {
            try
            {
                await _context.Set<T>().AddAsync(entity);

                return entity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> DeleteAsync(T entity)
        {
            try
            {
                _context.Set<T>().Remove(entity);

                return true;
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        public async Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>> filtro)
        {
            try
            {
                IQueryable<T> queryEntidad = filtro == null ? _context.Set<T>() : _context.Set<T>().Where(filtro);
                return queryEntidad;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public async Task<T> GetAsync(Expression<Func<T, bool>> filtro)
        {
            try
            {
                var entidad = await _context.Set<T>().FirstOrDefaultAsync(filtro);
                return entidad;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<bool> UpdateAsync(T entity)
        {
            try
            {
                _context.Set<T>().Update(entity);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            try
            {
                return await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
