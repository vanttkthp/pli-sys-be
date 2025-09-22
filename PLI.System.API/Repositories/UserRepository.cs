using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PLI.System.API.Data;
using PLI.System.API.Entities.Business;
using PLI.System.API.Entities.General;
using PLI.System.API.Interfaces.IRepositories;
using PLI.System.API.Interfaces.IServices;
using System;

namespace PLI.System.API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _db;

        public UserRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _db.Users.FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<User> AddAsync(User user)
        {
            _db.Users.Add(user);
            await _db.SaveChangesAsync();
            return user;
        }
    }
}