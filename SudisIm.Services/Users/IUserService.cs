using SudisIm.Model.Models;

namespace SudisIm.Services.Users
{
    public interface IUserService
    {
        Referee GetRefereeByUser(string username, string password);
    }
}
