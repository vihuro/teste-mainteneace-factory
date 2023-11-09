using AutoMapper;
using MediatR;
using TesteMainteneace.Domain.Entities.User;
using TesteMainteneace.Domain.Interfaces.System;
using TesteMainteneace.Domain.Interfaces.User;

namespace TesteMainteneace.Application.UseCases.User.CreateUser
{
    public class CreateUserHandler :
        IRequestHandler<CreateUserRequest, UserResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserAuthRepository _userAuthRepository;
        private readonly IMapper _mapper;

        public CreateUserHandler(IUnitOfWork unitOfWork, 
                                IUserAuthRepository userAuthRepository, 
                                IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _userAuthRepository = userAuthRepository;
            _mapper = mapper;
        }

        public async Task<UserResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<UserAuth>(request);
            
            _userAuthRepository.Create(user);
            
            await _unitOfWork.Commit(cancellationToken);

            return _mapper.Map<UserResponse>(user);
        }
    }
}
