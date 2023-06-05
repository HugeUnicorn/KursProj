using KursProj.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
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
    /// Логика взаимодействия для AddEditShortPage.xaml
    /// </summary>
    public partial class AddEditShortPage : Page
    {
        public TableName currentTable;       
        public string itemName;
        private Role role;
        private Genres genre;
        private PublishingHouse publishingHouse;
        private State state;
        bool addOrEditFlag = false; //добавление - true, изменение - false;

        //добавление
        public AddEditShortPage(TableName tn)
        {
            InitializeComponent();
            this.WindowTitle = "Добавление";
            currentTable = tn;
            addOrEditFlag = true;
        }
        //редактирование
        public AddEditShortPage(TableName tn, Genres gn = null, Role rl = null, PublishingHouse pbl = null, State st = null)
        {
            this.currentTable = tn;
            addOrEditFlag = false;

            this.genre = gn;
            this.role = rl;
            this.publishingHouse = pbl;
            this.state = st;
            InitializeComponent();

            switch (currentTable)
            {
                case TableName.Genres:
                    this.WindowTitle = "Редактирование жанров";
                    TBShortName.Text = genre.name;
                    break;
                case TableName.Role:
                    this.WindowTitle = "Редактирование ролей";
                    TBShortName.Text = role.name;
                    break;
                case TableName.PublishingHouse:
                    this.WindowTitle = "Редактирование издательств";
                    TBShortName.Text = publishingHouse.name;
                    break;
                case TableName.State:
                    this.WindowTitle = "Редактирование состояний книг";
                    TBShortName.Text = state.name;
                    break; 
                default:
                    break;
            }           
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            //(TableName)currentTable ct = new (TableName)currentTable();
            //CS8370: Feature 'top-level statements' is not available in C# 7.3. Please use language version 9.0 or greater.
            if (addOrEditFlag)
            {
                switch (currentTable)
                {                     
                    case TableName.Genres:
                        Genres genre = new Genres()
                        {
                            name = TBShortName.Text,
                        };
                        AppData.db.Genres.Add(genre);
                        break;
                    case TableName.Role:
                        Role role = new Role()
                        {
                            name = TBShortName.Text,
                        };
                        AppData.db.Role.Add(role);
                        break;
                    case TableName.PublishingHouse:
                        PublishingHouse publishingHouse = new PublishingHouse()
                        { 
                            name = TBShortName.Text,
                        };
                        AppData.db.PublishingHouse.Add(publishingHouse);
                        break;
                    case TableName.State:
                        State state = new State() { name = TBShortName.Text, };
                        AppData.db.State.Add(state);
                        break;
                    default:
                        break;
                }
                AppData.db.SaveChanges();
                MessageBox.Show("Запись успешно добавлена в таблицу!");
            }
            else 
            {
                switch (currentTable)
                {
                    case TableName.Genres:
                        genre.name = TBShortName.Text;
                        break;
                    case TableName.Role:
                        role.name = TBShortName.Text;
                        break;
                    case TableName.PublishingHouse:
                        publishingHouse.name = TBShortName.Text;
                        break;
                    case TableName.State:
                        state.name = TBShortName.Text;
                        break;
                    default:
                        break;
                }
                AppData.db.SaveChanges();
                MessageBox.Show("Запись успешно изменена");
            }
        }
    }
}
