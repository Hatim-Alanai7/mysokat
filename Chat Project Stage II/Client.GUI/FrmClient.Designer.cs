namespace Client.GUI
{
    partial class FrmClient
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
            this.lclColor = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.cmbColor = new System.Windows.Forms.ComboBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.btnLogIn = new System.Windows.Forms.Button();
            this.lblPort = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.tblAddress = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtSendMessege = new System.Windows.Forms.RichTextBox();
            this.lblWelcom = new System.Windows.Forms.Label();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.lstConvesation = new System.Windows.Forms.ListView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnSingUp = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lclColor
            // 
            this.lclColor.AutoSize = true;
            this.lclColor.Font = new System.Drawing.Font("Castellar", 9.75F, System.Drawing.FontStyle.Bold);
            this.lclColor.Location = new System.Drawing.Point(470, 92);
            this.lclColor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lclColor.Name = "lclColor";
            this.lclColor.Size = new System.Drawing.Size(100, 25);
            this.lclColor.TabIndex = 3;
            this.lclColor.Text = "Color:";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Castellar", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblUserName.Location = new System.Drawing.Point(206, 92);
            this.lblUserName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(145, 25);
            this.lblUserName.TabIndex = 2;
            this.lblUserName.Text = "UserName:";
            // 
            // cmbColor
            // 
            this.cmbColor.FormattingEnabled = true;
            this.cmbColor.Items.AddRange(new object[] {
            "Red",
            "Blue",
            "Green",
            "Gray",
            "Yellow",
            "Purple"});
            this.cmbColor.Location = new System.Drawing.Point(580, 88);
            this.cmbColor.Margin = new System.Windows.Forms.Padding(2);
            this.cmbColor.Name = "cmbColor";
            this.cmbColor.Size = new System.Drawing.Size(76, 28);
            this.cmbColor.TabIndex = 1;
            this.cmbColor.TextChanged += new System.EventHandler(this.CheckData);
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(367, 89);
            this.txtUserName.Margin = new System.Windows.Forms.Padding(2);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(95, 26);
            this.txtUserName.TabIndex = 0;
            this.txtUserName.TextChanged += new System.EventHandler(this.CheckData);
            // 
            // btnLogIn
            // 
            this.btnLogIn.Enabled = false;
            this.btnLogIn.Font = new System.Drawing.Font("Aharoni", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnLogIn.Location = new System.Drawing.Point(660, 88);
            this.btnLogIn.Margin = new System.Windows.Forms.Padding(2);
            this.btnLogIn.Name = "btnLogIn";
            this.btnLogIn.Size = new System.Drawing.Size(97, 29);
            this.btnLogIn.TabIndex = 5;
            this.btnLogIn.Text = "Log In";
            this.btnLogIn.UseVisualStyleBackColor = true;
            this.btnLogIn.Click += new System.EventHandler(this.LogInUser);
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Font = new System.Drawing.Font("Castellar", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblPort.Location = new System.Drawing.Point(470, 59);
            this.lblPort.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(81, 25);
            this.lblPort.TabIndex = 3;
            this.lblPort.Text = "Port:";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(367, 57);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(2);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(95, 26);
            this.txtAddress.TabIndex = 0;
            this.txtAddress.Text = "127.0.0.1";
            this.txtAddress.TextChanged += new System.EventHandler(this.CheckData);
            // 
            // tblAddress
            // 
            this.tblAddress.AutoSize = true;
            this.tblAddress.Font = new System.Drawing.Font("Castellar", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tblAddress.Location = new System.Drawing.Point(206, 60);
            this.tblAddress.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.tblAddress.Name = "tblAddress";
            this.tblAddress.Size = new System.Drawing.Size(152, 25);
            this.tblAddress.TabIndex = 2;
            this.tblAddress.Text = "IP Address:";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(580, 56);
            this.txtPort.Margin = new System.Windows.Forms.Padding(2);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(76, 26);
            this.txtPort.TabIndex = 1;
            this.txtPort.Text = "50000";
            this.txtPort.TextChanged += new System.EventHandler(this.CheckData);
            // 
            // btnSend
            // 
            this.btnSend.Enabled = false;
            this.btnSend.Font = new System.Drawing.Font("Aharoni", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnSend.Location = new System.Drawing.Point(318, 380);
            this.btnSend.Margin = new System.Windows.Forms.Padding(2);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(152, 34);
            this.btnSend.TabIndex = 2;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtSendMessege
            // 
            this.txtSendMessege.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSendMessege.Enabled = false;
            this.txtSendMessege.Location = new System.Drawing.Point(12, 342);
            this.txtSendMessege.Margin = new System.Windows.Forms.Padding(2);
            this.txtSendMessege.Name = "txtSendMessege";
            this.txtSendMessege.Size = new System.Drawing.Size(774, 34);
            this.txtSendMessege.TabIndex = 1;
            this.txtSendMessege.Text = "";
            this.txtSendMessege.TextChanged += new System.EventHandler(this.txtSendMessege_TextChanged);
            // 
            // lblWelcom
            // 
            this.lblWelcom.AutoSize = true;
            this.lblWelcom.Font = new System.Drawing.Font("Castellar", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcom.Location = new System.Drawing.Point(202, 8);
            this.lblWelcom.Name = "lblWelcom";
            this.lblWelcom.Size = new System.Drawing.Size(695, 53);
            this.lblWelcom.TabIndex = 8;
            this.lblWelcom.Text = "Welcome  to  the  chat";
            // 
            // btnLogOut
            // 
            this.btnLogOut.Enabled = false;
            this.btnLogOut.Font = new System.Drawing.Font("Aharoni", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnLogOut.Location = new System.Drawing.Point(660, 118);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(97, 30);
            this.btnLogOut.TabIndex = 10;
            this.btnLogOut.Text = "Log Out";
            this.btnLogOut.UseVisualStyleBackColor = true;
            this.btnLogOut.Click += new System.EventHandler(this.LogOutUser);
            // 
            // lstConvesation
            // 
            this.lstConvesation.Location = new System.Drawing.Point(12, 151);
            this.lstConvesation.Name = "lstConvesation";
            this.lstConvesation.Size = new System.Drawing.Size(774, 186);
            this.lstConvesation.TabIndex = 11;
            this.lstConvesation.UseCompatibleStateImageBehavior = false;
            this.lstConvesation.View = System.Windows.Forms.View.List;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Client.GUI.Properties.Resources.Chat_Icon;
            this.pictureBox1.Location = new System.Drawing.Point(-4, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(133, 115);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // btnSingUp
            // 
            this.btnSingUp.Enabled = false;
            this.btnSingUp.Font = new System.Drawing.Font("Aharoni", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnSingUp.Location = new System.Drawing.Point(758, 88);
            this.btnSingUp.Margin = new System.Windows.Forms.Padding(2);
            this.btnSingUp.Name = "btnSingUp";
            this.btnSingUp.Size = new System.Drawing.Size(118, 29);
            this.btnSingUp.TabIndex = 13;
            this.btnSingUp.Text = "Sing Up";
            this.btnSingUp.UseVisualStyleBackColor = true;
            this.btnSingUp.Click += new System.EventHandler(this.SingUpUser);
            // 
            // FrmClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(943, 415);
            this.Controls.Add(this.btnSingUp);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lstConvesation);
            this.Controls.Add(this.btnLogOut);
            this.Controls.Add(this.lblWelcom);
            this.Controls.Add(this.btnLogIn);
            this.Controls.Add(this.lblPort);
            this.Controls.Add(this.lclColor);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.tblAddress);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.cmbColor);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.txtSendMessege);
            this.Controls.Add(this.btnSend);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmClient";
            this.Text = "Client Side";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmClient_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.Label tblAddress;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lclColor;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.ComboBox cmbColor;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Button btnLogIn;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.RichTextBox txtSendMessege;
        private System.Windows.Forms.Label lblWelcom;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.ListView lstConvesation;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnSingUp;

    }
}

