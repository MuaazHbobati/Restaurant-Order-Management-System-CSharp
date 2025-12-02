using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using Tulpep.NotificationWindow;


namespace Restaurant__Order_Management_System
{
    public class clsMeal_Management
    {
        private static string Base_Path = @"Main_Folder\List_Meals_type\";

        public static List<clsMeal> _Middle_Eastern_Cuisine_List = new List<clsMeal>();
        public static List<clsMeal> _Fast_Food_List = new List<clsMeal>();
        public static List<clsMeal> _Asian_Cuisine_List = new List<clsMeal>();
        public static List<clsMeal> _Hot_Drink_List = new List<clsMeal>();
        public static List<clsMeal> _Cold_Drink_List = new List<clsMeal>();
        public static List<clsMeal> _My_Order_List = new List<clsMeal>();
        public static List<clsMeal> _All_Meals_List = new List<clsMeal>();
        public static List<clsMeal> _Result_Search_List = new List<clsMeal>();        
        private static List<clsMeal> _Pay_List = new List<clsMeal>();
        public static event Action Pay_List_Changed;

        public static List<clsMeal> Middle_Eastern_Cuisine_List
        {
            set { _Middle_Eastern_Cuisine_List  = value; }
            get { return _Middle_Eastern_Cuisine_List; }
        }
        public static List<clsMeal> Fast_Food_List
        {
            set { _Fast_Food_List = value; }
            get { return _Fast_Food_List; }
        }
        public static List<clsMeal> Asian_Cuisine_List
        {
            set { _Asian_Cuisine_List = value; }
            get { return _Asian_Cuisine_List; }
        }
        public static List<clsMeal> Hot_Drink_List
        {
            set { _Hot_Drink_List = value; }
            get { return _Hot_Drink_List; }
        }
        public static List<clsMeal> Cold_Drink_List
        {
            set { _Cold_Drink_List = value; }
            get { return _Cold_Drink_List; }
        }
        public static List<clsMeal> My_Order_List
        {
            set { _My_Order_List = value; }
            get { return _My_Order_List; }
        }
        public static List<clsMeal> All_Meals_List
        {
            set { _All_Meals_List = value; }
            get { return _All_Meals_List; }
        }
        public static List<clsMeal> Result_Search_List
        {
            set { _Result_Search_List = value; }
            get { return _Result_Search_List; }
        }
        public static List<clsMeal> Pay_List
        {
            get { return _Pay_List; }
            set { _Pay_List = value; Pay_List_Changed?.Invoke(); }
        }

        public static void LoadMealsFromFile()
        {
            Load_Meals_Type_From_File(Base_Path + "MiddleEasternCuisine_Meals.txt", Middle_Eastern_Cuisine_List);
            Load_Meals_Type_From_File(Base_Path + "FastFood_Meals.txt", Fast_Food_List);
            Load_Meals_Type_From_File(Base_Path + "AsianCuisine_Meals.txt", Asian_Cuisine_List);
            Load_Meals_Type_From_File(Base_Path + "HotDrink_Meals.txt", Hot_Drink_List);
            Load_Meals_Type_From_File(Base_Path + "ColdDrink_Meals.txt", Cold_Drink_List);
            Load_Meals_Type_From_File(Base_Path + "MyOrder_List.txt", My_Order_List);
        }

        public static void Save_Meals_To_File()
        {
            Save_Meals_Type_To_File(Base_Path + "MiddleEasternCuisine_Meals.txt", Middle_Eastern_Cuisine_List);
            Save_Meals_Type_To_File(Base_Path + "FastFood_Meals.txt", Fast_Food_List);
            Save_Meals_Type_To_File(Base_Path + "AsianCuisine_Meals.txt", Asian_Cuisine_List);
            Save_Meals_Type_To_File(Base_Path + "HotDrink_Meals.txt", Hot_Drink_List);
            Save_Meals_Type_To_File(Base_Path + "ColdDrink_Meals.txt", Cold_Drink_List);
            Save_Meals_Type_To_File(Base_Path + "MyOrder_List.txt", My_Order_List);
        }

