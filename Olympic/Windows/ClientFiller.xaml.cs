using Olympic.Database;
using Olympic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
using ApplicationContext = Olympic.Database.ApplicationContext;

namespace Olympic.Windows
{
    /// <summary>
    /// Логика взаимодействия для DatabaseFiller.xaml
    /// </summary>
    public partial class ClientFiller : Window
    {
        public ClientFiller(Type type)
        {
            InitializeComponent();
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
                !CheckEntry(DriveLicense) ||
                !CheckEntry(Passport) ||
                !CheckEntry(Phone))
            {
                MessageBox.Show("Вы заполнили не все");
                return;
            }

            Client client = new Client()
            {
                Name = Name.Text,
                Surname = Surname.Text,
                Lastname = Lastname.Text,
                DriveLicense = DriveLicense.Text,
                Passport = Passport.Text,
                Phone = Phone.Text
            };

            using (ApplicationContext db = new ApplicationContext())
            {
                db.Clients.Add(client);
                db.SaveChanges();
            }

            Close();
        }
    }
}
