using HR_Project_Group3_Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Project_Group3_Persistence.EntityTypeConfig
{
    public class CompanyConfig : BaseEntityConfig<Company>
    {

        public override void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(75);

            builder.HasData(new Company
            {
                Id = 1,
                Name = "BilgeAdam",
                Status = Status.Active,
                CreatedDate = DateTime.Now,

            },
            new Company
            {
                Id = 2,
                Name = "Group3",
                Status = Status.Active,
                CreatedDate = DateTime.Now,

            });


            base.Configure(builder);
        }
    }
}
