﻿using KeyboardPress_Analyzer.Helper;
using System;
using System.Windows.Forms;

namespace KeyboardPress
{
    public partial class EmptyForm : Form, IDisposable
    {
        private UserControl uc;

        public EmptyForm(UserControl Uc, string FormName, bool disableMinimizeButton = false)
        {
            InitializeComponent();
            uc = Uc;
            this.Text = FormName;
            this.MinimizeBox = !disableMinimizeButton;
        }
        
        private void EmptyForm_Load(object sender, EventArgs e)
        {
            try
            {
                this.Width = uc.Width + 20;
                this.Height = uc.Height + 35;
                uc.Dock = DockStyle.Fill;
                this.Controls.Add(uc);
            }
            catch(Exception ex)
            {
                LogHelper.ShowErrorMsgWithLog("Klaida atveriant langą", ex);
            }
        }
    }
}
