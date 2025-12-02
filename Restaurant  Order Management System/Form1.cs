using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurant__Order_Management_System
{
    public partial class Restaurant_Order_Management_System_Form : Form
    {
        private First_Screen_Open first_Screen_Open;
        private static Restaurant_Order_Management_System_Form instance;
        public static bool _Is_Arabic = false;
        public static bool Is_Arabic
        {
            set { _Is_Arabic = value; }
            get { return _Is_Arabic; }
        }
        public Restaurant_Order_Management_System_Form()
        {
            InitializeComponent();
            instance = this;
            ;
            this.FormClosed += Restaurant_Order_Management_System_Form_FormClosed;
        }
        private void Restaurant_Order_Management_System_Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            clsMeal_Management.LoadMealsFromFile();
            clsMeal_Management.Add_All_Meals_To_All_Meals_List();

            UpdateLanguage();
            comboBox_Language.SelectedIndex = 0;
        }
        private void btn_Log_Admain_Click(object sender, EventArgs e)
        {
            Admain_Login_Form admain_Login_Form = new Admain_Login_Form();
            admain_Login_Form.ShowDialog();
        }
        private void btn_Log_User_Click(object sender, EventArgs e)
        {
            User_Login_Form user_Login_Form = new User_Login_Form();
            user_Login_Form.ShowDialog();
        }
        private void btn_Log_Admain_MouseEnter(object sender, EventArgs e)
        {
            btn_Log_Admain.BackColor = Color.SteelBlue;
        }
        private void btn_Log_Admain_MouseLeave(object sender, EventArgs e)
        {
            btn_Log_Admain.BackColor = Color.Transparent;
        }
        private void btn_Log_User_MouseEnter(object sender, EventArgs e)
        {
            btn_Log_User.BackColor = Color.SteelBlue;
        }
        private void btn_Log_User_MouseLeave(object sender, EventArgs e)
        {
            btn_Log_User.BackColor= Color.Transparent;
        }
        private void comboBox_Language_SelectedIndexChanged(object sender, EventArgs e)
        {
            Is_Arabic = comboBox_Language.SelectedIndex == 1;
            UpdateLanguage();
            label1.Location = Is_Arabic ? new Point(225, 28) : new Point(142, 28);
        }
        private void comboBox_Language_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            e.DrawFocusRectangle();

            if (e.Index >= 0)
            {
                SizeF textSize = e.Graphics.MeasureString(comboBox_Language.Items[e.Index].ToString(), e.Font);

                int imageX = e.Bounds.Right - imageList1.ImageSize.Width - 2;
                int textX = e.Bounds.Left;

                Image flagImage = imageList1.Images[e.Index];
                e.Graphics.DrawImage(flagImage, imageX, e.Bounds.Top);

                e.Graphics.DrawString(comboBox_Language.Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), textX, e.Bounds.Top);
            }
        }
        private void UpdateLanguage()
        {
            btn_Log_Admain.Text = Is_Arabic ? "الدخول كمسؤول" : "Login as Admin";
            btn_Log_User.Text = Is_Arabic ? "الدخول كمستخدم" : "Login as User";
            label1.Text = Is_Arabic ? "نظام إدارة طلبات في مطعم" : "Restaurant Order Management System";
        }
    }
}