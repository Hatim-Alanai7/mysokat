using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common_Classes;
using Client.BL;
using System.Threading;

namespace Client.GUI
{
    public partial class FrmClient : Form
    {
        int port;
        HomeClient newClient;
        object locker = "nothing";

        public FrmClient()
        {
            InitializeComponent();
        }

        private void CheckData(object sender, EventArgs e)
        {
            btnFinish.Enabled = int.TryParse(txtPort.Text, out port) && txtUserName.Text != "" && cmbColor.Text != "" && txtAddress.Text != "";
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            btnFinish.Enabled = false;
            btnDisconnect.Enabled = true;
            txtSendMessege.Enabled = true;
            txtAddress.Enabled = false;
            txtPort.Enabled = false;
            txtUserName.Enabled = false;
            cmbColor.Enabled = false;
            ConnectUser();
        }

        private void ConnectUser()
        {
            newClient = new HomeClient(txtAddress.Text, port, txtUserName.Text, Color.FromName(cmbColor.Text));
            if (newClient.ServerError)
            {
                DialogResult dr = MessageBox.Show("Error! Please check the server activity.", "Server Error!",
                    MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                if (dr == DialogResult.Retry)
                {
                    ConnectUser();
                    return;
                }
                else
                {
                    newClient = null;
                    btnFinish.Enabled = true;
                    btnDisconnect.Enabled = false;
                    txtSendMessege.Enabled = false;
                    txtAddress.Enabled = true;
                    txtPort.Enabled = true;
                    txtUserName.Enabled = true;
                    cmbColor.Enabled = true;
                    return;
                }
            }
            newClient.receiveMessege += AddMessegesHandler;
            newClient.ReceiveMesseges();
            MsgStatus msg = new MsgStatus(newClient.GetUser, newClient.GetUser.UserStatus);
            newClient.SendMessege(msg);
            txtSendMessege.Enabled = true;
            this.btnSend.Enabled = txtSendMessege.Text != "";
        }

        private void AddMessegesHandler(object o, ReceiveMessegeEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<object,ReceiveMessegeEventArgs>(AddMessegesHandler),o,e);
                return;
            }

            if (e.GetMessege is MsgUser)
                lstConvesation.Items.Add(new ListViewItem() { Text = string.Format(((MsgUser)e.GetMessege).TxtMessege), ForeColor = e.GetMessege.Sender.TextColor });
            else
                lstConvesation.Items.Add(new ListViewItem() { Text = string.Format(((MsgStatus)e.GetMessege).TxtMsgStatus), Font = new System.Drawing.Font("Miriam Fixed", 10) });
        }

        private void txtSendMessege_TextChanged(object sender, EventArgs e)
        {
            btnSend.Enabled = txtSendMessege.Text != "";
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            MsgUser msg = new MsgUser(newClient.GetUser);
            msg.TxtMessege = txtSendMessege.Text;
            newClient.SendMessege(msg);
            if (newClient.ServerError)
            {
                DialogResult dr = MessageBox.Show("Error! Please check the server activity.", "Server Error!",
                    MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                if (dr == DialogResult.Retry)
                {
                    btnSend_Click(sender, e);
                    return;
                }
                else return;
            }
            txtSendMessege.Clear();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            btnDisconnect.Enabled = true;
            btnConnect.Enabled = false;
            ConnectUser();
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            btnDisconnect.Enabled = false;
            btnConnect.Enabled = true;
            this.txtSendMessege.Enabled = false;
            this.btnSend.Enabled = false;
            MsgStatus msg = new MsgStatus(newClient.GetUser, Status.disconnected);
            newClient.SendMessege(msg);
            newClient.GetUser.UserStatus = Status.disconnected;
        }

        private void FrmClient_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                if (newClient.GetUser.UserStatus != Status.disconnected)
                {
                    MsgStatus msg = new MsgStatus(newClient.GetUser, Status.disconnected);
                    newClient.SendMessege(msg);
                    newClient.GetStream.Dispose();
                }
            }
            catch { return; }
        }
    }
}
