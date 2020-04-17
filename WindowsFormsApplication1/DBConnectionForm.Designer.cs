namespace EntityMaker
{
    partial class DBConnectionForm
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
            this.textDb = new System.Windows.Forms.TextBox();
            this.textUsername = new System.Windows.Forms.TextBox();
            this.textPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textServer = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSqlConnect = new System.Windows.Forms.Button();
            this.textPort = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // textDb
            // 
            this.textDb.Location = new System.Drawing.Point(32, 118);
            this.textDb.Name = "textDb";
            this.textDb.Size = new System.Drawing.Size(204, 20);
            this.textDb.TabIndex = 2;
            // 
            // textUsername
            // 
            this.textUsername.Location = new System.Drawing.Point(32, 161);
            this.textUsername.Name = "textUsername";
            this.textUsername.Size = new System.Drawing.Size(204, 20);
            this.textUsername.TabIndex = 3;
            // 
            // textPassword
            // 
            this.textPassword.Location = new System.Drawing.Point(32, 201);
            this.textPassword.Name = "textPassword";
            this.textPassword.Size = new System.Drawing.Size(204, 20);
            this.textPassword.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Data Base";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Username";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 184);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Password";
            // 
            // textServer
            // 
            this.textServer.Location = new System.Drawing.Point(32, 26);
            this.textServer.Name = "textServer";
            this.textServer.Size = new System.Drawing.Size(204, 20);
            this.textServer.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Server";
            // 
            // btnSqlConnect
            // 
            this.btnSqlConnect.Location = new System.Drawing.Point(161, 234);
            this.btnSqlConnect.Name = "btnSqlConnect";
            this.btnSqlConnect.Size = new System.Drawing.Size(75, 23);
            this.btnSqlConnect.TabIndex = 6;
            this.btnSqlConnect.Text = "Connect";
            this.btnSqlConnect.UseVisualStyleBackColor = true;
            this.btnSqlConnect.Click += new System.EventHandler(this.btnSqlConnect_Click);
            // 
            // textPort
            // 
            this.textPort.Location = new System.Drawing.Point(32, 67);
            this.textPort.Name = "textPort";
            this.textPort.Size = new System.Drawing.Size(142, 20);
            this.textPort.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Port";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(32, 240);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(54, 17);
            this.checkBox1.TabIndex = 5;
            this.checkBox1.Text = "Save ";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // DBConnectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(273, 273);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.btnSqlConnect);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textPassword);
            this.Controls.Add(this.textPort);
            this.Controls.Add(this.textServer);
            this.Controls.Add(this.textUsername);
            this.Controls.Add(this.textDb);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "DBConnectionForm";
            this.Text = "Connection";
            this.Load += new System.EventHandler(this.DBConnectionForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textDb;
        private System.Windows.Forms.TextBox textUsername;
        private System.Windows.Forms.TextBox textPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textServer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSqlConnect;
        private System.Windows.Forms.TextBox textPort;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}