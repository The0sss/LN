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

namespace LN
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            SchoolEntities schoolEntities = new SchoolEntities();
            Tabl.ItemsSource = schoolEntities.Client.ToList(); //выводим данные из таблицы
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed; 
            Window1 window1 = new Window1();
            window1.Show();//выводим форму добавления клиента
        }

        private void search_TextChanged(object sender, TextChangedEventArgs e)
        {
            SchoolEntities schoolEntities = new SchoolEntities();
            var i = from u in schoolEntities.Client
                    where ((u.FirstName.Contains(search.Text)) || (u.LastName.Contains(search.Text)) || (u.Patronymic.Contains(search.Text)) || (u.Email.Contains(search.Text)))//ищем совпаденя в полях
                    select new { u.FirstName, u.LastName, u.Patronymic, u.Email, u.Gender, u.Birthday, u.RegistrationDate };
            Tabl.ItemsSource = i.ToList(); //выводим новые поля
            kolvo.Text = i.Count().ToString();// выводим количество строк в таблице
        }
    }
}
