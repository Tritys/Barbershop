using Barbershop.ApllicationData;
using Barbershop.Client;
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

namespace Barbershop
{
    /// <summary>
    /// Логика взаимодействия для PageBarber.xaml
    /// </summary>
    public partial class PageBarber : Page
    {
        private Barber clother = new Barber();
        public PageBarber()
        {
            InitializeComponent();
            DataContext = clother;
            DGridBarber.ItemsSource = BarbershopEntities.GetContext().Barber.ToList();
        }

        private void DGridBarber_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            if (clother.ID == 0)
                BarbershopEntities.GetContext().Barber.Add(clother);
            try
            {
                BarbershopEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");
                DGridBarber.ItemsSource = BarbershopEntities.GetContext().Barber.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            var hotelsForRemoving = DGridBarber.SelectedItems.Cast<Barber>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующее {hotelsForRemoving.Count()} элементов", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    BarbershopEntities.GetContext().Barber.RemoveRange(hotelsForRemoving);
                    BarbershopEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");

                    DGridBarber.ItemsSource = BarbershopEntities.GetContext().Barber.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                BarbershopEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGridBarber.ItemsSource = BarbershopEntities.GetContext().Barber.ToList();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService AppFrame = NavigationService.GetNavigationService(this);
            AppFrame.Navigate(new Client_Profile());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            NavigationService AppFrame = NavigationService.GetNavigationService(this);
            AppFrame.Navigate(new PageWork());
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            NavigationService AppFrame = NavigationService.GetNavigationService(this);
            AppFrame.Navigate(new PageRecord());
        }
    }
}
