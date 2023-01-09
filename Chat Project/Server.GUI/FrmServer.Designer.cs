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
            this.txtPort = new System.Windows.Forms.TextBox();
            this.lblHistory = new System.Windows.Forms.Label();
            this.lblActivityUsers = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lstConnectedUsers
            // 
            this.lstConnectedUsers.FormattingEnabled = true;
            this.lstConnectedUsers.ItemHeight = 16;
            this.lstConnectedUsers.Location = new System.Drawing.Point(612, 186);
            this.lstConnectedUsers.Margin = new System.Windows.Forms.Padding(4);
            this.lstConnectedUsers.Name = "lstConnectedUsers";
            this.lstConnectedUsers.Size = new System.Drawing.Size(189, 228);
            this.lstConnectedUsers.TabIndex = 1;
            // 
            // btnCreateServer
            // 
            this.btnCreateServer.Enabled = false;
            this.btnCreateServer.Font = new System.Drawing.Font("Aharoni", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnCreateServer.Location = new System.Drawing.Point(349, 113);
            this.btnCreateServer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCreateServer.Name = "btnCreateServer";
            this.btnCreateServer.Size = new System.Drawing.Size(181, 34);
            this.btnCreateServer.TabIndex = 5;
            this.btnCreateServer.Text = "Create Server!";
            this.btnCreateServer.UseVisualStyleBackColor = true;
            this.btnCreateServer.Click += new System.EventHandler(this.btnCreateServer_Click);
            // 
            // lstHistory
            // 
            this.lstHistory.Location = new System.Drawing.Point(31, 186);
            this.lstHistory.Margin = new System.Windows.Forms.Padding(4);
            this.lstHistory.Name = "lstHistory";
            this.lstHistory.Size = new System.Drawing.Size(340, 228);
            this.lstHistory.TabIndex = 2;
            this.lstHistory.UseCompatibleStateImageBehavior = false;
            this.lstHistory.View = System.Windows.Forms.View.List;
            // 
            // lblServerSideChat
            // 
            this.lblServerSideChat.AutoSize = true;
            this.lblServerSideChat.Font = new System.Drawing.Font("Castellar", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServerSideChat.Location = new System.Drawing.Point(216, 11);
            this.lblServerSideChat.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblServerSideChat.Name = "lblServerSideChat";
            this.lblServerSideChat.Size = new System.Drawing.Size(415, 44);
            this.lblServerSideChat.TabIndex = 9;
            this.lblServerSideChat.Text = "server side chat";
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Font = new System.Drawing.Font("Castellar", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblPort.Location = new System.Drawing.Point(473, 74);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(70, 21);
            this.lblPort.TabIndex = 13;
            this.lblPort.Text = "Port:";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(341, 71);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(100, 22);
            this.txtAddress.TabIndex = 10;
            this.txtAddress.Text = "127.0.0.1";
            this.txtAddress.TextChanged += new System.EventHandler(this.CheckDataEvent);
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("Castellar", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddress.Location = new System.Drawing.Point(193, 75);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(132, 21);
            this.lblAddress.TabIndex = 12;
            this.lblAddress.Text = "IP Address:";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(559, 70);
            this.txtPort.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(100, 22);
            this.txtPort.TabIndex = 11;
            this.txtPort.Text = "50000";
            this.txtPort.TextChanged += new System.EventHandler(this.CheckDataEvent);
            // 
            // lblHistory
            // 
            this.lblHistory.AutoSize = true;
            this.lblHistory.Font = new System.Drawing.Font("Castellar", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblHistory.Location = new System.Drawing.Point(31, 165);
            this.lblHistory.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHistory.Name = "lblHistory";
            this.lblHistory.Size = new System.Drawing.Size(106, 21);
            this.lblHistory.TabIndex = 14;
            this.lblHistory.Text = "History:";
            // 
            // lblActivityUsers
            // 
            this.lblActivityUsers.AutoSize = true;
            this.lblActivityUsers.Font = new System.Drawing.Font("Castellar", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblActivityUsers.Location = new System.Drawing.Point(608, 165);
            this.lblActivityUsers.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblActivityUsers.Name = "lblActivityUsers";
            this.lblActivityUsers.Size = new System.Drawing.Size(182, 21);
            this.lblActivityUsers.TabIndex = 15;
            this.lblActivityUsers.Text = "Activity Users:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Server.GUI.Properties.Resources.Chat_Icon;
            this.pictureBox1.Location = new System.Drawing.Point(-7, -2);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(177, 142);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // FrmServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(833, 425);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblActivityUsers);
            this.Controls.Add(this.lblHistory);
            this.Controls.Add(this.lblPort);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.txtPort);
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
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label lblHistory;
        private System.Windows.Forms.Label lblActivityUsers;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

