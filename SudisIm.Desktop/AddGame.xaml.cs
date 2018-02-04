using SudisIm.Desktop.Controllers;
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
    /// Interaction logic for AddGame.xaml
    /// </summary>
    public partial class AddGame : Window
    {
        private AdminController _adminController;
        public AddGame(AdminController adminController)
        {
            _adminController = adminController;
            InitializeComponent();
        }

        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Add_Game_Button_Click(object sender, RoutedEventArgs e)
        {
            _adminController.AddGame();
        }

        private void NumericUpDown_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            _adminController.NumberOfRefereeChanged((int)numberOfReferee.Value.Value);
        }

        private void RefereeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _adminController.AddSelectedReferee();
        }

        private void RefereeListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _adminController.RemoveRefereeFromList();
        }
    }
}
