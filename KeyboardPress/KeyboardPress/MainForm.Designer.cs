﻿namespace KeyboardPress
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.nustatymaiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripItem_start = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripItem_stop = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripItem_clean = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripItem_debug = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripItem_cleanDebugWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.apieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.informacijaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel_info = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_totalWorkTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.panelDebug = new System.Windows.Forms.Panel();
            this.richTB_debug = new System.Windows.Forms.RichTextBox();
            this.panelMain = new System.Windows.Forms.Panel();
            this.timer_workTime = new System.Windows.Forms.Timer(this.components);
            this.test2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.panelDebug.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nustatymaiToolStripMenuItem,
            this.testToolStripMenuItem,
            this.test2ToolStripMenuItem,
            this.apieToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(673, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip";
            // 
            // nustatymaiToolStripMenuItem
            // 
            this.nustatymaiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripItem_start,
            this.toolStripItem_stop,
            this.toolStripItem_clean,
            this.toolStripSeparator1,
            this.toolStripItem_debug,
            this.toolStripItem_cleanDebugWindow});
            this.nustatymaiToolStripMenuItem.Name = "nustatymaiToolStripMenuItem";
            this.nustatymaiToolStripMenuItem.Size = new System.Drawing.Size(80, 20);
            this.nustatymaiToolStripMenuItem.Text = "Nustatymai";
            // 
            // toolStripItem_start
            // 
            this.toolStripItem_start.CheckOnClick = true;
            this.toolStripItem_start.Name = "toolStripItem_start";
            this.toolStripItem_start.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F5)));
            this.toolStripItem_start.Size = new System.Drawing.Size(224, 22);
            this.toolStripItem_start.Text = "Pradėti";
            this.toolStripItem_start.Click += new System.EventHandler(this.toolStripItem_start_Click);
            // 
            // toolStripItem_stop
            // 
            this.toolStripItem_stop.CheckOnClick = true;
            this.toolStripItem_stop.Name = "toolStripItem_stop";
            this.toolStripItem_stop.Size = new System.Drawing.Size(224, 22);
            this.toolStripItem_stop.Text = "Sustabdyti";
            this.toolStripItem_stop.Click += new System.EventHandler(this.toolStripItem_stop_Click);
            // 
            // toolStripItem_clean
            // 
            this.toolStripItem_clean.Name = "toolStripItem_clean";
            this.toolStripItem_clean.Size = new System.Drawing.Size(224, 22);
            this.toolStripItem_clean.Text = "Anuliuoti rodmenis";
            this.toolStripItem_clean.Click += new System.EventHandler(this.toolStripItem_clean_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(221, 6);
            // 
            // toolStripItem_debug
            // 
            this.toolStripItem_debug.CheckOnClick = true;
            this.toolStripItem_debug.Name = "toolStripItem_debug";
            this.toolStripItem_debug.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F10)));
            this.toolStripItem_debug.Size = new System.Drawing.Size(224, 22);
            this.toolStripItem_debug.Text = "Debug";
            this.toolStripItem_debug.Click += new System.EventHandler(this.toolStripItem_debug_Click);
            // 
            // toolStripItem_cleanDebugWindow
            // 
            this.toolStripItem_cleanDebugWindow.Name = "toolStripItem_cleanDebugWindow";
            this.toolStripItem_cleanDebugWindow.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F11)));
            this.toolStripItem_cleanDebugWindow.Size = new System.Drawing.Size(224, 22);
            this.toolStripItem_cleanDebugWindow.Text = "Valyti debug langą";
            this.toolStripItem_cleanDebugWindow.Click += new System.EventHandler(this.toolStripItem_cleanDebugWindow_Click);
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.testToolStripMenuItem.Text = "test";
            this.testToolStripMenuItem.Click += new System.EventHandler(this.testToolStripMenuItem_Click);
            // 
            // apieToolStripMenuItem
            // 
            this.apieToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.informacijaToolStripMenuItem});
            this.apieToolStripMenuItem.Name = "apieToolStripMenuItem";
            this.apieToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.apieToolStripMenuItem.Text = "Apie";
            // 
            // informacijaToolStripMenuItem
            // 
            this.informacijaToolStripMenuItem.Name = "informacijaToolStripMenuItem";
            this.informacijaToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.informacijaToolStripMenuItem.Text = "Informacija";
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipText = "test";
            this.notifyIcon.BalloonTipTitle = "test";
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.BalloonTipClicked += new System.EventHandler(this.notifyIcon_BalloonTipClicked);
            this.notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseClick);
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // statusStrip
            // 
            this.statusStrip.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel_info,
            this.toolStripStatusLabel_totalWorkTime});
            this.statusStrip.Location = new System.Drawing.Point(0, 290);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(673, 22);
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "statusStrip";
            // 
            // toolStripStatusLabel_info
            // 
            this.toolStripStatusLabel_info.Name = "toolStripStatusLabel_info";
            this.toolStripStatusLabel_info.Size = new System.Drawing.Size(31, 17);
            this.toolStripStatusLabel_info.Text = "Info:";
            // 
            // toolStripStatusLabel_totalWorkTime
            // 
            this.toolStripStatusLabel_totalWorkTime.Name = "toolStripStatusLabel_totalWorkTime";
            this.toolStripStatusLabel_totalWorkTime.Size = new System.Drawing.Size(627, 17);
            this.toolStripStatusLabel_totalWorkTime.Spring = true;
            this.toolStripStatusLabel_totalWorkTime.Text = "--";
            this.toolStripStatusLabel_totalWorkTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panelDebug
            // 
            this.panelDebug.Controls.Add(this.richTB_debug);
            this.panelDebug.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelDebug.Location = new System.Drawing.Point(339, 24);
            this.panelDebug.Name = "panelDebug";
            this.panelDebug.Size = new System.Drawing.Size(334, 266);
            this.panelDebug.TabIndex = 2;
            this.panelDebug.Visible = false;
            // 
            // richTB_debug
            // 
            this.richTB_debug.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.richTB_debug.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTB_debug.ForeColor = System.Drawing.Color.LimeGreen;
            this.richTB_debug.Location = new System.Drawing.Point(0, 0);
            this.richTB_debug.Name = "richTB_debug";
            this.richTB_debug.ReadOnly = true;
            this.richTB_debug.Size = new System.Drawing.Size(334, 266);
            this.richTB_debug.TabIndex = 0;
            this.richTB_debug.Text = "";
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 24);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(339, 266);
            this.panelMain.TabIndex = 3;
            // 
            // timer_workTime
            // 
            this.timer_workTime.Interval = 1000;
            this.timer_workTime.Tick += new System.EventHandler(this.timer_workTime_Tick);
            // 
            // test2ToolStripMenuItem
            // 
            this.test2ToolStripMenuItem.Name = "test2ToolStripMenuItem";
            this.test2ToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.test2ToolStripMenuItem.Text = "test2";
            this.test2ToolStripMenuItem.Click += new System.EventHandler(this.test2ToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 312);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelDebug);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.panelDebug.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem nustatymaiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripItem_debug;
        private System.Windows.Forms.ToolStripMenuItem toolStripItem_start;
        private System.Windows.Forms.ToolStripMenuItem toolStripItem_stop;
        private System.Windows.Forms.ToolStripMenuItem toolStripItem_clean;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.Panel panelDebug;
        private System.Windows.Forms.RichTextBox richTB_debug;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.ToolStripMenuItem toolStripItem_cleanDebugWindow;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_info;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem apieToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem informacijaToolStripMenuItem;
        private System.Windows.Forms.Timer timer_workTime;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_totalWorkTime;
        private System.Windows.Forms.ToolStripMenuItem test2ToolStripMenuItem;
    }
}

