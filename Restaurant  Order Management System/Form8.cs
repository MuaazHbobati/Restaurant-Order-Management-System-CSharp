using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Restaurant__Order_Management_System
{
    public partial class Meals_Manegment_Form : Form
    {
        private clsMeal Meal = new clsMeal("", "", "", "", enMealType.MiddleEasternCuisine);
        private clsMeal_Management clsMeal_Management = new clsMeal_Management();
        private Panel parentPanel;
        private bool _Is_Edit;
        private string _meal_Name;
        private string _meal_info;
        private string _meal_price;
        private string _meal_photo;
        private enMealType _mealType;

        private bool Is_Edit
        {
            set { _Is_Edit = value; }
            get { return _Is_Edit; }
        }
        private string meal_Name
        {
            set { _meal_Name = value; }
            get { return _meal_Name; }
        }
        private string meal_info
        {
            set { _meal_info = value; }
            get { return _meal_info; }
        }
        private string meal_price
        {
            set { _meal_price = value; }
            get { return _meal_price; }
        }
        private string meal_photo
        {
            set { _meal_photo = value; }
            get { return _meal_photo; }
        }
        private enMealType mealType
        {
            set { _mealType = value; }
            get { return _mealType; }
        }



        public Meals_Manegment_Form(Panel panel, bool isEdit)
        {
            InitializeComponent();
            parentPanel = panel;
            this.Is_Edit = isEdit;

            comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox_Meal_Type_SelectedIndexChanged);
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
        }    

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog1.FileName;
                pictureBox_Viewer.Image = System.Drawing.Image.FromFile(filePath);
                meal_photo = filePath;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void txt_Box_Male_Name_TextChanged(object sender, EventArgs e)
        {
            meal_Name = txt_Box_Male_Name.Text;
        }

        private void txtBox_Male_Price_TextChanged(object sender, EventArgs e)
        {
            meal_price = txtBox_Male_Price.Text;
        }

        private void richTextBox_Male_Info_TextChanged(object sender, EventArgs e)
        {
            meal_info = richTextBox_Male_Info.Text;
        }

        private void Meal_Manegment_Form_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = Enum.GetValues(typeof(enMealType));
            comboBox1.SelectedIndex = -1;

            txt_Box_Male_Name.Clear();
            txtBox_Male_Price.Clear();
            richTextBox_Male_Info.Clear();

            pictureBox_Viewer.Image = null;

            meal_photo = string.Empty;
            meal_price = string.Empty;
            meal_info = string.Empty;
            meal_Name = string.Empty;
            mealType = enMealType.MiddleEasternCuisine;
        }

        private void comboBox_Meal_Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                mealType = (enMealType)comboBox1.SelectedItem;
            }
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1 || pictureBox_Viewer.Image == null || string.IsNullOrWhiteSpace(meal_info) || string.IsNullOrWhiteSpace(meal_Name) || string.IsNullOrWhiteSpace(meal_price))
            {
                clsMeal_Management.Note(Restaurant_Order_Management_System_Form._Is_Arabic ?
                "يرجى تعبئة جميع المعلومات" : "Please fill in all the information");
                return;
            }

            if (!float.TryParse(txtBox_Male_Price.Text, out float price))
            {
                clsMeal_Management.Note(Restaurant_Order_Management_System_Form._Is_Arabic ?
               "يرجى إدخال سعر صحيح." : "Please enter a valid price.");       
                return;
            }
            meal_price = txtBox_Male_Price.Text + " $";
            Meal.Image_Path = meal_photo;
            Meal.Price = meal_price;
            Meal.Information = meal_info;
            Meal.Name = meal_Name;
            Meal.MealType = mealType;

            clsMeal_Management.Add_Meal_To_List(Meal);
            Dashboard_For_Admain_Form.Meals_Manage.Add(Meal);
            clsMeal_Management.Save_Meals_To_File();
            clsMeal_Management.DisplayMeals(parentPanel, Get_Meal_List_By_Type(mealType), Is_Edit, true);

            meal_photo = string.Empty;
            meal_price = string.Empty;
            meal_info = string.Empty;
            meal_Name = string.Empty;
            mealType = enMealType.MiddleEasternCuisine;

            txt_Box_Male_Name.Clear();
            txtBox_Male_Price.Clear();
            richTextBox_Male_Info.Clear();
            pictureBox_Viewer.Image = null;
            comboBox1.SelectedIndex = -1;

            this.Hide();
        }

        private List<clsMeal> Get_Meal_List_By_Type(enMealType mealType)
        {
            switch (mealType)
            {
                case enMealType.MiddleEasternCuisine:
                    return clsMeal_Management.Middle_Eastern_Cuisine_List;
                case enMealType.FastFood:
                    return clsMeal_Management.Fast_Food_List;
                case enMealType.AsianCuisine:
                    return clsMeal_Management.Asian_Cuisine_List;
                case enMealType.HotDrink:
                    return clsMeal_Management.Hot_Drink_List;
                case enMealType.ColdDrink:
                    return clsMeal_Management.Cold_Drink_List;
                case enMealType.MyOrder:
                    return clsMeal_Management.My_Order_List;
                default:
                    return new List<clsMeal>();
            }
        }
    }
}