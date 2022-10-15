using Olympic.Database;
using Olympic.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Shapes;

namespace Olympic.Windows
{
    /// <summary>
    /// Логика взаимодействия для CarSearching.xaml
    /// </summary>
    public partial class CarSearching : Window
    {
        private readonly ApplicationContext db;
        private DateTime? previousRendEnd;

        public CarSearching(ApplicationContext db)
        {
            InitializeComponent();
            this.db = db;
            clients.ItemsSource = db.Clients.ToList();
            comforts.ItemsSource = db.Categories.ToList().Select(x => x.CategoryName);
            comforts.SelectedIndex = 0;
            clients.SelectedIndex = 0;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private bool IsWAFiltered(WorkAccounting a)
        {
            return IsWAFiltered(a, RentStart.SelectedDate.Value, RentEnd.SelectedDate.Value, comforts.SelectedItem as Category, double.Parse(maxCost.Text));
        }

        public static bool IsWAFiltered(WorkAccounting a, DateTime start, DateTime end, Category category, double? cost)
        {
            return (end <= a.RentStart ||
               start >= a.RentEnd) &&
               (category == null || a.Car.Category == category) &&
               (cost == null || a.Price <= cost.Value);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (!RentStart.SelectedDate.HasValue ||
                !RentEnd.SelectedDate.HasValue ||
                string.IsNullOrEmpty(maxCost.Text) ||
                !double.TryParse(maxCost.Text, out double maxCostVal) ||
                string.IsNullOrEmpty(Capability.Text) ||
                !int.TryParse(Capability.Text, out int capability) ||
                comforts.SelectedIndex == -1 ||
                clients.SelectedIndex == -1)
            {
                MessageBox.Show("Вы заполнили не все поля, или они заполнены некорректно");
                return;
            }

            IEnumerable<Car> exCars = db.WorkAccountings.ToList().Where(x => !IsWAFiltered(x)).Select(x => x.Car);
            IEnumerable<Car> cars = db.Cars.ToList().Except(exCars);
            int days = (RentEnd.SelectedDate - RentStart.SelectedDate).Value.Days;
            WorkAccounting wa = new WorkAccounting()
            {
                AvailableCars = cars.ToList(),
                IsReserved = true,
                RentStart = RentStart.SelectedDate.Value,
                RentEnd = RentEnd.SelectedDate.Value,
                Sale = days >= 4 ? 0.1 : 0,
                Client = clients.SelectedItem as Client
            };

            MainWindow.SetPage(new FreeCarsList(db, wa));
            Close();
        }

        private void RentEnd_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (RentEnd.SelectedDate < RentStart.SelectedDate)
            {
                RentEnd.SelectedDate = previousRendEnd;
                return;
            }

            previousRendEnd = RentEnd.SelectedDate;
        }
    }
}
