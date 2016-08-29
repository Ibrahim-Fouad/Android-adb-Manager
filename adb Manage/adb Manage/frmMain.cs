using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace adb_Manage
{
    public partial class frmMain : Form
    {
        List<ListViewItem> AllPackages = new List<ListViewItem>();
        public frmMain()
        {
            InitializeComponent();
            Thread thr = new Thread(WaitForDevices);
            thr.IsBackground = true;
            thr.Start();
        }

        Thread RefreshThread;

         public  string DeviceSerialNumber { get; set; }
        void WaitForDevices()
        {
            
            Log("Waiting For Devices...");
            ADB.Shell(" wait-for-device");
            Log("Getting Devices List...");

            GetConnectedDevices();
        }
        void GetConnectedDevices()
        {
            string Data = ADB.Shell(" devices");
            string[] AllData = Data.Split('\n');
            for (int i = 1; i < AllData.Length; i++)
            {
                string SerialNo = AllData[i].Substring(0, AllData[i].IndexOf('\t'));
                string DeviceModel = ADB.Shell(" -s " + SerialNo + " shell getprop ro.product.model");
                comboDevicesList.Invoke(() => { comboDevicesList.Items.Add(DeviceModel + " - " + SerialNo); });
                comboDevicesList.Invoke(() => { comboDevicesList.SelectedIndex = 0; });
                textBox1.Invoke(() => { textBox1.Enabled = true; });
            }
            btnGetPacks.Invoke(() => { btnGetPacks.Enabled = true; });
            lstPackagesList.Invoke(() => { lstPackagesList.Enabled = true; });
            Log("Loaded Successfully, Press \"Get Installed Packages\" Button To Load Packages...");
            comboDevicesList.Invoke(() => {
                DeviceSerialNumber = comboDevicesList.Items[0].ToString().Substring(
                comboDevicesList.SelectedItem.ToString().LastIndexOf(" - ") + 3
                ).Trim();
            });
        }

        void Log(string Msg,string operation = "log")
        {
            switch (operation.ToLower())
            {
                case "log":
                    if (statusStrip1.InvokeRequired)
                    {
                        statusStrip1.Invoke(new MethodInvoker(delegate()
                        {
                            lblStatus.Text = Msg;
                        }));
                    }
                    else
                    {
                        lblStatus.Text = Msg;
                    }
                    break;
                case "battery":
                    if (statusStrip2.InvokeRequired)
                    {
                        statusStrip2.Invoke(new MethodInvoker(delegate()
                        {
                            lblBattery.Text = Msg;
                        }));
                    }
                    else
                    {
                        lblBattery.Text = Msg;
                    }
                    break;
                case "temp":
                    if (statusStrip2.InvokeRequired)
                    {
                        statusStrip2.Invoke(new MethodInvoker(delegate()
                        {
                            lblTemp.Text = Msg;
                        }));
                    }
                    else
                    {
                        lblTemp.Text = Msg;
                    }
                    break;
                default:
                    if (statusStrip1.InvokeRequired)
                    {
                        statusStrip1.Invoke(new MethodInvoker(delegate()
                        {
                            lblStatus.Text = Msg;
                        }));
                    }
                    else
                    {
                        lblStatus.Text = Msg;
                    }
                    break;
            }
        }
        
        void LoadPackages()
        {
            btnGetPacks.Invoke(() => {
                btnGetPacks.Enabled = false;
                btnGetPacks.Text = "Getting Packages..."; 
            });
            string SerialNo = string.Empty;
            comboDevicesList.Invoke(() =>
            {
                 SerialNo = comboDevicesList.SelectedItem.ToString().Substring(
                comboDevicesList.SelectedItem.ToString().LastIndexOf(" - ") + 3
                ).Trim();});
            Log("Getting Installed Packages...");
            string AllApps = ADB.Shell(" -s " + SerialNo + " shell pm list packages -f -u");
            AllApps += ADB.Shell(" -s " + SerialNo + " shell pm list packages -f -d");
            //AllApps += ADB.Shell("-s " + SerialNo + " shell pm list packages -f -s");
            AllPackages = new List<ListViewItem>();
            lstPackagesList.Invoke(() =>
            {
                lstPackagesList.Items.Clear();
            });
            short num = 0;
            string[] PacksInArray = AllApps.Replace("/", @"\").Split('\r');
            for (int i = 0; i < PacksInArray.Length; i++)
            {
                if (string.IsNullOrEmpty(PacksInArray[i]) || PacksInArray[i].Contains("SystemUI"))
                    continue;
                string[] Data = PacksInArray[i].Trim().Substring(8).Split('=');
                ListViewItem itm = new ListViewItem();
                itm.Text = Data[0].Substring(Data[0].LastIndexOf(@"\") + 1);
                itm.SubItems.Add(Data[1]);
                itm.SubItems.Add(Data[0]);
                lstPackagesList.Invoke(() =>
                {
                    lstPackagesList.Items.Add(itm);
                    AllPackages.Add(itm);
                });
                num++;
                Log("Proccessing " + num + " Packages...");
            }
           lstPackagesList.Invoke(() => { 
                lstPackagesList.Sorting = SortOrder.Ascending;
                lstPackagesList.Sort();
            });
            Log("Successfully Loaded " + num + " Packages...");
            btnGetPacks.Invoke(() =>
            {
                btnGetPacks.Enabled = true;
                btnGetPacks.Text = "Get Installed Packages";
            });
           
        }
        private void btnGetPacks_Click(object sender, EventArgs e)
        {
            Thread thr = new Thread(LoadPackages);
            thr.IsBackground = true;
            thr.Start();
        }

        private void lstPackagesList_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            btnRemoveSelected.Enabled = lstPackagesList.CheckedItems.Count > 0 ? true : false;
        }

        private void btnRemoveSelected_Click(object sender, EventArgs e)
        {
            Thread thr = new Thread(DeleteSelected);
            thr.IsBackground = true;
            thr.Start();
        }
        void DeleteSelected()
        {

            //ListView.CheckedListViewItemCollection checkeditems = null;
            List<string> Packs = new List<string>();
            lstPackagesList.Invoke(() => {
                foreach (ListViewItem itm in lstPackagesList.CheckedItems)
                {
                    Packs.Add(itm.SubItems[1].Text);
                }
            });
            foreach (var itm in Packs)
            {
                Log("Uninstalling " + itm + "...");
                string msg = ADB.Shell(" -s " + DeviceSerialNumber + " uninstall " + itm);
                Log("Uninstalling " + itm + " " + msg + "...");
                // MessageBox.Show(msg);
            }
            btnGetPacks.Invoke(() =>
            {
                btnGetPacks.PerformClick();
            });
        }

        private void installNewAppToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //OpenFileDialog opn = new OpenFileDialog();
            //opn.Filter = "APK Files |*.apk";
            //if (opn.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //{
            //    opn.FileName = opn.FileName.Replace(@"\", "/");
            //    Log("Installing \"" + opn.FileName + "\"...");
            //    MessageBox.Show(ADB.Shell("-s " + DeviceSerialNumber + " install \"" + opn.FileName + "\""));
            //}
            frmInstallApp frm = new frmInstallApp();
            frm.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text.Trim()))
            {
                List<ListViewItem> list = new List<ListViewItem>();

                foreach (ListViewItem itm in AllPackages)
                {
                    if (itm.Text.ToLower().Contains(textBox1.Text.ToLower()) || itm.SubItems[1].Text.ToLower().Contains(textBox1.Text.ToLower()))
                    {
                        list.Add(itm);
                    }
                }
                lstPackagesList.Items.Clear();
                lstPackagesList.Items.AddRange(list.ToArray());

            }
            else
            {
                lstPackagesList.Items.Clear();
                lstPackagesList.Items.AddRange(AllPackages.ToArray());
            }
        }

        private void timerRefresh_Tick(object sender, EventArgs e)
        {
           
            //timerRefresh.Stop();
        }
      void RefreshDeviceInfo()
        {
            while (true)
            {
                string battery = ADB.Shell(" -s " + DeviceSerialNumber + " shell dumpsys battery");
                string percent = battery.Split('\n')[6].Trim().Substring(6);
                string temp = battery.Split('\n')[9].Trim().Substring(12);
                Log("Battery: " + percent + "%", "battery");
                Log("Temp: " + temp.Trim().Substring(0,2), "temp");
                Thread.Sleep(2000);
            }
        }

        private void comboDevicesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            DeviceSerialNumber = comboDevicesList.SelectedItem.ToString().Substring(
                comboDevicesList.SelectedItem.ToString().LastIndexOf(" - ") + 3
                ).Trim();
        }

        private void lstPackagesList_EnabledChanged(object sender, EventArgs e)
        {
            RefreshThread = new Thread(() => RefreshDeviceInfo());
            RefreshThread.IsBackground = true;
            RefreshThread.Start();
        }

        private void checkTakeScreenshot_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void backupSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = true;
            Thread backup = new Thread(() =>
            {
                Log("Backing up " + lstPackagesList.FocusedItem.SubItems[0].Text + "...");
                ADB.Shell(" -s " + DeviceSerialNumber + " pull " + ADB.Shell(" -s " + DeviceSerialNumber + " shell pm path " + lstPackagesList.FocusedItem.SubItems[1].Text).Substring(8) + " backup/" + lstPackagesList.FocusedItem.SubItems[0].Text);
                Log("Backing " + lstPackagesList.FocusedItem.SubItems[0].Text + " up succeeded to \"Backup\\" + lstPackagesList.FocusedItem.SubItems[0].Text  + "\"");
            });
            backup.Start();
            CheckForIllegalCrossThreadCalls = false;
        }


        private void clearAppDataToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("All data and account for this app will be removed\nAre you sure ?!", "Clear Data", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                Log("Clearing " + lstPackagesList.FocusedItem.Text + " data...");
                Log(string.Format("\"{0}\" data clearing  {1}", lstPackagesList.FocusedItem.Text, ADB.Shell(" -s " + DeviceSerialNumber + " shell pm clear " + lstPackagesList.FocusedItem.SubItems[1].Text)));
            }
        }

        


    }
}
/// <summary>
/// For Safe Thread
/// </summary>
public static class ControlExtensions
{
    public static void Invoke(this Control control, Action action)
    {
        if (control.InvokeRequired)
        {
            control.Invoke(new MethodInvoker(action), null);
        }
        else
        {
            action.Invoke();
        }
    }
}