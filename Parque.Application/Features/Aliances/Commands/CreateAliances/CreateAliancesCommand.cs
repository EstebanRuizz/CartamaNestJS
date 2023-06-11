using AutoMapper;
using MediatR;
using Parque.Application.Interfaces;
using Parque.Application.Wrappers;
using Parque.Domain.Entites;

namespace Parque.Application.Features.Aliances.Commands.CreateAliances
{
    public class CreateAliancesCommand : IRequest<GenericResponse<int>>
    {
        public string Name { get; set; }
        public string AlianceDate { get; set; }
        public string Description { get; set; }
        public int IdTypeAliance { get; set; }
        public string DocumentRoute { get; set; }
        public string Base64Archivo { get; set; }
        public string NombreCompletoArchivo { get; set; }
    }

    public class CreateAliancesCommandHandler : IRequestHandler<CreateAliancesCommand, GenericResponse<int>>
    {
        private readonly IRepositoryAsync<Aliance> _repositoryAsync;
        private readonly IMapper _mapper;

        public CreateAliancesCommandHandler(IRepositoryAsync<Aliance> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;

        }

        public async Task<GenericResponse<int>> Handle(CreateAliancesCommand request, CancellationToken cancellationToken)
        {

            try
            {
                Aliance alianzaNueva = new Aliance()
                {
                    Description = request.Description,
                    Name = request.Name,
                    AlianceDate = request.AlianceDate,
                    IdTypeAliance = request.IdTypeAliance,
                    DocumentRoute = request.DocumentRoute
                };

                var alianza = await _repositoryAsync.CreateAsync(alianzaNueva);
                await _repositoryAsync.SaveChangesAsync();

                return new GenericResponse<int>(alianza.Id);
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
