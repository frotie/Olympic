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
    /// Логика взаимодействия для PersonalFiller.xaml
    /// </summary>
    public partial class PersonalFiller : Window
    {
        public PersonalFiller()
        {
            InitializeComponent();

            using (ApplicationContext db = new ApplicationContext())
            {
                Categories.ItemsSource = db.Categories.Select(x => x.CategoryName).ToList();
                if (!db.Categories.Any())
                {
                    Categories.IsEnabled = false;
                    Create.IsEnabled = false;
                }

                Categories.SelectedIndex = 0;
            }
        }

        private bool CheckEntry(TextBox tb)
        {
            return !string.IsNullOrEmpty(tb.Text);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckEntry(Name) ||
                !CheckEntry(Surname) ||
                !CheckEntry(Lastname) ||
                !CheckEntry(Post) ||
                Categories.SelectedItem != null)
            {
                MessageBox.Show("Вы заполнили не все");
                return;
            }

            using (ApplicationContext db = new ApplicationContext())
            {

                Personal personal = new Personal()
                {
                    Name = Name.Text,
                    Surname = Surname.Text,
                    Lastname = Lastname.Text,
                    Post = Post.Text,
                    Category = db.Categories.First(x => x.CategoryName == Categories.SelectedItem)
                };

                db.Personals.Add(personal);
                db.SaveChanges();
            }

            Close();
        }
    }
}
