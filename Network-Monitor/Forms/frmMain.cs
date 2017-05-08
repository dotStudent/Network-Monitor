using System;
using System.Drawing;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Concurrent;
using DGVColumnSelector;
using Network_Monitor.FormHelpers;
using Network_Monitor.IP;
using Network_Monitor.IPChecks;


namespace Network_Monitor.Forms
{
    public partial class frmMain : Form
    {
        ConcurrentStack<string> messageBox = new ConcurrentStack<string>(); //List with new or disappeared hosts
        SortedBindingList<Host> ips = new SortedBindingList<Host>(); //List of hosts as Datagridview source
        IPSegment ipSeg;
        int timeout = 1000; //ms //Ping Timeout
        int cycleTime = 10; //s //Minimum duration from between two pings of the same host

        string firstIP = "";
        string lastIP = "";
        string nwpartial = "";
        int port;

        int addresses;
        int online;
        int portOpen;

        #region Constructor
        public frmMain()
        {
            InitializeComponent();

            this.Icon = Properties.Resources.Icons_Land_Vista_Hardware_Devices_Ethernet_Cable;
            btnStart.Image = Properties.Resources.Sekkyumu_Developpers_Play.ToBitmap();
            btnStop.Image = Properties.Resources.Sekkyumu_Developpers_Stop.ToBitmap();
            pBHelp.Image = Properties.Resources.Fatcow_Farm_Fresh_Information.ToBitmap();
            Nic.LoadNIC(); //Load all Nic's
            SetupForm(rbNames.Enabled); //Fill in everything needed
            timer1.Interval = 500; //Intervall CheckHosts is called
            timer1.Tick += new EventHandler(timer1_Tick);
        }
        #endregion

