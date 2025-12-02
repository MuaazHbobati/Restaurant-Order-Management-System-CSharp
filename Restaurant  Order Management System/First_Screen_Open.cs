using System;
using System.Drawing;
using System.Windows.Forms;

namespace Restaurant__Order_Management_System
{
    public partial class First_Screen_Open : Form
    {
        private Timer timer;
        private Timer delayTimer;
        private Form mainForm;

        public First_Screen_Open()
        {
            InitializeComponent();
            timer = new Timer();
            timer.Interval = 3500;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            this.Hide();
            SetDelayTimer();
        }

        private void SetDelayTimer()
        {
            delayTimer = new Timer();
            delayTimer.Interval = 1200;
            delayTimer.Tick += DelayTimer_Tick;
            delayTimer.Start();
        }

        private void DelayTimer_Tick(object sender, EventArgs e)
        {
            delayTimer.Stop();
            ShowMainForm();
        }

        private void ShowMainForm()
        {
            Restaurant_Order_Management_System_Form mainForm = new Restaurant_Order_Management_System_Form();
            mainForm.ShowDialog();
        }

        private void First_Screen_Open_Load(object sender, EventArgs e)
        {

        }
    }
}
