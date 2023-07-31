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

namespace Parque.Application.Features.NewsPapers.Commands.DeleteNewsPaper
{
    public class DeleteNewsPaperCommand : IRequest<GenericResponse<bool>>
    {
        public int Id { get; set; }
    }

    internal class DeleteNewsPaperCommandHandler : IRequestHandler<DeleteNewsPaperCommand, GenericResponse<bool>>
    {
        private readonly IRepositoryAsync<NewsPaper> _repositoryAsync;
        private readonly IMapper _mapper;

        public DeleteNewsPaperCommandHandler(IRepositoryAsync<NewsPaper> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<GenericResponse<bool>> Handle(DeleteNewsPaperCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var newPaper = await _repositoryAsync.GetAsync(p => p.Id == request.Id);
                if (newPaper == null)
                    throw new KeyNotFoundException($"Periodico con el id: {request.Id} no existe");

                await _repositoryAsync.DeleteAsync(newPaper);
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
