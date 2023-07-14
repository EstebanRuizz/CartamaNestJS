using AutoMapper;
using MediatR;
using Parque.Application.Interfaces;
using Parque.Application.Wrappers;
using Parque.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Parque.Application.Features.Users.Commands.CreateUsers
{
    public class CreateUserCommand : IRequest<GenericResponse<int>>
    {
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

    internal class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, GenericResponse<int>>
    {
        private readonly IRepositoryAsync<User> _repository;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(IRepositoryAsync<User> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GenericResponse<int>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                User nuevoUsuario = new User()
                {
                    IdentityDocument = request.IdentityDocument,
                    Email = request.Email,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Phone = request.Phone,
                    Password = BCrypt.Net.BCrypt.HashPassword(request.Password),
                    ProfilePictureRoute = request.ProfilePictureRoute,
                    IdTypeDocument = request.IdTypeDocument,
                    IdRol = request.IdRol
                };

                var usuario = await _repository.CreateAsync(nuevoUsuario);
                await _repository.SaveChangesAsync();

                return new GenericResponse<int>(usuario.Id);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
