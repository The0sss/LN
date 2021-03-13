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

namespace LN
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void addClient_Click(object sender, RoutedEventArgs e)
        {
            string nName = NewName.Text;
            string nLastName = NewLastName.Text;
            string nPatr = NewPatr.Text;
            DateTime nBirth = new DateTime();
            DateTime nRD = new DateTime(); 
            string nEmail = NewEmail.Text;
            string nPhone = NewPhone.Text;
            string nGendr = NewGendr.Text;

            nBirth = Convert.ToDateTime(NewBirthday.Text);
            nRD = Convert.ToDateTime(NewRegistrDate.Text);

            SchoolEntities schoolEntities = new SchoolEntities();
            
            if ((nName != null) & (nLastName != null) & (nRD != null) & (nEmail != null) & (nPhone != null) & (nGendr != null ))
            {
                Client NClient = new Client
                {
                    FirstName = nName,
                    LastName = nLastName,
                    Patronymic = nPatr,
                    Birthday = nBirth,
                    RegistrationDate = nRD,
                    Email = nEmail,
                    Phone = nPhone,
                    GenderCode = nGendr
                };

                schoolEntities.Client.Add(NClient);
                schoolEntities.SaveChanges();

                MainWindow mainWindow = new MainWindow();
                mainWindow.Visibility = Visibility.Visible;
                this.Close();
            }
            else
            {
                MessageBox.Show("заполните поля обозначенные знаком \"*\" ! ");
            }
        }
    }
}
