namespace adb_Manage
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
            this.lstPackagesList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextOptions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.installNewAppToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backupSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearAppDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comboDevicesList = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnGetPacks = new System.Windows.Forms.Button();
            this.btnRemoveSelected = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.statusStrip2 = new System.Windows.Forms.StatusStrip();
            this.lblBattery = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTemp = new System.Windows.Forms.ToolStripStatusLabel();
            this.contextOptions.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.statusStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstPackagesList
            // 
            this.lstPackagesList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstPackagesList.CheckBoxes = true;
            this.lstPackagesList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lstPackagesList.ContextMenuStrip = this.contextOptions;
            this.lstPackagesList.Enabled = false;
            this.lstPackagesList.FullRowSelect = true;
            this.lstPackagesList.GridLines = true;
            this.lstPackagesList.Location = new System.Drawing.Point(12, 62);
            this.lstPackagesList.Name = "lstPackagesList";
            this.lstPackagesList.Size = new System.Drawing.Size(823, 365);
            this.lstPackagesList.TabIndex = 0;
            this.lstPackagesList.UseCompatibleStateImageBehavior = false;
            this.lstPackagesList.View = System.Windows.Forms.View.Details;
            this.lstPackagesList.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lstPackagesList_ItemChecked);
            this.lstPackagesList.EnabledChanged += new System.EventHandler(this.lstPackagesList_EnabledChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "APK File";
            this.columnHeader1.Width = 282;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Package";
            this.columnHeader2.Width = 272;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Package Path";
            this.columnHeader3.Width = 247;
            // 
            // contextOptions
            // 
            this.contextOptions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.installNewAppToolStripMenuItem,
            this.removeSelectedToolStripMenuItem,
            this.backupSelectedToolStripMenuItem,
            this.clearAppDataToolStripMenuItem});
            this.contextOptions.Name = "contextOptions";
            this.contextOptions.Size = new System.Drawing.Size(165, 92);
            // 
            // installNewAppToolStripMenuItem
            // 
            this.installNewAppToolStripMenuItem.Name = "installNewAppToolStripMenuItem";
            this.installNewAppToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.installNewAppToolStripMenuItem.Text = "Install New App";
            this.installNewAppToolStripMenuItem.Click += new System.EventHandler(this.installNewAppToolStripMenuItem_Click);
            // 
            // removeSelectedToolStripMenuItem
            // 
            this.removeSelectedToolStripMenuItem.Name = "removeSelectedToolStripMenuItem";
            this.removeSelectedToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.removeSelectedToolStripMenuItem.Text = "Remove Selected";
            // 
            // backupSelectedToolStripMenuItem
            // 
            this.backupSelectedToolStripMenuItem.Name = "backupSelectedToolStripMenuItem";
            this.backupSelectedToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.backupSelectedToolStripMenuItem.Text = "Backup Selected";
            this.backupSelectedToolStripMenuItem.Click += new System.EventHandler(this.backupSelectedToolStripMenuItem_Click);
            // 
            // clearAppDataToolStripMenuItem
            // 
            this.clearAppDataToolStripMenuItem.Name = "clearAppDataToolStripMenuItem";
            this.clearAppDataToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.clearAppDataToolStripMenuItem.Text = "Clear App Data";
            this.clearAppDataToolStripMenuItem.Click += new System.EventHandler(this.clearAppDataToolStripMenuItem_Click_1);
            // 
            // comboDevicesList
            // 
            this.comboDevicesList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDevicesList.FormattingEnabled = true;
            this.comboDevicesList.Location = new System.Drawing.Point(672, 23);
            this.comboDevicesList.Name = "comboDevicesList";
            this.comboDevicesList.Size = new System.Drawing.Size(163, 21);
            this.comboDevicesList.TabIndex = 1;
            this.comboDevicesList.SelectedIndexChanged += new System.EventHandler(this.comboDevicesList_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(618, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Devices:";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 8);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(500, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(120, 17);
            this.lblStatus.Text = "Waiting For Devices...";
            // 
            // btnGetPacks
            // 
            this.btnGetPacks.Enabled = false;
            this.btnGetPacks.Location = new System.Drawing.Point(12, 15);
            this.btnGetPacks.Name = "btnGetPacks";
            this.btnGetPacks.Size = new System.Drawing.Size(176, 34);
            this.btnGetPacks.TabIndex = 4;
            this.btnGetPacks.Text = "Get Installed Packages";
            this.btnGetPacks.UseVisualStyleBackColor = true;
            this.btnGetPacks.Click += new System.EventHandler(this.btnGetPacks_Click);
            // 
            // btnRemoveSelected
            // 
            this.btnRemoveSelected.Enabled = false;
            this.btnRemoveSelected.Location = new System.Drawing.Point(194, 15);
            this.btnRemoveSelected.Name = "btnRemoveSelected";
            this.btnRemoveSelected.Size = new System.Drawing.Size(166, 34);
            this.btnRemoveSelected.TabIndex = 5;
            this.btnRemoveSelected.Text = "Remove Checked";
            this.btnRemoveSelected.UseVisualStyleBackColor = true;
            this.btnRemoveSelected.Click += new System.EventHandler(this.btnRemoveSelected_Click);
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(428, 23);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(141, 20);
            this.textBox1.TabIndex = 6;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(378, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Search:";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitContainer1.Location = new System.Drawing.Point(0, 436);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.statusStrip1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.statusStrip2);
            this.splitContainer1.Size = new System.Drawing.Size(847, 30);
            this.splitContainer1.SplitterDistance = 500;
            this.splitContainer1.TabIndex = 11;
            // 
            // statusStrip2
            // 
            this.statusStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblBattery,
            this.lblTemp});
            this.statusStrip2.Location = new System.Drawing.Point(0, 8);
            this.statusStrip2.Name = "statusStrip2";
            this.statusStrip2.Size = new System.Drawing.Size(343, 22);
            this.statusStrip2.SizingGrip = false;
            this.statusStrip2.TabIndex = 4;
            this.statusStrip2.Text = "statusStrip2";
            // 
            // lblBattery
            // 
            this.lblBattery.Name = "lblBattery";
            this.lblBattery.Size = new System.Drawing.Size(100, 17);
            this.lblBattery.Text = "Battery: unknown";
            // 
            // lblTemp
            // 
            this.lblTemp.Name = "lblTemp";
            this.lblTemp.Size = new System.Drawing.Size(94, 17);
            this.lblTemp.Text = "Temp: unknown";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(847, 466);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnRemoveSelected);
            this.Controls.Add(this.btnGetPacks);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboDevicesList);
            this.Controls.Add(this.lstPackagesList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "adb Manager - Ibrahim Fouad";
            this.contextOptions.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.statusStrip2.ResumeLayout(false);
            this.statusStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lstPackagesList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ComboBox comboDevicesList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.Button btnGetPacks;
        private System.Windows.Forms.Button btnRemoveSelected;
        private System.Windows.Forms.ContextMenuStrip contextOptions;
        private System.Windows.Forms.ToolStripMenuItem installNewAppToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeSelectedToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem backupSelectedToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.StatusStrip statusStrip2;
        private System.Windows.Forms.ToolStripStatusLabel lblBattery;
        private System.Windows.Forms.ToolStripStatusLabel lblTemp;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ToolStripMenuItem clearAppDataToolStripMenuItem;
    }
}

