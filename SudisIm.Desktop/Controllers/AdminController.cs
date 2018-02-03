using SudisIm.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SudisIm.Desktop.Controllers
{
    class AdminController
    {
        public void OpenAddRefereeForm()
        {
            AddReferee addReferee = new AddReferee();
            addReferee.Show();
            addReferee.Focus();
        }

        public void OpenAddGameForm()
        {
            AddGame addGame = new AddGame();
            addGame.Focus();
            addGame.Show();
        }

        public void OpenEditAdminAccountForm()
        {
            EditAdminAccountWindow editAdminAccountWindow = new EditAdminAccountWindow();
            editAdminAccountWindow.Show();
        }

        internal void LoadReferees(DataGrid suciDataGrid)
        {
            Referee referee = new Referee();
            referee.FirstName = "Alen";
            referee.LastName = "Dostal";
            referee.Address = "Zarilac 26";
            referee.Description = "dobar opis";
            referee.City = new City { Name = "Pleternica"};
            referee.Licence = new Licence { Name="Licenca_1"};

            suciDataGrid.Items.Add(referee);

            Referee referee2 = new Referee();
            referee2.FirstName = "PAlen";
            referee2.LastName = "PDostal";
            referee2.Address = "PZarilac 26";
            referee2.Description = "xxxdobar opis";
            referee2.City = new City { Name = "sssss" };
            referee2.Licence = new Licence { Name = "Licenca_12" };

            suciDataGrid.Items.Add(referee2);

        }
    }
}
