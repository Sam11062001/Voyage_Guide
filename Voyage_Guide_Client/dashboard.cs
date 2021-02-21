using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.ServiceModel;
namespace Voyage_Guide_Client
{
    public partial class dashboard : Form
    {
        public dashboard()
        {
            InitializeComponent();
            panel1.Hide();
            panel2.Hide();
         
            Voyage_Data_Grid.Hide();
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
            Voyage_Data_Grid.Show();
            guna2Button2.Visible = true;
            //getting the data from the textboxes
            string state = statetxtbox.Text;
            string city = citytxtbox.Text;

            //Creating the instance of the service proxy 
            VoyageClient.VoyageDataSerrviceClient dataProxy = new VoyageClient.VoyageDataSerrviceClient();

            //getting the result from the service
            int results = dataProxy.getResultNumber(state, city);

            //getting the content from the service
            VoyageClient.ImageDataContent[] imageDataContents = dataProxy.getImageDataContent(state, city, results);

             Voyage_Data_Grid.DataSource = imageDataContents;
             Voyage_Data_Grid.AutoResizeColumns();
              Voyage_Data_Grid.AutoResizeRows();

            //Voyage_Data_Grid.Columns.Add("UserId", "Number");
            //Voyage_Data_Grid.Columns.Add("firstName", "First Name");
            //Voyage_Data_Grid.Columns.Add("lastName", "Last Name");
            //Voyage_Data_Grid.Columns.Add("VoyageContent", "User Thoughts");
            //Voyage_Data_Grid.Columns.Add("imageData", "User Uploaded Photos");

           
            //for(int i = 0; i < results; i++)
            //{

            //    DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            //    imageColumn.Image = Bitmap.FromStream(new MemoryStream(imageDataContents[i].imageData));
            //    Voyage_Data_Grid.Rows.Add(new Object[] { i + 1, imageDataContents[i].firstName, imageDataContents[i].lastName, imageDataContents[i].VoyageContent, imageColumn });
           
            //}
            //Voyage_Data_Grid.AutoResizeRows();
            //Voyage_Data_Grid.AutoResizeColumns();




        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void opendialogBox_Click(object sender, EventArgs e)
        {
            OpenFileDialog imageDialog = new OpenFileDialog();
            imageDialog.ShowDialog();
            imageDialog.InitialDirectory = @"C:\";
            imageDialog.RestoreDirectory = true;
            imageDialog.Title = "Browse Image Files";
            imageDialog.DefaultExt = "png";
            imageDialog.Filter = "png files (*.png)|*.jpeg|All files (*.*)|*.*";
            imageDialog.FilterIndex = 2;
            imageDialog.CheckFileExists = true;
            imageDialog.CheckPathExists = true;
            string ImagePath = imageDialog.FileName;
            byte[] imageByte = File.ReadAllBytes(ImagePath);


            



        }

         static string newImagePath;
        private void browseBtn_Click(object sender, EventArgs e)
        {

            OpenFileDialog browseDialog = new OpenFileDialog();
            browseDialog.ShowDialog();
            browseDialog.InitialDirectory = @"C:\";
            browseDialog.RestoreDirectory = true;
            browseDialog.Title = "Browse Image Files";
            browseDialog.DefaultExt = "png";
            browseDialog.Filter = "png files (*.png)|*.jpeg|All files (*.*)|*.*";
            browseDialog.FilterIndex = 2;
            browseDialog.CheckFileExists = true;
            browseDialog.CheckPathExists = true;
            newImagePath = browseDialog.FileName;
           

          




        }

        [Obsolete]
        private void guna2Button4_Click(object sender, EventArgs e)
        {
            VoyageClient.VoyageDataSerrviceClient dataProxy = new VoyageClient.VoyageDataSerrviceClient();
            try
            {
                VoyageClient.VoyageData  data= new VoyageClient.VoyageData();
                data.UserId = Int32.Parse(ConfigurationSettings.AppSettings["UVID3"]);
                data.imageData = File.ReadAllBytes(newImagePath);
                data.VoyageContent = contentTextBox.Text;
                data.VoyageState = stateTextBox.Text;
                data.VoyageCity =cityTextBox.Text;

                bool result=dataProxy.addNewVoyageData(data);
                MessageBox.Show("Your Data is succesfully stored!!!" + "\n" + "Thank You for your contribution");

                contentTextBox.Text = "";
                stateTextBox.Text = "";
                cityTextBox.Text = "";
                panel1.Hide();


            }
            catch (TimeoutException execption)
            {
                MessageBox.Show("The service Operation is Timeout" + execption.Message);
                dataProxy.Abort();
            }
            catch (FaultException<VoyageClient.Custom_Exception> exception)
            {
                MessageBox.Show("Message Title" + exception.Detail.Title + "\n" + " Error Message:" + exception.Detail.ExceptionMessage);
                dataProxy.Abort();
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

        private void dashboard_Load(object sender, EventArgs e)
        {
           
           


        }
        public static Bitmap ByteToImage(byte[] blob)
        {
            MemoryStream mStream = new MemoryStream();
            byte[] pData = blob;
            mStream.Write(pData, 0, Convert.ToInt32(pData.Length));
            Bitmap bm = new Bitmap(mStream, false);
            mStream.Dispose();
            return bm;
        }
        private void demoImage_Click(object sender, EventArgs e)
        {

        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);

            config.AppSettings.Settings.Remove("UVID3");
            config.Save(ConfigurationSaveMode.Modified);
            this.Close();
        }
    }
}
