using AutoMapper;
using MediatR;
using Parque.Application.DTOs.TypeAliance;
using Parque.Application.Interfaces;
using Parque.Application.Wrappers;
using Parque.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parque.Application.Features.TypeAliances.Commands.CreateTypeAliance
{
    public class CreateTypeAlianceCommand : IRequest<GenericResponse<TypeAlianceDTO>>
    {
        public string Name { get; set; }
    }
   
    internal class CreateTypeAlianceCommandHandler : IRequestHandler<CreateTypeAlianceCommand, GenericResponse<TypeAlianceDTO>>
    {
        private readonly IRepositoryAsync<TypeAliance> _repositoryAsync;
        private readonly IMapper _mapper;

        public CreateTypeAlianceCommandHandler(IRepositoryAsync<TypeAliance> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<GenericResponse<TypeAlianceDTO>> Handle(CreateTypeAlianceCommand request, CancellationToken cancellationToken)
        {
            try
            {
                TypeAliance newTypeAliance = _mapper.Map<CreateTypeAlianceCommand, TypeAliance>(request);

                var typeAliance = await _repositoryAsync.CreateAsync(newTypeAliance);
                await _repositoryAsync.SaveChangesAsync();

                return new GenericResponse<TypeAlianceDTO>(_mapper.Map<TypeAlianceDTO>(typeAliance));
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
