using Microsoft.EntityFrameworkCore;
using Project.Shared.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Server.Configuration
{
    public class EventSeedConfiguration : IEntityTypeConfiguration<Events>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Events> builder)
        {
            _ = builder.HasData(
               new Events
               {
                   Id = 1,
                   EventName = "Student Help Program",
                   Venue = "Classroom",
                   Participants = 10,
                   StartingTime = DateTime.Now.AddHours(1),
                   EndingTime = DateTime.Now.AddHours(2),
                   CreatedTime = DateTime.Now,
                   CategoryId=1,
                   
                   

               },
new Events
{
    Id = 2,
    EventName = "Gaming Competition",
    Venue = "Lab",
    Participants = 5,
    StartingTime = DateTime.Now.AddHours(1),
    EndingTime = DateTime.Now.AddHours(2),
    CreatedTime = DateTime.Now,
    CategoryId = 2,
},
new Events
{
    Id = 3,
    EventName = "Make up class",
    Venue = "Classroom",
    Participants = 20,
    StartingTime = DateTime.Now.AddHours(1),
    EndingTime = DateTime.Now.AddHours(2),
    CreatedTime = DateTime.Now,
    CategoryId = 1,
}
);
        }
    }
}
