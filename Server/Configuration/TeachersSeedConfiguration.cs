using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Shared.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Server.Configuration
{
    public class TeachersSeedConfiguration : IEntityTypeConfiguration<Teachers>
    {
        public void Configure(EntityTypeBuilder<Teachers> builder)
        {
            builder.HasData(
                new Teachers
                {
                    Id = 1,
                    FirstName = "Lee",
                    LastName = "Jian Hong",
                    ContactNumber = 88288674,
                },
 new Teachers
 {
     Id = 2,
     FirstName = "Goh",
     LastName = "Yu sheng",
     ContactNumber = 92277213,
 }
);
        }
    }
}
