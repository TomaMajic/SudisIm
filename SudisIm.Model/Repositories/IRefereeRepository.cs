using System.Collections.Generic;
using SudisIm.Model.Models;

namespace SudisIm.Model.Repositories
{
    public interface IRefereeRepository
    {
        Referee GetRefereeById(long refereeId);
        ICollection<Referee> GetReferees();
        Referee AddReferee(Referee referee);
    }
}
