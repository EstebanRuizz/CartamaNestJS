using AutoMapper;
using MediatR;
using Parque.Application.DTOs.Users;
using Parque.Application.Interfaces;
using Parque.Application.Wrappers;
using Parque.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Parque.Application.Features.Users.Commands.UpdateUsers
{
    public class UpdateUserCommand : IRequest<GenericResponse<bool>>
    {
        public int Id { get; set; }
        public string IdentityDocument { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string ProfilePictureRoute { get; set; }
        public int IdTypeDocument { get; set; }
        public int IdRol { get; set; }
    }

    internal class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, GenericResponse<bool>>
    {
        private readonly IRepositoryAsync<User> _repositoryAsync;
        private readonly IMapper _mapper;

        public UpdateUserCommandHandler(IRepositoryAsync<User> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<GenericResponse<bool>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var usuario = await _repositoryAsync.GetAsync(p => p.Id == request.Id);
                if (usuario == null)
                    throw new KeyNotFoundException($"Usuario con el id : {request.Id} no existe");

                usuario.IdentityDocument = request.IdentityDocument ;
                usuario.Email = request.Email ;
                usuario.FirstName = request.FirstName ;
                usuario.LastName = request.LastName ;
                usuario.Phone = request.Phone ;
                usuario.Password = request.Password ;
                usuario.ProfilePictureRoute = request.ProfilePictureRoute ;
                usuario.IdTypeDocument = request.IdTypeDocument ;
                usuario.IdRol = request.IdRol;

                await _repositoryAsync.UpdateAsync(usuario);
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
