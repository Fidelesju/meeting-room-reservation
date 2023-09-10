using meetroomreservation.Data.Dao.Interfaces;
using meetroomreservation.Data.Models;
using meetroomreservation.Data.ResponseModel;
using System.Data.Common;

namespace meetroomreservation.Data.Dao
{
    public class AuthDb : Db<UserLoginResponseModel>, IAuthDb
    {

        #region Constructor
         public AuthDb(IConfiguration configuration, IWebHostEnvironment hostingEnviroment, MeetRoomReservationContext dbContext) : base(configuration,
            hostingEnviroment, dbContext)
        {
        }
        #endregion
    
        #region Methods
        /// <summary>
        /// Autenticando usuário
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<UserLoginResponseModel> AuthenticateUser(string email, string password)
        {
            string sql;
            UserLoginResponseModel loginResponseModel;
            sql = @"
                    SELECT 
                        u.id as UserId,
                        u.email as Email,
                        u.name as Name
                    FROM users u
                    WHERE 
                        u.email = @email 
                        AND 
                        u.password = @password
                    LIMIT 1
                ";
            await Connect();
            AddStringBind("email", email);
            AddStringBind("password", password);
            await Query(sql);
            loginResponseModel = await GetQueryResultObject();
            await Disconnect();
            return loginResponseModel;
        }

        protected override UserLoginResponseModel Mapper(DbDataReader reader)
        {
            UserLoginResponseModel userloginResponseModel;
            userloginResponseModel = new UserLoginResponseModel();
            userloginResponseModel.Id = Convert.ToInt32(reader["UserId"]);
            userloginResponseModel.Name = Convert.ToString(reader["Name"]);
            userloginResponseModel.Email = Convert.ToString(reader["Email"]);
            return userloginResponseModel;
        }
        #endregion
    }
}