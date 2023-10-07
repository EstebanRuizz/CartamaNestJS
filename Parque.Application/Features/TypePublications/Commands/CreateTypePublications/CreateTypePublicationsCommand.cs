using AutoMapper;
using MediatR;
using Parque.Application.DTOs.TypePublications;
using Parque.Application.Interfaces;
using Parque.Application.Wrappers;
using Parque.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parque.Application.Features.TypePublications.Commands.CreateTypePublications
{

    public class CreateTypePublicationsCommand : IRequest<GenericResponse<TypePublicationsDTO>>
    {        
        public string Name { get; set; }
        public string Description { get; set; }
    }

    internal class CreateTypePublicationsCommandHandler : IRequestHandler<CreateTypePublicationsCommand, GenericResponse<TypePublicationsDTO>>
    {
        private readonly IRepositoryAsync<TypePublication> _repositoryAsync;
        private readonly IMapper _mapper;

        public CreateTypePublicationsCommandHandler(IRepositoryAsync<TypePublication> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<GenericResponse<TypePublicationsDTO>> Handle(CreateTypePublicationsCommand request, CancellationToken cancellationToken)
        {
            try
            {
                TypePublication newTypePublication = _mapper.Map<CreateTypePublicationsCommand, TypePublication>(request);
                var typePublication = await _repositoryAsync.CreateAsync(newTypePublication);
                await _repositoryAsync.SaveChangesAsync();

                return new GenericResponse<TypePublicationsDTO>(_mapper.Map<TypePublicationsDTO>(typePublication));
            }
            catch (Exception)
            {

                throw;
            }
        }
}
