using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using meetroomreservation.Data.Dao.Interfaces;
using meetroomreservation.Data.Models;
using meetroomreservation.Data.ResponseModel;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;

namespace meetroomreservation.Data.Dao
{
    public class UserDb : Db<UserResponseModel>, IUserDb
    {
        public UserDb(IConfiguration configuration,
            IWebHostEnvironment webHostEnvironment, MeetRoomReservationContext dbContext) : base(configuration, webHostEnvironment, dbContext)
        {
        }

        public async Task<bool> UserPasswordIsValid(int userId, string oldPassword)
        {
            string sql;
            bool result;
            sql = @"
                SELECT
                   1
                FROM users u
                WHERE
                    (u.id = @userId AND u.password = @oldPassword)
                ";

            //
            AddIntegerBind("userId", userId);
            AddStringBind("oldPassword", oldPassword);
            await Connect();
            await Query(sql);
            try
            {
                result = await QueryHasResult();
                return result;
            }
            catch (MySqlException exception)
            {
                throw new DbUpdateException(exception.Message);
            }
            finally
            {
                await Disconnect();
            }
        }

        protected override UserResponseModel Mapper(DbDataReader reader)
        {
            throw new NotImplementedException();
        }
        // protected override UserResponseModel Mapper(DbDataReader reader)
        // {
        //     UserResponseModel user;
        //     user = new UserResponseModel();
        //     user.u = Convert.ToInt32(reader["userId"]);
        //     user.Email = Convert.ToString(reader["Email"]);
        //     user.Name = Convert.ToString(reader["Name"]);
        //     user.Password = Convert.ToString(reader["Password"]);
        //     return user;
        // }
    }
}