        #region Events
        private void btStart_Click(object sender, EventArgs e)
        {
            if (isNumeric(tbTimeOut.Text) == true)
            {
                port = 0;
                btnStart.Enabled = false;
                btnStop.Enabled = true;
                tbIPStart.Enabled = false;
                tbIPEnd.Enabled = false;
                cbNIC.Enabled = false;
                cbUseSubnet.Enabled = false;
                cbNIC.Enabled = false;
                rbNames.Enabled = false;
                rbDescription.Enabled = false;
                tbPort.Enabled = false;
                ips.Clear();
                timeout = Convert.ToInt32(tbTimeOut.Text);
                GetHosts();

                dataGridView1.DataSource = ips;
                DataGridViewColumnSelector dgvCS = new DataGridViewColumnSelector();
                dgvCS.DataGridView = dataGridView1;
                dataGridView1.ReadOnly = true;
                dataGridView1.AllowUserToAddRows = false;

                dataGridView1.Columns["Hostname"].Visible = false;
                dataGridView1.Columns["First_Seen"].DefaultCellStyle.Format = "dd/MM HH:mm:ss";
                dataGridView1.Columns["Last_Seen"].DefaultCellStyle.Format = "dd/MM HH:mm:ss";
                dataGridView1.Columns["Last_Checked"].DefaultCellStyle.Format = "dd/MM HH:mm:ss";
                dataGridView1.Columns["Last_Checked"].Visible = false;
                dataGridView1.Columns["RunningCheck"].Visible = false;
                dataGridView1.Columns["CountChecks"].Visible = false;

                timer1.Start();
            }
            else
            {
                MessageBox.Show("Enter valid Timeout!");
            }
            if (tbPort.Text != "" && IpHelpers.IsValidPort(tbPort.Text) == true)
            {
                port = Convert.ToInt32(tbPort.Text);
                dataGridView1.Columns["PortOpen"].Visible = true;
            }
            else if (tbPort.Text != "" && IpHelpers.IsValidPort(tbPort.Text) == false)
            {
                MessageBox.Show("Enter valid Port or leave empty");
                dataGridView1.Columns["PortOpen"].Visible = false;
            }
            else
            {
                dataGridView1.Columns["PortOpen"].Visible = false;
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            CheckStatus();
            //Use Restart Timer for Second Form
            if (FormsHelper.MessageBoxVisible == false && FormsHelper.MsgBoxMessage.Length != 0)
            {
                //Messagebox is not open and Message is not "";
                // Get Center Point of Main Form and pass to new Form
                int x = 0;
                int y = 0;
                GetFormCenter(out x, out y);
                MsgBox box = new MsgBox(x, y);
                box.Show();
            }
        }
        private void cbNIC_SelectedIndexChanged(object sender, EventArgs e)
        {//Refresh local IP based on selected Nic
            if (cbNIC.SelectedItem != null)
            {
                tbIP.Text = ((Nic)cbNIC.SelectedItem).IP.ToIpString();
                tbSubnetMask.Text = ((Nic)cbNIC.SelectedItem).Mask.ToIpString();
                SetupForm(rbNames.Enabled);
            }
        }
        private void btnStop_Click(object sender, EventArgs e)
        {
            timer1.Stop(); //Stop the Timer who is always starting the check
            btnStart.Enabled = true;
            btnStop.Enabled = false;
            tbIPStart.Enabled = true;
            tbIPEnd.Enabled = true;
            cbNIC.Enabled = true;
            cbUseSubnet.Enabled = true;
            cbNIC.Enabled = true;
            rbNames.Enabled = true;
            rbDescription.Enabled = true;
            tbPort.Enabled = true;
        }
        private void tbIPStart_TextChanged(object sender, EventArgs e)
        {
            if (IpHelpers.isValidIP(tbIPStart.Text) == true) //Fill Network for LastIP
            {
                //Check if First end Last IP is in Subnet
                ipSeg = new IPSegment(tbIPStart.Text, tbSubnetMask.Text);
                if (cbUseSubnet.Checked == true)
                {
                    if (CheckFirstIP() == true)
                    {
                        btnStart.Enabled = true;
                        tbIPEndNetwork.Enabled = true;
                        tbIPEnd.Enabled = true;
                    }
                    else
                    {
                        btnStart.Enabled = false;
                        tbIPEndNetwork.Enabled = false;
                        tbIPEnd.Enabled = false;
                    }
                }
                else
                {
                    if (cbUseSubnet.Enabled == true)
                    {
                        tbIPEndNetwork.Text = IPFirstPart(tbIPStart.Text);
                    }
                    btnStart.Enabled = true;
                }
            }
            else
            {
                tbIPEndNetwork.Enabled = false;
                tbIPEnd.Enabled = false;
                btnStart.Enabled = false;
            }
        }
        private void tbIPEnd_TextChanged(object sender, EventArgs e) //Check if value is correct
        {
            if (cbUseSubnet.Checked == true)
            {
                if (CheckLastIP() == true)
                {
                    btnStart.Enabled = true;
                }
                else
                {
                    btnStart.Enabled = false;
                }
            }
            else
            {
                if (isNumeric(tbIPEnd.Text) == true)
                {
                    int retNum = Convert.ToInt32(tbIPEnd.Text);
                    if (retNum > 0 && retNum < 255)
                    {
                        btnStart.Enabled = true;
                    }
                }
                else
                {
                    btnStart.Enabled = false;
                }
            }
        }
        private void dataGridView1_Sorted(object sender, EventArgs e) //Color rows new after using sorting
        {
            CellColor();
        }
        private void tbIPEndNetwork_TextChanged(object sender, EventArgs e)
        {
            if (CheckLastIP() == true)
            {
                btnStart.Enabled = true;
            }
            else
            {
                btnStart.Enabled = false;
            }
        }
        private void cbUseSubnet_CheckedChanged(object sender, EventArgs e)
        {
            if (cbUseSubnet.Checked == true)
            {
                tbSubnetMask.ReadOnly = false;
                calcSubnet();
            }
            else
            {
                tbSubnetMask.ReadOnly = true;
                tbIPEndNetwork.ReadOnly = true;
                tbIPStart.Text = nwpartial +"1";
                tbIPEndNetwork.Text = nwpartial;
            }
        }
        private void tbSubnetMask_TextChanged(object sender, EventArgs e)
        {
            calcSubnet();
        }
        private void tbTimeOut_Leave(object sender, EventArgs e)
        {
            int newtimeout = 0;
            if (isNumeric(tbTimeOut.Text) == true)
            {
                newtimeout = Convert.ToInt32(tbTimeOut.Text);
                if (newtimeout >= 100 && newtimeout <= 10000)
                {
                    timeout = newtimeout;
                }
                else
                {
                    newtimeout = 0;
                }
            }
            if (newtimeout == 0)
            {
                tbTimeOut.Text = timeout.ToString();
            }
        }
        private void tbTimeOut_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                SelectNextControl(ActiveControl, true, true, true, true);
            }
        }
        private void rbNames_CheckedChanged(object sender, EventArgs e)
        {
            SetupForm(rbNames.Checked);
        }
        private void tbIP_DoubleClick(object sender, EventArgs e)
        {
            tbIPStart.Text = tbIP.Text;
        }
        private void tbSubnetMask_Leave(object sender, EventArgs e)
        {
            calcSubnet();
        }
        private void tbSubnetMask_Enter(object sender, EventArgs e)
        {
            calcSubnet();
        }
        private void pBHelp_Click(object sender, EventArgs e)
        {
            ShowHelp();
        }
        private void cbHostnames_CheckedChanged(object sender, EventArgs e)
        {
            if (cbHostnames.Checked)
            {
                dataGridView1.Columns["Hostname"].Visible = true;
            }
            //else
            //{
            //    dataGridView1.Columns["Hostname"].Visible = false;
            //}

        }
        #endregion

