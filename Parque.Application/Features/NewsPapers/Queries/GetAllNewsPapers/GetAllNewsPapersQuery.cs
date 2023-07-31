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

namespace Parque.Application.Features.NewsPapers.Queries.GetAllNewsPapers
{
    public class GetAllNewsPapersQuery : IRequest<GenericResponse<List<NewsPaperDTO>>>
    {
    }

    internal class GetAllNewsPapersQueryHandler : IRequestHandler<GetAllNewsPapersQuery, GenericResponse<List<NewsPaperDTO>>>
    {
        private readonly IRepositoryAsync<NewsPaper> _repositoryAsync; 
        private readonly IMapper _mapper;

        public GetAllNewsPapersQueryHandler(IRepositoryAsync<NewsPaper> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<GenericResponse<List<NewsPaperDTO>>> Handle(GetAllNewsPapersQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var newsPapers = await _repositoryAsync.GetAllAsync();
                return new GenericResponse<List<NewsPaperDTO>>(_mapper.Map<List<NewsPaperDTO>>(newsPapers));
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
