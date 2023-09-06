using meetroomreservation.Business.Exceptions;
using meetroomreservation.Business.Services.Interfaces;
using meetroomreservation.Business.Utils;
using meetroomreservation.Data.Dao.Interfaces;
using meetroomreservation.Data.RequestModel;
using meetroomreservation.Data.ResponseModel;

namespace meetroomreservation.Business.Services
{
    public class AccessService : IAccessService
    {
        #region Variables
        private readonly IAuthDb _authDb;

        #endregion
        public AccessService(
            IAuthDb authDb
        )
        {
            _authDb = authDb;
        }

        /// <summary>
        /// Autenticação de usuário - Service
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<UserLoginResponseModel> AuthenticateUser(UserLoginRequestModel request)
        {
            HashMd5 hashMd5;
            UserLoginResponseModel response;
            hashMd5 = new HashMd5();
            string? password = request.Password;
            string? email = request.Email;
            string encryptPassword = hashMd5.EncryptMD5(password);

            response = await _authDb.AuthenticateUser(email, encryptPassword);
            if (response == null)
            {
                throw new RecordNotFoundException();
            }

            return response;
        }
    }
}