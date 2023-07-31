using AutoMapper;
using MediatR;
using Parque.Application.DTOs.Aliances;
using Parque.Application.Interfaces;
using Parque.Application.Wrappers;
using Parque.Domain.Entites;

namespace Parque.Application.Features.Aliances.Commands.CreateAliances
{
    public class CreateAliancesCommand : IRequest<GenericResponse<AliancesDTO>>
    {
        public string Name { get; set; }
        public string AlianceDate { get; set; }
        public string Description { get; set; }
        public int IdTypeAliance { get; set; }
        public string DocumentRoute { get; set; }
        public string Base64Archivo { get; set; }
        public string NombreCompletoArchivo { get; set; }
    }
    internal class CreateAliancesCommandHandler : IRequestHandler<CreateAliancesCommand, GenericResponse<AliancesDTO>>
    {
        private readonly IRepositoryAsync<Aliance> _repositoryAsync;
        private readonly IMapper _mapper;

        public CreateAliancesCommandHandler(IRepositoryAsync<Aliance> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<GenericResponse<AliancesDTO>> Handle(CreateAliancesCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Aliance alianzaNueva = _mapper.Map<CreateAliancesCommand, Aliance>(request);
                var alianza = await _repositoryAsync.CreateAsync(alianzaNueva);
                await _repositoryAsync.SaveChangesAsync();
                var alince = await _repositoryAsync.GetAsync(p => p.Id == alianzaNueva.Id, includeProperties: $"{nameof(Aliance.IdTypeAliancesNavigation)}");

                return new GenericResponse<AliancesDTO>(_mapper.Map<AliancesDTO>(alince));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
