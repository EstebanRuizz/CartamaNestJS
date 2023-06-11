using Parque.Domain.Entites;
using System.Linq.Expressions;

namespace Parque.Application.Interfaces
{
    public interface IAliancesRepository
    {
        Task<List<Aliance>> GetAllAliances(Expression<Func<Aliance, bool>> filtro = null);
    }
}
