using Microsoft.EntityFrameworkCore;
using Oficios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficios.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly OficioDbContext _oficioDbContext;

        public UserRepository(OficioDbContext oficioDbContext)
        {
            this._oficioDbContext = oficioDbContext;
        }
        public async Task<User> Add(User user)
        {
            _oficioDbContext.Add<User>(user);
            if (await SaveChangesAsync()) return user;
            else return null; 
        }

        public async Task<bool> Delete(User user)
        {
            _oficioDbContext.Remove<User>(user);
            return await SaveChangesAsync();
        }

        public async Task<User> GetUserAsync(int userId)
        {
            return await _oficioDbContext.Users
                .Where(user => user.UserId == userId)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<User>> GetUsersAsync(bool worker = true)
        {
            var rawQuery = "Select * from dbo.USERS";
            rawQuery += !worker ? " where discriminator = 'User'" : "";
            return await _oficioDbContext.Users.FromSqlRaw(rawQuery).ToArrayAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _oficioDbContext.SaveChangesAsync()) > 0;
        }
    }
}
