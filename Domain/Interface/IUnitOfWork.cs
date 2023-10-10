using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface IUnitOfWork 
    {
        IPais ? Paises { get; }
        ICita ? Citas { get; }
        Task<int> SaveAsync();

    }
}