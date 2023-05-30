using KursProj.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace KursProj.Windows
{
    /// <summary>
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
            
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            if (SelectTable.SelectedIndex == 0)
            {
                var authors = AppData.db.Authors.ToList();
                MainFrame.Navigate(new Views.SignInPage());
            }
            else if (SelectTable.SelectedIndex == 1)
            {
                MainFrame.Navigate(new Views.SignUpPage());
            }
        }

        private void DtnAdd_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
