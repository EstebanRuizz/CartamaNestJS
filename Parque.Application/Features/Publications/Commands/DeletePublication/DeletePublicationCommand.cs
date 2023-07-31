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

namespace Parque.Application.Features.Publications.Commands.DeletePublication
{
    public class DeletePublicationCommand : IRequest<GenericResponse<bool>>
    {
        public int Id { get; set; }
    }

   internal class DeletePublicationCommandHandler : IRequestHandler<DeletePublicationCommand, GenericResponse<bool>>
    {
        private readonly IRepositoryAsync<Publication> _repositoryAsync;

        public DeletePublicationCommandHandler(IRepositoryAsync<Publication> repositoryAsync)
        {
           _repositoryAsync = repositoryAsync;
        }

        public async Task<GenericResponse<bool>> Handle(DeletePublicationCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var publication = await _repositoryAsync.GetAsync(p => p.Id == request.Id);
                if (publication == null)
                    throw new KeyNotFoundException($"Publicación con el id: {request.Id} no existe");

                await _repositoryAsync.DeleteAsync(publication);
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
