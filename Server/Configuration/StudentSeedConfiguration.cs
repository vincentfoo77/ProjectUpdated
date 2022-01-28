using Microsoft.EntityFrameworkCore;
using Project.Shared.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Server.Configuration
{
    public class StudentSeedConfiguration : IEntityTypeConfiguration<Students>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Students> builder)
        {
            builder.HasData(
                new Students
 {
     Id = 1,
     FirstName = "Black",
     LastName="Yu Xuan",
     ContactNumber=88288675,
 },
 new Students
 {
     Id = 2,
     FirstName = "White",
     LastName = "Amir",
     ContactNumber = 92277216,
 }
);
        }
    }
}
