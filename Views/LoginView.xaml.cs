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
            txtUser.Focus();
            loginViewModel = new LoginViewModel();
            DataContext = loginViewModel;

            txtUser.KeyDown += TxtUser_KeyDown;
            txtPass.KeyDown += TxtPass_KeyDown;
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

        private void TxtUser_KeyDown(object sender, KeyEventArgs e)
        {
            // Se a tecla pressionada for Enter, chama o método de login
            if (e.Key == Key.Enter)
            {
                TryLogin();
            }
        }

        private void TxtPass_KeyDown(object sender, KeyEventArgs e)
        {
            // Se a tecla pressionada for Enter, chama o método de login
            if (e.Key == Key.Enter)
            {
                TryLogin();
            }
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            TryLogin();
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

        private void TryLogin()
        {
            btnLogin.Background = new System.Windows.Media.SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#5FB2E2"));
            if (txtUser.Text == "" || txtPass.Password == "")
            {
                MessageBox.Show("Preencha todos os campos.");
                txtUser.Focus();
            }
            else if (!loginViewModel.Authenticate(txtUser.Text, txtPass.Password))
            {
                MessageBox.Show("Credenciais inválidas. Tente novamente.");
                txtUser.Text = "";
                txtPass.Password = "";
                txtUser.Focus();
            }
            else
            {
                MainWindow mainWindow = new MainWindow(txtUser.Text);
                mainWindow.Show();

                this.Close();
            }
            btnLogin.Background = new System.Windows.Media.SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#93B1C3"));
        }

    }
}
