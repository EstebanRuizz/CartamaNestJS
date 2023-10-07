using AutoMapper;
using MediatR;
using Parque.Application.DTOs.Aliances;
using Parque.Application.Interfaces;
using Parque.Application.Wrappers;
using Parque.Domain.Entites;

namespace Parque.Application.Features.Aliances.Commands.UpdateAliances
{
    public class UpdateAliancesCommand : IRequest<GenericResponse<AliancesDTO>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string AlianceDate { get; set; }
        public string DocumentRoute { get; set; }
        public int IdTypeAliance { get; set; }

    }
    internal class UpdateAliancesCommandHandler : IRequestHandler<UpdateAliancesCommand, GenericResponse<AliancesDTO>>
    {
        private readonly IRepositoryAsync<Aliance> _repositoryAsync;
        private readonly IMapper _mapper;

        public UpdateAliancesCommandHandler(IMapper mapper, IRepositoryAsync<Aliance> repositoryAsync)
        {
            _mapper = mapper;
            _repositoryAsync = repositoryAsync;
        }

        public async Task<GenericResponse<AliancesDTO>> Handle(UpdateAliancesCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var aliance = await _repositoryAsync.GetAsync(p => p.Id == request.Id);

                if (aliance == null)
                    throw new KeyNotFoundException($"Alinaza con el id: {request.Id} no existe");

                aliance.Description = request.Description;
                aliance.AlianceDate = request.AlianceDate.ToString();
                aliance.Name = request.Name;
                aliance.IdTypeAliance = request.IdTypeAliance;
                aliance.DocumentRoute = request.DocumentRoute;

                await _repositoryAsync.UpdateAsync(aliance);
                await _repositoryAsync.SaveChangesAsync();

                var getAliance = await _repositoryAsync.GetAsync(p => p.Id == request.Id, includeProperties: $"{nameof(Aliance.IdTypeAliancesNavigation)}");

                return new GenericResponse<AliancesDTO>(_mapper.Map<AliancesDTO>(getAliance));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
