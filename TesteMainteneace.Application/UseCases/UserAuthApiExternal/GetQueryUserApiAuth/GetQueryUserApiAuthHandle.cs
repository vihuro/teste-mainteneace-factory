using AutoMapper;
using MediatR;
using TesteMainteneace.Domain.Interfaces;

namespace TesteMainteneace.Application.UseCases.UserAuthApiExternal.GetQueryUserApiAuth
{
    public sealed class GetQueryUserApiAuthHandle :
        IRequestHandler<GetQueryUserApiAuthRequest, List<GetQueryUserApiAuthResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IUserAuthApiRepository _userApiRepository;

        public GetQueryUserApiAuthHandle(IMapper mapper,
                                    IUserAuthApiRepository userApiRepository)
        {
            _mapper = mapper;
            _userApiRepository = userApiRepository;
        }

        public async Task<List<GetQueryUserApiAuthResponse>> Handle(GetQueryUserApiAuthRequest request,
                                                                    CancellationToken cancellationToken)
        {
            var usersInApiAuth = await _userApiRepository.GetList();

            return _mapper.Map<List<GetQueryUserApiAuthResponse>>(usersInApiAuth);

        }
    }
}
