using System.Collections.Generic;
using SudisIm.Model.Models;

namespace SudisIm.Model.Repositories
{
    public interface ILicenceRepository
    {
        Licence GetLicenceById(long licenceId);
        ICollection<Licence> GetLicences();
        Licence AddLicence(Licence licence);
    }
}
