using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace Rimhard
{
    public partial class SaleHistory : Form
    {
        public SaleHistory()
        {
            InitializeComponent();
        }

        private MySqlConnection CreateDatabaseConnection()
        {
            string connectionString = "server=127.0.0.1;port=3306;username=root;password=;database=rimhard;";
            return new MySqlConnection(connectionString);
        }

        private void SaleHistory_Load(object sender, EventArgs e)
        {
            
        }

        private void dayPicker_ValueChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = dayPicker.Value.Date;

            using (MySqlConnection connection = CreateDatabaseConnection())
            {
                connection.Open();

                
                string historyQuery = @"SELECT * FROM history 
                                       WHERE DATE(datetime) = @selectedDate";
                using (MySqlCommand historyCmd = new MySqlCommand(historyQuery, connection))
                {
                    historyCmd.Parameters.AddWithValue("@selectedDate", selectedDate);
                    DataTable dtHistory = new DataTable();
                    MySqlDataAdapter historyAdapter = new MySqlDataAdapter(historyCmd);
                    historyAdapter.Fill(dtHistory);

                    DGV.DataSource = dtHistory;
                }

             
                string priceQuery = @"SELECT SUM(price) AS TotalPrice
                                     FROM history
                                     WHERE DATE(datetime) = @selectedDate"; 
                using (MySqlCommand priceCmd = new MySqlCommand(priceQuery, connection))
                {
                    priceCmd.Parameters.AddWithValue("@selectedDate", selectedDate);
                    object result = priceCmd.ExecuteScalar();
                    decimal totalPrice = result != DBNull.Value ? Convert.ToDecimal(result) : 0;

                    tb_day.Text = totalPrice.ToString("N2"); 
                }
            }
        }
        private void monthPicker2_ValueChanged(object sender, EventArgs e)
        {
            int selectedMonth = monthPicker2.Value.Month;
            int selectedYear = monthPicker2.Value.Year;

            using (MySqlConnection connection = CreateDatabaseConnection())
            {
                connection.Open();

               
                string historyQuery = @"SELECT * FROM history 
                                       WHERE MONTH(datetime) = @selectedMonth AND YEAR(datetime) = @selectedYear";
                using (MySqlCommand historyCmd = new MySqlCommand(historyQuery, connection))
                {
                    historyCmd.Parameters.AddWithValue("@selectedMonth", selectedMonth);
                    historyCmd.Parameters.AddWithValue("@selectedYear", selectedYear);
                    DataTable dtHistory = new DataTable();
                    MySqlDataAdapter historyAdapter = new MySqlDataAdapter(historyCmd);
                    historyAdapter.Fill(dtHistory);

                    DGV.DataSource = dtHistory; // Update DataGridView
                }

               
                string priceQuery = @"SELECT SUM(price) AS TotalPrice
                                     FROM history
                                     WHERE MONTH(datetime) = @selectedMonth AND YEAR(datetime) = @selectedYear";
                using (MySqlCommand priceCmd = new MySqlCommand(priceQuery, connection))
                {
                    priceCmd.Parameters.AddWithValue("@selectedMonth", selectedMonth);
                    priceCmd.Parameters.AddWithValue("@selectedYear", selectedYear);
                    object result = priceCmd.ExecuteScalar();
                    decimal totalPrice = result != DBNull.Value ? Convert.ToDecimal(result) : 0;

                    tb_month.Text = totalPrice.ToString("N2"); 
                }
            }
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Admin admin = new Admin();
            admin.Show();
            this.Hide();
        }
    }
}
