using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Infrastructure
{
    public interface IPinNumberDataService
    {
        Task Save(int number);
        Task<bool> Exists(int number);
    }
}
