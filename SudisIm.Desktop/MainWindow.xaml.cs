using SudisIm.DAL.NHibernate;
using System.Windows;
using SudisIm.Services.Users;

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

        private void Login_Button_Click(object sender, RoutedEventArgs e)
        {
            if (UserService.HasClaim(emailTextBox.Text, passwordTextBox.Password, "admin"))
            {
                AdminWindow adminWindow = new AdminWindow();
                adminWindow.Top = this.Top;
                adminWindow.Left = this.Left;
                App.Current.MainWindow = adminWindow;
                shutDownApplication = false;
                this.Close();
                adminWindow.Show();
            }

            if (UserService.HasClaim(emailTextBox.Text, passwordTextBox.Password, "referee"))
            {
                UserService userService = new UserService(NHibernateHelper.Instance.OpenSession());
                RefereeWindow refereeWindow = new RefereeWindow(userService.GetRefereeByUser(emailTextBox.Text, passwordTextBox.Password));
                refereeWindow.Top = this.Top;
                refereeWindow.Left = this.Left;
                App.Current.MainWindow = refereeWindow;
                this.shutDownApplication = false;
                this.Close();
                refereeWindow.Show();
            }
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
