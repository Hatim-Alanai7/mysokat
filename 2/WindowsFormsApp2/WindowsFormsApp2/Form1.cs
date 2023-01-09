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
using System.Configuration;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        Socket sock = null;
        Socket Client = null;
        Thread trStart;
        Thread trRecive;
        private string label_text;
        const int sizeByte = 1024;

        public Form1()
        {
            InitializeComponent();
        }


    //    private void ReciveFile()
    //    {
    //        while (true)
    //        {
    //            try
    //            {
    //                byte[] b = new byte[sizeByte];
    //                int rec = 1;
    //                int vp = 0;
    //                rec = Client.Receive(b);

    //                int index;
    //                for (index = 0; index < b.Length; index++)
    //                    if (b[index] == 63)
    //                        break;
    //                string[] fInfo = Encoding.UTF8.GetString(b.Take(index).ToArray()).Split(':');
    //                this.Invoke((MethodInvoker)delegate
    //                {
    //                    progressBar1.Maximum = int.Parse(fInfo[0]);
    //                });
    //                string path = Application.StartupPath + "\\Downloads\\";
    //                if (!Directory.Exists(path))
    //                    Directory.CreateDirectory(path);
    //                FileStream fs = new FileStream(path + fInfo[1], FileMode.Append, FileAccess.Write);
    //                string strEnd;
    //                while (true)
    //                {
    //                    rec = Client.Receive(b);
    //                    vp = vp + rec;
    //                    strEnd = ((char)b[0]).ToString() + ((char)b[1]).ToString() + ((char)b[2]).ToString() + ((char)b[3]).ToString() + ((char)b[4]).ToString() + ((char)b[5]).ToString();
    //                    if (strEnd == "!endf!")
    //                    {
    //                        fs.Flush();
    //                        fs.Close();
    //                        MessageBox.Show("Receive File " + ((float)(float.Parse(fInfo[0]) / 1024)).ToString() + "  KB");
    //                        break;
    //                    }
    //                    fs.Write(b, 0, rec);
    //                    this.Invoke((MethodInvoker)delegate
    //                    {
    //                        progressBar1.Value = vp;
    //                    });
    //                }
    //            }
    //            catch (Exception ex)
    //            {
    //                MessageBox.Show(ex.Message);
    //                Form1_FormClosing(null, null);
    //            }
    //        }
    //    }
    //    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    //{
    //    try
    //    {
    //        trRecive.Abort();
    //        trStart.Abort();
    //        Environment.Exit(Environment.ExitCode);
    //    }
    //    catch (Exception)
    //    {
    //        Environment.Exit(Environment.ExitCode);
    //    }
    //}


        //private void StartSocket()
        //{
        //    Server.Listen(1);
        //    Client = Server.Accept();
        //    trRecive = new Thread(new ThreadStart(ReciveFile));
        //    trRecive.Start();
        //}
















        private void Form1_Load(object sender, EventArgs e)
        {
            //Socket Server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            //IPEndPoint IP = new IPEndPoint(IPAddress.Any, 5050);
            //Server.Bind(IP);
            //trStart = new Thread(new ThreadStart(StartSocket));
            //trStart.Start();

            
        }

        

        private void button1_Click(object sender, EventArgs e)
        {

            //OpenFileDialog fdl = new OpenFileDialog();
            //if (fdl.ShowDialog() == DialogResult.OK)
            //{
            //    //trRecive = new Thread(new ParameterizedThreadStart(SendFile));
            //    //trRecive.Start(fdl.FileName);
            //    textBox1.Text = fdl.FileName;
            //}

            //fdl = null;
        }

        private void sev_Click(object sender, EventArgs e)
        {
            //string receivedPath = ConfigurationManager.AppSettings["Location"];

            Socket Server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            var listener = new TcpListener(IPAddress.Any, 5656);
            
           

            try
            {
                listener.Start();

                label1.Text = label_text;
                label1.Refresh();



                //IPAddress[] ipAddress = Dns.GetHostAddresses("localhost");
                //IPEndPoint ipEnd = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5656);
                //Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
                //server.Connect(ipEnd);



                string ori_btn_text = button1.Text;
                button1.Text = "Do not click already waiting...";
                button1.Refresh();
                label1.Text = label1.Text + "\nWaiting for client";
                label1.Refresh();
                string receivedPath = ConfigurationManager.AppSettings["Location"];
                Socket clientSock = sock.Accept();
                label1.Text = label1.Text + "\nServer Started and connected to client" + clientSock.LocalEndPoint + "\nWaiting for the file to receive";
                label1.Refresh();
                int max = 1024 * 1024 * 10;

                string logfile = receivedPath + "\\serverlog.log";
                if (File.Exists(logfile))
                {
                    File.Delete(logfile);
                }

                FileStream fs = File.Create(logfile);
                byte[] serverdata = new byte[100];
                string fileName = "";
                int fileNameLen = 0, fileDataLen = 0;
                int i = 0;
                BinaryWriter bWrite = null;

                while (true)
                {
                    i += 1;

                    byte[] clientData = new byte[max];

                    int receivedBytesLen = clientSock.Receive(clientData);
                    if (receivedBytesLen <= 0)
                        break;

                    string tmp = "\nStarted:" + i;
                    fs.Write(Encoding.ASCII.GetBytes(tmp), 0, Encoding.ASCII.GetBytes(tmp).Length);
                    if (i == 1)
                    {
                        fileNameLen = BitConverter.ToInt32(clientData, 0);
                        fileName = Encoding.ASCII.GetString(clientData, 4, fileNameLen);
                        fileDataLen = BitConverter.ToInt32(clientData, 4);
                        if (File.Exists(receivedPath + fileName))
                        {
                            File.Delete(receivedPath + fileName);
                        }
                        bWrite = new BinaryWriter(File.Open(receivedPath + fileName, FileMode.Create));
                        label1.Text = label1.Text + "\nReceiving File:" + fileName;
                    }

                    label1.Text = label1.Text + "\nReceived " + i.ToString() + " block of file:" + fileName;
                    label1.Refresh();
                    bWrite.Write(clientData, 4 + fileNameLen, receivedBytesLen - 4 - fileNameLen);
                    Array.Clear(clientData, 0, clientData.Length);
                    clientData = null;
                    GC.Collect();

                    clientSock.Send(serverdata);
                    label1.Text = label1.Text + "\nSent confirmation for " + i.ToString() + " block of file:" + fileName;
                    label1.Refresh();
                }
                if (bWrite != null)
                {
                    bWrite.Flush();
                    bWrite.Dispose();
                    bWrite.Close();
                }
                fs.Close();
                label1.Text = label1.Text + "\nFile has been received:" + fileName;
                label1.Refresh();
                MessageBox.Show("File has been received:" + fileName);
                button1.Text = ori_btn_text;
                button1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("File Receiving fail." + ex.ToString());
            }
            finally
            {
                if (listener.Active)
                    listener.Stop();
            }
        }
    }
}


