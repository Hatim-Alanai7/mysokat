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


namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        //public Socket socketClient;
        //private static Thread threadWatch = null;
        //private static Socket socketWatch = null;
        //private static ListBox lstbxMsgView;//إظهار المعلومات مثل الملفات المقبولة
        //private static ListBox listbOnline;//عرض قائمة اتصال المستخدم

        string splitter = "'\\'";
        string fName;
        string[] split = null;
        byte[] clientData;

        //private static Dictionary<string, Socket> dict = new Dictionary<string, Socket>();
        public Form1()
        {
            InitializeComponent();
            button1.Visible = false;
            //TextBox.CheckForIllegalCrossThreadCalls = false;
        }
        ///// <summary>
        /////  ابدأ بالاستماع
        ///// </summary>
        ///// <param name="localIp"></param>
        ///// <param name="localPort"></param>
        ///// 

        //public static void BeginListening(string localIp, string localPort, ListBox listbox, ListBox listboxOnline)
        //{
        //    //تهيئة المعلمة الأساسية
        //    lstbxMsgView = listbox;
        //    listbOnline = listboxOnline;

        //    //قم بإنشاء خادم مسؤول عن الاستماع والمعلمات (باستخدام بروتوكولات IPv4، باستخدام البث، باستخدام بيانات نقل بروتوكول TCP)
        //    socketWatch = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        //    //الحصول على كائن عنوان IP
        //    IPAddress address = IPAddress.Parse(localIp);
        //    //قم بإنشاء كائن عقدة شبكة يحتوي على IP والمنفذ
        //    IPEndPoint endpoint = new IPEndPoint(address, int.Parse(localPort));
        //    //المقبس الذي سيكون مسؤولا عن الاستماع مرتبط بالملكية الفكرية الفريدة والمنفذ
        //    socketWatch.Bind(endpoint);
        //    //اضبط طول قائمة انتظار المستمع
        //    socketWatch.Listen(10);
        //    //قم بإنشاء سلسلة رسائل مسؤولة عن الاستماع، ودمج طريقة المراقبة
        //    threadWatch = new Thread(WatchConnecting);
        //    threadWatch.IsBackground = true;//تعيين إلى خلفية الخلفية
        //    threadWatch.Start();//بدء الموضوع
        //    //ShowMgs ("خادم يبدأ في مراقبة النجاح")؛
        //    ShwMsgForView.ShwMsgforView(lstbxMsgView, "خادم يبدأ في الاستماع نجاح");
        //}

        ///// <summary>
        /////  ربط العميل
        ///// </summary>
        //private static void WatchConnecting()
        //{
        //    while (true)//طلب عميل المراقبة المستمر
        //    {
        //        //ابدأ الاستماع إلى طلب اتصال العميل، إيلاء الاهتمام: طريقة قبول ستحظر الخيط الحالي
        //        Socket connection = socketWatch.Accept();
        //        if (connection.Connected)
        //        {
        //            //إضافة عنوان IP والمنفذ للعميل إلى عنصر تحكم القائمة، كما هوية فريدة من العميل عند إرسالها
        //            listbOnline.Items.Add(connection.RemoteEndPoint.ToString());
        //            //أضف اتصال كائن المقبس في اتصال العميل بالقيمة الرئيسية إلى المجموعة، واتخاذ IP العميل كصحة
        //            dict.Add(connection.RemoteEndPoint.ToString(), connection);

        //            //إنشاء موضوع اتصال
        //            ParameterizedThreadStart pts = new ParameterizedThreadStart(RecMsg);
        //            Thread thradRecMsg = new Thread(pts);
        //            thradRecMsg.IsBackground = true;
        //            thradRecMsg.Start(connection);
        //            ShwMsgForView.ShwMsgforView(lstbxMsgView, "نجاح اتصال العميل" + connection.RemoteEndPoint.ToString());
        //        }
        //    }
        //}



        ///// <summary>
        /////  يتلقى رسالة
        ///// </summary>
        ///// <param name="socketClientPara"></param>
        //private static void RecMsg(object socketClientPara)
        //{
        //    Socket socketClient = socketClientPara as Socket;

        //    while (true)
        //    {
        //        //تحديد مخزن مؤقت مقبول (صفيف بايت 100 متر)
        //        //byte[] arrMsgRec = new byte[1024 * 1024 * 100];
        //        //استخدم البيانات المستلمة في صفيف armsgrec وإرجاع طول البيانات المقبولة بالفعل.   
        //        if (socketClient.Connected)
        //        {
        //            try
        //            {
        //                //لأن الحد الأقصى المخزن المؤقت في كل مرة يكون الملف 512 بايت، يتم تعريف كل استقبال أيضا باسم 512 بايت.
        //                byte[] buffer = new byte[512];
        //                int size = 0;
        //                long len = 0;
        //                string fileSavePath = @"..\..\files";//احصل على المسار إلى الملف المحفوظ
        //                if (!Directory.Exists(fileSavePath))
        //                {
        //                    Directory.CreateDirectory(fileSavePath);
        //                }
        //                string fileName = fileSavePath + "\\" + DateTime.Now.ToString("yyyyMMddHHmmssffff") + ".doc";
        //                //قم بإنشاء دفق ملف، ثم اترك دفق الملف بإنشاء ملف وفقا للمسار.
        //                FileStream fs = new FileStream(fileName, FileMode.Create);
        //                //من بيانات القبول الثابت المحطة، ثم اكتب الملف، فقط البيانات المستلمة هي 0، اتصال المقاطعة

        //                DateTime oTimeBegin = DateTime.Now;

        //                while ((size = socketClient.Receive(buffer, 0, buffer.Length, SocketFlags.None)) > 0)
        //                {
        //                    fs.Write(buffer, 0, size);
        //                    len += size;
        //                }
        //                DateTime oTimeEnd = DateTime.Now;
        //                TimeSpan oTime = oTimeEnd.Subtract(oTimeBegin);
        //                fs.Flush();
        //                ShwMsgForView.ShwMsgforView(lstbxMsgView, socketClient.RemoteEndPoint + "قطع الاتصال");
        //                dict.Remove(socketClient.RemoteEndPoint.ToString());
        //                listbOnline.Items.Remove(socketClient.RemoteEndPoint.ToString());
        //                socketClient.Close();
        //                ShwMsgForView.ShwMsgforView(lstbxMsgView, "يتم حفظ الملف:" + fileName);
        //                ShwMsgForView.ShwMsgforView(lstbxMsgView, "عند تلقي الملفات:" + oTime.ToString() + "،حجم الملف:" + len / 1024 + "kb");
        //            }
        //            catch
        //            {
        //                ShwMsgForView.ShwMsgforView(lstbxMsgView, socketClient.RemoteEndPoint + "الذهاب غير متصل");
        //                dict.Remove(socketClient.RemoteEndPoint.ToString());
        //                listbOnline.Items.Remove(socketClient.RemoteEndPoint.ToString());
        //                break;
        //            }
        //        }
        //        else
        //        {

        //        }
        //    }
        //}


        /// <summary>
        ///  اغلاق اتصال
        /// </summary>
        //public static void CloseTcpSocket()
        //{
        //    dict.Clear();
        //    listbOnline.Items.Clear();
        //    threadWatch.Abort();
        //    socketWatch.Close();
        //    ShwMsgForView.ShwMsgforView(lstbxMsgView, "خادم إغلاق الشاشات");
        //}

        //public ShakeHands()
        //{
        //    InitializeComponent();
        //    IPAddress[] ips = Dns.GetHostAddresses(Dns.GetHostName());
        //    txtIp.Text = ips[1].ToString();
        //    int port = 50001;
        //    txtPort.Text = port.ToString();
        //    ListBox.CheckForIllegalCrossThreadCalls = false;//قم بإيقاف تشغيل مؤشر ترابط ListBox عبر المواضيع
        //}

        //delegate void ShwMsgforViewCallBack(ListBox listbox, string text);
        //public static void ShwMsgforView(ListBox listbox, string text)
        //{
        //    if (listbox.InvokeRequired)
        //    {
        //        ShwMsgforViewCallBack shwMsgforViewCallBack = ShwMsgforView;
        //        listbox.Invoke(shwMsgforViewCallBack, new object[] { listbox, text });
        //    }
        //    else
        //    {
        //        listbox.Items.Add(text);
        //        listbox.SelectedIndex = listbox.Items.Count - 1;
        //        listbox.ClearSelected();
        //    }
        //}



        private void button1_Click(object sender, EventArgs e )
        {
            // IPAddress address = IPAddress.Parse(txtIp.Text.Trim());
            // IPEndPoint endpoint = new IPEndPoint(address, int.Parse(txtPort.Text.Trim()));
            // //إنشاء خادم مسؤول عن الاستماع إلى المقبس، المعلمة (باستخدام بروتوكول IPv4، باستخدام البث، باستخدام بيانات نقل بروتوكول TCO)
            //socketClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            // socketClient.Connect(endpoint);
            // if (socketClient.Connected)
            // {
            //     MessageBox.Show(socketClient.RemoteEndPoint + "نجح الاتصال");
            // }
            Socket clientSock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //IPAddress ip = new IPAddress;


            byte[] fileName = Encoding.UTF8.GetBytes(fName); //file name
            byte[] fileData = File.ReadAllBytes(textBox1.Text); //file
            byte[] fileNameLen = BitConverter.GetBytes(fileName.Length); //lenght of file name
            clientData = new byte[4 + fileName.Length + fileData.Length];

            fileNameLen.CopyTo(clientData, 0);
            fileName.CopyTo(clientData, 4);
            fileData.CopyTo(clientData, 4 + fileName.Length);

            textBox2.AppendText("Preparing File To Send");
            clientSock.Connect("127.0.0.1", 9050); //target machine's ip address and the port number
            clientSock.Send(clientData);
            //clientSock.
            clientSock.Close();






        }

        private void button3_Click(object sender, EventArgs e)
        {
            //OpenFileDialog ofd = new OpenFileDialog();
            //if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //{
            //    txtFileName.Text = ofd.FileName;
            //}
            char[] delimiter = splitter.ToCharArray();
            //openFileDialog1.ShowDialog();
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
                textBox2.AppendText("Selected file " + textBox1.Text);
                button1.Visible = true;
            }
            else
            {
                textBox2.AppendText("Please Select any one file to send");
                button1.Visible = false;
            }

            split = textBox1.Text.Split(delimiter);
            int limit = split.Length;
            fName = split[limit - 1].ToString();
            if (textBox1.Text != null)
                button3.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //int i = Net.SendFile(socketClient, txtFileName.Text, 512, 1);
            //if (i == 0)
            //{
            //    MessageBox.Show(txtFileName.Text + "الوثيقة ترسل النجاح");
            //    socketClient.Close();
            //    MessageBox.Show("اتصال قبالة");
            //}
            //else
            //{
            //    MessageBox.Show(txtFileName.Text + "فشل إرسال الملف، i =" + i);
            //}
            

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }










    }
}










