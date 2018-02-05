using SudisIm.DAL.NHibernate;
using SudisIm.DAL.Repositories;
using SudisIm.Desktop.ViewModels;
using SudisIm.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using NHibernate;

namespace SudisIm.Desktop.Controllers
{
    public class AdminController
    {
        private CityRepository _cityRepository;
        private TeamRepository _teamRepository;
        private LicenceRepository _licenceRepository;
        private RefereeRepository _refereeRepository;
        private GameRepository _gameRepository;
        private AdminWindow _adminWindow;
        private AddGame _addGame;
        private AddReferee _addReferee;
        private int _numberOfReferee = 1;
        private int _numberOfAddedReferees = 0;
        private List<Referee> _selectedReferees = new List<Referee>();

        public AdminController(AdminWindow adminWindow)
            : this(NHibernateHelper.Instance.OpenSession())
        { _adminWindow = adminWindow; }

        public AdminController(ISession session)
            : this(new CityRepository(session), new TeamRepository(session), new LicenceRepository(session), new RefereeRepository(session), new GameRepository(session))
        { }

        public AdminController(CityRepository cityRepository, TeamRepository teamRepository, LicenceRepository licenceRepository, RefereeRepository refereeRepository, GameRepository gameRepository)
        {
            _cityRepository = cityRepository;
            _teamRepository = teamRepository;
            _licenceRepository = licenceRepository;
            _refereeRepository = refereeRepository;
            _gameRepository = gameRepository;
        }

        internal void RemoveRefereeFromList()
        {
            _addGame.RefereeListBox.Items.Remove(_addGame.RefereeListBox.SelectedItem);
            _numberOfAddedReferees = _addGame.RefereeListBox.Items.Count;
            _addGame.RefereeComboBox.IsEnabled = true;
        }

        internal void AddSelectedReferee()
        {
            ComboBoxItem refereeSelector = (ComboBoxItem)_addGame.RefereeComboBox.SelectedItem;
            if (refereeSelector != null && _numberOfAddedReferees < _numberOfReferee)
            {
                Referee referee = _refereeRepository.GetRefereeById((long)refereeSelector.Tag);
                bool addItem = true;
                foreach(ListBoxItem item in _addGame.RefereeListBox.Items)
                {
                    if (item.Content.ToString() == referee.FirstName + " " + referee.LastName)
                    {
                        addItem = false;
                        break;
                    }
                }
                if(addItem == true)
                {
                    _addGame.RefereeListBox.Items.Add(new ListBoxItem { Content = referee.FirstName + " " + referee.LastName, Tag = referee.Id });
                    _selectedReferees.Add(referee);
                    _numberOfAddedReferees = _addGame.RefereeListBox.Items.Count;
                }

                if (_numberOfAddedReferees >= _numberOfReferee)
                {
                    _addGame.RefereeComboBox.IsEnabled = false;
                }
                else
                {
                    _addGame.RefereeComboBox.IsEnabled = true;
                }
            }
        }

        internal void NumberOfRefereeChanged(int numberOfReferee)
        {
            _numberOfReferee = numberOfReferee;

            if (_addGame != null)
            {
                if (_numberOfAddedReferees == _numberOfReferee)
                {
                    _addGame.RefereeComboBox.IsEnabled = false;
                }
                if (_numberOfAddedReferees > _numberOfReferee)
                {
                    _addGame.RefereeComboBox.IsEnabled = false;

                    _addGame.RefereeListBox.Items.RemoveAt(_addGame.RefereeListBox.Items.Count - 1);
                    _numberOfAddedReferees = _addGame.RefereeListBox.Items.Count;
                }
                else
                {
                    _addGame.RefereeComboBox.IsEnabled = true;
                }
            }
        }

        public void OpenAddRefereeForm()
        {
            _addReferee = new AddReferee(this);
            List<City> cities = _cityRepository.GetCities().ToList();
            foreach (City city in cities)
            {
                _addReferee.CityComboBox.Items.Add(new ComboBoxItem { Content = city.Name, Tag = city.Id });
            }
            _addReferee.CityComboBox.SelectedIndex = 0;

            List<Licence> licences = _licenceRepository.GetLicences().ToList();
            foreach (Licence licence in licences)
            {
                _addReferee.LicenceComboBox.Items.Add(new ComboBoxItem { Content = licence.Name + " prioritet: " + licence.Priority, Tag = licence.Id });
            }
            _addReferee.LicenceComboBox.SelectedIndex = 0;

            _addReferee.Show();
        }

        public void AddReferee()
        {
            Referee referee = new Referee();

            referee.FirstName = _addReferee.FirstNameTextBox.Text;
            referee.LastName = _addReferee.LastNameTextBox.Text;
            referee.Address = _addReferee.AddressTextBox.Text;
            referee.Description = _addReferee.DescriptionTextBox.Text;
            referee.Contact = _addReferee.ContactTextBox.Text;

            ComboBoxItem selectedCity = (ComboBoxItem)_addReferee.CityComboBox.SelectedItem;
            City city = _cityRepository.GetCityById((long)selectedCity.Tag);
            referee.City = city;

            ComboBoxItem selectedLicence = (ComboBoxItem)_addReferee.LicenceComboBox.SelectedItem;
            Licence licence = _licenceRepository.GetLicenceById((long)selectedLicence.Tag);
            referee.Licence = licence;

            _refereeRepository.AddReferee(referee);

            _addReferee.Close();
            ReloadListOfReferees();
        }

