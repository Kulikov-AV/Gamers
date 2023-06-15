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
    /// Логика взаимодействия для OrdersBay.xaml
    /// </summary>
    public partial class OrdersBay : Window
    {
        // Контекст базы данных
        private GamersDBModel db = new GamersDBModel();
        public OrdersBay()
        {
            InitializeComponent();
            // Загружаем данные из таблиц Customers и Games в ComboBox при запуске окна
            customerComboBox.ItemsSource = db.Customers.ToList();
            gameComboBox.ItemsSource = db.Gamer.ToList();
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            // Получаем данные из ComboBox и DatePicker
            Customers customer = customerComboBox.SelectedItem as Customers;
            Gamer game = gameComboBox.SelectedItem as Gamer;
            DateTime date = datePicker.SelectedDate.Value;

            // Получаем данные из текстового поля
            int quantity = int.Parse(quantityTextBox.Text);

            // Создаем новый объект Order
            Orders order = new Orders()
            {
                customer_id = customer.id,
                game_id = game.id,
                date = date,
                quantity = quantity
            };

            // Добавляем объект в контекст базы данных
            db.Orders.Add(order);

            // Сохраняем изменения в базе данных
            db.SaveChanges();

            // Очищаем текстовое поле
            quantityTextBox.Clear();

            // Выводим сообщение об успешном добавлении
            MessageBox.Show("Order saved successfully!");
        }
    }
}
