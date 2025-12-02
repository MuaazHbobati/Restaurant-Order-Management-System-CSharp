using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Restaurant__Order_Management_System
{
    public partial class Admain_Login_Form : Form
    {
        private static Admain_Login_Form instance;

        private string Admain_Path = @"Main_Folder\Accounts\Admain_Account.txt";
        private string _Username = "";
        private string _Password = "";
        private string _record = "";
        
        private string Username
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
        public Admain_Login_Form()
        {
            InitializeComponent();
            instance = this;        
        }

        private void Admain_Login_Form_Load(object sender, EventArgs e)
        {
            clsResturant_Managementcs.Set_Language(textBox1, "Username", "اسم المستخدم");
            clsResturant_Managementcs.Set_Language(textBox2, "Password", "كلمة السر");
            clsResturant_Managementcs.Set_Language(label3, "You dont have account?", "ليس لديك حساب؟");
            clsResturant_Managementcs.Set_Language(linkLabel1, "Create one here!", "!انشئ واحد هنا");
            clsResturant_Managementcs.Set_Language(btn_Back, "Back", "رجوع");
            clsResturant_Managementcs.Set_Language(btn_Login, "Login", "تسجيل");

            textBox1.ForeColor = Color.Gray;
            textBox2.ForeColor = Color.Gray;

            textBox1.Enter += new EventHandler(textBox1_Enter);
            textBox1.Leave += new EventHandler(textBox1_Leave);
            textBox2.Enter += new EventHandler(textBox2_Enter);
            textBox2.Leave += new EventHandler(textBox2_Leave);         
        }
        
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Create_Form create_Form = new Create_Form(true, Admain_Path);
            create_Form.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Username = textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Password = textBox2.Text;
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            if (Username == "Username" || Username == "" || Username == "اسم المستخدم"
            || Password == "Password"  || Password == "" || Password == "كلمة السر")
            {
                clsMeal_Management.Note(Restaurant_Order_Management_System_Form.Is_Arabic?
                "يرجى تعبئة اسم المستخدم وكلمة السر" : "Please fill in the username and password");
            }
            else
            {
                this.Hide();
                string[] Line = { Username, Password };
                clsLogin.Login_System(Line, Admain_Path, true);
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
