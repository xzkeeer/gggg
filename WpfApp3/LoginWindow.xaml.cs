using Microsoft.EntityFrameworkCore;
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
using WpfApp3.Models;

namespace WpfApp3
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginBox.Text;
            string password = PasswordBox.Password;

            using (var context = new TestContext())
            {
                var user = context.Users
                    .Include(u => u.RoleUsers)
                    .FirstOrDefault(u => u.Password == password && u.Login == login);
                var RoleUsers = user.RoleUsers.Name;
                var mainwindow = new MainWindow(RoleUsers);
                mainwindow.Show();
                this.Close();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var mainwindow = new MainWindow("Авторизованный клиент");
            mainwindow.Show();
            this.Close();
        }
    }
}
