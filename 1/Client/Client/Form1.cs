using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using Microsoft.VisualBasic;


namespace Client
{
    public partial class Form1 : Form
    {
        private TcpClient myclient981;
        private BinaryWriter mysw981;
        private NetworkStream networkStream;

        public Form1()
        {
            InitializeComponent();
        }


        



        private void button2_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif|Png Image|*.Png";
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.pictureBox1.Image = Image.FromFile(this.openFileDialog1.FileName);
            }
            try
            {
                openFileDialog1.ShowDialog();
                textBox3.Text = openFileDialog1.FileName;
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message);
            }
        }


       

        private void Form1_Load(object sender, EventArgs e)
        {
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
           
          
            Image a12 = pictureBox1.Image;
            MemoryStream MY_MemoryStream = new MemoryStream();
            a12.Save(MY_MemoryStream, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] ArrImage = MY_MemoryStream.GetBuffer(); // here change it to Bytes
            MY_MemoryStream.Close();
            try
            {
                myclient981 = new TcpClient(ip_TextBox1.Text, int.Parse(pore_textBox.Text));
                networkStream = myclient981.GetStream();
                mysw981 = new BinaryWriter(networkStream);
                mysw981.Write(ArrImage);
                networkStream.Close();
                myclient981.Close();

            }
            catch (Exception ex) 
            { 
                MessageBox.Show(ex.Message); 
            }

           

        }




        public void ds()
        {

            string strr = message_TextBox.Text;
            byte[] b = ASCIIEncoding.ASCII.GetBytes(strr);
            string s64 = Convert.ToBase64String(b);
            string type ="Image" ;
            string data = type + "||" + s64;
            //byte[] senddata = ASCIIEncoding.ASCII.GetBytes(data);
           
            //MemoryStream text = new MemoryStream(senddata);

            //string[] ss =data.Split(new string[] { "||" },StringSplitOptions.None);
            //string type1 = ss[0];


            try
            {
                myclient981 = new TcpClient(ip_TextBox1.Text, int.Parse(pore_textBox.Text));
                networkStream = myclient981.GetStream();
                mysw981 = new BinaryWriter(networkStream);
                mysw981.Write(data);
                networkStream.Close();
                myclient981.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }








        private void button1_Click(object sender, EventArgs e)
        {


            string strr = message_TextBox.Text;
            byte[] b = ASCIIEncoding.ASCII.GetBytes(strr);
            string s64 = Convert.ToBase64String(b);
            string type = "Image";
            string data = type + "||" + s64;
            //byte[] senddata = ASCIIEncoding.ASCII.GetBytes(data);

            //MemoryStream text = new MemoryStream(senddata);

            //string[] ss =data.Split(new string[] { "||" },StringSplitOptions.None);
            //string type1 = ss[0];


            try
            {
                myclient981 = new TcpClient(ip_TextBox1.Text, int.Parse(pore_textBox.Text));
                networkStream = myclient981.GetStream();
                mysw981 = new BinaryWriter(networkStream);
                mysw981.Write(data);
                networkStream.Close();
                myclient981.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }







            //String strr = message_TextBox.Text;
            //MemoryStream text = new MemoryStream();
            //ASCIIEncoding asen = new ASCIIEncoding();
            //byte[] ba = asen.GetBytes(strr);

            //try
            //{
            //    myclient981 = new TcpClient(ip_TextBox1.Text, int.Parse(pore_textBox.Text));
            //    networkStream = myclient981.GetStream();
            //    mysw981 = new BinaryWriter(networkStream);
            //    mysw981.Write(ba);
            //    networkStream.Close();
            //    myclient981.Close();

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}

        }
    }
}
