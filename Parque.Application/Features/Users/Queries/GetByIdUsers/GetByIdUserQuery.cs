using AutoMapper;
using MediatR;
using Parque.Application.DTOs.Users;
using Parque.Application.Interfaces;
using Parque.Application.Wrappers;
using Parque.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parque.Application.Features.Users.Queries.GetByIdUsers
{
    public class GetByIdUserQuery : IRequest<GenericResponse<UserDTO>>
    {
        public int Id { get; set; }
    }

    internal class GetByIdUserQueryHandler : IRequestHandler<GetByIdUserQuery, GenericResponse<UserDTO>>
    {
        private readonly IRepositoryAsync<User> _repositoryAsync;
        private readonly IMapper _mapper;

        public GetByIdUserQueryHandler(IRepositoryAsync<User> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<GenericResponse<UserDTO>> Handle(GetByIdUserQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var usuario = await _repositoryAsync.GetAsync(p => p.Id == request.Id);
                if (usuario == null)
                    throw new KeyNotFoundException($"Usuario con el id: {request.Id} no existe");

                return new GenericResponse<UserDTO>(_mapper.Map<UserDTO>(usuario));
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
