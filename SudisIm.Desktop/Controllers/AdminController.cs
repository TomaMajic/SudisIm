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
    public class AdminController
    {
        private CityRepository _cityRepository;
        private TeamRepository _teamRepository;
        private LicenceRepository _licenceRepository;
        private RefereeRepository _refereeRepository;
        private GameRepository _gameRepository;
        private AddGame addGame; 
        public AdminController()
            : this(new CityRepository(), new TeamRepository(), new LicenceRepository(),new RefereeRepository(),new GameRepository())
        { }

        public AdminController(CityRepository cityRepository, TeamRepository teamRepository, LicenceRepository licenceRepository,RefereeRepository refereeRepository,GameRepository gameRepository)
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
            addReferee.Show();
            addReferee.Focus();
        }

        public void OpenAddGameForm()
        {
            addGame = new AddGame(this);

            List<City> cities = _cityRepository.GetCities().ToList();
            foreach (City city in cities)
            {
                addGame.CityComboBox.Items.Add(new ComboBoxItem { Content = city.Name, Tag = city.Id });
            }

            List<Team> teams = _teamRepository.GetTeams().ToList();
            foreach (Team team in teams)
            {
                addGame.HomeTeamComboBox.Items.Add(new ComboBoxItem { Content = team.Name, Tag = team.Id });
                addGame.AwayTeamComboBox.Items.Add(new ComboBoxItem { Content = team.Name, Tag = team.Id });
            }

            List<Licence> licences = _licenceRepository.GetLicences().ToList();
            foreach (Licence licence in licences)
            {
                addGame.LicenceComboBox.Items.Add(new ComboBoxItem { Content = licence.Name + " prioritet: " + licence.Priority, Tag = licence.Id });
            }

            List<Referee> referees = _refereeRepository.GetReferees().ToList();
            foreach(Referee referee in referees)
            {
                addGame.RefereeComboBox.Items.Add(new ComboBoxItem { Content = referee.FirstName + " " + referee.LastName, Tag = referee.Id });
            }

            addGame.Show();
        }

        public void AddGame()
        {
            Game game = new Game();
            //Team team = _teamRepository.get
            game.Address = addGame.AddressTextBox.Text;
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
    }
}
