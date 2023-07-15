using AutoMapper;
using MediatR;
using Parque.Application.DTOs.Roles;
using Parque.Application.Interfaces;
using Parque.Application.Wrappers;
using Parque.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Parque.Application.Features.Roles.Queries.GetAllRoles
{
    public class GetAllRolesQuery : IRequest<GenericResponse<List<RolesDTO>>>
    {
    }

    internal class GetAllRolesQueryHandler : IRequestHandler<GetAllRolesQuery, GenericResponse<List<RolesDTO>>>
    {
        private readonly IRepositoryAsync<Rol> _repositoryAsync;
        private readonly IMapper _mapper;

        public GetAllRolesQueryHandler(IRepositoryAsync<Rol> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<GenericResponse<List<RolesDTO>>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var roles = await _repositoryAsync.GetAllAsync();
                return new GenericResponse<List<RolesDTO>>(_mapper.Map<List<RolesDTO>>(roles));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
