using System.Collections.Generic;
using SudisIm.Model.Models;

namespace SudisIm.Model.Repositories
{
    public interface IAbsenceRepository
    {
        Absence GetAbsenceById(long absenceId);
        ICollection<Absence> GetAbsences();
        ICollection<Absence> GetAbsencesForReferee(long refereeId);
        Absence AddAbsence(Absence absence);
    }
}
