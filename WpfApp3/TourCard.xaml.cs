using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WpfApp3.Models;
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

namespace WpfApp3
{
    /// <summary>
    /// Логика взаимодействия для TourCard.xaml
    /// </summary>
    public partial class TourCard : UserControl
    {
        public TourCard()
        {
            InitializeComponent();
            DataContextChanged += TourCard_DataContextChanged;
        }

        private void TourCard_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (DataContext is Models.Tour tour)
            {
                SetImage(tour.Image);
            }
        }

        private void SetImage(string ImagePath)
        {
            try
            {
                if (!string.IsNullOrEmpty(ImagePath))
                {
                    ImageTour.Source = new BitmapImage(new Uri($"pack://application:,,,/Image/{ImagePath}", UriKind.RelativeOrAbsolute));
                }
                else
                {
                    SetIcon();
                }
            }
            catch
            {
                SetIcon();
            }
        }

        private void SetIcon()
        {
            try
            {
                ImageTour.Source = new BitmapImage(new Uri("pack://application:,,,/Image/icon.png"));
            }
            catch
            {
                ImageTour.Visibility = Visibility.Collapsed;
            }
        }
    }
}
