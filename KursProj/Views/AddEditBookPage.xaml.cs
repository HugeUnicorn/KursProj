﻿using KursProj.Model;
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
using System.Text.RegularExpressions;
using Microsoft.Win32;
using System.IO;

namespace KursProj.Views
{
    /// <summary>
    /// Логика взаимодействия для AddEditBookPage.xaml
    /// </summary>
    public partial class AddEditBookPage : Page
    {
        private byte[] _mainImageData = null;
        public string img = null;
        public string path = Path.Combine(Directory.GetParent(Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName)).FullName, @"Images\");
        public string selectefFileName;
        public string extension = "";
        public Books currentBook;

        public AddEditBookPage()
        {
            InitializeComponent();
        }
        public AddEditBookPage(Books cb)
        {
            InitializeComponent();

            currentBook = cb;

            TBBookName.Text = currentBook.name;
            TBArticule.Text = currentBook.article;
            TBDescription.Text = currentBook.description;
            TBAuthor.SelectedItem = currentBook.Authors.surname;
            TBGenre.SelectedItem = currentBook.Genres.name;
            TBPublisher.SelectedItem = currentBook.PublishingHouse.name;
            TBGenre.SelectedItem = currentBook.Genres.name;
            TBState.SelectedItem = currentBook.State.name;

            var authors = AppData.db.Authors.Select(r => r.surname).ToList();
            TBAuthor.ItemsSource = authors;
            var genres = AppData.db.Genres.Select(r => r.name).ToList();
            TBGenre.ItemsSource = genres;
            var publishers = AppData.db.PublishingHouse.Select(r => r.name).ToList();
            TBPublisher.ItemsSource = publishers;
            var states = AppData.db.State.Select(r => r.name).ToList();
            TBState.ItemsSource = states;          
        }

        private void BtnImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;
            ofd.Filter = "Фото | *.png; *.jpg; *.jpeg";
            if (ofd.ShowDialog() == true)
            {
                img = Path.GetFileName(ofd.FileName);
                extension = Path.GetExtension(img);
                selectefFileName = ofd.FileName;
                _mainImageData = File.ReadAllBytes(ofd.FileName);
                ImagePFP.Source = new ImageSourceConverter()
                    .ConvertFrom(_mainImageData) as ImageSource;
            }
            if (img != null)
            {
                img = TBArticule.Text + extension;
                int a = 0;
                while (File.Exists(path + img))
                {
                    a++;
                    img = TBArticule.Text + $" ({a})" + extension;
                }
                path += img;
                File.Copy(selectefFileName, path);
            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (currentBook == null )
            {
                Books book = new Books()
                {
                    article = TBArticule.Text,
                    name = TBBookName.Text,
                    yearOfPublic = Int32.Parse(TBYoP.Text),
                };
            }
        }
    }
}
