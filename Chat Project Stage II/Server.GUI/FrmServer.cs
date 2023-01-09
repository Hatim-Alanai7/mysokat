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
        int userIdSearch;
        HomeServer server;
        List<ListViewItem> activeList = new List<ListViewItem>();
        User userSearch;

        public FrmServer()
        {
            InitializeComponent();
            CheckData();
        }

        private void CheckData()
        {
            btnCreateServer.Enabled = int.TryParse(txtPort.Text, out port) && txtAddress.Text != "";
        }

        private void CheckDataEvent_txtUserSearch(object sender, EventArgs e)
        {
            btnSearchUser.Visible = (cmbUserSearch.SelectedIndex == 0 && int.TryParse(txtUserSearch.Text, out userIdSearch))
                || (cmbUserSearch.SelectedIndex == 1 && txtUserSearch.Text != ""); 
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
            cmbMessegesSearch.Enabled = true;
            cmbUserSearch.Enabled = true;
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
                lstConnectedUsers.Items.Add(e.GetUser.UserName);
                lstHistory.Items.Add(new ListViewItem()
                {
                    Text = string.Format("{0} || {1} is {2}",
                        DateTime.Now, e.GetUser.UserName, Status.connected),
                    ForeColor = e.GetUser.TextColor
                });
            }
            else
            {
                lstConnectedUsers.Items.Remove(e.GetUser.UserName);
                lstHistory.Items.Add(new ListViewItem()
                {
                    Text = string.Format("{0} || {1} is {2}",
                        DateTime.Now, e.GetUser.UserName, Status.disconnected),
                    ForeColor = e.GetUser.TextColor
                });
            }
        }

        private void FrmServer_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                for (int i = 0; i < server.GetUserManager.GetActiveUsers.Count(); i++)
                {
                    server.GetUserManager.GetMessegesManager.UpdateUserStatusAndLastSeenInDb(new MsgStatus(server.GetUserManager.GetActiveUsers.ElementAt(i).GetUser, Status.disconnected));
                    server.GetUserManager.GetActiveUsers.ElementAt(i).GetTcpStream.Dispose();
                }
            }
            catch { return; }
        }

        private void cmbMessegeSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMessegesSearch.SelectedIndex == 0)
            {
                rtxtTextMesseges.Visible = true;
                dtpMesseges.Visible = false;
            }
            else
            {
                rtxtTextMesseges.Visible = false;
                dtpMesseges.Visible = true;
            }
        }

        private void ValueSearchMessegesChanged(object sender, EventArgs e)
        {
            btnSearchMesseges.Visible = (cmbMessegesSearch.SelectedIndex == 0 && rtxtTextMesseges.Text != "") || (cmbMessegesSearch.SelectedIndex == 1 && dtpMesseges.Value != null);
        }

        private void btnSearchMesseges_Click(object sender, EventArgs e)
        {

            lstMessegesResult.Items.Clear();

            if (cmbMessegesSearch.SelectedIndex == 0 && rtxtTextMesseges.Text != "")
            {
                List<MsgUser> searchMessegesResult = (List<MsgUser>)server.SearchMesseges(rtxtTextMesseges.Text);
                foreach (MsgUser msg in searchMessegesResult)
                {
                    lstMessegesResult.Items.Add(msg.TxtMessege);
                }
            }
            else if (cmbMessegesSearch.SelectedIndex == 1 && dtpMesseges.Value != null)
            {
                List<MsgUser> searchMessegesResult = (List<MsgUser>)server.SearchMesseges(dtpMesseges.Value);
                foreach (MsgUser msg in searchMessegesResult)
                {
                    lstMessegesResult.Items.Add(msg.TxtMessege);
                }
            }
        }

        private void cmbUserSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtUserSearch.Visible = true;
        }

        private void btnSearchUser_Click(object sender, EventArgs e)
        {
            lstUserResult.Items.Clear();
            if (cmbUserSearch.SelectedIndex == 0 && userIdSearch!=0)
            {
                userSearch = server.SearchUser(userIdSearch);
                if (userSearch != null)
                {
                    lstUserResult.Items.Add(userSearch);
                    lblNote.Visible = true;
                }
            }
            else if (cmbUserSearch.SelectedIndex==1 && txtUserSearch.Text != "")
            {
                userSearch = server.SearchUser(txtUserSearch.Text);
                if (userSearch !=null)
                {
                    lstUserResult.Items.Add(userSearch);
                    lblNote.Visible = true;
                }
            }
        }

        private void txtPortAndtxtAddress_TextChanged(object sender, EventArgs e)
        {
            CheckData();
        }

        private void lstUserResult_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (userSearch.UserStatus == Status.disconnected)
            {
                btnRemoveUser.Enabled = true;
                btnRemoveUser.Visible = true;
            }
            else
            {
                btnRemoveUser.Enabled = false;
                btnRemoveUser.Visible = true;
            }
        }

        private void btnRemoveUser_Click(object sender, EventArgs e)
        {
            server.RemoveUser(userSearch);
            lstUserResult.Items.Clear();
            txtUserSearch.Clear();
            btnRemoveUser.Visible = false;
            lblNote.Visible = false;
        }

    }
}
