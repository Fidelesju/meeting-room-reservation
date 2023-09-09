using meetroomreservation.Business.Mapper.Interfaces;
using meetroomreservation.Data.Models;
using meetroomreservation.Data.RequestModel;

namespace meetroomreservation.Business.Mapper
{
    public class SchedulingCreateMapper : Mapper<SchedulingCreateRequest>, ISchedulingCreateMapper
    {
        private readonly Scheduling _scheduling;

        public SchedulingCreateMapper()
        {
            _scheduling = new Scheduling();
        }

        public Scheduling GetScheduling()
        {
            _scheduling.UserId = BaseMapping.UserId;
            //_scheduling.Data = BaseMapping.Data;
            _scheduling.Data = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd hh:mm"));
            return _scheduling;
        }
    }
}