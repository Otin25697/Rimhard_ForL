using MySql.Data.MySqlClient;
using Rimhard.usercontrol;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rimhard
{
    public partial class stock : Form
    {
        MySqlConnection connection = new MySqlConnection("datasource=127.0.0.1; port=3306; username=root; password=; database = rimhard;");
        public stock()
        {
            InitializeComponent();
        }
        private void showEquipment()
        {
            FillDGV("");
        }
        
        public void FillDGV(string valueToSearch)
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM menu WHERE CONCAT(id, name, price,amount, image) LIKE '%" + valueToSearch + "%'", connection);

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
        private void bt_menu(object sender, EventArgs e)
        {

        }

        private void bt_stock(object sender, EventArgs e)
        {
            Stock stock = new Stock();
            stock.Show();
            this.Hide();
        }

        private void guna2DataGridView1_Click(object sender, EventArgs e)
        {
            try
            {
                Byte[] img = (Byte[])dataEquipment.CurrentRow.Cells[4].Value;

                MemoryStream ms = new MemoryStream(img);

                pictureBox1.Image = Image.FromStream(ms);

                tb_id.Text = dataEquipment.CurrentRow.Cells[0].Value.ToString();
                tb_name.Text = dataEquipment.CurrentRow.Cells[1].Value.ToString();
                tb_price.Text = dataEquipment.CurrentRow.Cells[2].Value.ToString();
                tb_amount.Text = dataEquipment.CurrentRow.Cells[3].Value.ToString();
            }

            catch { }
            
        }

        private void bt_back(object sender, EventArgs e)
        {
            Admin admin = new Admin();
            admin.Show();
            this.Hide();    
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Admin_Load(object sender, EventArgs e)
        {
            showEquipment();
        }

        private void bt_add_img(object sender, EventArgs e)
        {
            
        }

        private void bt_add(object sender, EventArgs e)
        {
            MemoryStream ms = new MemoryStream();
            pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
            byte[] img = ms.ToArray();

            MySqlCommand command = new MySqlCommand("INSERT INTO menu(id, name,  price, amount, image) VALUES (@id, @name,  @price, @amount, @image)", connection);

            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = tb_id.Text;
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = tb_name.Text;
            command.Parameters.Add("@amount", MySqlDbType.VarChar).Value = tb_amount.Text;
            command.Parameters.Add("@price", MySqlDbType.VarChar).Value = tb_price.Text;
            command.Parameters.Add("@image", MySqlDbType.Blob).Value = img;

            ExecMyQuery(command, "Data Inserted");
        }

        private void bt_delete(object sender, EventArgs e)
        {
            MemoryStream ms = new MemoryStream();
            pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
            byte[] img = ms.ToArray();

            MySqlCommand command = new MySqlCommand("DELETE FROM menu WHERE id = @id", connection);

            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = tb_id.Text;

            //นำไปที่ ExecMyQuery เพื่อตรวจสอบความถูกต้อง
            ExecMyQuery(command, "Data Deleted");
        }

        private void bt_edit(object sender, EventArgs e)
        {
            MemoryStream ms = new MemoryStream();
            pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
            byte[] img = ms.ToArray();

            MySqlCommand command = new MySqlCommand("UPDATE menu SET name=@name, price=@price,amount=@amount, image=@image WHERE id = @id", connection);

            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = tb_id.Text;
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = tb_name.Text;
            command.Parameters.Add("@amount", MySqlDbType.VarChar).Value = tb_amount.Text;
            command.Parameters.Add("@price", MySqlDbType.VarChar).Value = tb_price.Text;
            command.Parameters.Add("@image", MySqlDbType.Blob).Value = img;

            //นำไปที่ ExecMyQuery เพื่อตรวจสอบความถูกต้อง
            ExecMyQuery(command, "Data Update");
        }

        public void ExecMyQuery(MySqlCommand mcomd, String myMsg)
        {
            try
            {
                connection.Open();
                if (mcomd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show(myMsg);
                }
                else
                {
                    MessageBox.Show("Query Not Executed");
                }
                connection.Close();

                FillDGV("");
            } 
            catch (Exception ex) 
            {
                MessageBox.Show("error", ex.Message);
            }
        }

        private void bt_exit(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tb_price_TextChanged(object sender, EventArgs e)
        {

        }

        private void tb_search_TextChanged(object sender, EventArgs e)
        {
            FillDGV(tb_search.Text);
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Choose Image(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";

            if (opf.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(opf.FileName);
            }
        }

        private void tb_id_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataEquipment_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
