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

namespace Parque.Application.Features.Users.Commands.DeleteUsers
{
    public class DeleteUserCommand : IRequest<GenericResponse<bool>>
    {
        public int Id { get; set; }
    }

    internal class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, GenericResponse<bool>>
    {
        private IRepositoryAsync<User> _repositoryAsync;

        public DeleteUserCommandHandler(IRepositoryAsync<User> repositoryAsync)
        {
            _repositoryAsync = repositoryAsync;
        }

        public async Task<GenericResponse<bool>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _repositoryAsync.GetAsync(p => p.Id == request.Id);
                if (user == null) 
                    throw new KeyNotFoundException($"El usuario con el id: {request.Id} no existe");

                await _repositoryAsync.DeleteAsync(user);
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
