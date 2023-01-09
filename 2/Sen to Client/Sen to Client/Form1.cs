using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.IO;

namespace Sen_to_Client
{
    public partial class Form1 : Form
    {

        //Thread trRecive;
        //const int sizeByte = 1024;
        //string splitter = "'\\'";
        //string fName;
        //string[] split = null;
        //Socket Client = null;
        public Form1()
        {
            InitializeComponent();
            //button5.Visible = false;
        }


        string n;
        byte[] b1;
        OpenFileDialog op;

        //Socket Clinet = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        //IPEndPoint IP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5050);






        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }



        //void SendFile()
        //{
          
        //     string txt= textBox3.Text;
            
            
        //    string filePath = null;
        //    int lastStatus = 0;
        //    MemoryStream memoryStream = new MemoryStream();
        //    FileStream file = new FileStream(filePath, FileMode.Open); 

        //    long totalBytes = file.Length, bytesSoFar = 0;
        //    Client.SendTimeout = 1000000; //timeout in milliseconds
        //    try
        //    {
        //        Client.Connect(IP);
        //        byte[] filechunk = new byte[4096];
        //        int numBytes;
        //        while ((numBytes = file.Read(filechunk, 0, 4096)) > 0)
        //        {
        //            if (Clinet.Send(filechunk, numBytes, SocketFlags.None) != numBytes)
        //            {
        //                throw new Exception("Error in sending the file");
        //            }
        //            bytesSoFar += numBytes;
        //            Byte progress = (byte)(bytesSoFar * 100 / totalBytes);
        //            if (progress > lastStatus && progress != 100)
        //            {
        //                Console.WriteLine("File sending progress:{0}", lastStatus);
        //                lastStatus = progress;
        //            }
        //        }
        //        Clinet.Shutdown(SocketShutdown.Both);
        //    }
        //    catch (SocketException e)
        //    {
        //        Console.WriteLine("Socket exception: {0}", e.Message.ToString());

        //    }
        //}



        








            private void button5_Click(object sender, EventArgs e)
            {
            TcpClient client = new TcpClient("SwtRascal", 5050);
            Stream s = client.GetStream();
            b1 = File.ReadAllBytes(op.FileName);
            s.Write(b1, 0, b1.Length);
            client.Close();
            textBox4.Text = "File Transferred....";

            //trRecive = new Thread(new ThreadStart(SendFile));
            // trRecive.Start();


        }

            private void button4_Click(object sender, EventArgs e)
            {
            //char[] delimiter = splitter.ToCharArray();
            //OpenFileDialog openFileDialog1 = new OpenFileDialog();
            //if (openFileDialog1.ShowDialog() == DialogResult.OK)
            //{

            //    textBox3.Text = openFileDialog1.FileName;
            //    textBox4.AppendText("Selected file " + textBox3.Text);
            //    button5.Visible = true;
            //}
            //else
            //{
            //    textBox4.AppendText("Please Select any one file to send");
            //    button5.Visible = false;
            //}

            //split = textBox3.Text.Split(delimiter);
            //int limit = split.Length;
            //fName = split[limit - 1].ToString();
            //if (textBox3.Text != null)
            //    button4.Enabled = true;




            op = new OpenFileDialog();
            if (op.ShowDialog() == DialogResult.OK)
            {
                string t = textBox1.Text;
                t = op.FileName;
                FileInfo fi = new FileInfo(textBox1.Text = op.FileName);
                n = fi.Name + "." + fi.Length;
                TcpClient client = new TcpClient("SwtRascal", 5055);
                StreamWriter sw = new StreamWriter(client.GetStream());
                sw.WriteLine(n);
                sw.Flush();
                label1.Text = "File Transferred....";
            }



        }

            //private void Form1_FormClosing(object sender, FormClosingEventArgs e)
            //{
            //    try
            //    {
            //        trRecive.Abort();
            //        Environment.Exit(Environment.ExitCode);
            //    }
            //    catch (Exception)
            //    {
            //        Environment.Exit(Environment.ExitCode);
            //    }
            //}

        private void button2_Click(object sender, EventArgs e)
        {
            //char[] delimiter = splitter.ToCharArray();
            //this.openFileDialog1.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif|Png Image|*.Png";
            //if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            //{
            //    this.pictureBox1.Image = Image.FromFile(this.openFileDialog1.FileName);
            //    textBox2.Text = openFileDialog1.FileName;
            //    textBox4.AppendText("Selected file " + textBox2.Text);
            //    button3.Visible = true;

            //}
            //else
            //{
            //    textBox4.AppendText("Please Select any one file to send");
            //    button5.Visible = false;
            //}

            //split = textBox3.Text.Split(delimiter);
            //int limit = split.Length;
            //fName = split[limit - 1].ToString();
            //if (textBox2.Text != null)
            //    button2.Enabled = true;
            
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Image a12 = pictureBox1.Image;
            //MemoryStream MY_MemoryStream = new MemoryStream();
            //a12.Save(MY_MemoryStream, System.Drawing.Imaging.ImageFormat.Jpeg);
            //byte[] ArrImage = MY_MemoryStream.GetBuffer(); // here change it to Bytes
            //MY_MemoryStream.Close();
            //try
            //{
            //    Client.SendTo(ArrImage, IP);
            //    Clinet.Close();

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
        //    //StreamReader str = File.OpenText(openFileDialog1.FileName);
        //    //textBox1.Text = str.ReadToEnd();
        //    String strr = textBox1.Text;
        //    MemoryStream text = new MemoryStream();
        //    ASCIIEncoding asen = new ASCIIEncoding();
        //    byte[] ba = asen.GetBytes(strr);


           
        //    //  this.textBox1.Text = listBox1.Text;
        //    //    textBox4.AppendText("Selected text " + textBox1.Text);
        //    //    button3.Visible = true;
        //    //listBox1.Show();






        //    try
        //    {
        //        Client.SendTo(ba, IP);
        //        Clinet.Close();

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }
    }
}




