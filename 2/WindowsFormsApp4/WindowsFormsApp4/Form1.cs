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

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {


        Thread t1;
        int flag = 0;
        string receivedPath = "yok";
        public delegate void MyDelegate();
        private string fileName;


        public Form1()
        {
            t1 = new Thread(new ThreadStart(StartListening));
            t1.Start();
            InitializeComponent();
        }
        public class StateObject
        {
            // Client socket.
            public Socket workSocket = null;

            public const int BufferSize = 8096;
            // Receive buffer.
            public byte[] buffer = new byte[BufferSize];
        }

        public static ManualResetEvent allDone = new ManualResetEvent(true);
        public void StartListening()
        {
            byte[] bytes = new Byte[8096];
            IPEndPoint ipEnd = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9050);
            Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                listener.Bind(ipEnd);
                listener.Listen(100);
                //SetText("Listening For Connection");//.net framework 4.5
                while (true)
                {
                    allDone.Reset();
                    listener.BeginAccept(new AsyncCallback(AcceptCallback), listener);
                    allDone.WaitOne();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        public void AcceptCallback(IAsyncResult ar)
        {
            allDone.Set();

            Socket listener = (Socket)ar.AsyncState;
            Socket handler = listener.EndAccept(ar);

            StateObject state = new StateObject();
            state.workSocket = handler;
            handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReadCallback), state);
            flag = 0;

        }

        public void ReadCallback(IAsyncResult ar)
        {
            int fileNameLen = 1;
            String content = String.Empty;
            StateObject state = (StateObject)ar.AsyncState;
            Socket handler = state.workSocket;
            int bytesRead = handler.EndReceive(ar);
            BinaryWriter writer = null;
            while (true)
            {
                flag += 1;
                if (bytesRead > 0)
                {
                    if (flag == 0)
                    {
                        fileNameLen = BitConverter.ToInt32(state.buffer, 0);
                        fileName = Encoding.UTF8.GetString(state.buffer, 4, fileNameLen);
                        receivedPath = @"C:\" + fileName;
                        flag++;
                    }

                    if (flag >= 1)
                    {
                        writer = new BinaryWriter(File.Open(receivedPath + fileName, FileMode.Create));
                        //writer = new BinaryWriter(File.Open(receivedPath, FileMode.Append));
                        if (flag == 1)
                        {
                            writer.Write(state.buffer, 4 + fileNameLen, bytesRead - (4 + fileNameLen));
                            flag++;
                        }
                        //if (writer != null)
                        //{
                        //    writer.Flush();
                        //    writer.Dispose();
                        //    //writer.Close();
                        //}
                        else
                            writer.Write(state.buffer, 0, bytesRead);
                        writer.Close();
                        handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReadCallback), state);
                    }
                }

                else
                {
                    Invoke(new MyDelegate(LabelWriter));
                }
            }
            

        }
        public void LabelWriter()
        {
            label1.Text = "Data has been received " + fileName;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            t1.Abort();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    




    }
}
