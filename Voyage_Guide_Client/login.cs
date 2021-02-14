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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
            label3.Visible = false;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            label3.Visible = false;
            guna2Button1.Enabled = false;
            string username = guna2TextBox1.Text;
            string password = guna2TextBox2.Text;
            

            VoyageClient.RegisterServiceClient registerProxy = new VoyageClient.RegisterServiceClient();

            bool result = false;
            //result = registerProxy.authenticateUser( username , password );

            if (result)
            {
                dashboard d1 = new dashboard();
                d1.Show();
                this.Hide();
            }
            else
            {
                label3.Visible = true;
            }







        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register r1 = new Register();
            r1.Show();
            this.Hide();
        }
    }
}
