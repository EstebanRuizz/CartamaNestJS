using AutoMapper;
using MediatR;
using Parque.Application.DTOs.Users;
using Parque.Application.Interfaces;
using Parque.Application.Wrappers;
using Parque.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parque.Application.Features.Users.Queries.GetAllUsers
{
    public class GetAllUsersQuery : IRequest<GenericResponse<List<UserListDTO>>> {}

    internal class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, GenericResponse<List<UserListDTO>>>
    {
        private readonly IRepositoryAsync<User> _repositoryAsync;
        private readonly IMapper _mapper;

        public GetAllUsersQueryHandler(IRepositoryAsync<User> userRepository, IMapper mapper)
        {
            _repositoryAsync = userRepository;
            _mapper = mapper;
        }

        public async Task<GenericResponse<List<UserListDTO>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var users = await _repositoryAsync.GetAllAsync();
                return new GenericResponse<List<UserListDTO>>(_mapper.Map<List<UserListDTO>>(users));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
