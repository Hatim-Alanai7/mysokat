namespace Server.GUI
{
    partial class FrmServer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lstConnectedUsers = new System.Windows.Forms.ListBox();
            this.btnCreateServer = new System.Windows.Forms.Button();
            this.lstHistory = new System.Windows.Forms.ListView();
            this.lblServerSideChat = new System.Windows.Forms.Label();
            this.lblPort = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtUserSearch = new System.Windows.Forms.TextBox();
            this.lblHistory = new System.Windows.Forms.Label();
            this.lblActivityUsers = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cmbMessegesSearch = new System.Windows.Forms.ComboBox();
            this.rtxtTextMesseges = new System.Windows.Forms.RichTextBox();
            this.dtpMesseges = new System.Windows.Forms.DateTimePicker();
            this.btnSearchMesseges = new System.Windows.Forms.Button();
            this.lstMessegesResult = new System.Windows.Forms.ListBox();
            this.lblSearchMesseges = new System.Windows.Forms.Label();
            this.lblResSearchMesseges = new System.Windows.Forms.Label();
            this.cmbUserSearch = new System.Windows.Forms.ComboBox();
            this.btnSearchUser = new System.Windows.Forms.Button();
            this.lblResSearchUser = new System.Windows.Forms.Label();
            this.lstUserResult = new System.Windows.Forms.ListBox();
            this.lblSearchUser = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.btnRemoveUser = new System.Windows.Forms.Button();
            this.lblNote = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lstConnectedUsers
            // 
            this.lstConnectedUsers.FormattingEnabled = true;
            this.lstConnectedUsers.ItemHeight = 20;
            this.lstConnectedUsers.Location = new System.Drawing.Point(528, 232);
            this.lstConnectedUsers.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lstConnectedUsers.Name = "lstConnectedUsers";
            this.lstConnectedUsers.Size = new System.Drawing.Size(212, 284);
            this.lstConnectedUsers.TabIndex = 1;
            // 
            // btnCreateServer
            // 
            this.btnCreateServer.Enabled = false;
            this.btnCreateServer.Font = new System.Drawing.Font("Aharoni", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnCreateServer.Location = new System.Drawing.Point(393, 141);
            this.btnCreateServer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCreateServer.Name = "btnCreateServer";
            this.btnCreateServer.Size = new System.Drawing.Size(204, 42);
            this.btnCreateServer.TabIndex = 5;
            this.btnCreateServer.Text = "Create Server!";
            this.btnCreateServer.UseVisualStyleBackColor = true;
            this.btnCreateServer.Click += new System.EventHandler(this.btnCreateServer_Click);
            // 
            // lstHistory
            // 
            this.lstHistory.Location = new System.Drawing.Point(35, 232);
            this.lstHistory.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lstHistory.Name = "lstHistory";
            this.lstHistory.Size = new System.Drawing.Size(382, 284);
            this.lstHistory.TabIndex = 2;
            this.lstHistory.UseCompatibleStateImageBehavior = false;
            this.lstHistory.View = System.Windows.Forms.View.List;
            // 
            // lblServerSideChat
            // 
            this.lblServerSideChat.AutoSize = true;
            this.lblServerSideChat.Font = new System.Drawing.Font("Castellar", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServerSideChat.Location = new System.Drawing.Point(243, 14);
            this.lblServerSideChat.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblServerSideChat.Name = "lblServerSideChat";
            this.lblServerSideChat.Size = new System.Drawing.Size(489, 53);
            this.lblServerSideChat.TabIndex = 9;
            this.lblServerSideChat.Text = "server side chat";
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Font = new System.Drawing.Font("Castellar", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblPort.Location = new System.Drawing.Point(532, 92);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(81, 25);
            this.lblPort.TabIndex = 13;
            this.lblPort.Text = "Port:";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(384, 89);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(112, 26);
            this.txtAddress.TabIndex = 10;
            this.txtAddress.Text = "127.0.0.1";
            this.txtAddress.TextChanged += new System.EventHandler(this.txtPortAndtxtAddress_TextChanged);
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("Castellar", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddress.Location = new System.Drawing.Point(217, 94);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(152, 25);
            this.lblAddress.TabIndex = 12;
            this.lblAddress.Text = "IP Address:";
            // 
            // txtUserSearch
            // 
            this.txtUserSearch.Location = new System.Drawing.Point(1049, 123);
            this.txtUserSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtUserSearch.Name = "txtUserSearch";
            this.txtUserSearch.Size = new System.Drawing.Size(112, 26);
            this.txtUserSearch.TabIndex = 11;
            this.txtUserSearch.Visible = false;
            this.txtUserSearch.TextChanged += new System.EventHandler(this.CheckDataEvent_txtUserSearch);
            // 
            // lblHistory
            // 
            this.lblHistory.AutoSize = true;
            this.lblHistory.Font = new System.Drawing.Font("Castellar", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblHistory.Location = new System.Drawing.Point(35, 206);
            this.lblHistory.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHistory.Name = "lblHistory";
            this.lblHistory.Size = new System.Drawing.Size(123, 25);
            this.lblHistory.TabIndex = 14;
            this.lblHistory.Text = "History:";
            // 
            // lblActivityUsers
            // 
            this.lblActivityUsers.AutoSize = true;
            this.lblActivityUsers.Font = new System.Drawing.Font("Castellar", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblActivityUsers.Location = new System.Drawing.Point(524, 206);
            this.lblActivityUsers.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblActivityUsers.Name = "lblActivityUsers";
            this.lblActivityUsers.Size = new System.Drawing.Size(209, 25);
            this.lblActivityUsers.TabIndex = 15;
            this.lblActivityUsers.Text = "Activity Users:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Server.GUI.Properties.Resources.Chat_Icon;
            this.pictureBox1.Location = new System.Drawing.Point(-8, -2);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(199, 178);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // cmbMessegesSearch
            // 
            this.cmbMessegesSearch.Enabled = false;
            this.cmbMessegesSearch.FormattingEnabled = true;
            this.cmbMessegesSearch.Items.AddRange(new object[] {
            "text messege",
            "date time messege"});
            this.cmbMessegesSearch.Location = new System.Drawing.Point(785, 86);
            this.cmbMessegesSearch.Name = "cmbMessegesSearch";
            this.cmbMessegesSearch.Size = new System.Drawing.Size(129, 28);
            this.cmbMessegesSearch.TabIndex = 17;
            this.cmbMessegesSearch.SelectedIndexChanged += new System.EventHandler(this.cmbMessegeSearch_SelectedIndexChanged);
            // 
            // rtxtTextMesseges
            // 
            this.rtxtTextMesseges.Location = new System.Drawing.Point(785, 121);
            this.rtxtTextMesseges.Name = "rtxtTextMesseges";
            this.rtxtTextMesseges.Size = new System.Drawing.Size(200, 41);
            this.rtxtTextMesseges.TabIndex = 18;
            this.rtxtTextMesseges.Text = "";
            this.rtxtTextMesseges.Visible = false;
            this.rtxtTextMesseges.TextChanged += new System.EventHandler(this.ValueSearchMessegesChanged);
            // 
            // dtpMesseges
            // 
            this.dtpMesseges.Location = new System.Drawing.Point(785, 121);
            this.dtpMesseges.Name = "dtpMesseges";
            this.dtpMesseges.Size = new System.Drawing.Size(200, 26);
            this.dtpMesseges.TabIndex = 19;
            this.dtpMesseges.Visible = false;
            this.dtpMesseges.ValueChanged += new System.EventHandler(this.ValueSearchMessegesChanged);
            // 
            // btnSearchMesseges
            // 
            this.btnSearchMesseges.Location = new System.Drawing.Point(785, 169);
            this.btnSearchMesseges.Name = "btnSearchMesseges";
            this.btnSearchMesseges.Size = new System.Drawing.Size(148, 34);
            this.btnSearchMesseges.TabIndex = 20;
            this.btnSearchMesseges.Text = "Search Messeges";
            this.btnSearchMesseges.UseVisualStyleBackColor = true;
            this.btnSearchMesseges.Visible = false;
            this.btnSearchMesseges.Click += new System.EventHandler(this.btnSearchMesseges_Click);
            // 
            // lstMessegesResult
            // 
            this.lstMessegesResult.FormattingEnabled = true;
            this.lstMessegesResult.ItemHeight = 20;
            this.lstMessegesResult.Location = new System.Drawing.Point(785, 232);
            this.lstMessegesResult.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lstMessegesResult.Name = "lstMessegesResult";
            this.lstMessegesResult.Size = new System.Drawing.Size(212, 284);
            this.lstMessegesResult.TabIndex = 21;
            // 
            // lblSearchMesseges
            // 
            this.lblSearchMesseges.AutoSize = true;
            this.lblSearchMesseges.Font = new System.Drawing.Font("Castellar", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearchMesseges.Location = new System.Drawing.Point(780, 62);
            this.lblSearchMesseges.Name = "lblSearchMesseges";
            this.lblSearchMesseges.Size = new System.Drawing.Size(184, 19);
            this.lblSearchMesseges.TabIndex = 13;
            this.lblSearchMesseges.Text = "Search Messeges:";
            // 
            // lblResSearchMesseges
            // 
            this.lblResSearchMesseges.AutoSize = true;
            this.lblResSearchMesseges.Font = new System.Drawing.Font("Castellar", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblResSearchMesseges.Location = new System.Drawing.Point(780, 206);
            this.lblResSearchMesseges.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblResSearchMesseges.Name = "lblResSearchMesseges";
            this.lblResSearchMesseges.Size = new System.Drawing.Size(104, 25);
            this.lblResSearchMesseges.TabIndex = 15;
            this.lblResSearchMesseges.Text = "Result:";
            // 
            // cmbUserSearch
            // 
            this.cmbUserSearch.Enabled = false;
            this.cmbUserSearch.FormattingEnabled = true;
            this.cmbUserSearch.Items.AddRange(new object[] {
            "User ID",
            "User Name"});
            this.cmbUserSearch.Location = new System.Drawing.Point(1049, 87);
            this.cmbUserSearch.Name = "cmbUserSearch";
            this.cmbUserSearch.Size = new System.Drawing.Size(129, 28);
            this.cmbUserSearch.TabIndex = 17;
            this.cmbUserSearch.SelectedIndexChanged += new System.EventHandler(this.cmbUserSearch_SelectedIndexChanged);
            // 
            // btnSearchUser
            // 
            this.btnSearchUser.Location = new System.Drawing.Point(1049, 169);
            this.btnSearchUser.Name = "btnSearchUser";
            this.btnSearchUser.Size = new System.Drawing.Size(148, 34);
            this.btnSearchUser.TabIndex = 20;
            this.btnSearchUser.Text = "Search User";
            this.btnSearchUser.UseVisualStyleBackColor = true;
            this.btnSearchUser.Visible = false;
            this.btnSearchUser.Click += new System.EventHandler(this.btnSearchUser_Click);
            // 
            // lblResSearchUser
            // 
            this.lblResSearchUser.AutoSize = true;
            this.lblResSearchUser.Font = new System.Drawing.Font("Castellar", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblResSearchUser.Location = new System.Drawing.Point(1044, 206);
            this.lblResSearchUser.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblResSearchUser.Name = "lblResSearchUser";
            this.lblResSearchUser.Size = new System.Drawing.Size(104, 25);
            this.lblResSearchUser.TabIndex = 15;
            this.lblResSearchUser.Text = "Result:";
            // 
            // lstUserResult
            // 
            this.lstUserResult.FormattingEnabled = true;
            this.lstUserResult.ItemHeight = 20;
            this.lstUserResult.Location = new System.Drawing.Point(1049, 232);
            this.lstUserResult.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lstUserResult.Name = "lstUserResult";
            this.lstUserResult.Size = new System.Drawing.Size(398, 24);
            this.lstUserResult.TabIndex = 21;
            this.lstUserResult.SelectedIndexChanged += new System.EventHandler(this.lstUserResult_SelectedIndexChanged);
            // 
            // lblSearchUser
            // 
            this.lblSearchUser.AutoSize = true;
            this.lblSearchUser.Font = new System.Drawing.Font("Castellar", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearchUser.Location = new System.Drawing.Point(1045, 62);
            this.lblSearchUser.Name = "lblSearchUser";
            this.lblSearchUser.Size = new System.Drawing.Size(142, 19);
            this.lblSearchUser.TabIndex = 13;
            this.lblSearchUser.Text = "Search User:";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(621, 91);
            this.txtPort.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(112, 26);
            this.txtPort.TabIndex = 11;
            this.txtPort.Text = "50000";
            this.txtPort.TextChanged += new System.EventHandler(this.txtPortAndtxtAddress_TextChanged);
            // 
            // btnRemoveUser
            // 
            this.btnRemoveUser.Location = new System.Drawing.Point(1049, 284);
            this.btnRemoveUser.Name = "btnRemoveUser";
            this.btnRemoveUser.Size = new System.Drawing.Size(129, 33);
            this.btnRemoveUser.TabIndex = 22;
            this.btnRemoveUser.Text = "Remove User";
            this.btnRemoveUser.UseVisualStyleBackColor = true;
            this.btnRemoveUser.Visible = false;
            this.btnRemoveUser.Click += new System.EventHandler(this.btnRemoveUser_Click);
            // 
            // lblNote
            // 
            this.lblNote.AutoSize = true;
            this.lblNote.Location = new System.Drawing.Point(1045, 261);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(354, 20);
            this.lblNote.TabIndex = 23;
            this.lblNote.Text = "Note: Check user to see if you can remove a user";
            this.lblNote.Visible = false;
            // 
            // FrmServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1455, 531);
            this.Controls.Add(this.lblNote);
            this.Controls.Add(this.btnRemoveUser);
            this.Controls.Add(this.lstUserResult);
            this.Controls.Add(this.lstMessegesResult);
            this.Controls.Add(this.btnSearchUser);
            this.Controls.Add(this.btnSearchMesseges);
            this.Controls.Add(this.dtpMesseges);
            this.Controls.Add(this.rtxtTextMesseges);
            this.Controls.Add(this.cmbUserSearch);
            this.Controls.Add(this.cmbMessegesSearch);
            this.Controls.Add(this.lblResSearchUser);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblResSearchMesseges);
            this.Controls.Add(this.lblActivityUsers);
            this.Controls.Add(this.lblHistory);
            this.Controls.Add(this.lblSearchUser);
            this.Controls.Add(this.lblSearchMesseges);
            this.Controls.Add(this.lblPort);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.txtUserSearch);
            this.Controls.Add(this.lblServerSideChat);
            this.Controls.Add(this.btnCreateServer);
            this.Controls.Add(this.lstHistory);
            this.Controls.Add(this.lstConnectedUsers);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmServer";
            this.Text = "Server Side";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmServer_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCreateServer;
        private System.Windows.Forms.ListBox lstConnectedUsers;
        private System.Windows.Forms.ListView lstHistory;
        private System.Windows.Forms.Label lblServerSideChat;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtUserSearch;
        private System.Windows.Forms.Label lblHistory;
        private System.Windows.Forms.Label lblActivityUsers;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox cmbMessegesSearch;
        private System.Windows.Forms.RichTextBox rtxtTextMesseges;
        private System.Windows.Forms.DateTimePicker dtpMesseges;
        private System.Windows.Forms.Button btnSearchMesseges;
        private System.Windows.Forms.ListBox lstMessegesResult;
        private System.Windows.Forms.Label lblSearchMesseges;
        private System.Windows.Forms.Label lblResSearchMesseges;
        private System.Windows.Forms.ComboBox cmbUserSearch;
        private System.Windows.Forms.Button btnSearchUser;
        private System.Windows.Forms.Label lblResSearchUser;
        private System.Windows.Forms.ListBox lstUserResult;
        private System.Windows.Forms.Label lblSearchUser;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Button btnRemoveUser;
        private System.Windows.Forms.Label lblNote;
    }
}

