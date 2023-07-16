using AutoMapper;
using MediatR;
using Parque.Application.DTOs.Users;
using Parque.Application.Exceptions;
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
    public class CreateUserCommand : IRequest<GenericResponse<UserListDTO>>
    {
        public string NationalIdentificationNumber { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string ProfilePictureRoute { get; set; }
        public int IdTypeDocument { get; set; }
        public int IdRol { get; set; }
    }

    internal class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, GenericResponse<UserListDTO>>
    {
        private readonly IRepositoryAsync<User> _repository;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(IRepositoryAsync<User> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GenericResponse<UserListDTO>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await ValidateNewUser(request);

                User user = _mapper.Map<CreateUserCommand, User>(request);
                user.Password = BCrypt.Net.BCrypt.HashPassword(request.Password);

                var newUser = await _repository.CreateAsync(user);
                await _repository.SaveChangesAsync();

                return new GenericResponse<UserListDTO>(_mapper.Map<User, UserListDTO>(newUser));
            }
            catch (ValidationException ex)
            {
                return new GenericResponse<UserListDTO>(ex.Errors, statusCode: 400);
            }
        }
        private async Task ValidateNewUser(CreateUserCommand request)
        {
            var existingUserWithNationalIdentification = await _repository.GetAsync(user => user.NationalIdentificationNumber == request.NationalIdentificationNumber);
            if (existingUserWithNationalIdentification != null)
            {
                throw new ValidationException(new List<string> { "NationalIdentificationNumber already in use." });
            }
            var existingUserWithEmail = await _repository.GetAsync(user => user.Email == request.Email);
            if (existingUserWithEmail != null)
            {
                throw new ValidationException(new List<string> { "Email already in use." });
            }
        }

    }


}
