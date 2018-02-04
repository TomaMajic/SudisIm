using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SudisIm.Model.Models;

namespace SudisIm.Models.Games
{
    public class GameCreateViewModel
    {
        public Game Game { get; set; }
        public IEnumerable<City> Cities { get; set; }
        public IEnumerable<Referee> Referees { get; set; }
        public IEnumerable<Licence> Licences { get; set; }
        public IEnumerable<Team> Teams { get; set; }
    }
}