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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SudisIm.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool shutDownApplication = true;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // ako je registrirani korisnik administrator
            AdminWindow adminWindow = new AdminWindow();
            adminWindow.Top = this.Top;
            adminWindow.Left = this.Left;
            App.Current.MainWindow = adminWindow;
            shutDownApplication = false;
            this.Close();
            adminWindow.Show();

            //// ako je registrirani korisnik sudac
            //RefereeWindow refereeWindow = new RefereeWindow();
            //refereeWindow.Top = this.Top;
            //refereeWindow.Left = this.Left;
            //App.Current.MainWindow = refereeWindow;
            //this.shutDownApplication = false;
            //this.Close();
            //refereeWindow.Show();

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (shutDownApplication == true)
            {
                Application.Current.Shutdown();
            }
        }
    }
}
