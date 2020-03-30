using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oficios.Models;

namespace Oficios.Data
{
    public interface IUserRepository
    {
        Task<User> Add(User user);
        Task<bool> Delete (User user);
        Task<bool> SaveChangesAsync ();
        Task<IEnumerable<User>> GetUsersAsync(bool worker = true);
        Task<User> GetUserAsync(int userId);

    }
}
