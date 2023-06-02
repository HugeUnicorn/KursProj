using KursProj.Model;
using KursProj.Views;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KursProj.Windows
{
    /// <summary>
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public int currentTable = 0;
        public AdminWindow()
        {
            InitializeComponent();    
            SelectTable.SelectedIndex = 0;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            currentTable = SelectTable.SelectedIndex;
            switch (SelectTable.SelectedIndex)
            {
                case 0:
                    MainFrame.Navigate(new Views.AuthorsPage());
                    break;
                    case 1:
                    MainFrame.Navigate(new Views.SignInPage());
                    break;
                default:
                    break;
            } 
        }

        private void DtnAdd_Click(object sender, RoutedEventArgs e)
        {
            switch (currentTable)
            {
                case 0:
                    MainFrame.Navigate(new Views.AddEditAuthorsPage());
                    break;
                default:
                    break;
            }
        }

        private void GoBackImage_Click(object sender, MouseEventArgs e)
        {
            if (MainFrame.CanGoBack && MessageBox.Show("Вы уверены, что хотите вернуться?",
                "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.Yes)
                MainFrame.GoBack();
        }
    }
}
