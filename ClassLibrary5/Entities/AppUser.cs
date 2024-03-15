using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Project_Group3_Domain.Entities
{
    public class AppUser : IdentityUser, IBaseEntity
    {
        public int? RenewPasswordCode { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public Status Status { get; set; }
        public SiteManager? SiteManager { get; set; }
        public Director? Director { get; set; }

        public Employee? Employee { get; set; }
    }
}
