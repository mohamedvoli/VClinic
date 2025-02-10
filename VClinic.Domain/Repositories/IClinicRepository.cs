using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VClinic.Domain.Entities;

namespace VClinic.Domain.Repositories
{
    public interface IClinicRepository : IAsyncRepository<Clinic>
    {
        //No custom methods yet
    }
}
