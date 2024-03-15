using HR_Project_Group3_Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Project_Group3_Persistence.EntityTypeConfig
{
    public class AppUserConfig : BaseEntityConfig<AppUser>
    {

        public async override void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasKey(x => x.Id);
            base.Configure(builder);

        }

    }
}