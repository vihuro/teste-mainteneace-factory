using AutoMapper;
using MediatR;
using TesteMainteneace.Application.UseCases.User;
using TesteMainteneace.Domain.Entities.User;
using TesteMainteneace.Domain.Interfaces.System;
using TesteMainteneace.Domain.Interfaces.User;

namespace TesteMainteneace.Application.UseCases.UserAuthApiExternal.GetUserApiAuthForThisService
{
    public class GetUserApiAuthForThisServiceHandle :
        IRequestHandler<GetUserApiAuthForThisServiceRequest, List<UserResponse>>
    {
        private readonly IUnitOfWork _unitWork;
        private readonly IUserAuthApiRepository _userApiAuthRespository;
        private readonly IUserAuthRepository _userAuthRepository;
        private readonly IMapper _mapper;

        public GetUserApiAuthForThisServiceHandle(IUnitOfWork unitWork, 
                                                    IUserAuthApiRepository userApiAuthRespository,
                                                    IUserAuthRepository userAuthRepository,
                                                    IMapper mapper)
        {
            _unitWork = unitWork;
            _userApiAuthRespository = userApiAuthRespository;
            _userAuthRepository = userAuthRepository;
            _mapper = mapper;
        }

        public async Task<List<UserResponse>> Handle(GetUserApiAuthForThisServiceRequest request, 
                                                        CancellationToken cancellationToken)
        {
            var listUsersApiExternal = await _userApiAuthRespository.GetList(cancellationToken);

            var listUsersInThisService = await _userAuthRepository.GetAll(cancellationToken);

            var verificationUserNotRegisteres = listUsersApiExternal.Where(userExternal =>
                                                                !listUsersInThisService.Any(x => 
                                                                    x.Id == userExternal.UsuarioId)).ToList();

            if (!verificationUserNotRegisteres.Any())
            {
                throw new Exception("Not Updated!");
            }

            var itemsMapping = _mapper.Map<List<UserAuth>>(verificationUserNotRegisteres);

            _userAuthRepository.CreateList(itemsMapping);

            await _unitWork.Commit(cancellationToken);

            return _mapper.Map<List<UserResponse>>(itemsMapping);

        }
    }
}
