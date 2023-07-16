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

namespace Parque.Application.Features.TypeDocuments.Commands.CreateTypeDocument
{
    public class CreateTypeDocumentCommand: IRequest<GenericResponse<int>>
    {
        public string Name { get; set; }
    }
    internal class CreateTypeDocumentCommandHandler : IRequestHandler<CreateTypeDocumentCommand, GenericResponse<int>>
    {
        private readonly IRepositoryAsync<TypeDocument> _repositoryAsync;
        private readonly IMapper _mapper;

        public CreateTypeDocumentCommandHandler(IRepositoryAsync<TypeDocument> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<GenericResponse<int>> Handle(CreateTypeDocumentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                TypeDocument newTypeDocument = _mapper.Map<CreateTypeDocumentCommand, TypeDocument>(request);
                var typeDocumente = await _repositoryAsync.CreateAsync(newTypeDocument);
                await _repositoryAsync.SaveChangesAsync();

                return new GenericResponse<int>(typeDocumente.Id);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
