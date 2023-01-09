using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Server.BL;
using Common_Classes;
using System.Threading;

namespace Server.GUI
{
    public partial class FrmServer : Form
    {
        int port;
        HomeServer server;
        List<ListViewItem> activeList = new List<ListViewItem>();

        public FrmServer()
        {
            InitializeComponent();
            CheckData();
        }

        private void CheckData()
        {
            btnCreateServer.Enabled = int.TryParse(txtPort.Text, out port) && txtAddress.Text != "";
        }

        private void CheckDataEvent(object sender, EventArgs e)
        {
            CheckData();
        }

        private void btnCreateServer_Click(object sender, EventArgs e)
        {
            server = new HomeServer(txtAddress.Text, port);
            if (server.DataError)
            {
                DialogResult dr = MessageBox.Show("Error! Check your IP Address/Port.", "Data Error!",
                    MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                if (dr == DialogResult.Retry)
                {
                    btnCreateServer_Click(sender, e);
                    return;
                }
                else
                {
                    server = null;
                    return;
                }
            }
            btnCreateServer.Enabled = false;
            txtAddress.Enabled = false;
            txtPort.Enabled = false;
            server.activeUser += UpdateActiveUser;
        }

        private void UpdateActiveUser(object o, StatusUserEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<object, StatusUserEventArgs>(UpdateActiveUser), o, e);
                return;
            }

            if (e.GetUser.UserStatus == Status.connected)
            {
                lstConnectedUsers.Items.Add(e.GetUser.Name);
                lstHistory.Items.Add(new ListViewItem()
                {
                    Text = string.Format("{0} || {1} is {2}",
                        DateTime.Now, e.GetUser.Name, Status.connected),
                    ForeColor = e.GetUser.TextColor
                });
            }
            else
            {
                lstConnectedUsers.Items.Remove(e.GetUser.Name);
                lstHistory.Items.Add(new ListViewItem()
                {
                    Text = string.Format("{0} || {1} is {2}",
                        DateTime.Now, e.GetUser.Name, Status.disconnected),
                    ForeColor = e.GetUser.TextColor
                });
            }
        }

        private void FrmServer_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                for(int i =0;i<server.GetUserManager.GetActiveUsers.Count();i++)
                    server.GetUserManager.GetActiveUsers.ElementAt(i).GetTcpStream.Dispose();
            }
            catch  { return; }
        }

    }
}
