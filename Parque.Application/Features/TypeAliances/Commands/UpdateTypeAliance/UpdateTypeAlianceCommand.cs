using AutoMapper;
using MediatR;
using Parque.Application.DTOs.TypeAliance;
using Parque.Application.Interfaces;
using Parque.Application.Wrappers;
using Parque.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parque.Application.Features.TypeAliances.Commands.UpdateTypeAliance
{
    public class UpdateTypeAlianceCommand : IRequest<GenericResponse<TypeAlianceDTO>>
    {
        public int Id { get; set; } 
        public string Name { get; set; }
    }

    internal class UpdateTypeAlianceCommandHandler : IRequestHandler<UpdateTypeAlianceCommand, GenericResponse<TypeAlianceDTO>>
    {
        private readonly IRepositoryAsync<TypeAliance> _repositoryAsync;
        private readonly IMapper _mapper;

        public UpdateTypeAlianceCommandHandler(IRepositoryAsync<TypeAliance> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<GenericResponse<TypeAlianceDTO>> Handle(UpdateTypeAlianceCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var typeAliance = await _repositoryAsync.GetAsync(t => t.Id == request.Id);
                if (typeAliance == null)
                    throw new KeyNotFoundException($"Tipo de alianza con el id {request.Id} no existe");

                typeAliance.Name = request.Name;

                await _repositoryAsync.UpdateAsync(typeAliance);
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