        public static void Add_Meal_To_List(clsMeal meal)
        {
            switch (meal.MealType)
            {
                case enMealType.MiddleEasternCuisine:
                    Middle_Eastern_Cuisine_List.Add(meal);
                    Save_Meals_Type_To_File(Base_Path + "MiddleEasternCuisine_Meals.txt", Middle_Eastern_Cuisine_List);
                    break;
                case enMealType.FastFood:
                    Fast_Food_List.Add(meal);
                    Save_Meals_Type_To_File(Base_Path + "FastFood_Meals.txt", Fast_Food_List);
                    break;
                case enMealType.AsianCuisine:
                    Asian_Cuisine_List.Add(meal);
                    Save_Meals_Type_To_File(Base_Path + "AsianCuisine_Meals.txt", Asian_Cuisine_List);
                    break;
                case enMealType.HotDrink:
                    Hot_Drink_List.Add(meal);
                    Save_Meals_Type_To_File(Base_Path + "HotDrink_Meals.txt", Hot_Drink_List);
                    break;
                case enMealType.ColdDrink:
                    Cold_Drink_List.Add(meal);
                    Save_Meals_Type_To_File(Base_Path + "ColdDrink_Meals.txt", Cold_Drink_List);
                    break;
                case enMealType.MyOrder:
                    My_Order_List.Add(meal);
                    Save_Meals_Type_To_File(Base_Path + "MyOrder_List.txt", My_Order_List);
                    break;
            }
        }

        public static void Load_Meals_Type_From_File(string Meals_List_path, List<clsMeal> Meals_Type)
        {
            Meals_Type.Clear();
            StreamReader reader = null;

            if (File.Exists(Meals_List_path))
            {
                reader = new StreamReader(Meals_List_path);
                string fileContent = reader.ReadToEnd();
                string[] lines = fileContent.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

                foreach (string line in lines)
                {
                    if (string.IsNullOrWhiteSpace(line) || line.Trim() == "#0")
                        continue;

                    string[] parts = line.Split('#');
                    if (parts.Length == 6)
                    {
                        clsMeal meal = new clsMeal(
                            parts[0],
                            parts[1],
                            parts[2],
                            parts[3],
                            (enMealType)Enum.Parse(typeof(enMealType), parts[5]));

                        if (int.TryParse(parts[4], out int numOrderFromMeal))
                        {
                            meal.Num_Order_From_Meal = numOrderFromMeal;
                            Meals_Type.Add(meal);
                        }
                    }
                }
                reader.Close();
            }          
        }

        public static void Save_Meals_Type_To_File(string Meals_List_path, List<clsMeal> Meals_Type)
        {
            using (StreamWriter writer = new StreamWriter(Meals_List_path, append: false))
            {
                for (int i = 0; i < Meals_Type.Count; i++)
                {
                    if (!Is_Duplicate_Meal(Meals_Type, i))
                    {
                        writer.WriteLine($"{Meals_Type[i].Name}#{Meals_Type[i].Price}#{Meals_Type[i].Image_Path}#{Meals_Type[i].Information}#{Meals_Type[i].Num_Order_From_Meal}#{Meals_Type[i].MealType}");
                    }
                }
            }
        }

