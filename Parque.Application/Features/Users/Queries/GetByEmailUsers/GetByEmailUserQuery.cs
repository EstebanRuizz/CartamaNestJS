using AutoMapper;
using MediatR;
using Parque.Application.DTOs.Users;
using Parque.Application.Interfaces;
using Parque.Application.Wrappers;
using Parque.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parque.Application.Features.Users.Queries.GetByEmailUsers
{
    public class GetByEmailUserQuery : IRequest<GenericResponse<UserDTO>>
    {
        public string Email { get; set; }
    }

    internal class GetByEmailUserQueryHandler : IRequestHandler<GetByEmailUserQuery, GenericResponse<UserDTO>>
    {
        private readonly IRepositoryAsync<User> _repositoryAsync;
        private readonly IMapper _mapper;

        public GetByEmailUserQueryHandler(IRepositoryAsync<User> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<GenericResponse<UserDTO>> Handle(GetByEmailUserQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var usuario = await _repositoryAsync.GetAsync(p => p.Email == request.Email);
                if (usuario == null)
                    throw new KeyNotFoundException($"Usuario con el email {request.Email} no existe");

                return new GenericResponse<UserDTO>(_mapper.Map<UserDTO>(usuario));
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
