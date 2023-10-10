using MonitorFormsApp.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Collections.Specialized;

namespace AppWinforms
{
    public partial class MontrorForm : Form
    {
        public MontrorForm()
        {
            InitializeComponent();
            this.Load += Form1_Load;
            this.Resize += Form1_Resize;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RemaveRepeatApp();
            dataGV1.DataSource = sampleData();
            button1.Click += Button1_Click;
        }

        private void RemaveRepeatApp()
        {
            //本程序資料
            var mProcess = Process.GetCurrentProcess();

            var allProcesses = Process.GetProcesses().Where(w => w.Id != mProcess.Id && w.ProcessName == mProcess.ProcessName);
            foreach (var proc in allProcesses)
            {
                proc.Kill();
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                HideWindows();

            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            HideWindows();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //在工具列點擊兩下，回復視窗
            if (e.Button == MouseButtons.Left)
            {
                this.Show();
                this.WindowState = FormWindowState.Normal;
                this.ShowInTaskbar = true;
                this.notifyIcon1.Visible = false;
            }
        }

        private void ToolStripMenuItem_Close_Click(object sender, EventArgs e)
        {
            this.Close(); //關閉視窗

        }
        private void HideWindows()
        {

            // Convert to an icon and use for the form's icon.


            //縮小至工作列
            this.notifyIcon1.Text = "監控程式";               //欲顯示的文字
            this.notifyIcon1.Icon = Resources.monitor; //指定您的Icon圖示
            this.WindowState = FormWindowState.Minimized;        //決定視窗大小
            this.ShowInTaskbar = false;                          //決定是否出現在工作列
            this.notifyIcon1.Visible = true;                     //決定使否顯示notifyIcon1
            this.Hide();
        }
        private DataTable sampleData()
        {
            using (DataTable table = new DataTable())
            {

                Bitmap _checked = new Bitmap(Image.FromFile("Resources\\checked.png"), 12, 12);
                Bitmap _cross = new Bitmap(Image.FromFile("Resources\\cross.png"), 12, 12);

                // Add columns.
                table.Columns.Add("Name", typeof(string));
                table.Columns.Add("State", typeof(Bitmap));



                var appKeys = ConfigurationManager.AppSettings.AllKeys.Where(s => s.StartsWith("App_")).ToArray();
                foreach (var appKey in appKeys)
                {
                    var appName = appKey.Replace("App_", "");
                    var hasProc = Process.GetProcesses().Where(w => w.ProcessName == appName).Any();

                    var _mBitmap = hasProc ? _checked : _cross;
                    table.Rows.Add(appName, _mBitmap);
                }

                // Add rows.


                //table.Rows.Add("Allen", "Male", 0, DateTime.Now, _checked);
                //table.Rows.Add("Kevin", "Male", 1, DateTime.Now, _checked);
                //table.Rows.Add("Dean", "Male", 0, DateTime.Today, _cross);
                //table.Rows.Add("Jenny", "Female", 1, DateTime.Today, _cross);
                return table;
            }
        }
    }
}
