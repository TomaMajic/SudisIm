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
    /// Interaction logic for AddAbsenceWindow.xaml
    /// </summary>
    public partial class AddAbsenceWindow : Window
    {
        private RefereeController _refereeController;
        public AddAbsenceWindow(RefereeController refereeController)
        {
            InitializeComponent();
            _refereeController = refereeController;

            DatePicker.SelectedDate = DateTime.Now;
        }

        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddAbsence_Button_Click(object sender, RoutedEventArgs e)
        {
            _refereeController.AddAbsence();
        }
    }
}
