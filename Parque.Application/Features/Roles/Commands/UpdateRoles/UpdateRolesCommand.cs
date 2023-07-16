using AutoMapper;
using MediatR;
using Parque.Application.DTOs.Roles;
using Parque.Application.Interfaces;
using Parque.Application.Wrappers;
using Parque.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Parque.Application.Features.Roles.Commands.UpdateRoles
{
    public class UpdateRolesCommand: IRequest<GenericResponse<RolesDTO>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }

    internal class UpdateRolesCommandHandler : IRequestHandler<UpdateRolesCommand, GenericResponse<RolesDTO>>
    {
        private readonly IRepositoryAsync<Rol> _repositoryAsync;
        private readonly IMapper _mapper;

        public UpdateRolesCommandHandler(IRepositoryAsync<Rol> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<GenericResponse<RolesDTO>> Handle(UpdateRolesCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var role = await _repositoryAsync.GetAsync(role => role.Id == request.Id);
                if (role == null) 
                    throw new KeyNotFoundException($"Rol con Id {request.Id} no fue encontrado");

                role.Name = request.Name;
                role.Description = request.Description;
                role.IsActive = request.IsActive;

                await _repositoryAsync.UpdateAsync(role);
                await _repositoryAsync.SaveChangesAsync();

                return new GenericResponse<RolesDTO>(_mapper.Map<RolesDTO>(role));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
