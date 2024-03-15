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
    public class SiteManagerRepository : BaseRepository<SiteManager>, ISiteManagerRepository
    {
        public SiteManagerRepository(AppDbContext appDbContext) : base(appDbContext)
        {

        }
    }
}