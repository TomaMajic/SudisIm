using SudisIm.DAL.Repositories;
using SudisIm.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SudisIm.Desktop
{
    /// <summary>
    /// Interaction logic for AddReferee.xaml
    /// </summary>
    public partial class AddReferee : Window
    {
        private RefereeRepository refereeRepository;

        public AddReferee()
        {
            InitializeComponent();
            refereeRepository = new RefereeRepository();

        }

        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            Referee referee = new Referee();

            referee.FirstName = this.FirstNameTextBox.Text;
            referee.LastName = this.LastNameTextBox.Text;
            referee.Address = this.AddressTextBox.Text;
            referee.Description = this.DescriptionTextBox.Text;

            // popravit
            City city = new City();
            city.Name = "Zarilac";
            referee.City = city;

            Licence licence = new Licence();
            licence.Name = "najbolja licenca";
            licence.Priority = 1;
            referee.Licence = licence;

            refereeRepository.AddReferee(referee);

            this.Close();
        }
    }
}
