using System.Collections.Generic;
using SudisIm.Model.Models;

namespace SudisIm.Model.Repositories
{
    public interface ILicenceRepository
    {
        ICollection<Licence> GetLicences();
        Licence AddLicence(Licence licence);
    }
}
