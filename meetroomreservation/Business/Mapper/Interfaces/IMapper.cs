using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace meetroomreservation.Business.Mapper.Interfaces
{
    public interface IMapper<T>
    {
        void SetBaseMapping(T baseMapping);
    }
}