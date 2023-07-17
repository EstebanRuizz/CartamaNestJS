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

namespace Parque.Application.Features.TypePublications.Commands.DeleteTypePublications
{
    public class DeleteTypePublicationsCommand : IRequest<GenericResponse<bool>>
    {
        public int Id { get; set; }
    }

    internal class DeleteTypePublicationsCommandHandler : IRequestHandler<DeleteTypePublicationsCommand, GenericResponse<bool>>
    {
        private readonly IRepositoryAsync<TypePublication> _repositoryAsync;

        public DeleteTypePublicationsCommandHandler(IRepositoryAsync<TypePublication> repositoryAsync)
        {
            _repositoryAsync = repositoryAsync;
        }

        public async Task<GenericResponse<bool>> Handle(DeleteTypePublicationsCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var typePublication = await _repositoryAsync.GetAsync(tp => tp.Id == request.Id);
                if (typePublication == null)
                    throw new KeyNotFoundException($"Tipo de publicación con el id: {request.Id} no existe");

                await _repositoryAsync.DeleteAsync(typePublication);
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