        #region Helper Methods
        private void calcSubnet()
        {
            if (cbUseSubnet.Checked == true)
            {
                if (IpHelpers.isValidIP(tbSubnetMask.Text))
                {
                    btnStart.Enabled = true;
                    tbIPStart.Enabled = true;
                    tbIPEndNetwork.Enabled = true;
                    tbIPEnd.Enabled = true;

                    ipSeg = new IPSegment(tbIPStart.Text, tbSubnetMask.Text);
                    tbIPStart.Text = ipSeg.FirstIP.ToIpString();

                    tbIPEndNetwork.Text = IPFirstPart(ipSeg.LastIP.ToIpString());
                    tbIPEnd.Text = IPLastPart(ipSeg.LastIP.ToIpString());
                    tbIPEndNetwork.ReadOnly = false;
                }
                else
                {
                    btnStart.Enabled = false;
                    tbIPStart.Enabled = false;
                    tbIPEndNetwork.Enabled = false;
                    tbIPEnd.Enabled = false;
                }
            }
        }
        private bool isNumeric(string number)
        {
            double retNum;
            bool isNum = Double.TryParse((number), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;
        }
        private bool CheckLastIP()
        {
            string endIP = tbIPEndNetwork.Text + tbIPEnd.Text;
            if (IpHelpers.isValidIP(endIP) && tbIPEndNetwork.Text != "" && tbIPEnd.Text != "")
            {
                if (ipSeg.isInNetwork(endIP) == true)
                {
                    lastIP = endIP;
                    return true;
                }
                return false;
            }
            return false;
        }
        private bool CheckFirstIP()
        {
            string startIP = tbIPStart.Text;
            if (IpHelpers.isValidIP(startIP) && startIP != "")
            {
                if (ipSeg.isInNetwork(startIP) == true)
                {
                    firstIP = startIP;
                    return true;
                }
                return false;
            }
            return false;
        }
        private string IPFirstPart(string ip)
        {
            return ip.Substring(0, ip.LastIndexOf(".") + 1);
        }
        private string IPLastPart(string ip)
        {
            return ip.Substring(ip.LastIndexOf('.') + 1); ;
        }
        private void GetFormCenter(out int x1, out int y1)
        {
            //Calculate Center of Main Form
            x1 = this.Location.X + this.Size.Width / 2;
            y1 = this.Location.Y + this.Size.Height / 2;
        }
        private void ShowHelp()
        {
            // Get Center Point of Main Form and pass to new Form
            int x = 0;
            int y = 0;
            GetFormCenter(out x, out y);
            frmHelp frm = new frmHelp(x, y);
            frm.Show();
        }
        private void SetupForm(bool showNames)
        {
            tbTimeOut.Text = timeout.ToString();
            if (Nic.nics.Count > 0)
            {
                cbNIC.DataSource = Nic.nics;
                if (showNames == true)
                {
                    cbNIC.DisplayMember = "Name";
                }
                else
                {
                    cbNIC.DisplayMember = "Description";
                }
                cbNIC.ValueMember = "IP";

                btnStop.Enabled = false;
                tbSubnetMask.ReadOnly = true;
                tsslOnline.Text = "";
                tsslPortOpen.Text = "";
                string ip = tbIP.Text;
                nwpartial = IPFirstPart(ip);
                tbIPStart.Text = nwpartial + "1";
                tbIPEndNetwork.Text = nwpartial;
                tbIPEnd.Text = "254";
                //tbTimeOut.Text = "1000";
                FormsHelper.MessageBoxVisible = false;
                FormsHelper.MsgBoxMessage = "";
            }
        }
        private void GetHosts()
        {
            ips.Clear(); //Clear Hosts List
            if (IpHelpers.isValidIP(tbIPStart.Text) == true && IpHelpers.isValidIP(tbIPEnd.Text) && cbUseSubnet.Checked == false)
            {
                string ipStart = tbIPStart.Text;
                string ipEnd = tbIPEnd.Text;
                string ipNet = IPFirstPart(ipStart);
                int ipStartSub = Convert.ToInt32(IPLastPart(ipStart));
                int ipEndSub = Convert.ToInt32(ipEnd);

                if (ipStartSub <= ipEndSub)
                {
                    for (int i = ipStartSub; i <= ipEndSub; i++)
                    {
                        IPAddress newIP = IPAddress.Parse(ipNet + i.ToString());
                        Host newHost = new Host();
                        newHost.IP_Address = newIP;
                        newHost.CountChecks = 0;
                        newHost.RunningCheck = false;
                        ips.Add(newHost);
                    }
                }
            }
            if (IpHelpers.isValidIP(tbIPStart.Text) == true && cbUseSubnet.Checked == true)
            {
                foreach (var host in ipSeg.Hosts())
                {
                    if (host >= IpHelpers.ParseIp(firstIP) && host <= IpHelpers.ParseIp(lastIP))
                    {
                        //Prevent ip .0 and .255 in List
                        if (Convert.ToInt32(IPLastPart(host.ToIpString())) > 0 && Convert.ToInt32(IPLastPart(host.ToIpString())) < 255)
                        {
                            IPAddress newIP = IPAddress.Parse(host.ToIpString());
                            Host newHost = new Host();
                            newHost.IP_Address = newIP;
                            newHost.CountChecks = 0;
                            newHost.RunningCheck = false;
                            ips.Add(newHost);
                        }
                    }
                }
            }
        }
        public void CheckStatus()
        {
            Task t = Task.Run(() =>
            { //Prevents Lock of Form
                try
                {
                    Parallel.ForEach(ips, (x) => //does parallel but only exit after all finished
                    {
                        if (x.Last_Checked == null || (x.Last_Checked + TimeSpan.FromSeconds(cycleTime) < DateTime.Now && x.RunningCheck == false))
                        {//Never checked or last Check older than cycleTime
                            x.RunningCheck = true;
                            x.Last_Checked = DateTime.Now;
                            PingReply reply = Pinger.PingIP(x.IP_Address.ToString(), timeout);  //new PingReply();

                            if (reply != null)
                            {//Ping is not null (means success or not)
                                string hostname = "";
                                if (cbHostnames.Checked == true && x.Hostname != null)
                                { //Resolve hostname is enabled
                                    hostname = Hostname.Get(x.IP_Address.ToString());
                                    x.Hostname = hostname;
                                }
                                bool online = false;

                                if (reply.Status == IPStatus.Success)
                                {//Host is online
                                    online = true;
                                    if (x.First_Seen == null)
                                    {
                                        x.First_Seen = DateTime.Now;
                                    }
                                    x.Roundtrip = Convert.ToInt32(reply.RoundtripTime);
                                    x.Last_Seen = DateTime.Now;
                                    if (port != 0)
                                    {
                                        x.PortOpen = PortChecker.ScanPort(x.IP_Address, port);
                                    }
                                }
                                if (x.Active == false && online == true)
                                {//Host Status changed from offline to online
                                 //New Host
                                    if (port != 0)
                                    {
                                        messageBox.Push("NEW:                   " + x.IP_Address + ", " + x.Hostname + " First Seen: " + x.First_Seen + " Port " + port + ": " + x.PortOpen);
                                    }
                                    else
                                    {
                                        messageBox.Push("NEW:                   " + x.IP_Address + ", " + x.Hostname + " First Seen: " + x.First_Seen);
                                    }
                                }
                                else if (x.Active == true && online == false)
                                {//Host Status changed from online to offline
                                    if (port != 0)
                                    {
                                        messageBox.Push("DISAPPEARED: " + x.IP_Address + ", " + x.Hostname + " Last Seen: " + x.Last_Seen + " Port " + port + ": " + x.PortOpen);
                                    }
                                    else
                                    {
                                        messageBox.Push("DISAPPEARED: " + x.IP_Address + ", " + x.Hostname + " Last Seen: " + x.Last_Seen);
                                    }
                                }
                                x.Last_Checked = DateTime.Now;
                                x.Active = online;
                                x.CountChecks++;
                                x.RunningCheck = false;
                            }
                        }
                    });
                }
                catch (System.AggregateException e)
                {
                    throw e;
                }
            });
            UpdateMessage();
        }
        private void UpdateMessage() //Update Form within the loop
        {
            if (this.dataGridView1.InvokeRequired) //consider Threading...
            {
                this.dataGridView1.BeginInvoke((MethodInvoker)delegate () { this.dataGridView1.Refresh(); });
                foreach (string host in messageBox)
                {
                    FormsHelper.MsgBoxMessage = FormsHelper.MsgBoxMessage + host + Environment.NewLine;
                }
                messageBox.Clear();
                CellColor();
            }
            else //The same but without invoking
            {
                this.dataGridView1.Refresh();
                foreach (string host in messageBox)
                {
                    FormsHelper.MsgBoxMessage = FormsHelper.MsgBoxMessage + host + Environment.NewLine;
                }
                messageBox.Clear();
                CellColor();
            }
        }
        public void CellColor()
        {//Color rows depending on status
            int countAddresses = 0;
            int countOnline = 0;
            int countPortOpen = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                countAddresses++;
                bool? status = Convert.ToBoolean(row.Cells["Active"].Value);

                if (row.Cells["Active"].Value != null)
                {
                    if (status == true) //Host is online
                    {
                        countOnline++;
                        if (Convert.ToString(row.Cells["PortOpen"].Value) == "True")
                        {
                            countPortOpen++;
                        }
                        foreach (Nic nwcard in Nic.nics) //Check for each IP if its own IP
                        {
                            if (Convert.ToString(row.Cells["IP_Address"].Value) == tbIP.Text)
                            {
                                //IP from selected local Interface is yellow
                                row.DefaultCellStyle.BackColor = Color.LightBlue;
                            }
                            else if (Convert.ToString(row.Cells["IP_Address"].Value) == nwcard.IP.ToString() && Convert.ToString(row.Cells["IP_Address"].Value) != tbIP.Text)
                            {
                                //IP from other local Interface is Light Cyan
                                row.DefaultCellStyle.BackColor = Color.LightCyan;
                            }
                            else if (port != 0 && Convert.ToString(row.Cells["PortOpen"].Value) != "True")
                            {
                                //Host is online but Port is closed
                                row.DefaultCellStyle.BackColor = Color.Yellow;
                            }
                            else
                            {
                                //Host is online, Port is open
                                row.DefaultCellStyle.BackColor = Color.LightGreen; //Online is Green
                            }
                        }
                    }
                    else if (status == false)
                    {
                        //Host is offline
                        row.DefaultCellStyle.BackColor = Color.Red;
                    }
                }
            }
            if (countAddresses != addresses)
            {
                addresses = countAddresses;
            }
            if (countOnline != online)
            {
                online = countOnline;
            }
            if (port != 0)
            {
                if (countPortOpen != portOpen)
                {
                    portOpen = countPortOpen;
                }
                tsslPortOpen.Text = portOpen + "/" + online + " Hosts Online with open Port";
            }
            tsslOnline.Text = online + "/" + addresses + " Hosts Online";
        } //Change Datagrid Row Color regarding the status
        #endregion


    }
}
