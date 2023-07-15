using AutoMapper;
using MediatR;
using Parque.Application.Interfaces;
using Parque.Application.Wrappers;
using Parque.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parque.Application.Features.Roles.Commands.CreateRoles
{
    public class CreateRolesCommand : IRequest<GenericResponse<int>>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }

    }
    internal class CreateRolesCommandHandler : IRequestHandler<CreateRolesCommand, GenericResponse<int>>
    {
        private readonly IRepositoryAsync<Rol> _repositoryAsync;
        private readonly IMapper _mapper;

        public CreateRolesCommandHandler(IRepositoryAsync<Rol> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<GenericResponse<int>> Handle(CreateRolesCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Rol newRol = new Rol()
                {
                    Name = request.Name,
                    Description = request.Description,
                    IsActive = request.IsActive,
                };
                var rol = await _repositoryAsync.CreateAsync(newRol);
                await _repositoryAsync.SaveChangesAsync();
                return new GenericResponse<int>(rol.Id);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
