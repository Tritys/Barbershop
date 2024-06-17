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
    /// Логика взаимодействия для Register.xaml
    /// </summary>
    public partial class Register : Page
    {
        public Register()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBox1.Text) || string.IsNullOrWhiteSpace(TextBox2.Text))
            {
                // Вывод ошибки
                MessageBox.Show("Ошибка: отсутствует ФИО");
            }
            else if (string.IsNullOrWhiteSpace(TextBox2.Text))
            {
                MessageBox.Show("Ошибка: отсутствует E-mail");
            }
            else if (string.IsNullOrWhiteSpace(TextBox2.Text))
            {
                MessageBox.Show("Ошибка: отсутствует пароль");
            }

            if (AppConnect.modelOdb.User.Count(x => x.Login == TextBox1.Text) > 0)
            {
                MessageBox.Show("Пользователь с таким логином есть, придумай свой",
                    "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            try
            {
                User userObj = new User()
                {
                    Login = TextBox1.Text,
                    FIO = TextBox2.Text,
                    Password = PasswordBox1.Password,
                    ID = 4
                };
                AppConnect.modelOdb.User.Add(userObj);
                AppConnect.modelOdb.SaveChanges();
                MessageBox.Show("Данные успешно добавлены",
                    "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            catch
            {
                MessageBox.Show("Ошибка при добавлении данных",
                    "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void TextBox1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void PasswordBox1_PasswordChanged(object sender, RoutedEventArgs e)
        {

        }

        private void PasswordBox2_PasswordChanged(object sender, RoutedEventArgs e)
        {

        }
    }
}
