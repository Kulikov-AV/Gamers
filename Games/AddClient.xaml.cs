using Games.DB;
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

namespace Games
{
    /// <summary>
    /// Логика взаимодействия для AddClient.xaml
    /// </summary>
    public partial class AddClient : Window
    {
        private GamersDBModel db = new GamersDBModel();
        public AddClient()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            // Получаем данные из текстовых полей
            string name = nameTextBox.Text;
            int age = int.Parse(ageTextBox.Text);
            string email = emailTextBox.Text;

            // Создаем новый объект Customer
            Customers customer = new Customers()
            {
                name = name,
                age = age,
                email = email
            };

            // Добавляем объект в контекст базы данных
            db.Customers.Add(customer);

            // Сохраняем изменения в базе данных
            db.SaveChanges();

            // Очищаем текстовые поля
            nameTextBox.Clear();
            ageTextBox.Clear();
            emailTextBox.Clear();

            // Выводим сообщение об успешном добавлении
            MessageBox.Show("Customer added successfully!");
        }
    }
}
