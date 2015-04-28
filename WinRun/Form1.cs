using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HtmlPos.Lib;
namespace WinRun
{
    public partial class Form1 : Form
    {
        IExternalAdapter IEA;
        public Form1()
        {
            InitializeComponent();
            var exobj = new ExternalAdapter(this);
            IEA = exobj;
            exobj.ApplicationExit += new EventHandler((o, s) =>
            {
                if (MessageBox.Show("确定要退出应用程序?", "WinForm窗口", MessageBoxButtons.OKCancel,MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
                    this.Close();
            });
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                var uri = new Uri(System.IO.Path.Combine(Environment.CurrentDirectory, "webview/appmain.html"));
                //MessageBox.Show(uri.ToString());
                webBrowser1.ObjectForScripting = IEA;
                webBrowser1.Navigate(uri);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