        public static void DisplayMeals(Panel panel, List<clsMeal> mealList, bool isEdit, bool displayThree)
        {
            Font font = new Font("Tajawal", 10, FontStyle.Bold);

            panel.Controls.Clear();
            int panelTop = 10;
            int panelLeft = 10;
            int panelCount = 0;

            foreach (clsMeal meal in mealList)
            {
                Panel mealPanel = new Panel
                {
                    BorderStyle = BorderStyle.FixedSingle,
                    Width = (panel.Width - 40) / (displayThree ? 3 : 2),
                    Height = 170,
                    Top = panelTop,
                    Left = panelLeft,
                    Margin = new Padding(5),
                    BackColor = Color.Azure,
                    BackgroundImage = Image.FromFile(@"Main_Folder\Photo\لقطة شاشة 2025-01-15 050712.png"),
                    BackgroundImageLayout = ImageLayout.Stretch
                };

                mealPanel.MouseEnter += (sender, e) => { mealPanel.BackColor = Color.PaleTurquoise; };
                mealPanel.MouseLeave += (sender, e) => { mealPanel.BackColor = Color.WhiteSmoke; };

                PictureBox pictureBox = new PictureBox
                {
                    ImageLocation = meal.Image_Path,
                    Top = 3,
                    Left = 3,
                    Width = 100,
                    Height = 100,
                    SizeMode = PictureBoxSizeMode.StretchImage
                };

                Make_Picture_Box_Rounded(pictureBox);

                Label nameLabel = new Label
                {
                    Text = meal.Name,
                    Top = pictureBox.Bottom + 1,
                    Left = 10,
                    Font = font,
                    TextAlign = ContentAlignment.MiddleLeft,
                    BackColor = Color.Transparent,
                    ForeColor = Color.White
                };

                Label priceLabel = new Label
                {
                    Text = meal.Price,
                    Top = nameLabel.Bottom - 5,
                    Left = 10,
                    Font = font,
                    TextAlign = ContentAlignment.MiddleLeft,
                    BackColor = Color.Transparent,
                    ForeColor = Color.White
                };

                Label infoLabel = new Label
                {
                    Text = meal.Information,
                    Top = 3,
                    Left = pictureBox.Right + 10,
                    Font = font,
                    TextAlign = ContentAlignment.TopLeft,
                    AutoSize = false,
                    Width = mealPanel.Width - pictureBox.Width - 20,
                    Height = 140,
                    MaximumSize = new Size(mealPanel.Width - pictureBox.Width - 20, 140),
                    BorderStyle = BorderStyle.FixedSingle,
                    Padding = new Padding(5),
                    BackColor = Color.WhiteSmoke
                };                

                Label numOrderLabel = new Label
                {
                    Text = meal.Num_Order_From_Meal.ToString(),
                    Top = mealPanel.Height - 26,
                    Left = 29,
                    Font = font,
                    BackColor = Color.Transparent,
                    ForeColor = Color.White
                };

                if (!isEdit)
                {
                    if (DashboardForm.Is_Darke_Mode)
                    {
                        infoLabel.BackColor = Color.DarkSlateGray;
                    }

                    Button btnLeft = new Button
                    {
                        Text = ">",
                        Top = mealPanel.Height - 26,
                        Left = 49,
                        Width = 25,
                        Height = 25,
                        BackColor = Color.LightSeaGreen
                    };

                    btnLeft.Click += (sender, e) =>
                    {
                        meal.Num_Order_From_Meal++;               
                        numOrderLabel.Text = meal.Num_Order_From_Meal.ToString();
                        Add_Pays_Meals();
                    };

                    btnLeft.MouseEnter += (sender, e) =>
                    {
                        btnLeft.BackColor = Color.LightSkyBlue;
                    };

                    btnLeft.MouseLeave += (sender, e) =>
                    {
                        btnLeft.BackColor = Color.LightSeaGreen;
                    };

                    Button btnRight = new Button
                    {
                        Text = "<",
                        Top = mealPanel.Height - 26,
                        Left = 5,
                        Width = 25,
                        Height = 25,
                        BackColor = Color.LightSeaGreen
                    };

                    btnRight.Click += (sender, e) =>
                    {
                        if (meal.Num_Order_From_Meal > 0)
                        {
                            meal.Num_Order_From_Meal--;                            
                            numOrderLabel.Text = meal.Num_Order_From_Meal.ToString();
                            Add_Pays_Meals();
                        }
                    };

                    btnRight.MouseEnter += (sender, e) =>
                    {
                        btnRight.BackColor = Color.LightSkyBlue;
                    };

                    btnRight.MouseLeave += (sender, e) =>
                    {
                        btnRight.BackColor = Color.LightSeaGreen;
                    };

                    mealPanel.Controls.Add(nameLabel);
                    mealPanel.Controls.Add(priceLabel);
                    mealPanel.Controls.Add(pictureBox);
                    mealPanel.Controls.Add(infoLabel);
                    mealPanel.Controls.Add(btnLeft);
                    mealPanel.Controls.Add(numOrderLabel);
                    mealPanel.Controls.Add(btnRight);
                    panel.Controls.Add(mealPanel);

                    panelCount++;

                    if (displayThree)
                    {
                        if (panelCount % 3 == 0)
                        {
                            panelTop += mealPanel.Height + 10;
                            panelLeft = 10;
                        }
                        else
                        {
                            panelLeft += mealPanel.Width + 10;
                        }
                    }
                    else
                    {
                        if (panelCount % 2 == 0)
                        {
                            panelTop += mealPanel.Height + 10;
                            panelLeft = 10;
                        }
                        else
                        {
                            panelLeft += mealPanel.Width + 10;
                        }
                    }
                }
                else
                {
                    if (Dashboard_For_Admain_Form._Is_Darke_Mode)
                    {
                        infoLabel.BackColor = Color.DarkSlateGray;
                    }

                    Button btnDelete = new Button
                    {
                        Text = Restaurant_Order_Management_System_Form.Is_Arabic? "حذف" : "Delete",
                        BackColor = Color.Transparent,
                        ForeColor = Color.Red,
                        Top = 144,
                        Left = 10,
                        Width = 60,
                        Height = 25
                    };

                    btnDelete.Click += (sender, e) =>
                    {
                        mealList.Remove(meal);
                        Sync_Meal_List_With_Main_Lists(mealList);
                        Save_Meals_To_File();
                        LoadMealsFromFile();
                        DisplayMeals(panel, mealList, isEdit, displayThree);
                    };

                    btnDelete.MouseEnter += (sender, e) =>
                    {
                        btnDelete.BackColor = Color.Red;
                        btnDelete.ForeColor = Color.White;
                    };

                    btnDelete.MouseLeave += (sender, e) =>
                    {
                        btnDelete.BackColor = Color.Transparent;
                        btnDelete.ForeColor = Color.Red;
                    };

                    Button btnEdit = new Button
                    {
                        Text = Restaurant_Order_Management_System_Form.Is_Arabic ? "تعديل" : "Edit",
                        BackColor = Color.Transparent,
                        ForeColor = Color.Green,
                        Top = 144,
                        Left = 80,
                        Width = 60,
                        Height = 25
                    };

                    btnEdit.Click += (sender, e) =>
                    {
                        Edit_Meal_Form editMealForm = new Edit_Meal_Form(meal);

                        editMealForm.FormClosed += (s, args) => DisplayMeals(panel, mealList, isEdit, displayThree);
                        editMealForm.ShowDialog();

                        Sync_Meal_List_With_Main_Lists(mealList);
                        Save_Meals_To_File();
                        LoadMealsFromFile();
                    };

                    btnEdit.MouseEnter += (sender, e) =>
                    {
                        btnEdit.BackColor = Color.Green;
                        btnEdit.ForeColor = Color.White;
                    };

                    btnEdit.MouseLeave += (sender, e) =>
                    {
                        btnEdit.BackColor = Color.Transparent;
                        btnEdit.ForeColor = Color.Green;
                    };

                    mealPanel.Controls.Add(nameLabel);
                    mealPanel.Controls.Add(priceLabel);
                    mealPanel.Controls.Add(pictureBox);
                    mealPanel.Controls.Add(infoLabel);
                    mealPanel.Controls.Add(btnDelete);
                    mealPanel.Controls.Add(btnEdit);
                    panel.Controls.Add(mealPanel);

                    panelCount++;

                    if (displayThree)
                    {
                        if (panelCount % 3 == 0)
                        {
                            panelTop += mealPanel.Height + 10;
                            panelLeft = 10;
                        }
                        else
                        {
                            panelLeft += mealPanel.Width + 10;
                        }
                    }
                    else
                    {
                        if (panelCount % 2 == 0)
                        {
                            panelTop += mealPanel.Height + 10;
                            panelLeft = 10;
                        }
                        else
                        {
                            panelLeft += mealPanel.Width + 10;
                        }
                    }
                }
            }
        }

