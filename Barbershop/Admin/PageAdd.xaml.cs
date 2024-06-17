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

namespace Barbershop
{
    /// <summary>
    /// Логика взаимодействия для PageAdd.xaml
    /// </summary>
    public partial class PageAdd : Page
    {
        private Recording _currnetrecord = new Recording();
        public PageAdd(Recording selectedrecord)
        {
            InitializeComponent();
            DataContext = _currnetrecord;

        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (_currnetrecord.ID == 0)
                BarbershopEntities.GetContext().Recording.Add(_currnetrecord);

            BarbershopEntities.GetContext().Recording.Add(_currnetrecord);
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

        private void ComboWork_Copy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
