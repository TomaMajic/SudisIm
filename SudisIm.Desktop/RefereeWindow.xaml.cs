using SudisIm.Desktop.Controllers;
using SudisIm.Model.Models;
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
    /// Interaction logic for RefereeWindow.xaml
    /// </summary>
    public partial class RefereeWindow : Window
    {
        private bool shutDownApplication = true;
        private List<DateTime> absenceDates;
        private List<DateTime> gameDates;
        private Referee _myRefereeAccount;
        public RefereeWindow(Referee myRefereeAccount)
        {
            InitializeComponent();
            _myRefereeAccount = myRefereeAccount;
            RefereeController refereeController = new RefereeController(this);
            absenceDates = refereeController.GetAbsenceDates();
            gameDates = refereeController.GetGameDates();
            refereeController.LoadExcuses();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (shutDownApplication == true)
            {
                Application.Current.Shutdown();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Top = this.Top;
            mainWindow.Left = this.Left;
            App.Current.MainWindow = mainWindow;
            this.shutDownApplication = false;
            this.Close();
            mainWindow.Show();
        }


        //kalendar
        private void calendarButton_Loaded(object sender, EventArgs e)
        {
            CalendarDayButton button = (CalendarDayButton)sender;
            DateTime date = (DateTime)button.DataContext;
            HighlightDay(button, date);
            button.DataContextChanged += new DependencyPropertyChangedEventHandler(calendarButton_DataContextChanged);
        }

        private void HighlightDay(CalendarDayButton button, DateTime date)
        {
            if (absenceDates.Contains(date))
            {
                button.Background = Brushes.PaleVioletRed;
            }
            else if (gameDates.Contains(date))
            {
                button.Background = Brushes.LightBlue;
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

        private void AddAbsence_Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
