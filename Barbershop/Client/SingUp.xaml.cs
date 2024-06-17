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
    /// Логика взаимодействия для SingUp.xaml
    /// </summary>
    public partial class SingUp : Page
    {
        private RecordingWork clother = new RecordingWork();
        public SingUp()
        {
            InitializeComponent();
            DataContext = clother;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService AppFrame = NavigationService.GetNavigationService(this);
            AppFrame.Navigate(new Client_Profile());
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            NavigationService AppFrame = NavigationService.GetNavigationService(this);
            AppFrame.Navigate(new WorkClient());
        }

        private void Button6_Click(object sender, RoutedEventArgs e)
        {
            BarbershopEntities.GetContext().RecordingWork.Add(clother);
            try
            {
                BarbershopEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
