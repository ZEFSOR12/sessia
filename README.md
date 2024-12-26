using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace WpfApp1
{
    public class Pokupatel
    {
        public int IdPokupatelya { get; set; }
        public string Familiya { get; set; }
        public string Imya { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Parol { get; set; }
    }

    public partial class ManageAccountsWindow : Window
    {
        private List<Pokupatel> pokupateli;
        private string connectionString = "data source=stud-mssql.sttec.yar.ru,38325; initial catalog=user243_db; user id=user243_db; password=user243; MultipleActiveResultSets=True; App=EntityFramework";

        public ManageAccountsWindow()
        {
            InitializeComponent();
            LoadClientAccounts();
        }

        private void LoadClientAccounts()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM pokupatel1";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                pokupateli = new List<Pokupatel>();
                while (reader.Read())
                {
                    pokupateli.Add(new Pokupatel
                    {
                        IdPokupatelya = reader["id_pokupatelya"] != DBNull.Value ? (int)reader["id_pokupatelya"] : 0,
                        Familiya = reader["familiya"].ToString(),
                        Imya = reader["imya"].ToString(),
                        Email = reader["email"].ToString(),
                        Login = reader["login"].ToString(),
                        Parol = reader["parol"].ToString()
                    });
                }
                AccountsDataGrid.ItemsSource = pokupateli;
            }
        }

        private void SaveAccountsChanges_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                foreach (var pokupatel in pokupateli)
                {
                    SqlCommand command = new SqlCommand("UPDATE pokupatel1 SET familiya = @Familiya, imya = @Imya, email = @Email, login = @Login, parol = @Parol WHERE id_pokupatelya = @Id", connection);
                    command.Parameters.AddWithValue("@Familiya", pokupatel.Familiya);
                    command.Parameters.AddWithValue("@Imya", pokupatel.Imya);
                    command.Parameters.AddWithValue("@Email", pokupatel.Email);
                    command.Parameters.AddWithValue("@Login", pokupatel.Login);
                    command.Parameters.AddWithValue("@Parol", pokupatel.Parol);
                    command.Parameters.AddWithValue("@Id", pokupatel.IdPokupatelya);

                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при сохранении изменений: {ex.Message}");
                    }
                }
            }

            MessageBox.Show("Изменения сохранены.");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window4 window4 = new Window4();
            window4.Show();
            this.Close();
        }
    }
}
