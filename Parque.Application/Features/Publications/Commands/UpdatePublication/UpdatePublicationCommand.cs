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

namespace Parque.Application.Features.Publications.Commands.UpdatePublication
{
    public class UpdatePublicationCommand : IRequest<GenericResponse<ListPublicationDTO>>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool HasForm { get; set; }
        public int IdTypeOfPublication { get; set; }
        public string Description { get; set; }
        public string ImageRoute { get; set; }
    }

    internal class UpdatePublicationCommandHandler : IRequestHandler<UpdatePublicationCommand, GenericResponse<ListPublicationDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryAsync<Publication> _repositoryAsync;

        public UpdatePublicationCommandHandler(IMapper mapper, IRepositoryAsync<Publication> repositoryAsync)
        {
            _mapper = mapper;
            _repositoryAsync = repositoryAsync;
        }

        public async Task<GenericResponse<ListPublicationDTO>> Handle(UpdatePublicationCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var publication = await _repositoryAsync.GetAsync(p => p.Id == request.Id);
                if (publication == null)
                    throw new KeyNotFoundException($"Publicación con el id: {request.Id} no existe");

                publication.Title = request.Title;
                publication.HasForm = request.HasForm;
                publication.idTypeOfPublication = request.IdTypeOfPublication;
                publication.Description = request.Description;
                publication.ImageRoute = request.ImageRoute;

                await _repositoryAsync.UpdateAsync(publication);
                await _repositoryAsync.SaveChangesAsync();

                return new GenericResponse<ListPublicationDTO>(_mapper.Map<ListPublicationDTO>(publication));
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
