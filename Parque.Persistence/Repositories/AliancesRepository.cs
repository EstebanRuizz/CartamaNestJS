using Microsoft.EntityFrameworkCore;
using Parque.Application.Interfaces;
using Parque.Domain.Entites;
using Parque.Persistence.DBcontext;
using System.Linq.Expressions;

namespace Parque.Persistence.Repositories
{
    public class AliancesRepository : GenericRepository<Aliance>, IAliancesRepository
    {
        private readonly ParqueDbContext _parqueDbContext;
        public AliancesRepository(ParqueDbContext context) : base(context)
        {
            _parqueDbContext = context;
        }
        public async Task<List<Aliance>> GetAllAliances(Expression<Func<Aliance, bool>> filtro = null)
        {
            try
            {
                var listAliances = await _parqueDbContext.Aliances.Include(p => p.IdTypeAliancesNavigation).ToListAsync();
                return listAliances;
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
