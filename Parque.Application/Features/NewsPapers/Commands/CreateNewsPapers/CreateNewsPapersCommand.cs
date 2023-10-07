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

namespace Parque.Application.Features.NewsPapers.Commands.CreateNewsPapers
{
    public class CreateNewsPapersCommand : IRequest<GenericResponse<NewsPaperDTO>>
    {
        public string Title { get; set; }
        public int IdPublishingHouse { get; set; }
        public string DocumentRoute { get; set; }
    }

    internal class CreateNewsPapersCommandHandler : IRequestHandler<CreateNewsPapersCommand, GenericResponse<NewsPaperDTO>>
    {
        private readonly IRepositoryAsync<NewsPaper> _repositoryAsync;
        private readonly IMapper _mapper;

        public CreateNewsPapersCommandHandler(IRepositoryAsync<NewsPaper> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<GenericResponse<NewsPaperDTO>> Handle(CreateNewsPapersCommand request, CancellationToken cancellationToken)
        {
            try
            {
                NewsPaper newsPaper = _mapper.Map<CreateNewsPapersCommand, NewsPaper>(request);
                var newNewsPaper = await _repositoryAsync.CreateAsync(newsPaper);
                await _repositoryAsync.SaveChangesAsync();

                var getNewspaper = await _repositoryAsync.GetAsync(p => p.Id == newNewsPaper.Id, includeProperties: $"{nameof(NewsPaper.IdPublishingHouseNavigation)}");

                return new GenericResponse<NewsPaperDTO>(_mapper.Map<NewsPaperDTO>(getNewspaper));
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
