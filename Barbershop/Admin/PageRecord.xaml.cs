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
    /// Логика взаимодействия для PageRecord.xaml
    /// </summary>
    public partial class PageRecord : Page
    {
        private Recording clother = new Recording();
        public PageRecord()
        {
            InitializeComponent();
            DataContext = clother;
            DGridRecord.ItemsSource = BarbershopEntities.GetContext().Recording.ToList();
        }

        private void DGridRecord_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService AppFrame = NavigationService.GetNavigationService(this);
            AppFrame.Navigate(new Client_Profile());
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                BarbershopEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGridRecord.ItemsSource = BarbershopEntities.GetContext().Recording.ToList();
            }
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            BarbershopEntities.GetContext().Recording.Add(clother);
            try
            {
                BarbershopEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");
                DGridRecord.ItemsSource = BarbershopEntities.GetContext().Recording.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            var hotelsForRemoving = DGridRecord.SelectedItems.Cast<Recording>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующее {hotelsForRemoving.Count()} элементов", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    BarbershopEntities.GetContext().Recording.RemoveRange(hotelsForRemoving);
                    BarbershopEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");

                    DGridRecord.ItemsSource = BarbershopEntities.GetContext().Recording.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
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

        }
    }
}
