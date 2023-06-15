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
    /// Логика взаимодействия для AddGames.xaml
    /// </summary>
    public partial class AddGames : Window
    {
        // Контекст базы данных
        private GamersDBModel db = new GamersDBModel();
        public AddGames()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            // Получаем данные из текстовых полей
            string title = titleTextBox.Text;
            string genre = genreTextBox.Text;
            decimal price = decimal.Parse(priceTextBox.Text);

            // Создаем новый объект Game
            Gamer game = new Gamer()
            {
                title = title,
                genre = genre,
                price = price
            };

            // Добавляем объект в контекст базы данных
            db.Gamer.Add(game);

            // Сохраняем изменения в базе данных
            db.SaveChanges();

            // Очищаем текстовые поля
            titleTextBox.Clear();
            genreTextBox.Clear();
            priceTextBox.Clear();

            // Выводим сообщение об успешном добавлении
            MessageBox.Show("Game added successfully!");
        }
    }
}
