using SudisIm.Desktop.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
        private List<DateTime> gameDates;
        public AdminWindow()
        {
            InitializeComponent();
            adminController = new AdminController(this);
            adminController.LoadReferees();
            adminController.LoadGames();

            // testiranje datuma
            gameDates = adminController.GetGamesDates();

            adminCalendar.IsTodayHighlighted = false;


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


        // kalendar
        private void calendarButton_Loaded(object sender, EventArgs e)
        {
            CalendarDayButton button = (CalendarDayButton)sender;
            DateTime date = (DateTime)button.DataContext;
            HighlightDay(button, date);
            button.DataContextChanged += new DependencyPropertyChangedEventHandler(calendarButton_DataContextChanged);
        }

        private void HighlightDay(CalendarDayButton button, DateTime date)
        {
            if (gameDates.Contains(date))
            {
                button.Background = Brushes.PaleVioletRed;
            }
            else
            {
                button.Background = Brushes.White;
            }
        }

        private void calendarButton_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            CalendarDayButton button = (CalendarDayButton)sender;
            DateTime date = (DateTime)button.DataContext;
            HighlightDay(button, date);
        }
    }
}
