using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.ServiceModel;
namespace Voyage_Guide_Client
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
            label3.Visible = false;
        }

        [Obsolete]
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            label3.Visible = false;
            guna2Button1.Enabled = false;
            string username = guna2TextBox1.Text;
            string password = guna2TextBox2.Text;

            VoyageClient.AuthenticateUser authenticateUser = new VoyageClient.AuthenticateUser();

            VoyageClient.AuthServiceClient authProxy = new VoyageClient.AuthServiceClient();
            try
            {
                authenticateUser.VoyageUserName = username;
                authenticateUser.VoyagePassword = password;
                Boolean VoyageisAuthenticated = false;
                int UserID = authProxy.authenticateUser(authenticateUser.VoyagePassword, authenticateUser.VoyageUserName, out VoyageisAuthenticated);

                if (VoyageisAuthenticated)
                {
                    Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
                    config.AppSettings.Settings.Add("UserVoyageId", UserID.ToString());
                    config.Save(ConfigurationSaveMode.Minimal);
                    ConfigurationManager.RefreshSection("appSettings");
                    int UseridReterived = Int32.Parse(ConfigurationSettings.AppSettings["UserVoyageId"]);
                    dashboard d1 = new dashboard();

                    d1.Show();
                    this.Hide();

                }
                else
                {
                    label3.Visible = true;
                }

            }
            catch(TimeoutException execption)
            {
                MessageBox.Show("The service Operation is Timeout" + execption.Message);
                authProxy.Abort();
            }
            catch(FaultException<VoyageClient.Custom_Exception> exception)
            {
                MessageBox.Show("Message Title" + exception.Detail.Title + "\n" + " Error Message:" + exception.Detail.ExceptionMessage);
                authProxy.Abort();
            }
            catch (FaultException exception)
            {
                MessageBox.Show("Error Message:" + exception.Message);
            }
            catch (CommunicationException exception)
            {
                MessageBox.Show("Communication Error Occured, Message :" + exception.Message);

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
