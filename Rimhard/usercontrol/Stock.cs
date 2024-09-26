using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rimhard.usercontrol
{
    public partial class Stock : Form
    {
        public Stock()
        {
            InitializeComponent();
        }
        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource=127.0.0.1; port=3306; username=root; password=; database = rimhard;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;
        }
        MySqlConnection connection = new MySqlConnection("datasource=127.0.0.1; port=3306; username=root; password=; database = rimhard;");

        private void showEquipment()
        {
            FillDGV("");
        }

        public void FillDGV(string valueToSearch)
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM stock WHERE CONCAT(id, name, amount ) LIKE '%" + valueToSearch + "%'", connection);

            MySqlDataAdapter adapter = new MySqlDataAdapter(command);

            DataTable table = new DataTable();

            adapter.Fill(table);

            dataEquipment.RowTemplate.Height = 30;

            dataEquipment.AllowUserToDeleteRows = false;

            dataEquipment.DataSource = table;



            dataEquipment.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void bt_menu(object sender, EventArgs e)
        {
            stock menu = new stock();
            menu.Show();
            this.Hide();
        }

        private void Stock_Load(object sender, EventArgs e)
        {
            showEquipment();
        }

        private void guna2DataGridView1_Click(object sender, EventArgs e)
        {
            if (dataEquipment.CurrentRow != null)
            {
                try
                {
                    tb_id.Text = dataEquipment.CurrentRow.Cells[0].Value.ToString();
                    tb_name.Text = dataEquipment.CurrentRow.Cells[1].Value.ToString();
                    tb_amount.Text = dataEquipment.CurrentRow.Cells[2].Value.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An unexpected error occurred: " + ex.Message);
                }
            }
        }

        private void bt_add(object sender, EventArgs e)
        {
            try
            {
                connection.Open(); // Open the connection

                MySqlCommand command = new MySqlCommand("INSERT INTO stock(id, name, amount) VALUES (@id, @name, @amount)", connection);
                command.Parameters.Add("@id", MySqlDbType.VarChar).Value = tb_id.Text;
                command.Parameters.Add("@name", MySqlDbType.VarChar).Value = tb_name.Text;
                command.Parameters.Add("@amount", MySqlDbType.Int32).Value = int.Parse(tb_amount.Text);

                command.ExecuteNonQuery(); // Execute the insert statement

                MessageBox.Show("Equipment added successfully!");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error adding equipment: " + ex.Message);
                // Log the exception for further debugging
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred: " + ex.Message);
                // Log the exception for further debugging
            }
            finally
            {
                connection.Close(); // Close the connection (recommended)
            }
            showEquipment();

        }

        private void bt_dell(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand("DELETE FROM stock WHERE id = @id", connection);
                command.Parameters.Add("@id", MySqlDbType.VarChar).Value = tb_id.Text;
                command.ExecuteNonQuery();
                showEquipment();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("An unexpected error occurred: " + ex.Message);
            }
            finally 
            { 
                connection.Close(); 
            }
        }

        private void bt_edit(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand("UPDATE stock SET name=@name,  amount=@amount, WHERE id = @id", connection);

                command.Parameters.Add("@id", MySqlDbType.VarChar).Value = tb_id.Text;
                command.Parameters.Add("@name", MySqlDbType.VarChar).Value = tb_name.Text;
                command.Parameters.Add("@amount", MySqlDbType.Int32).Value = int.Parse(tb_amount.Text);

                command.ExecuteNonQuery(); 
                showEquipment();
            } catch (MySqlException ex) 
            {
                MessageBox.Show("An unexpected error occurred: " + ex.Message);
            }
            finally 
            { 
                connection.Close(); 
            }
        }
    }   
}