        private void ReloadListOfReferees()
        {
            _adminWindow.refereeDataGrid.Items.Clear();
            LoadReferees();
        }

        public void OpenAddGameForm()
        {
            _addGame = new AddGame(this);

            List<City> cities = _cityRepository.GetCities().ToList();
            foreach (City city in cities)
            {
                _addGame.CityComboBox.Items.Add(new ComboBoxItem { Content = city.Name, Tag = city.Id });
            }
            _addGame.CityComboBox.SelectedIndex = 0;

            List<Team> teams = _teamRepository.GetTeams().ToList();
            foreach (Team team in teams)
            {
                _addGame.HomeTeamComboBox.Items.Add(new ComboBoxItem { Content = team.Name, Tag = team.Id });
                _addGame.AwayTeamComboBox.Items.Add(new ComboBoxItem { Content = team.Name, Tag = team.Id });
            }
            _addGame.HomeTeamComboBox.SelectedIndex = 0;
            _addGame.AwayTeamComboBox.SelectedIndex = 0;

            List<Licence> licences = _licenceRepository.GetLicences().ToList();
            foreach (Licence licence in licences)
            {
                _addGame.LicenceComboBox.Items.Add(new ComboBoxItem { Content = licence.Name + " prioritet: " + licence.Priority, Tag = licence.Id });
            }
            _addGame.LicenceComboBox.SelectedIndex = 0;

            List<Referee> referees = _refereeRepository.GetReferees().ToList();
            foreach (Referee referee in referees)
            {
                _addGame.RefereeComboBox.Items.Add(new ComboBoxItem { Content = referee.FirstName + " " + referee.LastName, Tag = referee.Id });
            }

            _addGame.DatePicker.SelectedDate = DateTime.Now;

            _addGame.Show();
        }

        public void AddGame()
        {
            Game game = new Game();

            var homeSelector = (ComboBoxItem)_addGame.HomeTeamComboBox.SelectedItem;
            Team homeTeam = _teamRepository.GetTeamById((long)homeSelector.Tag);
            game.HomeTeam = homeTeam;

            var awaySelector = (ComboBoxItem)_addGame.AwayTeamComboBox.SelectedItem;
            Team awayTeam = _teamRepository.GetTeamById((long)awaySelector.Tag);
            game.AwayTeam = awayTeam;

            var citySelector = (ComboBoxItem)_addGame.CityComboBox.SelectedItem;
            City city = _cityRepository.GetCityById((long)citySelector.Tag);
            game.City = city;

            List<Referee> referees = new List<Referee>();
            foreach(ListBoxItem item in _addGame.RefereeListBox.Items)
            {
                referees.Add(_refereeRepository.GetRefereeById((long)item.Tag));
            }            
            game.Referees = referees;
            game.NoOfReferees = (int)_addGame.numberOfReferee.Value.Value;

            var licenceSelector = (ComboBoxItem)_addGame.LicenceComboBox.SelectedItem;
            Licence licence = _licenceRepository.GetLicenceById((long)licenceSelector.Tag);
            game.MinimalLicence = licence;

            game.Address = _addGame.AddressTextBox.Text;
            game.StartTime = _addGame.DatePicker.SelectedDate.Value;

            _gameRepository.AddGame(game);

            _addGame.Close();
            ReloadListOfGames();
        }

        private void ReloadListOfGames()
        {
            _adminWindow.gameDataGrid.Items.Clear();
            LoadGames();
        }

        public void OpenEditAdminAccountForm()
        {
            EditAdminAccountWindow editAdminAccountWindow = new EditAdminAccountWindow();
            editAdminAccountWindow.Show();
        }

        internal void LoadReferees()
        {
            List<Referee> referees = _refereeRepository.GetReferees().ToList();
            foreach (Referee referee in referees)
            {
                _adminWindow.refereeDataGrid.Items.Add(referee);
            }

        }

        internal void LoadGames()
        {
            List<Game> games = _gameRepository.GetGames().ToList();
            foreach (Game game in games)
            {
                GameViewModel gameViewModel = new GameViewModel();
                gameViewModel.HomeTeam = game.HomeTeam.Name;
                gameViewModel.AwayTeam = game.AwayTeam.Name;
                gameViewModel.Address = game.Address;
                gameViewModel.City = game.City.Name;
                gameViewModel.StartTime = game.GetFormatedStartTime();
                gameViewModel.Licence = game.MinimalLicence.Name;
                gameViewModel.Referees = game.Referees.Count().ToString() + " / " + game.NoOfReferees;
                _adminWindow.gameDataGrid.Items.Add(gameViewModel);
            }
        }

        public List<DateTime> GetGameDates()
        {
            List<DateTime> gameDates = new List<DateTime>();

            List<Game> games = _gameRepository.GetGames().ToList();
            foreach (Game game in games)
            {
                gameDates.Add(game.StartTime);
            }

            return gameDates;
        }
    }
}
