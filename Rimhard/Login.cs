using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Rimhard
{
    public partial class Login : Form

    {
        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource=127.0.0.1; port=3306; username=root; password=; database = rimhard;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;
        }
        public Login()
        {
            InitializeComponent();
        }

        private void Btsubmit(object sender, EventArgs e)
        {
           
            if (TxtUsername.Text != "rimhard" || Txtpassword.Text != "1234")
            {
                
                MySqlConnection conn = databaseConnection();
                try
                {
                    conn.Open();
                    string username = TxtUsername.Text;
                    string password = Txtpassword.Text;

                    string query = "SELECT COUNT(*) FROM employee WHERE username = @username AND password = @password";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    if(count > 0) 
                    {
                        MessageBox.Show("เข้าสู้ระบบสำเร็จ");
                        stock admin = new stock();
                        admin.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Username หรือ Password ผิดพลาด");
                    }

                }
                catch (Exception ex) 
                {
                    MessageBox.Show("error" + ex.Message);
                }
                finally 
                { 
                    conn.Close(); 
                    
                }

            }
            else
            {
                Admin admin = new Admin();
                admin.Show();
                this.Hide();
            }
        }

        private void button_cancel(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void TxtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
