using System;
using System.Windows.Forms;

namespace ssleep
{
    public partial class MainWindow : Form
    {

        private Timer timer;
        private int countDown;

        public MainWindow(int countDown)
        {
            InitializeComponent();
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            this.countDown = countDown;

            this.Closed += (s, ev) => Application.Exit();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            countDown--;
            Label.Text = string.Format("Computer will suspend in {0} seconds", countDown);
            if (countDown == 0)
            {
                Application.SetSuspendState(PowerState.Suspend, false, true);
                Application.Exit();
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //StartPosition = FormStartPosition.CenterScreen;
            timer.Start();

            Label.Text = string.Format("Computer will suspend in {0} seconds", countDown);
            if (countDown == 0)
            {
                Application.SetSuspendState(PowerState.Suspend, false, true);
                Application.Exit();
            }
        }
        private void Form1_Resize(object sender, EventArgs e)
        {
            //StartPosition = FormStartPosition.CenterScreen;
            //if the form is minimized  
            //hide it from the task bar  
            //and show the system tray icon (represented by the NotifyIcon control)  
            if (WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon1.Visible = true;
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btnSleep_Click(object sender, EventArgs e)
        {
            Application.SetSuspendState(PowerState.Suspend, false, true);
            Application.Exit();
        }
        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }
        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}