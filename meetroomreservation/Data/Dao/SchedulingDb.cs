using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using meetroomreservation.Data.ApplicationModels;
using meetroomreservation.Data.Dao.Interfaces;
using meetroomreservation.Data.Models;

namespace meetroomreservation.Data.Dao
{
    public class SchedulingDb : Db<SchedulingResponseModel>, ISchedulingDb
    {
        public SchedulingDb(
            IConfiguration configuration, 
            IWebHostEnvironment hostingEnviroment,
             MeetRoomReservationContext dbContext) : base(configuration, hostingEnviroment, dbContext)
        {
        }

        public async Task<PaginatedList<SchedulingResponseModel>> GetPaginatedListSchedulingByUserId (int userId, int page, int perPage, Pagination pagination)
        {
            string sql;
            PaginatedList<SchedulingResponseModel> schedulingResponseModel;

            sql = $@"
                SELECT 
                    userId as UserId,
                    DATE_FORMAT(data, '%d-%m-%Y %H:%m') AS Data
                FROM scheduling
                WHERE userId = {userId}
            ";

            await Connect();
            SetPagination(pagination);
            await QueryPagination(sql, page, perPage);
            schedulingResponseModel = new PaginatedList<SchedulingResponseModel>
            {
                List = await GetQueryResultList(),
                Pagination = await GetPagination()
            };
            await Disconnect();
            return schedulingResponseModel;
        }

        protected override SchedulingResponseModel Mapper(DbDataReader reader)
        {
            SchedulingResponseModel scheduling;
            scheduling = new SchedulingResponseModel
            {
                UserId = Convert.ToInt32(reader["UserId"]),
                Data = Convert.ToString(reader["Data"])
            };

            return scheduling;
        }
    }
}