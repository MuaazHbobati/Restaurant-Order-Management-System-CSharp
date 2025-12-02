using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Restaurant__Order_Management_System
{
    public partial class Create_Form : Form
    {
        private static Create_Form instance;

        private clsLogin Data_Client = new clsLogin();
        private ArrayList Login_List = new ArrayList();

        private bool _IS_Admain = false;
        private string _Path = "";
        private string _First_Name_Label = (Restaurant_Order_Management_System_Form.Is_Arabic) ? "الاسم الأول" : "First Name";
        private string _Last_Name_Label = (Restaurant_Order_Management_System_Form.Is_Arabic) ? "الاسم الأخير" : "Last Name";
        private string _Username = (Restaurant_Order_Management_System_Form.Is_Arabic) ? "اسم المستخدم" : "Username";
        private string _Mobile_Phone_Label = (Restaurant_Order_Management_System_Form.Is_Arabic) ? "رقم الهاتف" : "Mobile Phone";
        private string _Location_Label = (Restaurant_Order_Management_System_Form.Is_Arabic) ? "عنوان المنزل" : "Location";
        private string _Password_Label = (Restaurant_Order_Management_System_Form.Is_Arabic) ? "كلمة السر" : "Password";
        private string _Btn_Back_Label = (Restaurant_Order_Management_System_Form.Is_Arabic) ? "رجوع" : "Back";
        private string _Btn_Continue_Label = (Restaurant_Order_Management_System_Form.Is_Arabic) ? "استمرار" : "Continue";

        private string Path
        {
            set { _Path = value; }
            get { return _Path; }
        }
        private bool IS_Admain
        {
            set { _IS_Admain = value; }
            get { return _IS_Admain; }
        }
        public string First_Name_Label
        {
            get { return _First_Name_Label; }
            private set { _First_Name_Label = value; }
        }
        public string Last_Name_Label
        {
            get { return _Last_Name_Label; }
            private set { _Last_Name_Label = value; }
        }
        public string Username_Label
        {
            get { return _Username; }
            private set { _Username = value; }
        }
        public string Mobile_Phone_Label
        {
            get { return _Mobile_Phone_Label; }
            private set { _Mobile_Phone_Label = value; }
        }
        public string Location_Label
        {
            get { return _Location_Label; }
            private set { _Location_Label = value; }
        }
        public string Password_Label
        {
            get { return _Password_Label; }
            private set { _Password_Label = value; }
        }
        public string Btn_Back_Label
        {
            get { return _Btn_Back_Label; }
            private set { _Btn_Back_Label = value; }
        }
        public string Btn_Continue_Label
        {
            get { return _Btn_Continue_Label; }
            private set { _Btn_Continue_Label = value; }
        }

        public Create_Form(bool IS_Admain, string Path)
        {
            InitializeComponent();

            instance = this;
            this.IS_Admain = IS_Admain;
            this.Path = Path;

            Admain_Login_Form.CloseForm();
            User_Login_Form.CloseForm();
        }

        private void Create_Form_Load(object sender, EventArgs e)
        {
            Font font = new Font("Tajawal", 10, FontStyle.Bold);

            txt_Box_First_Name.Text = First_Name_Label;
            txt_Box_Last_Name.Text = Last_Name_Label;
            txt_Box_Username.Text = Username_Label;
            txt_Box_Mobile_Phone.Text = Mobile_Phone_Label;
            txt_Box_Location.Text = Location_Label;
            txt_Box_Password.Text = Password_Label;
            btn_Back.Text = Btn_Back_Label;
            btn_Continue.Text = Btn_Continue_Label;

            txt_Box_First_Name.Font = font;
            txt_Box_Last_Name.Font = font;
            txt_Box_Username.Font = font;
            txt_Box_Mobile_Phone.Font = font;
            txt_Box_Location.Font = font;
            txt_Box_Password.Font = font;

            txt_Box_First_Name.ForeColor = Color.Gray;
            txt_Box_Last_Name.ForeColor = Color.Gray;
            txt_Box_Username.ForeColor = Color.Gray;
            txt_Box_Mobile_Phone.ForeColor = Color.Gray;
            txt_Box_Location.ForeColor = Color.Gray;
            txt_Box_Password.ForeColor = Color.Gray;

            txt_Box_First_Name.Enter += new EventHandler(txt_Box_First_Name_Enter);
            txt_Box_First_Name.Leave += new EventHandler(txt_Box_First_Name_Leave);
            txt_Box_Username.Enter += new EventHandler(txt_Box_Username_Enter);
            txt_Box_Username.Leave += new EventHandler(txt_Box_Username_Leave);
            txt_Box_Mobile_Phone.Enter += new EventHandler(txt_Box_Mobile_Phone_Enter);
            txt_Box_Mobile_Phone.Leave += new EventHandler(txt_Box_Mobile_Phone_Leave);
            txt_Box_Location.Enter += new EventHandler(txt_Box_Location_Enter);
            txt_Box_Location.Leave += new EventHandler(txt_Box_Location_Leave);
            txt_Box_Password.Enter += new EventHandler(txt_Box_Password_Enter);
            txt_Box_Password.Leave += new EventHandler(txt_Box_Password_Leave);
        }

        private void txt_Box_First_Name_TextChanged(object sender, EventArgs e)
        {
            Data_Client.First_Name = txt_Box_First_Name.Text;
        }

        private void txt_Box_Last_Name_TextChanged(object sender, EventArgs e)
        {
            Data_Client.Last_Name = txt_Box_Last_Name.Text;
        }

        private void txt_Box_Username_TextChanged(object sender, EventArgs e)
        {
            Data_Client.Username = txt_Box_Username.Text;
            clsLogin.Username_For_Wellcome = txt_Box_Username.Text;
        }

        private void txt_Box_Mobile_Phone_TextChanged(object sender, EventArgs e)
        {
            Data_Client.Mobile_Phone = txt_Box_Mobile_Phone.Text;
        }

        private void txt_Box_Location_TextChanged(object sender, EventArgs e)
        {
            Data_Client.Location = txt_Box_Location.Text;
        }

        private void txt_Box_Password_TextChanged(object sender, EventArgs e)
        {
            Data_Client.Password = txt_Box_Password.Text;
        }

        private void btn_Continue_Click(object sender, EventArgs e)
        {
            if (Data_Client.First_Name == "First Name" || Data_Client.First_Name == "" || Data_Client.First_Name == "الاسم الأول"
            || Data_Client.Last_Name == "Last Name" || Data_Client.Last_Name == "" || Data_Client.Last_Name == "الاسم الأخير"
            || Data_Client.Username == "Username" || Data_Client.Username == "" || Data_Client.Username == "اسم المستخدم"
            || Data_Client.Mobile_Phone == "Mobile Phone" || Data_Client.Mobile_Phone == "" || Data_Client.Mobile_Phone == "رقم الهاتف"
            || Data_Client.Location == "Location" || Data_Client.Location == "" || Data_Client.Location == "عنوان المنزل"
            || Data_Client.Password == "Password" || Data_Client.Password == "" || Data_Client.Password == "كلمة السر")
            {
                clsMeal_Management.Note(Restaurant_Order_Management_System_Form._Is_Arabic ?
                "يرجى تعبئة جميع متطلبات إنشاء الحساب" : "Please fill in all the account creation requirements");
            }
            else
            {
                this.Hide();
                Login_List.Add(Data_Client);
                Data_Client.Add_This_Account(Path, IS_Admain);
                (IS_Admain ? (Form)new Admain_Login_Form() : new User_Login_Form()).ShowDialog();
            }
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            this.Hide();
            (IS_Admain ? (Form)new Admain_Login_Form() : new User_Login_Form()).ShowDialog();
        }

        private void btn_Continue_MouseEnter(object sender, EventArgs e)
        {
            btn_Continue.BackColor = Color.SteelBlue;
        }

        private void btn_Continue_MouseLeave(object sender, EventArgs e)
        {
            btn_Continue.BackColor = Color.Transparent;
        }

        private void btn_Back_MouseEnter(object sender, EventArgs e)
        {
            btn_Back.BackColor = Color.SteelBlue;
        }

        private void btn_Back_MouseLeave(object sender, EventArgs e)
        {
            btn_Back.BackColor = Color.Transparent;
        }

        private void txt_Box_First_Name_Enter(object sender, EventArgs e)
        {
            if (txt_Box_First_Name.Text == First_Name_Label)
            {
                txt_Box_First_Name.Text = "";
                txt_Box_First_Name.ForeColor = Color.Black;
            }
        }

        private void txt_Box_First_Name_Leave(object sender, EventArgs e)
        {
            if (txt_Box_First_Name.Text == "")
            {
                txt_Box_First_Name.Text = First_Name_Label;
                txt_Box_First_Name.ForeColor = Color.Gray;
            }
        }

        private void txt_Box_Last_Name_Enter(object sender, EventArgs e)
        {
            if (txt_Box_Last_Name.Text == Last_Name_Label)
            {
                txt_Box_Last_Name.Text = "";
                txt_Box_Last_Name.ForeColor = Color.Black;
            }
        }

        private void txt_Box_Last_Name_Leave(object sender, EventArgs e)
        {
            if (txt_Box_Last_Name.Text == "")
            {
                txt_Box_Last_Name.Text = Last_Name_Label;
                txt_Box_Last_Name.ForeColor = Color.Gray;
            }
        }

        private void txt_Box_Username_Enter(object sender, EventArgs e)
        {
            if (txt_Box_Username.Text == Username_Label)
            {
                txt_Box_Username.Text = "";
                txt_Box_Username.ForeColor = Color.Black;
            }
        }

        private void txt_Box_Username_Leave(object sender, EventArgs e)
        {
            if (txt_Box_Username.Text == "")
            {
                txt_Box_Username.Text = Username_Label;
                txt_Box_Username.ForeColor = Color.Gray;
            }
        }

        private void txt_Box_Mobile_Phone_Enter(object sender, EventArgs e)
        {
            if (txt_Box_Mobile_Phone.Text == Mobile_Phone_Label)
            {
                txt_Box_Mobile_Phone.Text = "";
                txt_Box_Mobile_Phone.ForeColor = Color.Black;
            }
        }

        private void txt_Box_Mobile_Phone_Leave(object sender, EventArgs e)
        {
            if (txt_Box_Mobile_Phone.Text == "")
            {
                txt_Box_Mobile_Phone.Text = Mobile_Phone_Label;
                txt_Box_Mobile_Phone.ForeColor = Color.Gray;
            }
        }

        private void txt_Box_Location_Enter(object sender, EventArgs e)
        {
            if (txt_Box_Location.Text == Location_Label)
            {
                txt_Box_Location.Text = "";
                txt_Box_Location.ForeColor = Color.Black;
            }
        }

        private void txt_Box_Location_Leave(object sender, EventArgs e)
        {
            if (txt_Box_Location.Text == "")
            {
                txt_Box_Location.Text = Location_Label;
                txt_Box_Location.ForeColor = Color.Gray;
            }
        }

        private void txt_Box_Password_Enter(object sender, EventArgs e)
        {
            if (txt_Box_Password.Text == Password_Label)
            {
                txt_Box_Password.Text = "";
                txt_Box_Password.ForeColor = Color.Black;
            }
        }

        private void txt_Box_Password_Leave(object sender, EventArgs e)
        {
            if (txt_Box_Password.Text == "")
            {
                txt_Box_Password.Text = Password_Label;
                txt_Box_Password.ForeColor = Color.Gray;
            }
        }

        private void txt_Box_First_Name_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_Box_Last_Name.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txt_Box_Last_Name_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                txt_Box_Username.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txt_Box_Username_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                txt_Box_Mobile_Phone.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txt_Box_Mobile_Phone_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_Box_Location.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txt_Box_Location_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_Box_Password.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txt_Box_Password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Continue.Focus();
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