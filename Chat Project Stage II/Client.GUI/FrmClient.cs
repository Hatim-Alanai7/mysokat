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

        private void SingUpUser(object o, EventArgs e)
        {
            newClient = new HomeClient(txtAddress.Text, port, txtUserName.Text, Color.FromName(cmbColor.Text), Operation.SingUp);
            newClient.existingAccount += ExistingAccount;
            newClient.receiveMessege += AddMessegesHandler;

            if (newClient.ServerError)
            {
                MessageBox.Show("Error! Please check the server activity.", "Server Error!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                ResultForErorr();
                return;
            }
            if (newClient.IsExist.ErrorExists == false)
            {
                MsgStatus msg = new MsgStatus(newClient.GetUser, newClient.GetUser.UserStatus);
                newClient.SendMessege(msg);
            }
            btnSingUp.Enabled = false;
            btnLogIn.Enabled = false;
            txtSendMessege.Enabled = true;
            btnSend.Enabled = true;
            txtUserName.Enabled = false;
            cmbColor.Enabled = false;
            btnLogOut.Enabled = true;
        }

        private void LogInUser(object sender, EventArgs e)
        {
            newClient = new HomeClient(txtAddress.Text, port, txtUserName.Text, Color.FromName(cmbColor.Text), Operation.LogIn);
            newClient.existingAccount += ExistingAccount;
            newClient.receiveMessege += AddMessegesHandler;

            if (newClient.ServerError)
            {
                DialogResult dr = MessageBox.Show("Error! Please check the server activity.", "Server Error!",
                    MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                if (dr == DialogResult.Retry)
                {
                    LogInUser(sender, e);
                    return;
                }
                else
                {
                    newClient = null;
                    btnLogIn.Enabled = true;
                    btnLogOut.Enabled = false;
                    txtSendMessege.Enabled = false;
                    txtAddress.Enabled = true;
                    txtPort.Enabled = true;
                    txtUserName.Enabled = true;
                    cmbColor.Enabled = true;
                    return;
                }
            }

            txtSendMessege.Enabled = true;
            txtAddress.Enabled = false;
            txtPort.Enabled = false;
            txtUserName.Enabled = false;
            cmbColor.Enabled = false;
            txtUserName.Enabled = false;
            cmbColor.Enabled = false;
            btnLogOut.Enabled = true;
            btnLogIn.Enabled = false;
            btnSingUp.Enabled = false;

            if (newClient.IsExist.ErrorExists == false)
            {
                MsgStatus msg = new MsgStatus(newClient.GetUser, newClient.GetUser.UserStatus);
                newClient.SendMessege(msg);
                this.txtSendMessege.Enabled = true;
                this.btnSend.Enabled = txtSendMessege.Text != "";
            }
        }

        private void LogOutUser(object sender, EventArgs e)
        {
            btnLogOut.Enabled = false;
            this.txtSendMessege.Enabled = false;
            this.btnSend.Enabled = false;
            MsgStatus msg = new MsgStatus(newClient.GetUser, Status.disconnected);
            newClient.SendMessege(msg);
            newClient.GetUser.UserStatus = Status.disconnected;

            btnLogIn.Enabled = true;
            btnSingUp.Enabled = true;
            txtUserName.Enabled = true;
            txtPort.Enabled = true;
            txtAddress.Enabled = true;
            cmbColor.Enabled = true;
        }

        private void CheckData(object sender, EventArgs e)
        {
            btnSingUp.Enabled = int.TryParse(txtPort.Text, out port) && txtUserName.Text != "" && cmbColor.Text != "" && txtAddress.Text != "";
            btnLogIn.Enabled = int.TryParse(txtPort.Text, out port) && txtUserName.Text != "" && cmbColor.Text != "" && txtAddress.Text != "";
        }

        private void ResultForErorr()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(ResultForErorr));
                return;
            }
            newClient = null;
            btnLogIn.Enabled = true;
            btnLogOut.Enabled = false;
            txtSendMessege.Enabled = false;
            txtAddress.Enabled = true;
            txtPort.Enabled = true;
            txtUserName.Enabled = true;
            cmbColor.Enabled = true;
        }

        private void ExistingAccount(object o, ExistingAccountEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<object, ExistingAccountEventArgs>(ExistingAccount), o, e);
                return;
            }
            if (e.GetOperation == Operation.SingUp)
                MessageBox.Show(string.Format("Error! The username {0} exists. Please try another username or log in.", e.GetUser.UserName), "Sing Up Error!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show(string.Format("Error! The username {0} does not exist. Please try again or sing up.", e.GetUser.UserName), "Log In Error!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            ResultForErorr();
        }

        private void AddMessegesHandler(object o, ReceiveMessegeEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<object, ReceiveMessegeEventArgs>(AddMessegesHandler), o, e);
                return;
            }

            if (e.GetMessege is MsgUser)
                lstConvesation.Items.Add(new ListViewItem() { Text = string.Format(((MsgUser)e.GetMessege).TxtMessege), ForeColor = ((MsgUser)e.GetMessege).Sender.TextColor });
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
