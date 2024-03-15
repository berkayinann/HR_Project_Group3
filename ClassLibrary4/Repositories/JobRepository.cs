using HR_Project_Group3_App.IRepositories;
using HR_Project_Group3_Domain.Entities;
using HR_Project_Group3_Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Project_Group3_Persistence.Repositories
{
    public class JobRepository : BaseRepository<Job>, IJobRepository
    {
        private readonly AppDbContext _appDbContext;

        public JobRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }
    }
}
