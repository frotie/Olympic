using Olympic.Database;
using System;
using System.Collections.Concurrent;
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
            comforts.ItemsSource = db.Categories.ToList().Select(x => x.CategoryName);
            comforts.SelectedIndex = 0;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow.SetPage(new FreeCarsList(db));
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
