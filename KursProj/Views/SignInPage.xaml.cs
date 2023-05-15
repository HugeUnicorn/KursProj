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
    /// Логика взаимодействия для SignInPage.xaml
    /// </summary>
    public partial class SignInPage : Page
    {
        public SignInPage()
        {
            InitializeComponent();
        }

        private void BtnSighIn_Click(object sender, RoutedEventArgs e)
        {
            try 
            {
                var CurrentUser = AppData.db.User.FirstOrDefault(u => u.login == TBLogin.Text && u.password == TBPassword.Text);

                if (CurrentUser == null)
                {
                    MessageBox.Show("Такого пользователя нет!", "Ошибка авторизации");
                } else
                {
                    switch (CurrentUser.roleID)
                    {
                        case 1:MessageBox.Show("Здравствуйте, Администратор " + CurrentUser.name + "!");
                            break;
                        case 2:MessageBox.Show("Здравствуйте, гость " + CurrentUser.name + "!");
                            break;
                        default:MessageBox.Show("Ошибка");
                            break;
                    }
                }
            } catch (Exception ex) 
            {
                MessageBox.Show("Ошибка " + ex.Message.ToString());
            }
            
        }
    }
}
