using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SLMS.Application.Contracts.Persistance;
using SLMS.Dto;
using SLMS.Dto.SocialNetwork;
using SLMS.Dto.User;

namespace SLMS.Application.Features.Users.Queries
{
    public class GetUserListRequestHandler : IRequestHandler<GetUserListRequest, PagedResult<UserDto>>
    {
        IMapper _mapper;
        IUnitOfWork _unitofwork;

        public GetUserListRequestHandler(IMapper mapper, IUnitOfWork unitofwork)
        {
            _mapper = mapper;
            _unitofwork = unitofwork;
        }

        public async Task<PagedResult<UserDto>> Handle(GetUserListRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var query = _unitofwork.UserRepository.GetQueryable();

                if (!string.IsNullOrWhiteSpace(request.SearchTerm))
                {
                    request.SearchTerm = request.SearchTerm.Trim();
                    query = query.Where(p =>
            p.UserName.Contains(request.SearchTerm) ||
            p.FirstName.Contains(request.SearchTerm) ||
            p.LastName.Contains(request.SearchTerm) ||
            p.NationalCode.Contains(request.SearchTerm));
                }
                var totalCount = await query.CountAsync(cancellationToken);

                var items = await query
         .OrderByDescending(p => p.CreateDate)
         .Skip((request.PageNumber - 1) * request.PageSize)
         .Take(request.PageSize)
         .ProjectTo<UserDto>(_mapper.ConfigurationProvider)
         .ToListAsync(cancellationToken);

                return new PagedResult<UserDto>(
                    items,
                    totalCount,
                    request.PageNumber,
                    request.PageSize
                    );
            }
            catch
            {
                throw;
            }
        }
    }
}
