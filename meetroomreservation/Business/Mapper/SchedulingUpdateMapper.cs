using meetroomreservation.Business.Mapper.Interfaces;
using meetroomreservation.Data.Models;
using meetroomreservation.Data.RequestModel;

namespace meetroomreservation.Business.Mapper
{
    public class SchedulingUpdateMapper : Mapper<SchedulingUpdateRequestModel>, ISchedulingUpdateMapper
    {
        private readonly Scheduling _scheduling;

        public SchedulingUpdateMapper()
        {
            _scheduling = new Scheduling();
        }

        public Scheduling GetScheduling()
        {
            _scheduling.Id = BaseMapping.Id;
            _scheduling.UserId = BaseMapping.UserId;
            _scheduling.Data = BaseMapping.GetDataAsDateTime();
            // _scheduling.Data = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd hh:mm"));
            return _scheduling;
        }
    }
}