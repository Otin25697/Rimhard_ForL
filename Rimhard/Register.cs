using MySql.Data.MySqlClient;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Rimhard
{
    public partial class Register : Form
    {
        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource=127.0.0.1; port=3306; username=root; password=; database=rimhard;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            return connection;
        }

        public Register()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = databaseConnection();

            try
            {
                conn.Open();

                string name = Txtname.Text;
                string surname = Txtsurname.Text;
                string tell = Txttell.Text;

            
                if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(surname) || string.IsNullOrWhiteSpace(tell))
                {
                    MessageBox.Show("แจ้งเตือนกรุณากรอกข้อมูลให้ครบทุกช่อง");
                    return;
                }

               
                if (!IsNameValid(name) || !IsSurnameValid(surname))
                {
                    MessageBox.Show("ชื่อและสกุลต้องเป็นภาษาอังกฤษเท่านั้น");
                    return;
                }

                // Validate phone number format (10 digits, numeric, starts with 0)
                if (!IsPhoneNumberValid(tell))
                {
                    MessageBox.Show("เบอร์โทรศัพท์ของคุณไม่ถูกต้อง กรุณากรอก 10 ตัวเลขและขึ้นต้นด้วยเลข 0");
                    return;
                }

                // Check for existing phone number
                string query = "SELECT COUNT(*) FROM user WHERE tell = @tell ";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@tell", tell);

                int count = Convert.ToInt32(cmd.ExecuteScalar());

                if (count > 0)
                {
                    MessageBox.Show("เบอร์ที่ต้องการลงทะเบียนของคุณซ้ำ");
                }
                else
                {
                    MySqlCommand cmd1 = new MySqlCommand("INSERT INTO user (name, surname, tell) VALUES (@name, @surname, @tell)", conn);
                    cmd1.Parameters.AddWithValue("@name", name);
                    cmd1.Parameters.AddWithValue("@surname", surname);
                    cmd1.Parameters.AddWithValue("@tell", tell);

                    cmd1.ExecuteNonQuery();
                    MessageBox.Show("สมัครสมาชิกสำเร็จ");

                    ShowMenu menu = new ShowMenu();
                    menu.Show();
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("error :" + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void button_cancel(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.Show();
            this.Hide();
        }

        private bool IsPhoneNumberValid(string phoneNumber)
        {
            
            return phoneNumber.Length == 10 && phoneNumber.StartsWith("0") && phoneNumber.All(char.IsDigit);
        }

        private bool IsNameValid(string name)
        {
         
            return Regex.IsMatch(name, @"^[a-zA-Z]+$");
        }

        private bool IsSurnameValid(string surname)
        {
           
            return Regex.IsMatch(surname, @"^[a-zA-Z]+$");
        }

        private void Register_Load(object sender, EventArgs e)
        {

        }
        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
