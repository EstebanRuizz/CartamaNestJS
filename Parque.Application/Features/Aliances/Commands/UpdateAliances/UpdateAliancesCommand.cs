using AutoMapper;
using MediatR;
using Parque.Application.Interfaces;
using Parque.Application.Wrappers;
using Parque.Domain.Entites;

namespace Parque.Application.Features.Aliances.Commands.UpdateAliances
{
    public class UpdateAliancesCommand : IRequest<GenericResponse<bool>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime AlianceDate { get; set; }
        public int IdTypeAliance { get; set; }

    }


    public class UpdateAliancesCommandHandler : IRequestHandler<UpdateAliancesCommand, GenericResponse<bool>>
    {
        private readonly IRepositoryAsync<Aliance> _repositoryAsync;
        private readonly IMapper _mapper;

        public UpdateAliancesCommandHandler(IMapper mapper, IRepositoryAsync<Aliance> repositoryAsync)
        {
            _mapper = mapper;
            _repositoryAsync = repositoryAsync;
        }

        public async Task<GenericResponse<bool>> Handle(UpdateAliancesCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var alianza = await _repositoryAsync.GetAsync(p => p.Id == request.Id);

                if (alianza == null)
                    throw new KeyNotFoundException($"Alinaza con el id: {request.Id} no existe");


                alianza.Description = request.Description;
                alianza.AlianceDate = request.AlianceDate.ToString();
                alianza.Name = request.Name;

                await _repositoryAsync.UpdateAsync(alianza);
                await _repositoryAsync.SaveChangesAsync();

                return new GenericResponse<bool>(true);


            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
