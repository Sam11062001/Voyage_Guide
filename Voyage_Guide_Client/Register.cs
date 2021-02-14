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
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void Register_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void registerBtn_Click(object sender, EventArgs e)
        {
            registerBtn.Enabled = false;
            //create the client side procy
            VoyageClient.RegisterServiceClient registerProxy = new VoyageClient.RegisterServiceClient();
            //create the object of the datacontract
            VoyageClient.UserRegister userRegister = new VoyageClient.UserRegister();
            //populating the user object with the values obtianed from the register form
            userRegister.email = emailtextbox.Text;
            userRegister.firstName = fnametextbox.Text;
            userRegister.lastName = lnametextbox.Text;
            userRegister.password = passwordtextbpx.Text;
            userRegister.username = usernametextbox.Text;

            //result represent the registration status
            bool result=registerProxy.registerUser(userRegister);
            if (result)
            {
                this.Hide();
                //successfull registeration
                Form1 f = new Form1();
                f.Show();
            }
            else
            {
                //succesfull registration
                registerBtn.Enabled = true;
            }
        }
    }
}
