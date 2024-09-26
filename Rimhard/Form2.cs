using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rimhard
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
           Form1 frm1 = new Form1();   
            frm1.Show();
            this.Hide();
        }

        private void Btlogin(object sender, EventArgs e)
        {
            Login login1 = new Login();
            login1.Show();
            this.Hide();
        }

        private void Button_register(object sender, EventArgs e)
        {
            Register register = new Register();
            register.Show();
            this.Hide();
        }

        private void Bt_guest(object sender, EventArgs e)
        {
            ShowMenu menu = new ShowMenu(); 
            menu.Show();
            this.Hide();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        } 

        private void button1_Click(object sender, EventArgs e)
        {
            Table payment = new Table();
            payment.Show();
            this.Hide();
        }
    }
}
