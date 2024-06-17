using Barbershop.ApllicationData;
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

namespace Barbershop.Client
{
    /// <summary>
    /// Логика взаимодействия для WorkClient.xaml
    /// </summary>
    public partial class WorkClient : Page
    {
        public WorkClient()
        {
            InitializeComponent();
            DGridWork.ItemsSource = BarbershopEntities.GetContext().Work.ToList();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService AppFrame = NavigationService.GetNavigationService(this);
            AppFrame.Navigate(new Client_Profile());
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            NavigationService AppFrame = NavigationService.GetNavigationService(this);
            AppFrame.Navigate(new SingUp());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void DGridBarber_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
