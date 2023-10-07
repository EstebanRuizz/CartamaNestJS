using MediatR;
using Parque.Application.Interfaces;
using Parque.Application.Wrappers;
using Parque.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Parque.Application.Features.Roles.Commands.DeleteRoles
{
    public class DeleteRolesCommand : IRequest<GenericResponse<bool>>
    {
        public int Id { get; set; }
    }
    internal class DeleteRolesCommandHandler : IRequestHandler<DeleteRolesCommand, GenericResponse<bool>>
    {
        private readonly IRepositoryAsync<Rol> _repositoryAsync;

        public DeleteRolesCommandHandler(IRepositoryAsync<Rol> repositoryAsync)
        {
            _repositoryAsync = repositoryAsync;
        }

        public async Task<GenericResponse<bool>> Handle(DeleteRolesCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var role = await _repositoryAsync.GetAsync(role => role.Id == request.Id);
                if (role == null)
                    throw new KeyNotFoundException($"Rol con Id {request.Id} no fue encontrado");

                await _repositoryAsync.DeleteAsync(role);
                await _repositoryAsync.SaveChangesAsync();

                return new GenericResponse<bool>(true);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
