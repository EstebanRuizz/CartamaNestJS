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

namespace Parque.Application.Features.TypeDocuments.Queries.GetByIdTypeDocument
{
    public class GetByIdTypeDocumentQuery : IRequest<GenericResponse<TypeDocumentDTO>>
    {
        public int Id { get; set; }
    }

    internal class GetByIdTypeDocumentQueryHandler : IRequestHandler<GetByIdTypeDocumentQuery, GenericResponse<TypeDocumentDTO>>
    {
        private readonly IRepositoryAsync<TypeDocument> _repositoryAsync;
        private readonly IMapper _mapper;

        public GetByIdTypeDocumentQueryHandler(IRepositoryAsync<TypeDocument> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<GenericResponse<TypeDocumentDTO>> Handle(GetByIdTypeDocumentQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var typeDocument = await _repositoryAsync.GetAsync(td => td.Id == request.Id);
                if (typeDocument == null)
                    throw new KeyNotFoundException($"Tipo de documento con el id: {request.Id} no existe");

                return new GenericResponse<TypeDocumentDTO>(_mapper.Map<TypeDocumentDTO>(typeDocument));
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
