using Barbershop.Client;
using Microsoft.Win32;
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

namespace Barbershop.Admin
{
    /// <summary>
    /// Логика взаимодействия для Admin_Profile.xaml
    /// </summary>
    public partial class Admin_Profile : Page
    {
        public Admin_Profile()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                Image.Source = new BitmapImage(new Uri(op.FileName));
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            NavigationService AppFrame = NavigationService.GetNavigationService(this);
            AppFrame.Navigate(new PageWork());
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            NavigationService AppFrame = NavigationService.GetNavigationService(this);
            AppFrame.Navigate(new PageBarber());
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            NavigationService AppFrame = NavigationService.GetNavigationService(this);
            AppFrame.Navigate(new PageRecord());
        }

        private void Button6_Click(object sender, RoutedEventArgs e)
        {
            NavigationService AppFrame = NavigationService.GetNavigationService(this);
            AppFrame.Navigate(new Enter());
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox2_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
