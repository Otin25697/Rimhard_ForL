using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rimhard
{
    public partial class Menu : Form
    {
        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource=127.0.0.1; port=3306; username=root; password=; database = rimhard;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            return connection;
        }
        MySqlConnection connection = new MySqlConnection("datasource=127.0.0.1; port=3306; username=root; password=; database = rimhard;");
        public Menu()
        {
            InitializeComponent();
        }

        private void showEquipment()
        {
            FillDGV("");
        }

        public void FillDGV(string valueToSearch)
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM menu WHERE CONCAT(id, name,  price, image) LIKE '%" + valueToSearch + "%'", connection);

            MySqlDataAdapter adapter = new MySqlDataAdapter(command);

            DataTable table = new DataTable();

            adapter.Fill(table);

            dataEquipment.RowTemplate.Height = 30;

            dataEquipment.AllowUserToDeleteRows = false;

            dataEquipment.DataSource = table;


            DataGridViewImageColumn imgCol = new DataGridViewImageColumn();
            imgCol = (DataGridViewImageColumn)dataEquipment.Columns[4];
            imgCol.ImageLayout = DataGridViewImageCellLayout.Stretch;

            dataEquipment.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void bt_back(object sender, EventArgs e)
        {
            ShowMenu SM = new ShowMenu();
            SM.Show();
            this.Hide();
        }

        private void dataEquipment_Click(object sender, EventArgs e)
        {
            try
            {
                Byte[] img = (Byte[])dataEquipment.CurrentRow.Cells[4].Value;

                MemoryStream ms = new MemoryStream(img);

                pictureBox1.Image = Image.FromStream(ms);

                tb_name.Text = dataEquipment.CurrentRow.Cells[1].Value.ToString();
             

            }

            catch { }
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            showEquipment();
        }

        private void dataEquipment_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void calculateTotal()
        {
            int totalSum = 0;

           
            if (dgv_showselect.Rows.Count > 0)
            {
                // Loop through each row
                foreach (DataGridViewRow row in dgv_showselect.Rows)
                {
                    
                    if (int.TryParse(row.Cells[2].Value?.ToString(), out int value))
                    {
                        totalSum += value;
                    }
                }
            }

            
            tb_total.Text = totalSum.ToString();
        }


        int n = 0;
        int sum = 0;


        private void bt_add(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tb_amount.Text))
            {
                MessageBox.Show("กรุณากรอกจำนวน");
                return; // Exit the function early if amount is empty
            }

            try
            {
                // Get selected menu item information
                int selectedRowIndex = dataEquipment.CurrentRow.Index;
                if (selectedRowIndex < 0)
                {
                    MessageBox.Show("กรุณาเลือกเมนูจากรายการ");
                    return; // Exit the function if no menu item is selected
                }

                string menuId = dataEquipment.Rows[selectedRowIndex].Cells[0].Value.ToString();
                Int64 currentAmount = 0; // Assuming a quantity column exists in the menu table

                // Retrieve current quantity from database (if applicable)
                MySqlCommand getAmountCmd = new MySqlCommand("SELECT amount FROM menu WHERE id = @menuId", connection);
                getAmountCmd.Parameters.AddWithValue("@menuId", menuId);
                connection.Open(); // Open connection for quantity retrieval

                using (MySqlDataReader reader = getAmountCmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        currentAmount = Convert.ToInt64(reader["amount"]);
                    }
                    reader.Close();
                }

                connection.Close(); // Close connection after quantity retrieval

                // Get amount entered by user
                Int64 amount = Int64.Parse(tb_amount.Text);

                // Validate amount against current quantity (if applicable)
                if (currentAmount > 0 && amount > currentAmount)
                {
                    MessageBox.Show($"ไม่สามารถสั่งเกิน {currentAmount} ชิ้น เนื่องจากสินค้าคงเหลือไม่เพียงพอ");
                    return; // Exit the function if amount exceeds available quantity
                }

                // Calculate new quantity (if applicable)
                Int64 newAmount = Math.Max(currentAmount - amount, 0); // Ensure new quantity is non-negative

                // Update quantity in database (if applicable)
                if (currentAmount > 0)
                {
                    MySqlCommand updateAmountCmd = new MySqlCommand("UPDATE menu SET amount = @newamount WHERE id = @menuId", connection);
                    updateAmountCmd.Parameters.AddWithValue("@newamount", newAmount);
                    updateAmountCmd.Parameters.AddWithValue("@menuId", menuId);

                    connection.Open(); // Open connection for quantity update
                    updateAmountCmd.ExecuteNonQuery();
                    connection.Close(); // Close connection after quantity update
                }

                // Check if item already exists in dgv_showselect
                bool itemExists = false;
                foreach (DataGridViewRow row in dgv_showselect.Rows)
                {
                    if (row.Cells[0].Value.ToString() == tb_name.Text)
                    {
                        // Update the existing row
                        Int64 existingAmount = Convert.ToInt64(row.Cells[1].Value);
                        Int64 newAmountInDGV = existingAmount + amount;
                        row.Cells[1].Value = newAmountInDGV;
                        string value = dataEquipment.CurrentRow.Cells[2].Value.ToString();
                        Int64 price = Int64.Parse(value);
                        row.Cells[2].Value = price * newAmountInDGV;

                        itemExists = true;
                        break;
                    }
                }

                // Add new item if it doesn't already exist
                if (!itemExists)
                {
                    n = dgv_showselect.Rows.Add();
                    dgv_showselect.Rows[n].Cells[0].Value = tb_name.Text;

                    string value = dataEquipment.CurrentRow.Cells[2].Value.ToString();
                    Int64 price = Int64.Parse(value);
                    sum = (int)(price * amount);

                    dgv_showselect.Rows[n].Cells[2].Value = sum;
                    dgv_showselect.Rows[n].Cells[1].Value = tb_amount.Text;
                }

                calculateTotal();
                showEquipment();
                dataEquipment.ClearSelection();
                tb_name.Clear();
                tb_amount.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาด: " + ex.Message);
            }
        }



        private void bt_remove(object sender, EventArgs e)
        {
            if (dgv_showselect.SelectedRows.Count > 0)
            {
                // Get the index of the selected row
                int selectedRowIndex = dgv_showselect.SelectedRows[0].Index;

                try
                {
                    // Get the name of the removed item
                    string removedItemName = dgv_showselect.Rows[selectedRowIndex].Cells[0].Value.ToString();

                    using (MySqlConnection connection = new MySqlConnection("datasource=127.0.0.1; port=3306; username=root; password=; database = rimhard;"))
                    {
                        connection.Open();

                        try
                        {
                            MySqlCommand findItemCmd = new MySqlCommand("SELECT id, amount FROM menu WHERE name = @name", connection);
                            findItemCmd.Parameters.AddWithValue("@name", removedItemName);

                            // Use ExecuteScalar to get single value
                            object result = findItemCmd.ExecuteScalar();


                            int currentAmount;

                            using (var reader = findItemCmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    currentAmount = Convert.ToInt32(reader["amount"]);
                                }
                                else
                                {
                                    // แสดงข้อความแจ้งเตือนว่าไม่พบรายการ
                                    MessageBox.Show("ไม่พบรายการที่ต้องการ");
                                    return;
                                }
                            }
                            if (result != null) // Check if result is not null
                            {
                                string menuId = result.ToString();


                                // Get the amount originally added from dgv_showselect (assuming it's stored in a column)
                                Int64 removedAmount = Convert.ToInt64(dgv_showselect.Rows[selectedRowIndex].Cells[1].Value); // Adjust cell index based on your data structure

                                // Calculate the new quantity in the menu table
                                Int64 newAmount = currentAmount + removedAmount;

                                // Update quantity in database (if applicable)
                                MySqlCommand updateQuantityCmd = new MySqlCommand("UPDATE menu SET amount = @newAmount WHERE id = @menuId", connection);
                                updateQuantityCmd.Parameters.AddWithValue("@newAmount", newAmount);
                                updateQuantityCmd.Parameters.AddWithValue("@menuId", menuId);
                                updateQuantityCmd.ExecuteNonQuery();
                            }
                            else
                            {
                                MessageBox.Show("ไม่พบรายการที่ต้องการ");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("เกิดข้อผิดพลาด: " + ex.Message);
                        }
                    } // Connection is automatically closed here

                    // Remove the selected row from the DataGridView
                    dgv_showselect.Rows.RemoveAt(selectedRowIndex);
                    calculateTotal();
                    showEquipment(); // Refresh the equipment list (optional)
                }
                catch
                {
                    MessageBox.Show("กรุณาเลือกช่องที่มีข้อมูล");
                }
                
            }
        }
        private void btcspecial_CheckedChanged(object sender, EventArgs e)
        {
         

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void tb_amount_TextChanged(object sender, EventArgs e)
        {

        }

        private void btcspecialmeat_CheckedChanged(object sender, EventArgs e)
        {
          
        }

        private void btcspecialsea_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void dgv_showselect_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bt_pay(object sender, EventArgs e)
        {
            if (dgv_showselect.Rows.Count == 0)
            {
                MessageBox.Show("ไม่มีรายการอาหาร");
                return;
            }

            try
            {
                using (MySqlConnection connection = new MySqlConnection("datasource=127.0.0.1; port=3306; username=root; password=; database = rimhard;"))
                {
                    connection.Open();

                    foreach (DataGridViewRow row in dgv_showselect.Rows)
                    {
                            
                            string name = row.Cells[0].Value.ToString();
                            Int64 amount = Convert.ToInt64(row.Cells[1].Value);
                            Int64 price = Convert.ToInt64(row.Cells[2].Value);
                            Int64 total = price * amount;

                            // Insert each item into the cart table
                            MySqlCommand insertCmd = new MySqlCommand("INSERT INTO cart (name, amount, price, total) VALUES (@name, @amount, @price, @total)", connection);
                            insertCmd.Parameters.AddWithValue("@name", name);
                            insertCmd.Parameters.AddWithValue("@amount", amount);
                            insertCmd.Parameters.AddWithValue("@price", price);
                            insertCmd.Parameters.AddWithValue("@total", tb_total.Text);
                            insertCmd.ExecuteNonQuery();
                            
                       
                    }

                    // Clear the selection table (dgv_showselect)
                    dgv_showselect.Rows.Clear();

                    // Reset total
                    tb_total.Text = "";

                    MessageBox.Show("สั่งอาหารเสร็จสิ้น");
                    
                    Table table = new Table();
                    table.Show();
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาด: " + ex.Message);
            }
        }

        private void tb_name_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
