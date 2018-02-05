using NHibernate;
using SudisIm.DAL.NHibernate;
using SudisIm.DAL.Repositories;
using SudisIm.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SudisIm.Desktop.Controllers
{
    public class RefereeController
    {
        private RefereeWindow _refereeWindow;
        private AbsenceRepository _absenceRepository;
        private GameRepository _gameRepository;
        private Referee _myRefereeAccount;
        private AddAbsenceWindow _addAbsenceWindow;
        private EditRefereeWindow _editRefereeWindow;
        private CityRepository _cityRepository;
        public RefereeController(RefereeWindow refereeWindow, Referee myRefereeAccount)
            : this(NHibernateHelper.Instance.OpenSession())
        {
            _refereeWindow = refereeWindow;
            _myRefereeAccount = myRefereeAccount;
        }

        public RefereeController(ISession session)
            : this(new AbsenceRepository(session), new GameRepository(session), new CityRepository(session))
        { }

        public RefereeController(AbsenceRepository abscenceRepository, GameRepository gameRepository, CityRepository cityRepository)
        {
            _absenceRepository = abscenceRepository;
            _gameRepository = gameRepository;
            _cityRepository = cityRepository;
        }

        public void LoadExcuses()
        {
            List<Absence> absences = _absenceRepository.GetAbsencesForReferee(1).ToList();
            foreach (Absence absence in absences)
            {
                _refereeWindow.absenceDataGrid.Items.Add(absence);
            }
        }

        internal List<DateTime> GetAbsenceDates()
        {
            List<DateTime> absenceDates = new List<DateTime>();

            List<Absence> absences = _absenceRepository.GetAbsencesForReferee(_myRefereeAccount.Id).ToList();
            foreach (Absence absence in absences)
            {
                absenceDates.Add(absence.StartDate);
            }

            return absenceDates;
        }

        internal List<DateTime> GetGameDates()
        {
            List<DateTime> gameDates = new List<DateTime>();

            List<Game> games = _gameRepository.GetGamesForReferee(_myRefereeAccount.Id).ToList();
            foreach (Game game in games)
            {
                gameDates.Add(game.StartTime);
            }

            return gameDates;
        }

        internal void OpenAddAbsenceWindow()
        {
            _addAbsenceWindow = new AddAbsenceWindow(this);
            _addAbsenceWindow.Top = _refereeWindow.Top;
            _addAbsenceWindow.Left = _refereeWindow.Left;
            _addAbsenceWindow.Show();
        }

        internal void AddAbsence()
        {
            Absence absence = new Absence();
            absence.StartDate = _addAbsenceWindow.DatePicker.SelectedDate.Value;
            absence.Excuse = _addAbsenceWindow.Excuse.Text;
            absence.Referee = _myRefereeAccount;
            _absenceRepository.AddAbsence(absence);
            _addAbsenceWindow.Close();
            ReloadListOfAdsence();
        }

        private void ReloadListOfAdsence()
        {
            _refereeWindow.absenceDataGrid.Items.Clear();
            LoadExcuses();
        }

        internal void OpenEditRefereeWindow()
        {
            _editRefereeWindow = new EditRefereeWindow();

            List<City> cities = _cityRepository.GetCities().ToList();
            foreach (City city in cities)
            {
                _editRefereeWindow.CityComboBox.Items.Add(new ComboBoxItem { Content = city.Name, Tag = city.Id });
            }
            _editRefereeWindow.CityComboBox.SelectedIndex = 0;

            _editRefereeWindow.FirstNameTextBox.Text = _myRefereeAccount.FirstName;
            _editRefereeWindow.LastNameTextBox.Text = _myRefereeAccount.LastName;
            _editRefereeWindow.DescriptionTextBox.Text = _myRefereeAccount.Description;
            _editRefereeWindow.AddressTextBox.Text = _myRefereeAccount.Address;
            _editRefereeWindow.ContactTextBox.Text = _myRefereeAccount.Contact;

            _editRefereeWindow.Top = _refereeWindow.Top;
            _editRefereeWindow.Left = _refereeWindow.Left;
            _editRefereeWindow.Show();
        }
    }
}
