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

namespace Parque.Application.Features.TypeAliances.Commands.DeleteTypeAliance
{
    public class DeleteTypeAlianceCommand :IRequest<GenericResponse<bool>>
    {
        public int Id { get; set; }
    }

    internal class DeleteTypeAlianceCommandHandler : IRequestHandler<DeleteTypeAlianceCommand, GenericResponse<bool>>
    {
        private readonly IRepositoryAsync<TypeAliance> _repositoryAsync;
        private readonly IMapper _mapper;

        public DeleteTypeAlianceCommandHandler(IRepositoryAsync<TypeAliance> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<GenericResponse<bool>> Handle(DeleteTypeAlianceCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var typeAliance = await _repositoryAsync.GetAsync(tp => tp.Id == request.Id);
                if (typeAliance == null)
                    throw new KeyNotFoundException($"Tipo de publicación con el id: {request.Id} no existe");

                await _repositoryAsync.DeleteAsync(typeAliance);
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
