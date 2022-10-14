﻿using Olympic.Database;
using Olympic.Models;
using Olympic.Windows;
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

namespace Olympic
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ApplicationContext db;
        private static ContentControl containerObject;

        public MainWindow()
        {
            InitializeComponent();
            db = new ApplicationContext();

            containerObject = container;
            container.Content = new StartPage(db);
        }

        public static void SetPage(UserControl uc)
        {
            if (containerObject == null)
            {
                return;
            }

            containerObject.Content = uc;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            new DatabaseFiller(db, typeof(Client)).ShowDialog();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            new DatabaseFiller(db, typeof(Personal)).ShowDialog();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            new DatabaseFiller(db, typeof(Category)).ShowDialog();
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            new DatabaseFiller(db, typeof(Car)).ShowDialog();
        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            new DatabaseFiller(db, typeof(WorkAccounting)).ShowDialog();
        }
    }
}