        public static void Sync_Meal_List_With_Main_Lists(List<clsMeal> meal_List)
        {
            List<clsMeal> middle_Eastern_CuisineList = new List<clsMeal>();
            List<clsMeal> fast_Food_List = new List<clsMeal>();
            List<clsMeal> asian_Cuisine_List = new List<clsMeal>();
            List<clsMeal> hot_Drink_List = new List<clsMeal>();
            List<clsMeal> cold_Drink_List = new List<clsMeal>();
            List<clsMeal> my_Order_List = new List<clsMeal>();

            foreach (clsMeal meal in meal_List)
            {
                if (meal.MealType == enMealType.MiddleEasternCuisine)
                {
                    middle_Eastern_CuisineList.Add(meal);
                }
                else if (meal.MealType == enMealType.FastFood)
                {
                    fast_Food_List.Add(meal);
                }
                else if (meal.MealType == enMealType.AsianCuisine)
                {
                    asian_Cuisine_List.Add(meal);
                }
                else if (meal.MealType == enMealType.HotDrink)
                {
                    hot_Drink_List.Add(meal);
                }
                else if (meal.MealType == enMealType.ColdDrink)
                {
                    cold_Drink_List.Add(meal);
                }
                else if (meal.MealType == enMealType.MyOrder)
                {
                    my_Order_List.Add(meal);
                }
            }

            Middle_Eastern_Cuisine_List = middle_Eastern_CuisineList;
            Fast_Food_List = fast_Food_List;
            Asian_Cuisine_List = asian_Cuisine_List;
            Hot_Drink_List = hot_Drink_List;
            Cold_Drink_List = cold_Drink_List;
            My_Order_List = my_Order_List;
        }

