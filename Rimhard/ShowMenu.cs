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
    public partial class ShowMenu : Form
    {
        public ShowMenu()
        {
            InitializeComponent();
        }
        MySqlConnection connection = new MySqlConnection("datasource=127.0.0.1; port=3306; username=root; password=; database = rimhard;");
       
    
        private void showEquipment()
        {
            FillDGV("");
        }

        public void FillDGV(string valueToSearch)
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM menu WHERE CONCAT(id, name,  price,amount, image) LIKE '%" + valueToSearch + "%'", connection);

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

        private void ShowMenu_Load(object sender, EventArgs e)
        {
            showEquipment();
        }

        private void bt_order(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void bt_back(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
