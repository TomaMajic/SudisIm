﻿using SudisIm.DAL.NHibernate;
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
        private AddGame addGame;

        public AdminController()
            : this(NHibernateHelper.Instance.OpenSession())
        { }

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
            AddReferee addReferee = new AddReferee();
            List<City> cities = _cityRepository.GetCities().ToList();
            foreach (City city in cities)
            {
                addReferee.CityComboBox.Items.Add(new ComboBoxItem { Content = city.Name, Tag = city.Id });
            }
            addReferee.CityComboBox.SelectedIndex = 0;

            List<Licence> licences = _licenceRepository.GetLicences().ToList();
            foreach (Licence licence in licences)
            {
                addReferee.LicenceComboBox.Items.Add(new ComboBoxItem { Content = licence.Name + " prioritet: " + licence.Priority, Tag = licence.Id });
            }
            addReferee.LicenceComboBox.SelectedIndex = 0;

            addReferee.Show();
        }

        public void OpenAddGameForm()
        {
            addGame = new AddGame(this);

            List<City> cities = _cityRepository.GetCities().ToList();
            foreach (City city in cities)
            {
                addGame.CityComboBox.Items.Add(new ComboBoxItem { Content = city.Name, Tag = city.Id });
            }
            addGame.CityComboBox.SelectedIndex = 0;

            List<Team> teams = _teamRepository.GetTeams().ToList();
            foreach (Team team in teams)
            {
                addGame.HomeTeamComboBox.Items.Add(new ComboBoxItem { Content = team.Name, Tag = team.Id });
                addGame.AwayTeamComboBox.Items.Add(new ComboBoxItem { Content = team.Name, Tag = team.Id });
            }
            addGame.HomeTeamComboBox.SelectedIndex = 0;
            addGame.AwayTeamComboBox.SelectedIndex = 0;

            List<Licence> licences = _licenceRepository.GetLicences().ToList();
            foreach (Licence licence in licences)
            {
                addGame.LicenceComboBox.Items.Add(new ComboBoxItem { Content = licence.Name + " prioritet: " + licence.Priority, Tag = licence.Id });
            }
            addGame.LicenceComboBox.SelectedIndex = 0;

            List<Referee> referees = _refereeRepository.GetReferees().ToList();
            foreach (Referee referee in referees)
            {
                addGame.RefereeComboBox.Items.Add(new ComboBoxItem { Content = referee.FirstName + " " + referee.LastName, Tag = referee.Id });
            }
            addGame.RefereeComboBox.SelectedIndex = 0;

            addGame.DatePicker.SelectedDate = DateTime.Now;

            addGame.Show();
        }

        public void AddGame()
        {
            Game game = new Game();

            var homeSelector = (ComboBoxItem)addGame.HomeTeamComboBox.SelectedItem;
            Team homeTeam = _teamRepository.GetTeamById((long)homeSelector.Tag);
            game.HomeTeam = homeTeam;

            var awaySelector = (ComboBoxItem)addGame.AwayTeamComboBox.SelectedItem;
            Team awayTeam = _teamRepository.GetTeamById((long)awaySelector.Tag);
            game.AwayTeam = awayTeam;

            var citySelector = (ComboBoxItem)addGame.CityComboBox.SelectedItem;
            City city = _cityRepository.GetCityById((long)citySelector.Tag);
            game.City = city;

            var refereeSelector = (ComboBoxItem)addGame.RefereeComboBox.SelectedItem;
            Referee referee = _refereeRepository.GetRefereeById((long)refereeSelector.Tag);
            List<Referee> referees = new List<Referee>();
            referees.Add(referee);
            game.Referees = referees;

            game.Address = addGame.AddressTextBox.Text;
            var a = addGame.DatePicker.Text;
            game.StartTime = addGame.DatePicker.SelectedDate.Value;

            _gameRepository.AddGame(game);
        }

        public void OpenEditAdminAccountForm()
        {
            EditAdminAccountWindow editAdminAccountWindow = new EditAdminAccountWindow();
            editAdminAccountWindow.Show();
        }

        internal void LoadReferees(DataGrid suciDataGrid)
        {
            List<Referee> referees = _refereeRepository.GetReferees().ToList();
            foreach (Referee referee in referees)
            {
                suciDataGrid.Items.Add(referee);
            }

        }

        internal void LoadGames(DataGrid gamesDataGrid)
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
                gamesDataGrid.Items.Add(gameViewModel);
            }
        }
    }
}
