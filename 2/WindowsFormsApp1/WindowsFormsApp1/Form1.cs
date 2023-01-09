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


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        //Socket Client = null;
        //Thread trRecive;
        const int sizeByte = 1024;
        //public string SendingFilePath = string.Empty;
        //private const int BufferSize = 1024;
        public Form1()
        {
            InitializeComponent();
        }


      


        //private void SendFile(object FName)
        //{

        //    try
        //    {

        //        FileInfo inf = new FileInfo((string)FName);
        //        progressBar1.Invoke((MethodInvoker)delegate
        //        {
        //            progressBar1.Maximum = 0;
        //            progressBar1.Value = 0;
        //        });
        //        FileStream f = new FileStream((string)FName, FileMode.Open);
        //        byte[] fsize = Encoding.UTF8.GetBytes(inf.Length.ToString() + ":");
        //        byte[] fname = Encoding.UTF8.GetBytes(inf.Name + "?");
        //        byte[] fInfo = new byte[sizeByte];
        //        fsize.CopyTo(fInfo, 0);
        //        fname.CopyTo(fInfo, fsize.Length);
        //        Client.Send(fInfo);
        //        if (sizeByte > f.Length)
        //        {
        //            byte[] b = new byte[f.Length];
        //            f.Seek(0, SeekOrigin.Begin);
        //            f.Read(b, 0, (int)f.Length);
        //            Client.Send(b);
        //        }
        //        else
        //        {
        //            for (int i = 0; i < (f.Length - sizeByte); i = i + sizeByte)
        //            {
        //                byte[] b = new byte[sizeByte];
        //                f.Seek(i, SeekOrigin.Begin);
        //                f.Read(b, 0, b.Length);
        //                Client.Send(b);
        //                progressBar1.Invoke((MethodInvoker)delegate
        //                {
        //                    progressBar1.Value = i;
        //                });
        //                if (i + sizeByte >= f.Length - sizeByte)
        //                {
        //                    progressBar1.Invoke((MethodInvoker)delegate
        //                    {
        //                        progressBar1.Value = (int)f.Length;
        //                    });
        //                    int ind = (int)f.Length - (i + sizeByte);
        //                    byte[] ed = new byte[ind];
        //                    f.Seek(i + sizeByte, SeekOrigin.Begin);
        //                    f.Read(ed, 0, ed.Length);
        //                    Client.Send(ed);
        //                }
        //            }

        //        }
        //        f.Close();
        //        Thread.Sleep(1000);
        //        Client.Send(Encoding.UTF8.GetBytes("!endf!"));
        //        Thread.Sleep(1000);
        //        MessageBox.Show("Send File " + ((float)inf.Length / 1024).ToString() + "  KB");
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }

        //}





        private void Form1_Load(object sender, EventArgs e)
        {

            //Socket Server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            //IPEndPoint IP = new IPEndPoint(IPAddress.Any, 5050);
            //Server.Bind(IP);
            //Thread trStart = new Thread(new ThreadStart(StartSocket));
            //trStart.Start();


            progressBar1.Visible = true;
            progressBar1.Minimum = 1;
            progressBar1.Value = 1;
            progressBar1.Step = 1;

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
            OpenFileDialog fdl = new OpenFileDialog();
            if (fdl.ShowDialog() == DialogResult.OK)
            {
                //trRecive = new Thread(new ParameterizedThreadStart(SendFile));
                //trRecive.Start(fdl.FileName);
                textBox1.Text = fdl.FileName;
            }

            fdl = null;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime startdate = DateTime.Now;
                string ori_text = button2.Text;
                button2.Text = "Do not click already sending...";
                button2.Refresh();
                IPAddress[] ipAddress = Dns.GetHostAddresses("localhost");
                IPEndPoint ipEnd = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5656);
                Socket clientSock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
                clientSock.Connect(ipEnd);

                label1.Text = label1.Text + "\nConnected to:" + ipEnd.Address.ToString();
                label1.Refresh();

                string fileName = "CCCCCC.zip"; //It has size greater than 2 GB
                string filePath = @"C:\Users\CCCCCC\Downloads\";
                byte[] fileNameByte = Encoding.ASCII.GetBytes(fileName);

                label1.Text = label1.Text + "\nSending the file:" + fileName;
                label1.Refresh();
                FileInfo fi = new FileInfo(filePath + fileName);

                int max = 1024 * 1024 * 10;
                long start = 0, bytesRead = 0;
                FileStream fileStream = new FileStream(filePath + fileName, FileMode.Open, FileAccess.Read);
                max = max - (4 + fileNameByte.Length);
                byte[] tmpserver = new byte[100];

                using (fileStream)
                {
                    int i = 0;
                    while (start < fi.Length)
                    {
                        i += 1;

                        label1.Text = label11.Text + "\nSending " + i.ToString() + " block of file:" + fileName;
                        label1.Refresh();

                        fileStream.Seek(start, SeekOrigin.Begin);
                        if (max > (fi.Length - start))
                            max = Convert.ToInt32(fi.Length - start);

                        byte[] buffer = new byte[max];
                        byte[] clientData = new byte[4 + fileNameByte.Length + max];
                        byte[] fileNameLen = BitConverter.GetBytes(fileNameByte.Length);
                        fileNameLen.CopyTo(clientData, 0);
                        fileNameByte.CopyTo(clientData, 4);

                        bytesRead = fileStream.Read(buffer, 0, max);
                        start += max;
                        buffer.CopyTo(clientData, 4 + fileNameByte.Length);
                        clientSock.Send(clientData);

                        Array.Clear(clientData, 0, clientData.Length);
                        Array.Clear(buffer, 0, buffer.Length);
                        Array.Clear(fileNameLen, 0, fileNameLen.Length);
                        Array.Clear(clientData, 0, clientData.Length);
                        clientData = null;
                        buffer = null;
                        fileNameLen = null;
                        GC.Collect();

                        label1.Text = label1.Text + "\nWaiting for confirmation of " + i.ToString() + " block of file:" + fileName;

                        int serverdata = clientSock.Receive(tmpserver);
                        if (serverdata == 0)
                        {
                            clientSock.Shutdown(SocketShutdown.Both);
                            clientSock.Close();
                            break;
                        }
                        else
                        {
                            label1.Text = label1.Text + "\nReceived confirmation for " + i.ToString() + " block of file:" + fileName;
                            label1.Refresh();
                        }
                    }
                }


                clientSock.Close();
                DateTime enddate = DateTime.Now;
                TimeSpan diff = startdate - enddate;
                label1.Text = label1.Text + "\nFile " + fileName + " has been sent to:" + ipEnd.Address.ToString();
                label1.Text = label1.Text + "\nTime Taken to sent the file(seconds):" + Math.Abs(diff.Seconds).ToString();
                label1.Refresh();
                button2.Text = ori_text;
                button2.Refresh();

            }
            catch (Exception ex)
            {
                MessageBox.Show("File Sending fail." + ex.ToString());
            }


        }


    }
}
