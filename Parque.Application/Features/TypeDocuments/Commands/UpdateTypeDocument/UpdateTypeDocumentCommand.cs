using AutoMapper;
using MediatR;
using Parque.Application.DTOs.TypeDocument;
using Parque.Application.Interfaces;
using Parque.Application.Wrappers;
using Parque.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parque.Application.Features.TypeDocuments.Commands.UpdateTypeDocument
{
    public class UpdateTypeDocumentCommand : IRequest<GenericResponse<TypeDocumentDTO>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    internal class UpdateTypeDocumentCommandHandler : IRequestHandler<UpdateTypeDocumentCommand, GenericResponse<TypeDocumentDTO>>
    {
        private readonly IRepositoryAsync<TypeDocument> _repositoryAsync;
        private readonly IMapper _mapper;

        public UpdateTypeDocumentCommandHandler(IRepositoryAsync<TypeDocument> repositoryAsinc, IMapper mapper)
        {
            _repositoryAsync = repositoryAsinc;
            _mapper = mapper;
        }

        public async Task<GenericResponse<TypeDocumentDTO>> Handle(UpdateTypeDocumentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var typeDocument = await _repositoryAsync.GetAsync(td => td.Id == request.Id);
                if (typeDocument == null)
                    throw new KeyNotFoundException($"Tipo de documento con el id: {request.Id} no existe");

                typeDocument.Name = request.Name;

                await _repositoryAsync.UpdateAsync(typeDocument);
                await _repositoryAsync.SaveChangesAsync();

                return new GenericResponse<TypeDocumentDTO>(_mapper.Map<TypeDocumentDTO>(typeDocument));
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
