using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Voyage_Guide_Client
{
    public partial class dashboard : Form
    {
        public dashboard()
        {
            InitializeComponent();
            panel1.Hide();
            panel2.Hide();
            guna2Button2.Visible = false;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            panel1.Show();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            panel2.Show();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            panel1.Hide();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            panel2.Hide();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            guna2Button2.Visible = true;
        }
    }
}
