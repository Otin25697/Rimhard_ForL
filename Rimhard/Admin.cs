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
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void bt_back(object sender, EventArgs e)
        {
            Form1 back = new Form1();   
            back.Show();
            this.Hide();
        }

        private void bt_stock(object sender, EventArgs e)
        {
            stock stock = new stock();
            stock.Show();
            this.Hide();
        }

        private void bt_employ(object sender, EventArgs e)
        {
          
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            SaleHistory saleHistory = new SaleHistory();
            saleHistory.Show();
            this.Hide();
        }

        private void Admin_Load(object sender, EventArgs e)
        {

        }
    }
}
