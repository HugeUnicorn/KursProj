using KursProj.Model;
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

namespace KursProj.Views
{
    /// <summary>
    /// Логика взаимодействия для SignUpPage.xaml
    /// </summary>
    public partial class SignUpPage : Page
    {
        public SignUpPage()
        {
            InitializeComponent();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void BtnReg_Click(object sender, RoutedEventArgs e)
        {
            if (AppData.db.User.Count(x => x.login==TBLogin.Text) > 0)
            {
                MessageBox.Show("Пользователь с таким логином уже существует!");
            }
            try
            {
                User user = new User();
                { 
                    user.name = TBName.Text;
                    user.surname = TBSurname.Text;
                    user.patronymic = TBPatronymic.Text;
                    user.yearOfBirth = Int32.Parse(TByob.Text);
                    user.login = TBLogin.Text;
                    user.password = PBPass.Password;
                    user.roleID = 2; //default user role //not admin
                };
                AppData.db.User.Add(user);
                AppData.db.SaveChanges();
                MessageBox.Show("Пользователь успешно добавлен!");
            }
            catch 
            {
                MessageBox.Show("Ошибка в добавлении данных!");
            }
        }

        private void PBPass_Changed(object sender, RoutedEventArgs e)
        {
            if (PBPass.Password != PBPassAgain.Password)
            {
                BtnReg.IsEnabled = false;
                PBPass.Background = Brushes.LightCoral;
                PBPass.Foreground = Brushes.Red;
                PBPassAgain.Background = Brushes.LightCoral;
                PBPassAgain.Foreground = Brushes.Red;
            }
            else
            {
                BtnReg.IsEnabled = true;
                PBPass.Background = Brushes.LightGreen;
                PBPass.Foreground = Brushes.Green;
                PBPassAgain.Background = Brushes.LightGreen;
                PBPassAgain.Foreground = Brushes.Green;
            }
        }
    }
}
