using meetroomreservation.Business.Exceptions;
using meetroomreservation.Business.Mapper.Interfaces;
using meetroomreservation.Business.Services.Interfaces;
using meetroomreservation.Business.Validations;
using meetroomreservation.Data.Models;
using meetroomreservation.Data.Repositories.Interfaces;
using meetroomreservation.Data.RequestModel;
using Microsoft.EntityFrameworkCore;

namespace meetroomreservation.Business.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserCreateMapper _userCreateMapper;

        public UserService(
            IUserRepository userRepository,
            IUserCreateMapper userCreateMapper) 
        {
            _userRepository = userRepository;
            _userCreateMapper = userCreateMapper;
        }

        public async Task<int> CreateUser (UserCreateRequestModel request)
        {
            User user;
            UserCreateValidation validation;
            Dictionary<string,string> errors;

            _userCreateMapper.SetBaseMapping(request);
            validation = new UserCreateValidation();
            if(!validation.IsValid(request))
            {
                errors = validation.GetErrors();
                throw new CustomValidationException(errors);
            }
            try
            {
                user = _userCreateMapper.GetUser();
                _userRepository.Create(user);
                return user.Id;
            }
            catch (DbUpdateException exception)
            {
                errors = validation.GetPersistenceErrors(exception);
                if (errors.Count == 0)
                {
                    throw;
                }
                throw new CustomValidationException(errors);
            }
        } 
    }
}
