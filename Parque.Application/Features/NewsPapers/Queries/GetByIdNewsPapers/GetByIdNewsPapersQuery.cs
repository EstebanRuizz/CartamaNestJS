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

namespace Parque.Application.Features.NewsPapers.Queries.GetByIdNewsPapers
{
    public class GetByIdNewsPapersQuery : IRequest<GenericResponse<NewsPaperDTO>>
    {
        public int Id { get; set; }
    }

    internal class GetByIdNewsPapersQueryHandler : IRequestHandler<GetByIdNewsPapersQuery, GenericResponse<NewsPaperDTO>>
    {
        private readonly IRepositoryAsync<NewsPaper> _repositoryAsync;
        private readonly IMapper _mapper;

        public GetByIdNewsPapersQueryHandler(IRepositoryAsync<NewsPaper> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<GenericResponse<NewsPaperDTO>> Handle(GetByIdNewsPapersQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var getNewspaper = await _repositoryAsync.GetAsync(p => p.Id == request.Id, includeProperties: $"{nameof(NewsPaper.IdPublishingHouseNavigation)}");

                if (getNewspaper == null)
                    throw new KeyNotFoundException($"Newspaper with id: {request.Id} does not exist");

                return new GenericResponse<NewsPaperDTO>(_mapper.Map<NewsPaperDTO>(getNewspaper));
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
