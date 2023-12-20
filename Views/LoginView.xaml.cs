using StockSystem.ViewModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;

namespace StockSystem.View
{
    public partial class LoginView : Window
    {
        private LoginViewModel loginViewModel;

        public LoginView()
        {
            InitializeComponent();
            loginViewModel = new LoginViewModel();
            DataContext = loginViewModel;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (loginViewModel.Authenticate(txtUser.Text, txtPass.Password))
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();

                this.Close();
            }
            else
            {
                MessageBox.Show("Credenciais inválidas. Tente novamente.");
                txtPass.Password = "";
            }
        }

        // Hyperlinks
        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = e.Uri.AbsoluteUri,
                    UseShellExecute = true
                });
                e.Handled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao abrir o link: {ex.Message}", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}
