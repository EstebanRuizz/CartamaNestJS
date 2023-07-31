using AutoMapper;
using MediatR;
using Parque.Application.DTOs.NewsPapers;
using Parque.Application.Interfaces;
using Parque.Application.Wrappers;
using Parque.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parque.Application.Features.NewsPapers.Commands.UpdateNewsPaper
{
    public class UpdateNewsPaperCommand : IRequest<GenericResponse<NewsPaperDTO>>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int PublishingHouse { get; set; }
        public string DocumentRoute { get; set; }
    }

    internal class UpdateNewsPaperCommandHandler : IRequestHandler<UpdateNewsPaperCommand, GenericResponse<NewsPaperDTO>>
    {
        private readonly IRepositoryAsync<NewsPaper> _repositoryAsync;
        private readonly IMapper _mapper;

        public UpdateNewsPaperCommandHandler(IRepositoryAsync<NewsPaper> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<GenericResponse<NewsPaperDTO>> Handle(UpdateNewsPaperCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var newPaper = await _repositoryAsync.GetAsync(p => p.Id == request.Id);
                if (newPaper == null)
                    throw new KeyNotFoundException($"Periodico con el id: {request.Id} no existe");

                newPaper.Title = request.Title;
                newPaper.IdPublishingHouse = request.PublishingHouse; 
                newPaper.DocumentRoute = request.DocumentRoute;

                await _repositoryAsync.UpdateAsync(newPaper);
                await _repositoryAsync.SaveChangesAsync();

                return new GenericResponse<NewsPaperDTO>(_mapper.Map<NewsPaperDTO>(newPaper));
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
