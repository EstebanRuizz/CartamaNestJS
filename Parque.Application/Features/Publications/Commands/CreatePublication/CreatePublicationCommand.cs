using AutoMapper;
using MediatR;
using Parque.Application.DTOs.Publication;
using Parque.Application.Interfaces;
using Parque.Application.Wrappers;
using Parque.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parque.Application.Features.Publications.Commands.CreatePublication
{
    public class CreatePublicationCommand : IRequest<GenericResponse<ListPublicationDTO>>
    {
        public string Title { get; set; }
        public bool HasForm { get; set; }
        public int IdTypeOfPublication { get; set; }
        public string Description { get; set; }
        public string ImageRoute { get; set; }
    }
    internal class CreatePublicationCommandHandler : IRequestHandler<CreatePublicationCommand, GenericResponse<ListPublicationDTO>>
    {
        private readonly IRepositoryAsync<Publication> _repositoryAsync;
        private readonly IMapper _mapper;

        public CreatePublicationCommandHandler(IRepositoryAsync<Publication> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<GenericResponse<ListPublicationDTO>> Handle(CreatePublicationCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Publication publication = _mapper.Map<CreatePublicationCommand, Publication>(request);
                var newPublication = await _repositoryAsync.CreateAsync(publication);
                await _repositoryAsync.SaveChangesAsync();

                var getPublication = await _repositoryAsync.GetAsync(p => p.Id == newPublication.Id, includeProperties: $"{nameof(Publication.IdTypePublicationNavigation)}");  

                return new GenericResponse<ListPublicationDTO>(_mapper.Map<ListPublicationDTO>(getPublication));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
