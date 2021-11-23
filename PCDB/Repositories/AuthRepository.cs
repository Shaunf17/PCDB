using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PCDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace PCDB.Repositories
{
    public class AuthRepository : IDisposable
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public AuthRepository()
        {
            _context = new ApplicationDbContext();
            _userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>());
        }

        public async Task<IdentityUser> FindUserAsync(string username, string password)
        {
            return await _userManager.FindAsync(username, password);
        }

        public IdentityUser FindUser(string username, string password)
        {
            return _userManager.Find(username, password);
        }


        public ApplicationUser ValidateUser(string username, string password)
        {
            throw new NotImplementedException();
        }

        public List<string> GetRoles(string username)
        {
            var user = _userManager.FindByName(username);
            return _userManager.GetRoles(user.Id).ToList();
        }

        private bool disposed = false;
        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                disposed = true;
            }
        }
    }
}