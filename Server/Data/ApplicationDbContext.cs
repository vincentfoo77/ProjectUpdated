using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Project.Server.Configuration;
using Project.Server.Models;
using Project.Shared.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
            
    }
        public DbSet<Attendees> Attendees { get; set; }
        public DbSet<Category> Category{get; set; }
        public DbSet<EventPost> EventPost { get; set; }
        public DbSet<Events> Events { get; set; }
        public DbSet<FeedBack> FeedBack { get; set; }
        public DbSet<Registration> Registration { get; set; }
        public DbSet<Students> Students { get; set; }
        public DbSet<Teachers> Teachers { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new StudentSeedConfiguration());
            builder.ApplyConfiguration(new TeachersSeedConfiguration());
            builder.ApplyConfiguration(new EventSeedConfiguration());
            builder.ApplyConfiguration(new CategorySeedConfiguration());
        }
    }
}
