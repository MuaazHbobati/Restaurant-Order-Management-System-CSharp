using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using Restaurant__Order_Management_System;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Reflection.Emit;

namespace Restaurant_Order_Management_System
{
    public partial class Form13 : Form
    {
        private string _Account_Number;
        private string _Password;
        public static bool _Is_Payed;

        public static bool Is_Payed
        {
            set { _Is_Payed = value; }
            get { return _Is_Payed; }
        }
        private string Account_Number
        {
            set { _Account_Number = value; }
            get { return _Account_Number; }
        }
        private string Password
        {
            set { _Password = value; }
            get { return _Password; }
        }


        public Form13()
        {
            InitializeComponent();
        }

        private void Form13_Load(object sender, EventArgs e)
        {
            clsResturant_Managementcs.Set_Language(textBox1, "Account Number", "رقم الحساب");
            clsResturant_Managementcs.Set_Language(textBox2, "Password", "كلمة السر");
            clsResturant_Managementcs.Set_Language(btn_Back, "Back", "رجوع");
            clsResturant_Managementcs.Set_Language(btn_Pay, "Pay", "شراء");

            textBox1.ForeColor = Color.Gray;
            textBox2.ForeColor = Color.Gray;

            textBox1.Enter += new EventHandler(textBox1_Enter);
            textBox1.Leave += new EventHandler(textBox1_Leave);
            textBox2.Enter += new EventHandler(textBox2_Enter);
            textBox2.Leave += new EventHandler(textBox2_Leave);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Account_Number = textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Password = textBox2.Text;
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
            if (textBox1.Text == "رقم الحساب" || textBox1.Text == "Account Number")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                clsResturant_Managementcs.Set_Language(textBox1, "Account Number", "رقم الحساب");
                textBox1.ForeColor = Color.Gray;
            }
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btn_Pay_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(Account_Number, out _))
            {
                if (!(textBox1.Text == "Account Number" || textBox1.Text == "رقم الحساب" || textBox1.Text == ""))
                {
                    clsMeal_Management.Note(Restaurant_Order_Management_System_Form.Is_Arabic ? "يرجى إدخال رقم الحساب " : "Please enter the Account Number.");
                    return;
                }
            }
            else
            {
                if (textBox1.Text == "Account Number" || textBox1.Text == "رقم الحساب" || textBox1.Text == ""
                || textBox2.Text == "Password" || textBox2.Text == "كلمة السر" || textBox2.Text == "")
                {
                    clsMeal_Management.Note(Restaurant_Order_Management_System_Form.Is_Arabic ? "يرجى تعبئة كل الخانات." : "Please fill in all the fields.");
                    return;
                }


                Is_Payed = true;
                clsMeal_Management.Note(Restaurant_Order_Management_System_Form.Is_Arabic ? "تم الدفع بنجاح" : "Paid Successfully");
                this.Close();
            }
        }     
    }
}