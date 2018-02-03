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
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        private bool shutDownApplication = true;
        private AdminController adminController; 
        public AdminWindow()
        {
            adminController = new AdminController();
            InitializeComponent();
            adminController.LoadReferees(this.suciDataGrid);
            adminController.LoadGames(this.gameDataGrid);

            // testiranje datuma
            adminCalendar.SelectedDate = DateTime.Parse("2.2.2018.");
        }

        private void Add_Referee_Button_Click(object sender, RoutedEventArgs e)
        {
            adminController.OpenAddRefereeForm();
        }

        private void Add_Game_Button_Click(object sender, RoutedEventArgs e)
        {
            adminController.OpenAddGameForm();
        }

        private void Edit_Admin_Account_Button_Click(object sender, RoutedEventArgs e)
        {
            adminController.OpenEditAdminAccountForm();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(shutDownApplication == true)
            {
                Application.Current.Shutdown();
            }
        }

        private void Logout_Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Top = this.Top;
            mainWindow.Left = this.Left;
            App.Current.MainWindow = mainWindow;
            shutDownApplication = false;
            this.Close();
            mainWindow.Show();
        }
    }
}