        public static void Remove_Duplicates(List<clsMeal> mealList)
        {
            for (int i = 0; i < mealList.Count; i++)
            {
                for (int j = i + 1; j < mealList.Count; j++)
                {
                    if (mealList[i].Name == mealList[j].Name &&
                        mealList[i].Price == mealList[j].Price &&
                        mealList[i].Information == mealList[j].Information &&
                        mealList[i].Image_Path == mealList[j].Image_Path &&
                        mealList[i].MealType == mealList[j].MealType)
                    {
                        mealList.RemoveAt(j);
                        j--;
                    }
                }
            }
        }

        public static void Remove_Empty_Meals(List<clsMeal> mealList)
        {
            mealList.RemoveAll(meal => string.IsNullOrWhiteSpace(meal.Name)        ||
                                       string.IsNullOrWhiteSpace(meal.Price)       ||
                                       string.IsNullOrWhiteSpace(meal.Information) ||
                                       string.IsNullOrWhiteSpace(meal.Image_Path)  ||
                                       !Enum.IsDefined(typeof(enMealType), meal.MealType));
        }

        public static bool Is_Duplicate_Meal(List<clsMeal> Meals_Type, int currentIndex)
        {
            for (int j = 0; j < currentIndex; j++)
            {
                if (Meals_Type[currentIndex].Name == Meals_Type[j].Name)
                {
                    return true;
                }
            }
            return false;
        }

        public static void Reset_Meal_Orders()
        {
            List<List<clsMeal>> all_Meal_Lists = new List<List<clsMeal>>()
            {
                Asian_Cuisine_List,
                Middle_Eastern_Cuisine_List,
                Fast_Food_List,
                Hot_Drink_List,
                Cold_Drink_List,
                My_Order_List
            };

            foreach (List<clsMeal> meal_List in all_Meal_Lists)
            {
                foreach (clsMeal meal in meal_List)
                {
                    meal.Num_Order_From_Meal = 0;
                }
            }
        }

