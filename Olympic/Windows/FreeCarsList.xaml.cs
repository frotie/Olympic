using Olympic.Database;
using Olympic.Models;
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

namespace Olympic.Windows
{
    /// <summary>
    /// Логика взаимодействия для FreeCarsList.xaml
    /// </summary>
    public partial class FreeCarsList : UserControl
    {
        private readonly ApplicationContext db;
        private readonly WorkAccounting wa;

        public FreeCarsList(ApplicationContext db, WorkAccounting wa)
        {
            InitializeComponent();
            this.db = db;
            this.wa = wa;

            table.ItemsSource = wa.AvailableCars;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            wa.Car = (sender as Button).Tag as Car;
            wa.Price = (wa.RentEnd - wa.RentStart).Days * wa.Car.Price * (1 - wa.Sale);
            MainWindow.SetPage(new ReserveConfirm(db, wa));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow.SetPage(new StartPage(db));
        }
    }
}
