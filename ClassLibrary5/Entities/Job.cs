using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Project_Group3_Domain.Entities
{
    public class Job : IBaseEntity
    {
        public Job()
        {
            SiteManagers = new List<SiteManager>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public Status Status { get; set; }
        public List<SiteManager> SiteManagers { get; set; }
    }
}
