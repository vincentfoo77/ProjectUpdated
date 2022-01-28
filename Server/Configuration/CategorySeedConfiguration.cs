using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Shared.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Server.Configuration
{
    public class CategorySeedConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            _ = builder.HasData(
               new Category
               {
                   Id = 1,
                   CategoryName = "Study",

               },
new Category
{
    Id = 2,
    CategoryName = "Gaming",
}
) ;
        }
    }
}
