using System.Collections.Generic;
using SudisIm.Model.Models;

namespace SudisIm.Model.Repositories
{
    public interface ITeamRepository
    {
        ICollection<Team> GetTeams();
        Team AddTeam(Team team);
    }
}
