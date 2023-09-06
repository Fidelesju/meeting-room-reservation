using meetroomreservation.Business.Exceptions;
using meetroomreservation.Business.Mapper.Interfaces;
using meetroomreservation.Business.Services.Interfaces;
using meetroomreservation.Business.Utils;
using meetroomreservation.Business.Validations;
using meetroomreservation.Data.Dao.Interfaces;
using meetroomreservation.Data.Models;
using meetroomreservation.Data.Repositories.Interfaces;
using meetroomreservation.Data.RequestModel;
using Microsoft.EntityFrameworkCore;

namespace meetroomreservation.Business.Services
{
    public class UserService : IUserService
    {
        #region Variaveis
        private readonly IUserRepository _userRepository;
        private readonly IUserCreateMapper _userCreateMapper;
        private readonly IUserUpdateMapper _userUpdateMapper;
        private readonly IUserDb _userDb;
        #endregion

        #region Construtor
        public UserService(
            IUserRepository userRepository,
            IUserCreateMapper userCreateMapper,
            IUserUpdateMapper userUpdateMapper,
            IUserDb userDb)
        {
            _userRepository = userRepository;
            _userCreateMapper = userCreateMapper;
            _userUpdateMapper = userUpdateMapper;
            _userDb = userDb;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Metodo de criar usuario
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="CustomValidationException"></exception> <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<int> CreateUser(UserCreateRequestModel request)
        {
            User user;
            UserCreateValidation validation;
            Dictionary<string, string> errors;

            _userCreateMapper.SetBaseMapping(request);
            validation = new UserCreateValidation();
            if (!validation.IsValid(request))
            {
                errors = validation.GetErrors();
                throw new CustomValidationException(errors);
            }
            try
            {
                user = _userCreateMapper.GetUser();
                _userRepository.Create(user);
                return Task.FromResult(user.Id);
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

        /// <summary>
        /// Metodo de alterar usuarios
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="CustomValidationException"></exception> <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<bool> UpdateUser(UserUpadateRequestModel request)
        {
            User user;
            UserUpdateValidation validation;
            Dictionary<string, string> errors;

            validation = new UserUpdateValidation();
            if (!validation.IsValid(request))
            {
                errors = validation.GetErrors();
                throw new CustomValidationException(errors);
            }

            _userUpdateMapper.SetBaseMapping(request);
            user = _userUpdateMapper.GetUser();
            try
            {
                _userRepository.Update(user);
                return Task.FromResult(true);
            }
            catch (DbUpdateException exception)
            {
                errors = validation.GetPersistenceErrors(exception);
                throw new CustomValidationException(errors);
            }
        }

        public async Task<bool> UpdateUserPassword(UserUpdatePasswordRequestModel request)
        {
            UserUpdatePasswordValidation validation;
            HashMd5 hashMd5;
            Dictionary<string, string> errors;
            bool success;
            bool userSuccess;
            hashMd5 = new HashMd5();
            validation = new UserUpdatePasswordValidation();
            if (!validation.IsValid(request))
            {
                errors = validation.GetErrors();
                throw new CustomValidationException(errors);
            }
            request.OldPassword = hashMd5.EncryptMD5(request.OldPassword);
            request.NewPassword = hashMd5.EncryptMD5(request.NewPassword);
            try
            {
                userSuccess = await _userDb.UserPasswordIsValid(request.Id, request.OldPassword);
                if (!userSuccess)
                {
                    return false;
                }
                success = await _userRepository.UpdateUserPassword(request.Id, request.NewPassword);
                return success;
            }
            catch (DbUpdateException exception)
            {
                errors = validation.GetPersistenceErrors(exception);
                throw new CustomValidationException(errors);
            }
        }
        #endregion
    }
}
