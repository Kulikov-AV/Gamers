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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Games
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Контекст базы данных
        private GamersDBModel db = new GamersDBModel();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void refreshButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Загружаем данные из трех таблиц с помощью метода Join в DataGrid при запуске окна
                var query = db.Customers.Join(db.Orders,
                    customer => customer.id,
                    order => order.customer_id,
                    (customer, order) => new { customer, order })
                    .Join(db.Gamer,
                    combined => combined.order.game_id,
                    game => game.id,
                    (combined, game) => new
                    {
                        Name = combined.customer.name,
                        Age = combined.customer.age,
                        Email = combined.customer.email,
                        Title = game.title,
                        Genre = game.genre,
                        Price = game.price,
                        Quantity = combined.order.quantity,
                        Date = combined.order.date
                    });
                ordersDataGrid.ItemsSource = query.ToList();
                //carOwnerDataGrid.ItemsSource = carOwners;
            }
            catch (Exception ex)
            {
                //выводим сообщение об ошибке
                MessageBox.Show(ex.Message);
            }
        }

        private void btnGamePay_Click(object sender, RoutedEventArgs e)
        {
            OrdersBay win2 = new OrdersBay();
            win2.Show();
        }

        private void btnGamers_Click(object sender, RoutedEventArgs e)
        {
            AddGames win2 = new AddGames();
            win2.Show();
        }

        private void btnClient_Click(object sender, RoutedEventArgs e)
        {
            AddClient win2 = new AddClient();
            win2.Show();
        }
    }
}
