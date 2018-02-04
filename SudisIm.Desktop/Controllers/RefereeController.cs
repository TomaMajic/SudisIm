using NHibernate;
using SudisIm.DAL.NHibernate;
using SudisIm.DAL.Repositories;
using SudisIm.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudisIm.Desktop.Controllers
{
    public class RefereeController
    {
        private RefereeWindow _refereeWindow;
        private AbsenceRepository _absenceRepository;
        private GameRepository _gameRepository;
        public RefereeController(RefereeWindow refereeWindow)
            : this(NHibernateHelper.Instance.OpenSession())
        {
            _refereeWindow = refereeWindow;
        }

        public RefereeController(ISession session)
            : this(new AbsenceRepository(session), new GameRepository(session))
        { }

        public RefereeController(AbsenceRepository abscenceRepository,GameRepository gameRepository)
        {
            _absenceRepository = abscenceRepository;
            _gameRepository = gameRepository;
        }

        public void LoadExcuses()
        {
            List<Absence> absences = _absenceRepository.GetAbsencesForReferee(1).ToList();
            _refereeWindow.absenceDataGrid.Items.Add(absences);
        }

        internal List<DateTime> GetAbsenceDates()
        {
            List<DateTime> absenceDates = new List<DateTime>();

            List<Absence> absences = _absenceRepository.GetAbsencesForReferee(1).ToList();
            foreach(Absence absence in absences)
            {
                absenceDates.Add(absence.Date);
            }

            return absenceDates;
        }

        internal List<DateTime> GetGameDates()
        {
            List<DateTime> gameDates = new List<DateTime>();

            //List<Game> games = _gameRepository.GetGameForReferee(1).ToList();
            //foreach (Game game in games)
            //{
            //    gameDates.Add(game.StartTime);
            //}

            return gameDates;
        }
    }
}
