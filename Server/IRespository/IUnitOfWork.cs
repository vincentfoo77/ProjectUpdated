using Project.Shared.Domain;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Server.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        Task Save(HttpContext httpContext);
        IGenericRepository<Attendees> Attendees { get; }
        IGenericRepository<Category> Category { get; }
        IGenericRepository<EventPost> EventPost { get; }
        IGenericRepository<Events> Events { get; }
        IGenericRepository<FeedBack> FeedBack { get; }
        IGenericRepository<Registration> Registration { get; }
        IGenericRepository<Students> Students { get; }
        IGenericRepository<Teachers> Teachers { get; }
    }
}