using System.Linq;
using SudisIm.Model.Models;

namespace SudisIm.Model.Repositories
{
    public interface IRefereeRepository
    {
        Referee GetRefereeById(long refereeId);
        IQueryable<Referee> GetReferees();
        Referee AddReferee(Referee referee);
        Referee GetRefereeByUser(string username);
    }
}
