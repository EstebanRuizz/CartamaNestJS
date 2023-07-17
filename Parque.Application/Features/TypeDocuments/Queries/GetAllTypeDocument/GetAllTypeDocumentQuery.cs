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

namespace Parque.Application.Features.TypeDocuments.Queries.GetAllTypeDocument
{
    public class GetAllTypeDocumentQuery : IRequest<GenericResponse<List<TypeDocumentDTO>>>
    {
    }

    internal class GetAllTypeDocumentQueryHandler : IRequestHandler<GetAllTypeDocumentQuery, GenericResponse<List<TypeDocumentDTO>>>
    {
        private readonly IRepositoryAsync<TypeDocument> _repositoryAsync;
        private readonly IMapper _mapper;

        public GetAllTypeDocumentQueryHandler(IRepositoryAsync<TypeDocument> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<GenericResponse<List<TypeDocumentDTO>>> Handle(GetAllTypeDocumentQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var typeDocuments = await _repositoryAsync.GetAllAsync();
                return new GenericResponse<List<TypeDocumentDTO>>(_mapper.Map<List<TypeDocumentDTO>>(typeDocuments));
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
