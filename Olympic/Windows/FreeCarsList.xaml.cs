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
    /// Логика взаимодействия для FreeCarsList.xaml
    /// </summary>
    public partial class FreeCarsList : UserControl
    {
        private readonly ApplicationContext db;

        public FreeCarsList(ApplicationContext db)
        {
            InitializeComponent();
            this.db = db;
            table.ItemsSource = db.Cars.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
