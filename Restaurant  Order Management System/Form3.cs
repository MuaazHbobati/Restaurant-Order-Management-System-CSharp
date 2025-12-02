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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Restaurant__Order_Management_System
{
    public partial class User_Login_Form : Form
    {
        private static User_Login_Form instance;

        private string _User_Path = @"Main_Folder\Accounts\Client_Account.txt";
        public static string _Username = "";
        private string _Password = "";
        private string _record = "";

        public static string Username
        {
            set { _Username = value; }
            get { return _Username; }
        }
        private string Password
        {
            set { _Password = value; }
            get { return _Password; }
        }
        private string record
        {
            set { _record = value; }
            get { return _record; }
        }
        private string User_Path
        {
            set { _User_Path = value; }
            get { return _User_Path; }
        }

        public User_Login_Form()
        {
            InitializeComponent();
            instance = this;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            clsResturant_Managementcs.Set_Language(textBox1, "Username", "اسم المستخدم");
            clsResturant_Managementcs.Set_Language(textBox2, "Password", "كلمة السر");
            clsResturant_Managementcs.Set_Language(label3, "You dont have account?", "ليس لديك حساب؟");
            clsResturant_Managementcs.Set_Language(linkLabel1, "Create one here!", "!انشئ واحد هنا");
            clsResturant_Managementcs.Set_Language(btn_Back, "Back", "رجوع");
            clsResturant_Managementcs.Set_Language(btn_Login, "Login", "تسجيل");

            textBox1.ForeColor = Color.Gray;
            textBox1.Enter += textBox1_Enter;
            textBox1.Leave += textBox1_Leave;

            textBox2.ForeColor = Color.Gray;
            textBox2.Enter += textBox2_Enter;
            textBox2.Leave += textBox2_Leave;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Username = textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Password = textBox2.Text;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Create_Form createForm = new Create_Form(false, User_Path);
            createForm.ShowDialog();
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            if (Username == "Username" || string.IsNullOrEmpty(Username) || Username == "اسم المستخدم"
            || Password == "Password"  || string.IsNullOrEmpty(Password) || Password == "كلمة السر")
            {
                clsMeal_Management.Note(Restaurant_Order_Management_System_Form.Is_Arabic ?
                "يرجى تعبئة اسم المستخدم وكلمة السر" : "Please fill in the username and password");
            }
            else
            {
                this.Hide();
                string[] line = { Username, Password };
                clsLogin.Login_System(line, User_Path, false);
            }
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btn_Back_MouseEnter(object sender, EventArgs e)
        {
            btn_Back.BackColor = Color.SteelBlue;
        }

        private void btn_Back_MouseLeave(object sender, EventArgs e)
        {
            btn_Back.BackColor = Color.Transparent;
        }

        private void btn_Login_MouseEnter(object sender, EventArgs e)
        {
            btn_Login.BackColor = Color.SteelBlue;
        }

        private void btn_Login_MouseLeave(object sender, EventArgs e)
        {
            btn_Login.BackColor = Color.Transparent;
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "كلمة السر" || textBox2.Text == "Password")
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.Black;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                clsResturant_Managementcs.Set_Language(textBox2, "Password", "كلمة السر");
                textBox2.ForeColor = Color.Gray;
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "اسم المستخدم" || textBox1.Text == "Username")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                clsResturant_Managementcs.Set_Language(textBox1, "Username", "اسم المستخدم");
                textBox1.ForeColor = Color.Gray;
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox2.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Login.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        public static void CloseForm()
        {
            if (instance != null)
            {
                instance.Close();
                instance.Dispose();
                instance = null;
            }
        }
    }
}