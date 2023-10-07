using AutoMapper;
using MediatR;
using Parque.Application.DTOs.Roles;
using Parque.Application.Interfaces;
using Parque.Application.Wrappers;
using Parque.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parque.Application.Features.Roles.Queries.GetById
{
    public class GetRoleByIdQuery : IRequest<GenericResponse<RolesDTO>>
    {
        public int Id { get; set; }
    }

    internal class GetRoleByIdQueryHandler : IRequestHandler<GetRoleByIdQuery, GenericResponse<RolesDTO>>
    {
        private readonly IRepositoryAsync<Rol> _repositoryAsync;
        private readonly IMapper _mapper;

        public GetRoleByIdQueryHandler(IRepositoryAsync<Rol> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<GenericResponse<RolesDTO>> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var role = await _repositoryAsync.GetAsync(role => role.Id == request.Id);
                if (role == null)
                    throw new KeyNotFoundException($"El rol con Id {request.Id} no fue encontrado");

                return new GenericResponse<RolesDTO>(_mapper.Map<RolesDTO>(role));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
