using Olympic.Database;
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
    /// Логика взаимодействия для StartPage.xaml
    /// </summary>
    public partial class StartPage : UserControl
    {
        private readonly ApplicationContext db;

        public StartPage(ApplicationContext db)
        {
            InitializeComponent();
            this.db = db;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new CarSearching(db).ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            new DatabaseSearcher(db.Clients.ToList()).ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            new DatabaseSearcher(db.WorkAccountings.Where(x => x.IsReserved).ToList()).ShowDialog();
        }
    }
}
