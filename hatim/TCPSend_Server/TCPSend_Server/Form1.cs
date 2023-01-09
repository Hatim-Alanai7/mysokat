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

namespace TCPSend_Server
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
        Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        IPEndPoint ipe = new IPEndPoint(IPAddress.Any, 6400);
        public Form1()
        {
            InitializeComponent();
        }

        //delegate void mydle(string d);

        //void Show(string msg)
        //{
        //    listBox1.Items.Add(msg);
        //}
        //void resv()
        //{
        //    //Socket c = s.Accept();
        //    while (true)
        //    {
        //        EndPoint ip = (EndPoint)ipe;
        //        byte[] bf = new byte[1000];
        //        s.ReceiveFrom(bf, ref ip);
        //        string msg = UnicodeEncoding.Unicode.GetString(bf);
        //        this.Invoke(new mydle(Show), msg);

        //    }
        //}

        public void REcivedData()
        {
            try
            {

                s.Bind(ipe);
                s.Listen(-1);
                s.Accept();


                while (true)
                {
                    try
                    {
                        byte[] b = ASCIIEncoding.ASCII.GetBytes(message_TextBox.Text);
                        string s64 = Convert.ToBase64String(b);
                        string type = "Image";
                        string data = type + "||" + s64;
                        //var senddata = Convert.FromBase64String(data);
                        //string text = textBox1.Text;
                        // split string 
                        string[] result = data.Split(new string[] { "||" }, StringSplitOptions.None);
                        //Console.Write("Result: ");
                        foreach (String str in result)
                        {
                            Console.Write(str + ", ");
                            this.Text = message_TextBox.Text;
                            //Socket r = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                            //IPEndPoint remote = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 6500);
                            //r.Connect(remote);
                            //r.SendFile(str);
                            //byte[] b = UnicodeEncoding.Unicode.GetBytes(textBox1.Text);
                            //r.SendTo(str, remote);

                            s.Close();



                        }
                        Console.ReadLine();



                        //string x = message_TextBox.Text;
                        //byte[] b = UnicodeEncoding.Unicode.GetBytes(x);
                        //string s64 = Convert.ToBase64String(b);
                        //string type = "Image";
                        //string data = type + "||" + s64;
                        //byte[] senddata = ASCIIEncoding.ASCII.GetBytes(data);

                        //MemoryStream text = new MemoryStream(senddata);

                        //string[] ss =data.Split(new string[] { "||" },StringSplitOptions.None);
                        //string type1 = ss[0];

                        //string[] ss =data.Split(new string[] { "||" },StringSplitOptions.None);
                        //string type1 = ss[0];
                        ////byte[] senddata = ASCIIEncoding.ASCII.GetBytes(ss[1]);
                        //byte[] imge = Convert.FromBase64String(ss[1]);

                        
                                
                              
                                
                                //MessageBox.Show(message_TextBox.Text);
                                

                        
                      
                        
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
                s.Bind(ipe);
                s.Listen(-1);
                s.Accept();


                while (true)
                {
                    try
                    {
                        //MySocket1 = MYTcpListener1.AcceptSocket();
                        MyNetworkStream = new NetworkStream(s);

                        this.pictureBox1.Image = Image.FromStream(MyNetworkStream);
                        s.Close();
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

        private void Form1_Load(object sender, EventArgs e)
        {
            myth = new Thread(new ThreadStart(REcivedData));
            myth.Start();
            myth1 = new Thread(new ThreadStart(REcivedDataimage));
            myth1.Start();
        }
    }
}
