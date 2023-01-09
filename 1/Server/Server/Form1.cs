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
using System.IO;
using System.Threading;
using Microsoft.VisualBasic;

namespace Server
{
    public partial class Form1 : Form
    {

        private TcpListener MYTcpListener;
        private Socket MySocket;
        private Thread myth;
        private StreamReader mysr;
        private NetworkStream MyNetworkStream;
        private TcpListener MYTcpListener1;
        private Socket MySocket1;
        private Thread myth1;


        public Form1()
        {
            InitializeComponent();
        }

        public void REcivedData()
        {
            try
            {
                MYTcpListener = new TcpListener(IPAddress.Any, int.Parse(pore_textBox.Text));
                MYTcpListener.Start();

                while (true)
                {
                    try
                    {
                        MySocket = MYTcpListener.AcceptSocket();
                        MyNetworkStream = new NetworkStream(MySocket);
                        mysr = new StreamReader(MyNetworkStream);
                        Console.Write(mysr);

                        string strr = message_TextBox.Text;
                        byte[] b = ASCIIEncoding.ASCII.GetBytes(strr);
                        string s64 = Convert.ToBase64String(b);
                        string type = "Image";
                        string data = type + "||" + s64;
                        //byte[] senddata = ASCIIEncoding.ASCII.GetBytes(data);

                        //MemoryStream text = new MemoryStream(senddata);

                        //string[] ss =data.Split(new string[] { "||" },StringSplitOptions.None);
                        //string type1 = ss[0];

                        string[] ss =data.Split(new string[] { "||" },StringSplitOptions.None);
                        string type1 = ss[0];
                        byte[] senddata = ASCIIEncoding.ASCII.GetBytes(ss[1]);
                        byte[] imge = Convert.FromBase64String(ss[1]);
                        switch (type1)
                        {
                            case "type1":
                                string x = mysr.ReadToEnd();
                                this.message_TextBox.Text = this.message_TextBox.Text + Constants.vbNewLine + x;
                                
                                MessageBox.Show(message_TextBox.Text);
                                break;

                        }

                        //string x = mysr.ReadToEnd();
                        //this.message_TextBox.Text = this.message_TextBox.Text + Constants.vbNewLine + x;
                        //MySocket.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            catch (Exception ex2)
            {
                MessageBox.Show(ex2.Message);
            }
        }


        


        void REcivedDataimage()
        {
            try
            {
                MYTcpListener1 = new TcpListener(IPAddress.Any,int.Parse(pore_textBox.Text));
                MYTcpListener1.Start();


                while (true)
                {
                    try
                    {
                        MySocket1 = MYTcpListener1.AcceptSocket();
                        MyNetworkStream = new NetworkStream(MySocket1);

                        this.pictureBox1.Image = Image.FromStream(MyNetworkStream);
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            catch (Exception ex2)
            {
                MessageBox.Show(ex2.Message);
            }
        }



            private void Form1_Load(object sender, EventArgs e)
        {

            myth = new Thread(new ThreadStart(REcivedData));
            myth.Start();
            myth1 = new Thread(new ThreadStart(REcivedDataimage));
            myth1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.listBox1.Items.Clear();
            this.listBox1.Items.Add("MySocket.TextBox=" + MySocket.RemoteEndPoint.ToString());
            this.listBox1.Items.Add("MySocket.Connected=" + MySocket.Connected);
            this.listBox1.Items.Add("MYTcpListener.LocalEndpoint=" + MYTcpListener.LocalEndpoint.ToString());
            this.listBox1.Items.Add("MYTcpListener.Server=" + MYTcpListener.Server.ToString());
            this.listBox1.Items.Add("MYTcpListener.ExclusiveAddressUse=" + MYTcpListener.ExclusiveAddressUse.ToString());
            this.listBox1.Items.Add("MySocket.Available=" + MySocket.Available);
        }
    }
}
