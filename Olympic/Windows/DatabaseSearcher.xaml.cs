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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Olympic.Windows
{
    /// <summary>
    /// Логика взаимодействия для DatabaseSeracher.xaml
    /// </summary>
    public partial class DatabaseSearcher : Window
    {
        private readonly IEnumerable<object> initData;
        private Type ElementType => initData.Any() ? initData.First().GetType() : null;

        public DatabaseSearcher(IEnumerable<object> data)
        {
            InitializeComponent();
            initData = data.ToList();
            mainDb.ItemsSource = data;
        }

        private void Searcher_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (ElementType == null)
            {
                return;
            }

            List<object> newCollection = new List<object>();
            string[] text = Searcher.Text.ToLower().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            foreach (object el in initData)
            {
                int propsEq = 0;
                foreach (PropertyInfo pi in ElementType.GetProperties())
                {
                    object data = pi.GetValue(el);
                    if (text.Any(t => data.ToString().ToLower().Contains(t)))
                    {
                        propsEq++;
                    }
                }

                if (propsEq >= text.Length)
                {
                    newCollection.Add(el);
                }
            }

            mainDb.ItemsSource = newCollection;
        }
    }
}
