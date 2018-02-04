using SudisIm.Model.Models;

namespace SudisIm.Services.Users
{
    interface IUserService
    {
        Referee GetRefereeByUser(string username, string password);
    }
}
