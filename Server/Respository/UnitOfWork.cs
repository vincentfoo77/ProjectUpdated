using Project.Server.Data;
using Project.Server.IRepository;
using Project.Server.Models;
using Project.Shared.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Project.Server.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IGenericRepository<Attendees> _Attendee;
        private IGenericRepository<Category> _Category;
        private IGenericRepository<EventPost> _EventPost;
        private IGenericRepository<Events> _Events;
        private IGenericRepository<FeedBack> _FeedBack;
        private IGenericRepository<Registration> _Registration;
        private IGenericRepository<Students> _Students;
        private IGenericRepository<Teachers> _Teachers;

        private UserManager<ApplicationUser> _userManager;

        public UnitOfWork(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IGenericRepository<Attendees> Attendees
            => _Attendee ??= new GenericRepository<Attendees>(_context);
        public IGenericRepository<Category> Category
            => _Category ??= new GenericRepository<Category>(_context);
        public IGenericRepository<EventPost> EventPost
            => _EventPost ??= new GenericRepository<EventPost>(_context);
        public IGenericRepository<Events> Events
            => _Events ??= new GenericRepository<Events>(_context);
        public IGenericRepository<FeedBack> FeedBack
            => _FeedBack ??= new GenericRepository<FeedBack>(_context);
        public IGenericRepository<Registration> Registration
            => _Registration ??= new GenericRepository<Registration>(_context);
        public IGenericRepository<Students> Students
            => _Students ??= new GenericRepository<Students>(_context);
        public IGenericRepository<Teachers> Teachers
            => _Teachers ??= new GenericRepository<Teachers>(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save(HttpContext httpContext)
        {

            await _context.SaveChangesAsync();
        }
    }
}
