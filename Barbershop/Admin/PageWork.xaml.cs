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
    /// Логика взаимодействия для PageWork.xaml
    /// </summary>
    public partial class PageWork : Page
    {
        private Work clother = new Work();
        public PageWork()
        {
            InitializeComponent();
            DataContext = clother;
            DGridWork.ItemsSource = BarbershopEntities.GetContext().Work.ToList();
        }

        private void DGridBarber_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            if (clother.ID == 0)
                
            BarbershopEntities.GetContext().Work.Add(clother);
            try
            {
                BarbershopEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");
                DGridWork.ItemsSource = BarbershopEntities.GetContext().Work.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            var hotelsForRemoving = DGridWork.SelectedItems.Cast<Work>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующее {hotelsForRemoving.Count()} элементов", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    BarbershopEntities.GetContext().Work.RemoveRange(hotelsForRemoving);
                    BarbershopEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");

                    DGridWork.ItemsSource = BarbershopEntities.GetContext().Work.ToList();
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
                DGridWork.ItemsSource = BarbershopEntities.GetContext().Work.ToList();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService AppFrame = NavigationService.GetNavigationService(this);
            AppFrame.Navigate(new Client_Profile());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

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
    }
}
