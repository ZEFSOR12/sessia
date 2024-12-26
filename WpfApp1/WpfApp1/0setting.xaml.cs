using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
using System.Data.SqlClient;
using System.Data;


namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для _0setting.xaml
    /// </summary>
    public partial class _0setting : Window
    {
        private string cone = "Data Source=stud-mssql.sttec.yar.ru,38325;Initial Catalog=user238_db;User ID=user238_db;Password=user238;Encrypt=False";

        public _0setting()
        {
            InitializeComponent();
            load();
        }
        private void load()
        {
            using (SqlConnection con = new SqlConnection(cone))
            {
                con.Open();
                string query = "SELECT * FROM [000polz]";

                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                DataTable usersTable = new DataTable();
                adapter.Fill(usersTable);
                bd.ItemsSource = usersTable.DefaultView;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string name = "Имя";
            string fam = "Фамилия";
            string Otch = "Отчество";
            using (SqlConnection con = new SqlConnection(cone))
            {
                con.Open();
                string query = "INSERT INTO [000polz] (im9, familia, otchestvo) VALUES (@im9, @familia, @otchestvo)";

                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@im9", name);
                    command.Parameters.AddWithValue("@familia", fam);
                    command.Parameters.AddWithValue("@otchestvo", Otch);

                    command.ExecuteNonQuery();
                    MessageBox.Show("Пользователь успешно добавлен!");
                    load();
                }
            }
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            using (SqlConnection con = new SqlConnection(cone))
            {
                var selectedUser = bd.SelectedItem as DataRowView;
                int userId = Convert.ToInt32(selectedUser["id_polz"]);

                con.Open();
                string query = "DELETE FROM [000polz] WHERE id_polz=@Id";

                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@Id", userId);

                    int rowsAffected = command.ExecuteNonQuery();

                    MessageBox.Show("Пользователь успешно удален!");
                    load();
                }
            }
        }

        private void Button_Click3(object sender, RoutedEventArgs e)
        {
            DataTable usersTable = ((DataView)bd.ItemsSource).Table;

            var selectedUser = bd.SelectedItem as DataRowView;
            int userId = Convert.ToInt32(selectedUser["id_polz"]);

            using (SqlConnection con = new SqlConnection(cone))
            {
                con.Open();

                foreach (DataRow row in usersTable.Rows)
                {
                    string name = row["im9"].ToString();
                    string fam = row["familia"].ToString();
                    string otch = row["otchestvo"].ToString();


                    string query = "UPDATE [000polz] SET im9 = @Name, familia = @familia, otchestvo=@otchestvo WHERE Id_polz = @Id";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Id", userId);

                        cmd.Parameters.AddWithValue("@Name", name);
                        cmd.Parameters.AddWithValue("@familia", fam);
                        cmd.Parameters.AddWithValue("@otchestvo", otch);

                        cmd.ExecuteNonQuery();
                    }
                }
            }

            load();
        }

        private void bd_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
