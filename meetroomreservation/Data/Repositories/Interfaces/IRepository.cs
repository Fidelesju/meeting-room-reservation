using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace meetroomreservation.Data.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task CreateAsync(T entidade);
        Task CreateAsync(List<T> entidadeLista);
        Task UpdateAsync(T entidade);
    }
}