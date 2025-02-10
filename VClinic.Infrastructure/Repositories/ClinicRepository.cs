using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VClinic.Domain.Entities;
using VClinic.Domain.Repositories;
using VClinic.Infrastructure.Persistence.DbContexts;

namespace VClinic.Infrastructure.Repositories
{
    public class ClinicRepository : BaseRepository<Clinic>, IClinicRepository
    {
        private VClinicDbContext _dbContext;
        public ClinicRepository(VClinicDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        //No custom methods yet
    }
}
