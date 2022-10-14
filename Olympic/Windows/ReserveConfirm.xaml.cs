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

        public ReserveConfirm(ApplicationContext db, WorkAccounting wa)
        {
            InitializeComponent();
            this.db = db;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow.SetPage(new StartPage(db));
        }
    }
}
