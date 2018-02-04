using System.Linq;
using Microsoft.AspNet.Identity;
using SudisIm.DAL.NHibernate;

namespace SudisIm.Services.Users
{
    public class UserService : IUserService
    {
        public static bool HasClaim(string username,string password, string claimValue)
        {
            var user = UserManagerExtensions.Find(NHibernateHelper.userManager, username, password);
            return user.Claims.Select(c => c.ClaimValue).Contains(claimValue);
        }
    }
}
