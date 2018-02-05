using System.Collections.Generic;
using SudisIm.Model.Models;

namespace SudisIm.Model.Repositories
{
    public interface ITeamRepository
    {
        Team GetTeamById(long teamId);
        ICollection<Team> GetTeams();
        Team AddTeam(Team team);
    }
}
