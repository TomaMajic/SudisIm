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
        public AdminWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // otvori formu za dodavanje novog sudca
            AddReferee addReferee = new AddReferee();
            addReferee.Show();
            addReferee.Focus();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AddGame addGame = new AddGame();
            addGame.Focus();
            addGame.Show();
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
