using AutoMapper;
using MediatR;
using Parque.Application.Interfaces;
using Parque.Application.Wrappers;
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
        //private readonly IRepositoryAsync _repositoryAsync;
        private readonly IMapper _mapper;

        public Task<GenericResponse<int>> Handle(CreateTypeDocumentCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
