using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Olympic.Database;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
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
    /// Логика взаимодействия для DatabaseFiller.xaml
    /// </summary>
    public partial class DatabaseFiller : Window
    {
        private ApplicationContext db;
        private Type columnType;
        public DatabaseFiller(ApplicationContext db, Type columnType)
        {
            InitializeComponent();
            this.db = db;
            this.columnType = columnType;

            List<Type> dbAvailableTypes = db.GetType()
                .GetProperties()
                .Where(x => x.PropertyType.IsGenericType)
                .Select(x => x.PropertyType.GetGenericArguments().First())
                .ToList();

            object listObj = GetDataFromDbByType(columnType);
            IEnumerable res = listObj as IEnumerable;

            foreach (PropertyInfo pi in listObj.GetType().GetGenericArguments().First().GetProperties())
            {
                if (pi.PropertyType.IsGenericType &&
                    dbAvailableTypes.Contains(pi.PropertyType.GetGenericArguments().First()) ||
                    pi.Name.Contains("Id"))
                {
                    continue;
                }

                if (dbAvailableTypes.Contains(pi.PropertyType))
                {
                    IEnumerable elementsToSelect = GetDataFromDbByType(pi.PropertyType) as IEnumerable;
                    mainDb.Columns.Add(new DataGridComboBoxColumn()
                    {
                        Header = pi.Name,
                        ItemsSource = elementsToSelect,
                        SelectedItemBinding = new Binding(pi.Name)
                    });
                    continue;
                }

                mainDb.Columns.Add(new DataGridTextColumn() { Header = pi.Name, Binding = new Binding(pi.Name) });
            }

            mainDb.ItemsSource = res;
        }

        private object GetDbSet(Type type)
        {
            return db.GetType()
               .GetProperties()
               .FirstOrDefault(x => x.PropertyType.IsGenericType && x.PropertyType.GetGenericArguments().First() == type)
               .GetValue(db);
        }

        private object GetDataFromDbByType(Type type)
        {
            object obj = GetDbSet(type);

            typeof(EntityFrameworkQueryableExtensions)
                .GetMethod("Load")
                .MakeGenericMethod(type)
                .Invoke(obj, new[] { obj });

            object lv = obj.GetType().GetProperty("Local").GetValue(obj);
            MethodInfo mi = lv.GetType().GetMethod("ToObservableCollection");
            return mi.Invoke(lv, null);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MethodInfo mi = typeof(DbContext).GetMethod("SaveChanges", new Type[0]);
            mi.Invoke(db, null);

            Close();
        }
    }
}
