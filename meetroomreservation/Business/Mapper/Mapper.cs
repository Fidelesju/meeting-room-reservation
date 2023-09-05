using meetroomreservation.Business.Mapper.Interfaces;

namespace meetroomreservation.Business.Mapper
{
    public class Mapper<T> : IMapper<T>
    {
        protected T BaseMapping;

        public void SetBaseMapping(T baseMapping)
        {
            BaseMapping = baseMapping;
        }
    }
}