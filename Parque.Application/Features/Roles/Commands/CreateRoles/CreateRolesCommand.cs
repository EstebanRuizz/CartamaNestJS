using AutoMapper;
using MediatR;
using Parque.Application.DTOs.Enviroment;
using Parque.Application.DTOs.Roles;
using Parque.Application.Interfaces;
using Parque.Application.Wrappers;
using Parque.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parque.Application.Features.Roles.Commands.CreateRoles
{
    public class CreateRolesCommand : IRequest<GenericResponse<RolesDTO>>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
    internal class CreateRolesCommandHandler : IRequestHandler<CreateRolesCommand, GenericResponse<RolesDTO>>
    {
        private readonly IRepositoryAsync<Rol> _repositoryAsync;
        private readonly IMapper _mapper;

        public CreateRolesCommandHandler(IRepositoryAsync<Rol> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<GenericResponse<RolesDTO>> Handle(CreateRolesCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Rol newRol = _mapper.Map<CreateRolesCommand, Rol>(request);

                var rol = await _repositoryAsync.CreateAsync(newRol);
                await _repositoryAsync.SaveChangesAsync();

                return new GenericResponse<RolesDTO>(_mapper.Map<RolesDTO>(rol));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
