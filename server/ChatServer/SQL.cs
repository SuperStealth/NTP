using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace COURSED
{
    class Sql
    {
        public static string _connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\5semestr\BD\COURSED\COURSED\Database1.mdf;Integrated Security=True";
        public void FillDataGridViewByQuery(DataGridView dgv, string query)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = _connectionString;
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = query;
            DataTable dataTable = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(dataTable);
            dgv.DataSource = dataTable;
        }
    }
}
