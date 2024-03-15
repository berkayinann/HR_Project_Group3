using HR_Project_Group3_App.DTOs.SiteManagerDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Project_Group3_App.Services
{
    public interface ISiteManagerService
    {
        Task<DetailsSiteManager> GetDetailSiteOwner(int id);
        Task<UpdateSiteManager> GetUpdateSiteOwner(int id);
    }
}
