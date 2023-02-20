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

namespace GiB.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddUserPage.xaml
    /// </summary>
    public partial class AddUserPage : Page
    {
        private Drivers _currentUser = new Drivers();

        public AddUserPage(Drivers selectedUser)
        {
            InitializeComponent();
            if (selectedUser != null)
                _currentUser = selectedUser;

            DataContext = _currentUser;
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UserPage());
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentUser.name))
                errors.AppendLine("Укажите имя и фамилию!");
            if (string.IsNullOrWhiteSpace(_currentUser.middlename))
                errors.AppendLine("Укажите отчество");
            if (string.IsNullOrWhiteSpace(_currentUser.passportserial))
                errors.AppendLine("Укажите серию паспорта");
            if (string.IsNullOrWhiteSpace(_currentUser.passportnumber))
                errors.AppendLine("Укажите номер паспорта!");
            if (string.IsNullOrWhiteSpace(_currentUser.postcode))
                errors.AppendLine("Укажите индекс!");
            if (string.IsNullOrWhiteSpace(_currentUser.address))
                errors.AppendLine("Укажите адрес!");
            if (string.IsNullOrWhiteSpace(_currentUser.company))
                errors.AppendLine("Укажите компанию!");
            if (string.IsNullOrWhiteSpace(_currentUser.jobname))
                errors.AppendLine("Укажите профессию");
            if (string.IsNullOrWhiteSpace(_currentUser.phone))
                errors.AppendLine("Укажите телефон!");
            if (string.IsNullOrWhiteSpace(_currentUser.email))
                errors.AppendLine("Укажите почту");
         
            if (string.IsNullOrWhiteSpace(_currentUser.photo))
                errors.AppendLine("Укажите фото!");
          

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentUser.id == 0)
                Entities.GetContext().Drivers.Add(_currentUser);
            try
            {
                Entities.GetContext().SaveChanges();
                MessageBox.Show("Данные успешно сохранены!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            NavigationService.Navigate(new UserPage());
        }
    }
}