        public static void Make_Picture_Box_Rounded(PictureBox pictureBox)
        {
            int cornerRadius = 35;
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.StartFigure();
            path.AddArc(new Rectangle(0, 0, cornerRadius, cornerRadius), 180, 90);
            path.AddArc(new Rectangle(pictureBox.Width - cornerRadius, 0, cornerRadius, cornerRadius), 270, 90);
            path.AddArc(new Rectangle(pictureBox.Width - cornerRadius, pictureBox.Height - cornerRadius, cornerRadius, cornerRadius), 0, 90);
            path.AddArc(new Rectangle(0, pictureBox.Height - cornerRadius, cornerRadius, cornerRadius), 90, 90);
            path.CloseFigure();
            pictureBox.Region = new Region(path);
        }

        public static void Add_All_Meals_To_List(List<clsMeal> List)
        {

            if (List != null)
            {
                foreach (clsMeal meal in List)
                {
                    All_Meals_List.Add(meal);
                }
            }
        }

        public static void Add_All_Meals_To_All_Meals_List()
        {
            Add_All_Meals_To_List(Middle_Eastern_Cuisine_List);
            Add_All_Meals_To_List(Fast_Food_List);
            Add_All_Meals_To_List(Asian_Cuisine_List);
            Add_All_Meals_To_List(Hot_Drink_List);
            Add_All_Meals_To_List(Cold_Drink_List);
        }

        public static List<clsMeal> Find_Meals_By_Name(string mealName)
        {
            List<clsMeal> matchingMeals = new List<clsMeal>();
            foreach (clsMeal meal in All_Meals_List)
            {
                if (meal.Name.StartsWith(mealName, StringComparison.OrdinalIgnoreCase))
                {
                    matchingMeals.Add(meal);
                }
            }
            return matchingMeals;
        }

        public static void Display_Searched_Meals(string Search, Panel panel, bool IS_Edit)
        {
            Result_Search_List = Find_Meals_By_Name(Search);
            DisplayMeals(panel, Result_Search_List, IS_Edit, false);
        }

        public static void Add_Pays_Meals()
        {
            List<clsMeal> tempPayList = new List<clsMeal>();
            foreach (clsMeal meal in All_Meals_List)
            {
                if (meal.Num_Order_From_Meal > 0)
                {
                    tempPayList.Add(meal);
                }
            }
            Pay_List = tempPayList;
        }

        public static string Get_Total_Price_Of_Meals_string()
        {
            float total = Get_Total_Price_Of_Meals_float();
            return total.ToString() + " $";
        }

        public static string Get_Total_Price_Of_Meals_After_Discount()
        {
            float total = Get_Total_Price_Of_Meals_float() - 10;
            if (total < 0)
            {
                total = 0;
            }
            return total.ToString() + " $";
        }
         
        public static float Get_Total_Price_Of_Meals_float()
        {
            float Total = 0;
            foreach (clsMeal meal in Pay_List)
            {
                Total += (float.Parse(meal.Price.Split(' ')[0])) * meal.Num_Order_From_Meal;
            }
            return Total;
        }

        public static void Notification(string title, string message)
        {
            Font font = new Font("Tajawal", 10, FontStyle.Bold);
            PopupNotifier popup = new PopupNotifier();

            popup.TitleText = title;
            popup.ContentText = message;
            popup.ContentFont = font;
            popup.TitleFont = font;

            Image originalImage = Image.FromFile(@"Main_Folder\Photo\لقطة شاشة 2025-01-02 013423.ico");
            int newWidth = 50;
            int newHeight = 50;
            Image resizedImage = new Bitmap(originalImage, new Size(newWidth, newHeight));
           
            popup.Image = resizedImage;
            popup.Delay = 5000;
            popup.Popup();
        }

        public static void Note(String Note)
        {
            string Title = Restaurant_Order_Management_System_Form._Is_Arabic? Title = "تنبيه": Title = "Note";          
            Notification(Title, Note);
        }
    }
}