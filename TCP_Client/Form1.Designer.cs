namespace TCP_Client
{
    partial class Form1
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.refreshBTN = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.selectBTN = new System.Windows.Forms.Button();
            this.sendBTN = new System.Windows.Forms.Button();
            this.exitServerBTN = new System.Windows.Forms.Button();
            this.connectServerBTN = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.serverAddress = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(-2, 59);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(219, 32);
            this.comboBox1.TabIndex = 0;
            // 
            // refreshBTN
            // 
            this.refreshBTN.Enabled = false;
            this.refreshBTN.Location = new System.Drawing.Point(347, 55);
            this.refreshBTN.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.refreshBTN.Name = "refreshBTN";
            this.refreshBTN.Size = new System.Drawing.Size(138, 42);
            this.refreshBTN.TabIndex = 1;
            this.refreshBTN.Text = "Refresh List";
            this.refreshBTN.UseVisualStyleBackColor = true;
            this.refreshBTN.Click += new System.EventHandler(this.refreshBTN_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Enabled = false;
            this.richTextBox1.Location = new System.Drawing.Point(22, 131);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(459, 240);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // selectBTN
            // 
            this.selectBTN.Enabled = false;
            this.selectBTN.Location = new System.Drawing.Point(244, 55);
            this.selectBTN.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.selectBTN.Name = "selectBTN";
            this.selectBTN.Size = new System.Drawing.Size(105, 42);
            this.selectBTN.TabIndex = 3;
            this.selectBTN.Text = "Select";
            this.selectBTN.UseVisualStyleBackColor = true;
            this.selectBTN.Click += new System.EventHandler(this.selectBTN_Click);
            // 
            // sendBTN
            // 
            this.sendBTN.Enabled = false;
            this.sendBTN.Location = new System.Drawing.Point(185, 436);
            this.sendBTN.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.sendBTN.Name = "sendBTN";
            this.sendBTN.Size = new System.Drawing.Size(138, 42);
            this.sendBTN.TabIndex = 4;
            this.sendBTN.Text = "Send";
            this.sendBTN.UseVisualStyleBackColor = true;
            this.sendBTN.Click += new System.EventHandler(this.sendBTN_Click);
            // 
            // exitServerBTN
            // 
            this.exitServerBTN.Location = new System.Drawing.Point(425, 6);
            this.exitServerBTN.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.exitServerBTN.Name = "exitServerBTN";
            this.exitServerBTN.Size = new System.Drawing.Size(92, 39);
            this.exitServerBTN.TabIndex = 6;
            this.exitServerBTN.Text = "Exit";
            this.exitServerBTN.UseVisualStyleBackColor = true;
            this.exitServerBTN.Click += new System.EventHandler(this.exitServerBTN_Click);
            // 
            // connectServerBTN
            // 
            this.connectServerBTN.Location = new System.Drawing.Point(299, 6);
            this.connectServerBTN.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.connectServerBTN.Name = "connectServerBTN";
            this.connectServerBTN.Size = new System.Drawing.Size(116, 39);
            this.connectServerBTN.TabIndex = 7;
            this.connectServerBTN.Text = "Connect";
            this.connectServerBTN.UseVisualStyleBackColor = true;
            this.connectServerBTN.Click += new System.EventHandler(this.connectServerBTN_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(22, 386);
            this.textBox1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(459, 29);
            this.textBox1.TabIndex = 8;
            // 
            // serverAddress
            // 
            this.serverAddress.Location = new System.Drawing.Point(185, 10);
            this.serverAddress.Name = "serverAddress";
            this.serverAddress.Size = new System.Drawing.Size(100, 29);
            this.serverAddress.TabIndex = 9;
            this.serverAddress.Text = "localhost";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 25);
            this.label1.TabIndex = 10;
            this.label1.Text = "Server Address";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 482);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.serverAddress);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.connectServerBTN);
            this.Controls.Add(this.exitServerBTN);
            this.Controls.Add(this.sendBTN);
            this.Controls.Add(this.selectBTN);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.refreshBTN);
            this.Controls.Add(this.comboBox1);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "Form1";
            this.Text = "CSCE 513 - P2P Chat Room Project";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button refreshBTN;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button selectBTN;
        private System.Windows.Forms.Button sendBTN;
        private System.Windows.Forms.Button exitServerBTN;
        private System.Windows.Forms.Button connectServerBTN;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox serverAddress;
        private System.Windows.Forms.Label label1;
    }
}

