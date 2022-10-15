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
    /// Логика взаимодействия для ReserveConfirm.xaml
    /// </summary>
    public partial class ReserveConfirm : UserControl
    {
        private readonly ApplicationContext db;
        private readonly WorkAccounting wa;

        public ReserveConfirm(ApplicationContext db, WorkAccounting wa)
        {
            InitializeComponent();
            this.db = db;
            this.wa = wa;

            ReserveNum.Text = wa.Id.ToString();
            ReserveDate.Text = wa.RentStart.ToString();
            StartRent.Text = wa.RentStart.ToString();
            EndRent.Text = wa.RentEnd.ToString();
            DaysCount.Text = (wa.RentEnd - wa.RentStart).Days.ToString();
            CategoryName.Text = wa.Car.Category.CategoryName;
            Sale.Text = (wa.Sale * 1000 / 10).ToString() + "%";
            Cost.Text = wa.Price.ToString();
            FIO.Text = wa.Client.ToString();
            Phone.Text = wa.Client.Phone.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            db.WorkAccountings.Add(wa);
            MainWindow.SetPage(new StartPage(db));
            MessageBox.Show("Бронированиие успешно выполнено");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow.SetPage(new StartPage(db));
        }
    }
}
