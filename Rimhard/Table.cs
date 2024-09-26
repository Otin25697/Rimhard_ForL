using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rimhard
{
    public partial class Table : Form
    {


        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource=127.0.0.1; port=3306; username=root; password=; database = rimhard;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            return connection;
        }


        public Table()
        {
            InitializeComponent();
        }
        

        private void Bt_back(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.ShowDialog();
            this.Hide();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

        }

        private void checkState()

        {
            MySqlConnection conn = databaseConnection();
            conn.Open();
            string query = "SELECT COUNT(*) FROM table1 ";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            int count = Convert.ToInt32(cmd.ExecuteScalar());

            if (count > 0)
            {
                
                button1.BackColor = Color.Tomato;

            }
            else
            {
                button1.BackColor = Color.Snow;
            }
            
            string query1= "SELECT COUNT(*) FROM table2 ";
            MySqlCommand cmd1 = new MySqlCommand(query1, conn);
            int count1 = Convert.ToInt32(cmd1.ExecuteScalar());
            if (count1 > 0)
            {

                button2.BackColor = Color.Tomato;

            }
            else
            {
                button2.BackColor = Color.Snow;
            }

            string query2 = "SELECT COUNT(*) FROM table3 ";
            MySqlCommand cmd2 = new MySqlCommand(query2, conn);
            int count2 = Convert.ToInt32(cmd2.ExecuteScalar());
            if (count2 > 0)
            {

                button3.BackColor = Color.Tomato;

            }
            else
            {
                button3.BackColor = Color.Snow;
            }

            string query3 = "SELECT COUNT(*) FROM table4 ";
            MySqlCommand cmd3 = new MySqlCommand(query3, conn);
            int count3 = Convert.ToInt32(cmd3.ExecuteScalar());
            if (count3 > 0)
            {

                button4.BackColor = Color.Tomato;

            }
            else
            {
                button4.BackColor = Color.Snow;
            }
            string query4 = "SELECT COUNT(*) FROM table5 ";
            MySqlCommand cmd4 = new MySqlCommand(query4, conn);
            int count4 = Convert.ToInt32(cmd4.ExecuteScalar());
            if (count4 > 0)
            {

                button5.BackColor = Color.Tomato;

            }
            else
            {
                button5.BackColor = Color.Snow;
            }
            
            string query5 = "SELECT COUNT(*) FROM table6 ";
            MySqlCommand cmd5 = new MySqlCommand(query5, conn);
            int count5 = Convert.ToInt32(cmd5.ExecuteScalar());
            if (count5 > 0)
            {

                button6.BackColor = Color.Tomato;

            }
            else
            {
                button6.BackColor = Color.Snow;
            }
            conn.Close();
        }
        private void ClearDBcart()
        {
            try
            {
                MySqlConnection conn = databaseConnection();
                conn.Open();
                MySqlCommand command = new MySqlCommand("DELETE FROM cart", conn);
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
        private void ClearDBtable1()
        {
            try
            {
                MySqlConnection conn = databaseConnection();
                conn.Open();
                MySqlCommand command = new MySqlCommand("DELETE FROM table1", conn);
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
        private void ClearDBtable2()
        {
            try
            {
                MySqlConnection conn = databaseConnection();
                conn.Open();
                MySqlCommand command = new MySqlCommand("DELETE FROM table2", conn);
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
        private void ClearDBtable3()
        {
            try
            {
                MySqlConnection conn = databaseConnection();
                conn.Open();
                MySqlCommand command = new MySqlCommand("DELETE FROM table3", conn);
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
        private void ClearDBtable4()
        {
            try
            {
                MySqlConnection conn = databaseConnection();
                conn.Open();
                MySqlCommand command = new MySqlCommand("DELETE FROM table4", conn);
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
        private void ClearDBtable5()
        {
            try
            {
                MySqlConnection conn = databaseConnection();
                conn.Open();
                MySqlCommand command = new MySqlCommand("DELETE FROM table5", conn);
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
        private void ClearDBtable6()
        {
            try
            {
                MySqlConnection conn = databaseConnection();
                conn.Open();
                MySqlCommand command = new MySqlCommand("DELETE FROM table6", conn);
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
        private void opPayment()
        {
            Payment payment = new Payment();
            payment.Show();
            this.Hide();
        }

        private void bt_table1(object sender, EventArgs e)
        {
            
            MySqlConnection conn = databaseConnection();
            if(button1.BackColor == Color.Snow)
            {
                if(MessageBox.Show("ต้องการเลือกโต๊ะนี้ใช่หรือไม่","?",MessageBoxButtons.YesNo) == DialogResult.Yes)
                    
                    conn.Open();
                    string query = "INSERT INTO  table1 SELECT * FROM cart ";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.ExecuteNonQuery();

                    checkState();
                    ClearDBcart();
               
            }
            
            else if (button1.BackColor == Color.Tomato)
            {
                if (MessageBox.Show("จ่ายเงินใช่หรือไม่", "?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    conn.Open();
                    string query = "INSERT INTO  prehistory SELECT * FROM table1 ";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    opPayment();
                    ClearDBtable1();
                    checkState();
            }

        }


        private void bt_table2(object sender, EventArgs e)
        {
            MySqlConnection conn = databaseConnection();
            if (button2.BackColor == Color.Snow)
            {
                if (MessageBox.Show("ต้องการเลือกโต๊ะนี้ใช่หรือไม่", "?", MessageBoxButtons.YesNo) == DialogResult.Yes)

                   conn.Open();
                   string query = "INSERT INTO  table2 SELECT * FROM cart ";
                   MySqlCommand cmd = new MySqlCommand(query, conn);
                   cmd.ExecuteNonQuery();

                   checkState();
                   ClearDBcart();
            }
            else if (button2.BackColor == Color.Tomato)
            {
                if (MessageBox.Show("จ่ายเงินใช่หรือไม่", "?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    conn.Open();
                    string query = "INSERT INTO  prehistory SELECT * FROM table2 ";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.ExecuteNonQuery();

                    opPayment();
                    ClearDBtable2();
                    checkState();
            }
        }

        private void bt_table3(object sender, EventArgs e)
        {
            MySqlConnection conn = databaseConnection();
            if (button3.BackColor == Color.Snow)
            {
                if (MessageBox.Show("ต้องการเลือกโต๊ะนี้ใช่หรือไม่", "?", MessageBoxButtons.YesNo) == DialogResult.Yes)

                    conn.Open();
                    string query = "INSERT INTO  table3 SELECT * FROM cart ";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.ExecuteNonQuery();

                    checkState();
                    ClearDBcart();
            }
            else if (button3.BackColor == Color.Tomato)
            {
                if (MessageBox.Show("จ่ายเงินใช่หรือไม่", "?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    conn.Open();
                    string query = "INSERT INTO  prehistory SELECT * FROM table3 ";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.ExecuteNonQuery();

                    opPayment();
                    ClearDBtable3();
                    checkState();
            }
        }

        private void bt_table4(object sender, EventArgs e)
        {
            MySqlConnection conn = databaseConnection();
            if (button4.BackColor == Color.Snow)
            {
                if (MessageBox.Show("ต้องการเลือกโต๊ะนี้ใช่หรือไม่", "?", MessageBoxButtons.YesNo) == DialogResult.Yes)

                    conn.Open();
                    string query = "INSERT INTO  table4 SELECT * FROM cart ";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.ExecuteNonQuery();

                    checkState();
                    ClearDBcart();
            }
            else if (button4.BackColor == Color.Tomato)
            {
                if (MessageBox.Show("จ่ายเงินใช่หรือไม่", "?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    conn.Open();
                    string query = "INSERT INTO  prehistory SELECT * FROM table4 ";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.ExecuteNonQuery();

                    opPayment();
                    ClearDBtable4();
                    checkState();
            }
        }

        private void bt_table5(object sender, EventArgs e)
        {
            MySqlConnection conn = databaseConnection();
            if (button5.BackColor == Color.Snow)
            {
                if (MessageBox.Show("ต้องการเลือกโต๊ะนี้ใช่หรือไม่", "?", MessageBoxButtons.YesNo) == DialogResult.Yes)

                    conn.Open();
                    string query = "INSERT INTO  table5 SELECT * FROM cart ";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.ExecuteNonQuery();

                    checkState();
                    ClearDBcart();
            }
            else if (button5.BackColor == Color.Tomato)
            {
                if (MessageBox.Show("จ่ายเงินใช่หรือไม่", "?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    conn.Open();
                    string query = "INSERT INTO  prehistory SELECT * FROM table5 ";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.ExecuteNonQuery();

                    opPayment();
                    ClearDBtable5();
                    checkState();
            }
        }

        private void bt_table6(object sender, EventArgs e)
        {
            MySqlConnection conn = databaseConnection();
            if (button6.BackColor == Color.Snow)
            {
                if (MessageBox.Show("ต้องการเลือกโต๊ะนี้ใช่หรือไม่", "?", MessageBoxButtons.YesNo) == DialogResult.Yes)

                    conn.Open();
                    string query = "INSERT INTO  table6 SELECT * FROM cart ";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.ExecuteNonQuery();

                    checkState();
                    ClearDBcart();
            }
            else if (button6.BackColor == Color.Tomato)
            {
                if (MessageBox.Show("จ่ายเงินใช่หรือไม่", "?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    conn.Open();
                    string query = "INSERT INTO  prehistory SELECT * FROM table6 ";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.ExecuteNonQuery();

                    opPayment();
                    ClearDBtable6();
                    checkState();
            }
        }

        private void Table_Load(object sender, EventArgs e)
        {
            checkState();
        }
    }
}
