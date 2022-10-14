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
using System.Windows.Shapes;

namespace Olympic.Windows
{
    /// <summary>
    /// Логика взаимодействия для CategoriesFiller.xaml
    /// </summary>
    public partial class CategoriesFiller : Window
    {
        public CategoriesFiller()
        {
            InitializeComponent();
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Name.Text))
            {
                MessageBox.Show("Вы не заполнили все поля");
                return;
            }   

            Category cat = new Category()
            {
                CategoryName = Name.Text,
            };

            using (ApplicationContext db = new ApplicationContext())
            {
                db.Categories.Add(cat);
                db.SaveChanges();
            }

            Close();
        }
    }
}
