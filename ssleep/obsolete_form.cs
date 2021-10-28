using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ssleep
{
    public partial class settingWindow : System.Windows.Forms.Form
    {
        public settingWindow()
        {
            InitializeComponent();
        }
        /*private void Form2_Load(object sender, EventArgs e)
        {

        }*/
        private void Form2_Resize(object sender, EventArgs e)
        {
            //if the form is minimized  
            //hide it from the task bar  
            //and show the system tray icon (represented by the NotifyIcon control)  
        }
        private void btnEsc_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void btnApply_Click(object sender, EventArgs e)
        {
            int userInput;
            int time;
            if (int.TryParse(userVal.Text, out userInput))
            {
                //parsing successful 
                if (radioMinutes.Checked == true)
                    time = userInput * 60;
                else
                    time = userInput;
                MainWindow form1 = new MainWindow(time);
                form1.Show();

                Hide();
            }
            else
            {
                //parsing failed.
            }
        }
        private void userVal_TextChanged(object sender, EventArgs e)
        {
            int userInput;
            if (int.TryParse(userVal.Text, out userInput))
            {
                //parsing successful 
                btnApply.Text = "Apply";
                btnApply.ForeColor = System.Drawing.SystemColors.ControlText;
            }
            else if (userVal.Text == "")
            {
                btnApply.Text = "Apply";
                btnApply.ForeColor = System.Drawing.SystemColors.ControlText;
            }
            else
            {
                //parsing failed.
                btnApply.Text = "Nope";
                btnApply.ForeColor = System.Drawing.Color.Red;
            }
        }
        /*
        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            notifyIcon1.Visible = true;
            WindowState = FormWindowState.Normal;
        }
        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }

        private void exitToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        } */
    }
}
