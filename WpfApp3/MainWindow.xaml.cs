using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Windows;
using WpfApp3.Models;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string _RoleUsers;
        public MainWindow(string RoleUsers)
        {
            InitializeComponent();
            _RoleUsers = RoleUsers;

            if (_RoleUsers == "Администратор" || _RoleUsers == "Менеджер")
            {
                RequestTabItem.Visibility = Visibility.Visible;
                LoadRequest();
            }
            else
            {
                RequestTabItem.Visibility= Visibility.Collapsed;
            }

            LoadTours();
        }

        private void LoadTours()
        {
            using (var conext = new TestContext())
            {
                var tours = conext.Tours
                    .Include(u => u.Country)
                    .Include(u => u.TipsBus)
                    .ToList();
                TourListView.ItemsSource = tours;
            }
        }

        private void LoadRequest()
        {
            using (var context = new TestContext())
            {
                var request = context.Requests
                    .Include(u => u.StatusrRequest)
                    .Include(u => u.Tours)
                    .Include(u => u.Users)
                    .ToList();
                RequestListView.ItemsSource = request;
            }
        }
    }
}