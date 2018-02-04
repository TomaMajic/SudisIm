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
        public void OpenAddRefereeForm()
        {
            AddReferee _addReferee = new AddReferee();
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
            _addGame.RefereeComboBox.SelectedIndex = 0;

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

            var refereeSelector = (ComboBoxItem)_addGame.RefereeComboBox.SelectedItem;
            Referee referee = _refereeRepository.GetRefereeById((long)refereeSelector.Tag);
            List<Referee> referees = new List<Referee>();
            referees.Add(referee);
            game.Referees = referees;

            game.Address = _addGame.AddressTextBox.Text;
            var a = _addGame.DatePicker.Text;
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
                _adminWindow.suciDataGrid.Items.Add(referee);
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
                //gameViewModel.Licence = game.licence;
                gameViewModel.Referees = game.Referees.Count().ToString() + "/Max";
                _adminWindow.gameDataGrid.Items.Add(gameViewModel);
            }
        }
    }
}
