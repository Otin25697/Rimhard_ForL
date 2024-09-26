using MySql.Data.MySqlClient;
using QRCoder;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Diagnostics;

namespace Rimhard
{
    public partial class Payment : Form
    {
        decimal sumTotal;
        
        public Payment()
        {
            InitializeComponent();
        }

        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource=127.0.0.1; port=3306; username=root; password=; database = rimhard;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            return connection;
        }

        MySqlConnection connection = new MySqlConnection("datasource=127.0.0.1; port=3306; username=root; password=; database = rimhard;");

        public void FillDGV(string valueToSearch)
        {
            MySqlCommand command = new MySqlCommand("SELECT name, amount, price FROM prehistory", connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            dataEquipment.RowTemplate.Height = 30;
            dataEquipment.AllowUserToDeleteRows = false;
            dataEquipment.DataSource = table;
            dataEquipment.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void showEquipment()
        {
            FillDGV("");
        }

   

        private void bt_back(object sender, EventArgs e)
        {
            Table table = new Table();
            table.Show();
            this.Hide();
        }

        private void Payment_Load(object sender, EventArgs e)
        {
            
            showEquipment();
            
            SumTotalColumn();
            GenerateQRCode();
           
        }

        private void bt_submit(object sender, EventArgs e)
        {
            string tell = tb_telluser.Text;
            tb_sname.Text = "";

            MySqlCommand command = new MySqlCommand("SELECT name FROM user WHERE tell = @tell", connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            command.Parameters.AddWithValue("@tell", tell);

            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            if (dataTable.Rows.Count > 0)
            {
                decimal discount = 0;
                decimal final_total = 0;
                string userName = dataTable.Rows[0]["name"].ToString();
                tb_sname.Text = userName;
                discount = sumTotal * 5 / 100;
                tb_discount.Text = discount.ToString("N2");
                final_total = sumTotal - discount;
                tb_finaltotal.Text = final_total.ToString("N2");

               
                GenerateQRCode();



            }
            else
            {
                // Handle case where no user is found with the provided tell
                MessageBox.Show("User not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bt_finish(object sender, EventArgs e)
        {
            try
            {
                // Get user name
                string userName = tb_sname.Text;
                decimal amount = 0;
                // Get menu items and quantities
                string menuItems = "";
                foreach (DataGridViewRow row in dataEquipment.Rows)
                {
                    menuItems += row.Cells["name"].Value.ToString() + " x" + row.Cells["amount"].Value.ToString() + ", ";
                }
                menuItems = menuItems.TrimEnd(',', ' ');
                
                foreach (DataGridViewRow row in dataEquipment.Rows)
                {
                    amount += Convert.ToDecimal(row.Cells[1].Value);
                }

                // Get total price
                double totalPrice = Convert.ToDouble(tb_finaltotal.Text);

                // Get current date and time
                DateTime dateTime = DateTime.Now;

                // Insert data into history table
                MySqlConnection conn = databaseConnection();
                conn.Open();
                MySqlCommand command = new MySqlCommand("INSERT INTO history (user, menu, amount, price, datetime) VALUES (@user, @menu, @amount, @totalprice, @datetime)", conn);
                command.Parameters.AddWithValue("@user", userName);
                command.Parameters.AddWithValue("@menu", menuItems);
                command.Parameters.AddWithValue("@amount", amount);
                command.Parameters.AddWithValue("@totalprice", totalPrice);
                command.Parameters.AddWithValue("@datetime", dateTime);
                command.ExecuteNonQuery();
                conn.Close();

                // Generate PDF receipt
                GeneratePDFReceipt();

                // Clear prehistory table
                ClearDB();

                // Reset total column
                SumTotalColumn();

                // Show menu form
                Table table = new Table();
                table.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void GeneratePDFReceipt()
        {
            try
            {
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string fileName = "Receipt.pdf";
                string filePath = Path.Combine(desktopPath, fileName);

                // Check if the file already exists
                int count = 1;
                while (File.Exists(filePath))
                {
                    fileName = $"Receipt_{count}.pdf";
                    filePath = Path.Combine(desktopPath, fileName);
                    count++;
                }

                // Create PrintDocument
                PrintDocument pd = new PrintDocument();
                pd.PrintPage += new PrintPageEventHandler(GeneratePDFContent);

                // Set printer settings
                pd.PrinterSettings.PrintToFile = true;
                pd.PrinterSettings.PrintFileName = filePath;

                // Print document
                pd.Print();

                MessageBox.Show($"Receipt has been generated and saved to Desktop as {fileName}", "PDF Generated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Process.Start(new ProcessStartInfo(filePath) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generating PDF: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void GeneratePDFContent(object sender, PrintPageEventArgs e)
        {
            using (Font font = new Font("Arial", 12))
            {
                int startX = 10;
                int startY = 10;
                int offsetY = 20;

                e.Graphics.DrawString("RIMHARD", font, Brushes.Black, startX + 200, startY);
                startY += offsetY; 
                e.Graphics.DrawString("Address : Rimhard, Soi Buakhao, Pattaya Tell: 0944423705", font, Brushes.Black, startX + 200, startY);
                startY += offsetY; 
                e.Graphics.DrawString("Tax ID : 98-7654321", font, Brushes.Black, startX + 200, startY);

             
                startY = 10;

             
                e.Graphics.DrawString("Date: " + DateTime.Now.ToString("dd/MM/yyyy"), font, Brushes.Black, startX, startY + offsetY);

            
                e.Graphics.DrawString("User Name: " + tb_sname.Text, font, Brushes.Black, startX, startY + 2 * offsetY);

             
                e.Graphics.DrawString("Name", font, Brushes.Black, startX, startY + 4 * offsetY);
                e.Graphics.DrawString("Amount", font, Brushes.Black, startX + 200, startY + 4 * offsetY);
                e.Graphics.DrawString("Price", font, Brushes.Black, startX + 400, startY + 4 * offsetY);

              
                int tableX = startX;
                int tableY = startY + 6 * offsetY;
                int cellWidth = 200;
                int cellHeight = 20;

                for (int i = 0; i < dataEquipment.Rows.Count; i++)
                {
                    for (int j = 0; j < dataEquipment.Columns.Count; j++)
                    {
                        e.Graphics.DrawString(dataEquipment.Rows[i].Cells[j].Value.ToString(), font, Brushes.Black, tableX + j * cellWidth, tableY + i * cellHeight);
                    }
                }

                e.Graphics.DrawString("Price : " + tb_total.Text, font, Brushes.Black, startX, tableY + dataEquipment.Rows.Count * cellHeight +  offsetY);

                e.Graphics.DrawString("Discount 5% : " + tb_discount.Text, font, Brushes.Black, startX, tableY + dataEquipment.Rows.Count * cellHeight +2 * offsetY);

                e.Graphics.DrawString("VAT 7% : " + tb_vat.Text, font, Brushes.Black, startX, tableY + dataEquipment.Rows.Count * cellHeight + 3 * offsetY);

                e.Graphics.DrawString("Total : " + tb_finaltotal.Text, font, Brushes.Black, startX, tableY + dataEquipment.Rows.Count * cellHeight + 4 * offsetY);
            }
        }

        private void ClearDB()
        {
            try
            {
                MySqlConnection conn = databaseConnection();
                conn.Open();
                MySqlCommand command = new MySqlCommand("DELETE FROM prehistory", conn);
                command.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
            finally
            {
                MySqlConnection conn = databaseConnection();
                conn.Close();
            }
        }
        private void SumTotalColumn()
        {
            try
            {
                decimal total = 0;
                foreach (DataGridViewRow row in dataEquipment.Rows)
                {
                    total += Convert.ToDecimal(row.Cells[2].Value); 
                }

                sumTotal = total;
                tb_finaltotal.Text = sumTotal.ToString("N2");
                tb_total.Text = sumTotal.ToString("N2");
                decimal vat = sumTotal * 7 / 100;
                tb_vat.Text = vat.ToString("N2");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

       

        private void GenerateQRCode()
        {

            decimal totalValue;
            if (decimal.TryParse(tb_finaltotal.Text, out totalValue))
            {
                string totalValueString = totalValue.ToString("F2"); 
                string url = $"https://promptpay.io/0944423705/{totalValueString}";

                try
                {
                    using (WebClient webClient = new WebClient())
                    {
                        byte[] imageBytes = webClient.DownloadData(url);
                        using (MemoryStream memoryStream = new MemoryStream(imageBytes))
                        {
                            Image qrCodeImage = Image.FromStream(memoryStream);
                            PictureBox1.Image = new Bitmap(qrCodeImage);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error generating QR code: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Invalid total value for QR code generation.");
            }
        }


        private void dataEquipment_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void tb_total_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
