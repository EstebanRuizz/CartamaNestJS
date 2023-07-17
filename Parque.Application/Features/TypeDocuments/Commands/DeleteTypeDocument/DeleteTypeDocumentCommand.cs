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

namespace Parque.Application.Features.TypeDocuments.Commands.DeleteTypeDocument
{
    public class DeleteTypeDocumentCommand : IRequest<GenericResponse<bool>>
    {
        public int Id { get; set; }
    }

    internal class DeleteTypeDocumentCommandHandler : IRequestHandler<DeleteTypeDocumentCommand, GenericResponse<bool>>
    {
        private readonly IRepositoryAsync<TypeDocument> _repositoryAsync;
        private readonly IMapper _mapper;

        public DeleteTypeDocumentCommandHandler(IRepositoryAsync<TypeDocument> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<GenericResponse<bool>> Handle(DeleteTypeDocumentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var typeDocument = await _repositoryAsync.GetAsync(td => td.Id == request.Id);
                if (typeDocument == null)
                    throw new KeyNotFoundException($"Tipo de documento con el id: {request.Id} no existe");

                await _repositoryAsync.DeleteAsync(typeDocument);
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
