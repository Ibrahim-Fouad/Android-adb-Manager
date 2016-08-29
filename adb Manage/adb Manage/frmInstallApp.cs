using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace adb_Manage
{
    public partial class frmInstallApp : Form
    {
        public frmInstallApp()
        {
            InitializeComponent();
        }
        Thread thr;
        #region Methods
            void InstallApps()
            {

                List<string> Paths = new List<string>();
                lstPaths.Invoke(() =>
                {
                    for (int i = 0; i < lstPaths.Items.Count; i++)
                    {
                        Paths.Add(lstPaths.Items[i].SubItems[1].Text);
                    }
                });
                for (int i = 0; i < Paths.Count; i++)
                {
                    lstPaths.Invoke(() =>
                    {
                        lstPaths.Items[i].SubItems[2].Text = "Preparing...";
                    });
                    File.Copy(Paths[i], "apkfile.apk",true);
                    lstPaths.Invoke(() =>
                    {
                        lstPaths.Items[i].SubItems[2].Text = "Installing...";
                        lstPaths.Items[i].ForeColor = Color.Blue;
                    });
                    string Result = ADB.Shell(" install apkfile.apk"); ;
                    lstPaths.Invoke(() =>
                    {
                        lstPaths.Items[i].SubItems[2].Text = Result;
                        lstPaths.Items[i].ForeColor = Color.Green;
                    });
                }
                btnInstall.Invoke(() => { btnInstall.Enabled = true; });
            }
        #endregion
        private void btnClear_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this,"Are You Sure ?!","Clear Apps",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                lstPaths.Items.Clear();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            OpenFileDialog opn = new OpenFileDialog();
            opn.Filter = "APK Files |*.apk";
            opn.Multiselect = true;
            if (opn.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                for (int i = 0; i < opn.FileNames.Length; i++)
                {
                    ListViewItem itm = new ListViewItem();
                    itm.Text = Path.GetFileName(opn.FileNames[i]);
                    itm.SubItems.Add(opn.FileNames[i]);
                    itm.SubItems.Add("Ready");
                    lstPaths.Items.Add(itm);
                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            lstPaths.Items.Remove(lstPaths.FocusedItem);
        }
        
        private void btnInstall_Click(object sender, EventArgs e)
        {
            thr = new Thread(InstallApps);
            thr.IsBackground = true;
            thr.Start();
            btnInstall.Enabled = false;
        }
    }
}
