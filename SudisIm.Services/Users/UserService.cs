using System;
using System.Linq;
using Microsoft.AspNet.Identity;
using NHibernate;
using SudisIm.DAL.NHibernate;
using SudisIm.DAL.Repositories;
using SudisIm.Model.Models;
using SudisIm.Model.Repositories;

namespace SudisIm.Services.Users
{
    public class UserService : IUserService
    {
        private readonly ISession session;
        private readonly IRefereeRepository refereeRepository;
        public UserService(ISession session)
            :this(new RefereeRepository(session))
        {}

        public UserService(IRefereeRepository refereeRepository)
        {
            this.refereeRepository = refereeRepository;
        }

        public static bool HasClaim(string username,string password, string claimValue)
        {
            var user = UserManagerExtensions.Find(NHibernateHelper.userManager, username, password);
            return user.Claims.Select(c => c.ClaimValue).Contains(claimValue);
        }

        public Referee GetRefereeByUser(string username, string password)
        {
            var user = NHibernateHelper.userManager.Find(username, password);
            if (user == null)
                throw new Exception("Wrong username or password");

            var referee = this.refereeRepository.GetReferees().FirstOrDefault(r => r.User.Id == user.Id);

            if(referee == null)
                throw new Exception("User does not have defined referee");

            return referee;
        }
    }
}
