namespace Network_Monitor.Forms
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lbStartIP = new System.Windows.Forms.Label();
            this.lbEndIP = new System.Windows.Forms.Label();
            this.cbNIC = new System.Windows.Forms.ComboBox();
            this.tbIPStart = new System.Windows.Forms.TextBox();
            this.tbIPEnd = new System.Windows.Forms.TextBox();
            this.lbYIP = new System.Windows.Forms.Label();
            this.tbIP = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.pBHelp = new System.Windows.Forms.PictureBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lbInterfaces = new System.Windows.Forms.Label();
            this.rbDescription = new System.Windows.Forms.RadioButton();
            this.rbNames = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblUseSubnet = new System.Windows.Forms.Label();
            this.cbHostnames = new System.Windows.Forms.CheckBox();
            this.tbTimeOut = new System.Windows.Forms.TextBox();
            this.lblTimeout = new System.Windows.Forms.Label();
            this.cbUseSubnet = new System.Windows.Forms.CheckBox();
            this.lblResolve = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbSubnetMask = new System.Windows.Forms.TextBox();
            this.lblSubnetMask = new System.Windows.Forms.Label();
            this.tbIPEndNetwork = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbPort = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslOnline = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslPortOpen = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBHelp)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(837, 288);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.Sorted += new System.EventHandler(this.dataGridView1_Sorted);
            // 
            // lbStartIP
            // 
            this.lbStartIP.AutoSize = true;
            this.lbStartIP.Location = new System.Drawing.Point(7, 13);
            this.lbStartIP.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbStartIP.Name = "lbStartIP";
            this.lbStartIP.Size = new System.Drawing.Size(45, 13);
            this.lbStartIP.TabIndex = 4;
            this.lbStartIP.Text = "Start IP:";
            // 
            // lbEndIP
            // 
            this.lbEndIP.AutoSize = true;
            this.lbEndIP.Location = new System.Drawing.Point(7, 41);
            this.lbEndIP.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbEndIP.Name = "lbEndIP";
            this.lbEndIP.Size = new System.Drawing.Size(42, 13);
            this.lbEndIP.TabIndex = 5;
            this.lbEndIP.Text = "End IP:";
            // 
            // cbNIC
            // 
            this.cbNIC.FormattingEnabled = true;
            this.cbNIC.Location = new System.Drawing.Point(8, 34);
            this.cbNIC.Margin = new System.Windows.Forms.Padding(2);
            this.cbNIC.Name = "cbNIC";
            this.cbNIC.Size = new System.Drawing.Size(209, 21);
            this.cbNIC.TabIndex = 6;
            this.cbNIC.SelectedIndexChanged += new System.EventHandler(this.cbNIC_SelectedIndexChanged);
            // 
            // tbIPStart
            // 
            this.tbIPStart.Location = new System.Drawing.Point(81, 11);
            this.tbIPStart.Margin = new System.Windows.Forms.Padding(2);
            this.tbIPStart.Name = "tbIPStart";
            this.tbIPStart.Size = new System.Drawing.Size(104, 20);
            this.tbIPStart.TabIndex = 11;
            this.tbIPStart.TextChanged += new System.EventHandler(this.tbIPStart_TextChanged);
            // 
            // tbIPEnd
            // 
            this.tbIPEnd.Location = new System.Drawing.Point(155, 38);
            this.tbIPEnd.Margin = new System.Windows.Forms.Padding(2);
            this.tbIPEnd.Name = "tbIPEnd";
            this.tbIPEnd.Size = new System.Drawing.Size(30, 20);
            this.tbIPEnd.TabIndex = 12;
            this.tbIPEnd.TextChanged += new System.EventHandler(this.tbIPEnd_TextChanged);
            // 
            // lbYIP
            // 
            this.lbYIP.AutoSize = true;
            this.lbYIP.Location = new System.Drawing.Point(8, 15);
            this.lbYIP.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbYIP.Name = "lbYIP";
            this.lbYIP.Size = new System.Drawing.Size(45, 13);
            this.lbYIP.TabIndex = 14;
            this.lbYIP.Text = "Your IP:";
            // 
            // tbIP
            // 
            this.tbIP.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbIP.Location = new System.Drawing.Point(64, 11);
            this.tbIP.Margin = new System.Windows.Forms.Padding(2);
            this.tbIP.Name = "tbIP";
            this.tbIP.ReadOnly = true;
            this.tbIP.Size = new System.Drawing.Size(103, 20);
            this.tbIP.TabIndex = 15;
            this.tbIP.DoubleClick += new System.EventHandler(this.tbIP_DoubleClick);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.splitContainer1.Panel1.Controls.Add(this.groupBox5);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox4);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox3);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.statusStrip1);
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer1.Size = new System.Drawing.Size(837, 408);
            this.splitContainer1.SplitterDistance = 117;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 17;
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox5.Controls.Add(this.pBHelp);
            this.groupBox5.Location = new System.Drawing.Point(788, 2);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox5.Size = new System.Drawing.Size(47, 91);
            this.groupBox5.TabIndex = 28;
            this.groupBox5.TabStop = false;
            // 
            // pBHelp
            // 
            this.pBHelp.Location = new System.Drawing.Point(7, 32);
            this.pBHelp.Margin = new System.Windows.Forms.Padding(2);
            this.pBHelp.Name = "pBHelp";
            this.pBHelp.Size = new System.Drawing.Size(32, 35);
            this.pBHelp.TabIndex = 0;
            this.pBHelp.TabStop = false;
            this.pBHelp.Click += new System.EventHandler(this.pBHelp_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox4.Controls.Add(this.lbInterfaces);
            this.groupBox4.Controls.Add(this.rbDescription);
            this.groupBox4.Controls.Add(this.rbNames);
            this.groupBox4.Controls.Add(this.cbNIC);
            this.groupBox4.Location = new System.Drawing.Point(565, 2);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox4.Size = new System.Drawing.Size(219, 91);
            this.groupBox4.TabIndex = 27;
            this.groupBox4.TabStop = false;
            // 
            // lbInterfaces
            // 
            this.lbInterfaces.AutoSize = true;
            this.lbInterfaces.Location = new System.Drawing.Point(4, 11);
            this.lbInterfaces.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbInterfaces.Name = "lbInterfaces";
            this.lbInterfaces.Size = new System.Drawing.Size(100, 13);
            this.lbInterfaces.TabIndex = 26;
            this.lbInterfaces.Text = "Network Interfaces:";
            // 
            // rbDescription
            // 
            this.rbDescription.AutoSize = true;
            this.rbDescription.Location = new System.Drawing.Point(140, 67);
            this.rbDescription.Margin = new System.Windows.Forms.Padding(2);
            this.rbDescription.Name = "rbDescription";
            this.rbDescription.Size = new System.Drawing.Size(78, 17);
            this.rbDescription.TabIndex = 10;
            this.rbDescription.Text = "Description";
            this.rbDescription.UseVisualStyleBackColor = true;
            // 
            // rbNames
            // 
            this.rbNames.AutoSize = true;
            this.rbNames.Checked = true;
            this.rbNames.Location = new System.Drawing.Point(8, 67);
            this.rbNames.Margin = new System.Windows.Forms.Padding(2);
            this.rbNames.Name = "rbNames";
            this.rbNames.Size = new System.Drawing.Size(53, 17);
            this.rbNames.TabIndex = 9;
            this.rbNames.TabStop = true;
            this.rbNames.Text = "Name";
            this.rbNames.UseVisualStyleBackColor = true;
            this.rbNames.CheckedChanged += new System.EventHandler(this.rbNames_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox3.Controls.Add(this.lblUseSubnet);
            this.groupBox3.Controls.Add(this.cbHostnames);
            this.groupBox3.Controls.Add(this.tbTimeOut);
            this.groupBox3.Controls.Add(this.lblTimeout);
            this.groupBox3.Controls.Add(this.cbUseSubnet);
            this.groupBox3.Controls.Add(this.lblResolve);
            this.groupBox3.Location = new System.Drawing.Point(388, 2);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(170, 91);
            this.groupBox3.TabIndex = 27;
            this.groupBox3.TabStop = false;
            // 
            // lblUseSubnet
            // 
            this.lblUseSubnet.AutoSize = true;
            this.lblUseSubnet.Location = new System.Drawing.Point(4, 67);
            this.lblUseSubnet.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUseSubnet.Name = "lblUseSubnet";
            this.lblUseSubnet.Size = new System.Drawing.Size(91, 13);
            this.lblUseSubnet.TabIndex = 25;
            this.lblUseSubnet.Text = "Use Subnetmask:";
            // 
            // cbHostnames
            // 
            this.cbHostnames.AutoSize = true;
            this.cbHostnames.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.cbHostnames.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cbHostnames.Location = new System.Drawing.Point(141, 40);
            this.cbHostnames.Margin = new System.Windows.Forms.Padding(2);
            this.cbHostnames.Name = "cbHostnames";
            this.cbHostnames.Size = new System.Drawing.Size(15, 14);
            this.cbHostnames.TabIndex = 16;
            this.cbHostnames.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.cbHostnames.UseVisualStyleBackColor = false;
            this.cbHostnames.CheckedChanged += new System.EventHandler(this.cbHostnames_CheckedChanged);
            // 
            // tbTimeOut
            // 
            this.tbTimeOut.Location = new System.Drawing.Point(85, 11);
            this.tbTimeOut.Margin = new System.Windows.Forms.Padding(2);
            this.tbTimeOut.Name = "tbTimeOut";
            this.tbTimeOut.Size = new System.Drawing.Size(71, 20);
            this.tbTimeOut.TabIndex = 18;
            this.tbTimeOut.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbTimeOut_KeyDown);
            this.tbTimeOut.Leave += new System.EventHandler(this.tbTimeOut_Leave);
            // 
            // lblTimeout
            // 
            this.lblTimeout.AutoSize = true;
            this.lblTimeout.Location = new System.Drawing.Point(4, 15);
            this.lblTimeout.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTimeout.Name = "lblTimeout";
            this.lblTimeout.Size = new System.Drawing.Size(70, 13);
            this.lblTimeout.TabIndex = 19;
            this.lblTimeout.Text = "Timeout (ms):";
            // 
            // cbUseSubnet
            // 
            this.cbUseSubnet.AutoSize = true;
            this.cbUseSubnet.Location = new System.Drawing.Point(141, 67);
            this.cbUseSubnet.Margin = new System.Windows.Forms.Padding(2);
            this.cbUseSubnet.Name = "cbUseSubnet";
            this.cbUseSubnet.Size = new System.Drawing.Size(15, 14);
            this.cbUseSubnet.TabIndex = 24;
            this.cbUseSubnet.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.cbUseSubnet.UseVisualStyleBackColor = true;
            this.cbUseSubnet.CheckedChanged += new System.EventHandler(this.cbUseSubnet_CheckedChanged);
            // 
            // lblResolve
            // 
            this.lblResolve.AutoSize = true;
            this.lblResolve.Location = new System.Drawing.Point(4, 40);
            this.lblResolve.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblResolve.Name = "lblResolve";
            this.lblResolve.Size = new System.Drawing.Size(105, 13);
            this.lblResolve.TabIndex = 21;
            this.lblResolve.Text = "Resolve Hostnames:";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox2.Controls.Add(this.tbSubnetMask);
            this.groupBox2.Controls.Add(this.tbIPStart);
            this.groupBox2.Controls.Add(this.tbIPEnd);
            this.groupBox2.Controls.Add(this.lbEndIP);
            this.groupBox2.Controls.Add(this.lblSubnetMask);
            this.groupBox2.Controls.Add(this.lbStartIP);
            this.groupBox2.Controls.Add(this.tbIPEndNetwork);
            this.groupBox2.Location = new System.Drawing.Point(188, 2);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(195, 90);
            this.groupBox2.TabIndex = 27;
            this.groupBox2.TabStop = false;
            // 
            // tbSubnetMask
            // 
            this.tbSubnetMask.Location = new System.Drawing.Point(81, 66);
            this.tbSubnetMask.Margin = new System.Windows.Forms.Padding(2);
            this.tbSubnetMask.Name = "tbSubnetMask";
            this.tbSubnetMask.Size = new System.Drawing.Size(104, 20);
            this.tbSubnetMask.TabIndex = 22;
            this.tbSubnetMask.TextChanged += new System.EventHandler(this.tbSubnetMask_TextChanged);
            this.tbSubnetMask.Enter += new System.EventHandler(this.tbSubnetMask_Enter);
            this.tbSubnetMask.Leave += new System.EventHandler(this.tbSubnetMask_Leave);
            // 
            // lblSubnetMask
            // 
            this.lblSubnetMask.AutoSize = true;
            this.lblSubnetMask.Location = new System.Drawing.Point(7, 66);
            this.lblSubnetMask.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSubnetMask.Name = "lblSubnetMask";
            this.lblSubnetMask.Size = new System.Drawing.Size(73, 13);
            this.lblSubnetMask.TabIndex = 23;
            this.lblSubnetMask.Text = "Subnet Mask:";
            // 
            // tbIPEndNetwork
            // 
            this.tbIPEndNetwork.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbIPEndNetwork.Location = new System.Drawing.Point(81, 38);
            this.tbIPEndNetwork.Margin = new System.Windows.Forms.Padding(2);
            this.tbIPEndNetwork.Name = "tbIPEndNetwork";
            this.tbIPEndNetwork.ReadOnly = true;
            this.tbIPEndNetwork.Size = new System.Drawing.Size(71, 20);
            this.tbIPEndNetwork.TabIndex = 17;
            this.tbIPEndNetwork.TextChanged += new System.EventHandler(this.tbIPEndNetwork_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox1.Controls.Add(this.tbPort);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnStop);
            this.groupBox1.Controls.Add(this.tbIP);
            this.groupBox1.Controls.Add(this.btnStart);
            this.groupBox1.Controls.Add(this.lbYIP);
            this.groupBox1.Location = new System.Drawing.Point(5, 1);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(175, 91);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            // 
            // tbPort
            // 
            this.tbPort.Location = new System.Drawing.Point(111, 36);
            this.tbPort.Margin = new System.Windows.Forms.Padding(2);
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(56, 20);
            this.tbPort.TabIndex = 25;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 41);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Check Port:";
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnStop.Location = new System.Drawing.Point(111, 58);
            this.btnStop.Margin = new System.Windows.Forms.Padding(2);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(56, 28);
            this.btnStop.TabIndex = 8;
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnStart.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnStart.Location = new System.Drawing.Point(8, 58);
            this.btnStart.Margin = new System.Windows.Forms.Padding(2);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(56, 28);
            this.btnStart.TabIndex = 2;
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btStart_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslOnline,
            this.tsslPortOpen});
            this.statusStrip1.Location = new System.Drawing.Point(0, 266);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 10, 0);
            this.statusStrip1.Size = new System.Drawing.Size(837, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsslOnline
            // 
            this.tsslOnline.Name = "tsslOnline";
            this.tsslOnline.Size = new System.Drawing.Size(59, 17);
            this.tsslOnline.Text = "tsslOnline";
            // 
            // tsslPortOpen
            // 
            this.tsslPortOpen.Name = "tsslPortOpen";
            this.tsslPortOpen.Size = new System.Drawing.Size(75, 17);
            this.tsslPortOpen.Text = "tsslPortOpen";
            // 
            // timer1
            // 
            this.timer1.Interval = 5000;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(837, 408);
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmMain";
            this.Text = "Network-Monitor";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pBHelp)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lbStartIP;
        private System.Windows.Forms.Label lbEndIP;
        private System.Windows.Forms.ComboBox cbNIC;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.TextBox tbIPStart;
        private System.Windows.Forms.TextBox tbIPEnd;
        private System.Windows.Forms.Label lbYIP;
        private System.Windows.Forms.TextBox tbIP;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox cbHostnames;
        private System.Windows.Forms.TextBox tbIPEndNetwork;
        private System.Windows.Forms.Label lblTimeout;
        private System.Windows.Forms.TextBox tbTimeOut;
        private System.Windows.Forms.Label lblUseSubnet;
        private System.Windows.Forms.CheckBox cbUseSubnet;
        private System.Windows.Forms.Label lblSubnetMask;
        private System.Windows.Forms.TextBox tbSubnetMask;
        private System.Windows.Forms.Label lblResolve;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbDescription;
        private System.Windows.Forms.RadioButton rbNames;
        private System.Windows.Forms.Label lbInterfaces;
        private System.Windows.Forms.TextBox tbPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.PictureBox pBHelp;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsslOnline;
        private System.Windows.Forms.ToolStripStatusLabel tsslPortOpen;
    }
}

