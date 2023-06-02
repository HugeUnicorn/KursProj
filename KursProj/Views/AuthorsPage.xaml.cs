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
    /// Логика взаимодействия для AuthorsPage.xaml
    /// </summary>
    public partial class AuthorsPage : Page
    {      
        public AuthorsPage()
        {
            InitializeComponent();
            Update();
        }       
        public void Update()
        {
            var content = AppData.db.Authors.ToList();
            LVAuthors.ItemsSource = content;
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var currentAuthor = button.DataContext as Authors;
            NavigationService.Navigate(new AddEditAuthorsPage(currentAuthor));
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var currentAuthor = (sender as Button).DataContext as Authors;
            if (MessageBox.Show("Вы уверены что хотите удалить этоо автора?", "Внимание", 
                MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                AppData.db.Authors.Remove(currentAuthor);
                AppData.db.SaveChanges();
                Update();
            }
        }
    }
}
