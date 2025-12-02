using Restaurant__Order_Management_System;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurant__Order_Management_System
{
    public class clsResturant_Managementcs
    {
        public static void Set_Language(Control control, string En_Txt, string Ar_Txt)
        {
            control.Text = Restaurant_Order_Management_System_Form.Is_Arabic ? Ar_Txt : En_Txt;
        }

        public static void Save_DataGridView_To_File(DataGridView dataGridView, string Username, string filePath)
        {
            char delimiter = ',';
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine("Save Date: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                writer.WriteLine("Username: " + Username);

                for (int i = 0; i < dataGridView.Columns.Count; i++)
                {
                    writer.Write(dataGridView.Columns[i].HeaderText);
                    if (i < dataGridView.Columns.Count - 1)
                    {
                        writer.Write(delimiter);
                    }
                }
                writer.WriteLine();

                for (int i = 0; i < dataGridView.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView.Columns.Count; j++)
                    {
                        if (dataGridView.Rows[i].Cells[j].Value != null)
                        {
                            writer.Write(dataGridView.Rows[i].Cells[j].Value.ToString());
                        }
                        if (j < dataGridView.Columns.Count - 1)
                        {
                            writer.Write(delimiter);
                        }
                    }
                    writer.WriteLine();
                }
                writer.WriteLine();
            }
        }

        public static DataTable Load_Data_From_File(string filePath)
        {
            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("Date", typeof(string));
            dataTable.Columns.Add("Username", typeof(string));
            dataTable.Columns.Add("Name", typeof(string));
            dataTable.Columns.Add("Price", typeof(string));
            dataTable.Columns.Add("Quantity", typeof(int));

            string[] lines = File.ReadAllLines(filePath);

            string currentDate = string.Empty;
            string currentUsername = string.Empty;

            foreach (string line in lines)
            {
                if (line.StartsWith("Save Date:"))
                {
                    currentDate = line.Replace("Save Date: ", "").Trim();
                }
                else if (line.StartsWith("Username:"))
                {
                    currentUsername = line.Replace("Username: ", "").Trim();
                }
                else if (!line.StartsWith("Name,Price,Quantity") && !line.StartsWith("الاسم,السعر,الكمية") && !line.StartsWith("Save Date:") && !line.StartsWith("Username:"))
                {
                    string[] parts = line.Split(',');
                    if (parts.Length == 3)
                    {
                        DataRow row = dataTable.NewRow();
                        row["Date"] = currentDate;
                        row["Username"] = currentUsername;
                        row["Name"] = parts[0].Trim();
                        row["Price"] = parts[1].Trim();
                        if (int.TryParse(parts[2].Trim().Replace(" ", "").Replace("$", ""), out int quantity))
                        {
                            row["Quantity"] = quantity;
                        }
                        dataTable.Rows.Add(row);
                    }
                }
            }

            return dataTable;
        }

        public static void DisplayMeals(Panel panel, List<clsMeal> mealList, bool Is_Edit, bool displayThree)
        {
            Font font = new Font("Tajawal", 10, FontStyle.Bold);

            panel.Controls.Clear();
            int panelTop = 10;
            int panelLeft = 10;
            int panelCount = 0;

            List<clsMeal> Meal_List_Copy = new List<clsMeal>(mealList);

            List<string> addedMeals = new List<string>();
            for (int i = Meal_List_Copy.Count - 1; i >= 0; i--)
            {
                if (addedMeals.Contains(Meal_List_Copy[i].Name))
                {
                    Meal_List_Copy.RemoveAt(i);
                }
                else
                {
                    addedMeals.Add(Meal_List_Copy[i].Name);
                }
            }

            foreach (clsMeal meal in Meal_List_Copy)
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

                clsMeal_Management.Make_Picture_Box_Rounded(pictureBox);

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

                if (Dashboard_For_Admain_Form._Is_Darke_Mode)
                {
                    infoLabel.BackColor = Color.DarkSlateGray;
                }

                Label numOrderLabel = new Label
                {
                    Text = meal.Num_Order_From_Meal.ToString(),
                    Top = mealPanel.Height - 26,
                    Left = 29,
                    Font = font,
                    BackColor = Color.Transparent,
                    ForeColor = Color.White
                };

                if (!Is_Edit)
                {
                    Label orderLabel = new Label
                    {
                        Text = "Orders: " + meal.Num_Order_From_Meal.ToString(),
                        Top = mealPanel.Height - 26,
                        Left = 10,
                        Font = font,
                        BackColor = Color.Transparent,
                        ForeColor = Color.White
                    };

                    mealPanel.Controls.Add(nameLabel);
                    mealPanel.Controls.Add(priceLabel);
                    mealPanel.Controls.Add(pictureBox);
                    mealPanel.Controls.Add(infoLabel);
                    mealPanel.Controls.Add(orderLabel);
                    panel.Controls.Add(mealPanel);
                }
                else
                {
                    Button btnPrepared = new Button
                    {
                        Text = Restaurant_Order_Management_System_Form._Is_Arabic ? "حُضِرت" : "Prepared",
                        BackColor = Color.Transparent,
                        ForeColor = Color.Green,
                        Top = 144,
                        Left = 10,
                        Width = 80,
                        Height = 25
                    };

                    btnPrepared.Click += (sender, e) =>
                    {                       
                        if (Restaurant_Order_Management_System_Form._Is_Arabic)
                        {
                            Update_Meal_Status(meal, "حُضِرت");
                        }
                        else
                        {
                            Update_Meal_Status(meal, "Prepared");
                        }
                    };

                    btnPrepared.MouseEnter += (sender, e) =>
                    {
                        btnPrepared.BackColor = Color.Green;
                        btnPrepared.ForeColor = Color.White;
                    };

                    btnPrepared.MouseLeave += (sender, e) =>
                    {
                        btnPrepared.BackColor = Color.Transparent;
                        btnPrepared.ForeColor = Color.Green;
                    };

                    Button btnCancelled = new Button
                    {
                        Text = Restaurant_Order_Management_System_Form._Is_Arabic ? "أُلغِيَت" : "Cancelled",
                        BackColor = Color.Transparent,
                        ForeColor = Color.Red,
                        Top = 144,
                        Left = 100,
                        Width = 80,
                        Height = 25
                    };

                    btnCancelled.Click += (sender, e) =>
                    {
                        if (Restaurant_Order_Management_System_Form._Is_Arabic)
                        {
                            Update_Meal_Status(meal, "أُلغِيَت");
                        }
                        else
                        {
                            Update_Meal_Status(meal, "Cancelled");
                        }                       
                    };

                    btnCancelled.MouseEnter += (sender, e) =>
                    {
                        btnCancelled.BackColor = Color.Red;
                        btnCancelled.ForeColor = Color.White;
                    };

                    btnCancelled.MouseLeave += (sender, e) =>
                    {
                        btnCancelled.BackColor = Color.Transparent;
                        btnCancelled.ForeColor = Color.Red;
                    };

                    Button btnInProgress = new Button
                    {
                        Text = Restaurant_Order_Management_System_Form._Is_Arabic ? "قيد التحضير" : "In Progress",
                        BackColor = Color.LightSkyBlue,
                        ForeColor = Color.Black,
                        Top = 144,
                        Left = 190,
                        Width = 100,
                        Height = 25
                    };

                    btnInProgress.Click += (sender, e) =>
                    {
                        if (Restaurant_Order_Management_System_Form._Is_Arabic)
                        {
                            Update_Meal_Status(meal, "قيد التحضير");
                        }
                        else
                        {
                            Update_Meal_Status(meal, "In Progress");
                        }                        
                    };

                    btnInProgress.MouseEnter += (sender, e) =>
                    {
                        btnInProgress.BackColor = Color.SkyBlue;
                    };

                    btnInProgress.MouseLeave += (sender, e) =>
                    {
                        btnInProgress.BackColor = Color.LightSkyBlue;
                    };

                    mealPanel.Controls.Add(nameLabel);
                    mealPanel.Controls.Add(priceLabel);
                    mealPanel.Controls.Add(pictureBox);
                    mealPanel.Controls.Add(infoLabel);
                    mealPanel.Controls.Add(btnPrepared);
                    mealPanel.Controls.Add(btnCancelled);
                    mealPanel.Controls.Add(btnInProgress);
                    panel.Controls.Add(mealPanel);
                }

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

        private static void Update_Meal_Status(clsMeal meal, string newStatus)
        {
            meal.Status = newStatus;

            clsMeal mealToUpdate = clsMeal_Management.Pay_List.FirstOrDefault(m => m.Name == meal.Name);
            if (mealToUpdate != null)
            {
                mealToUpdate.Status = newStatus;
            }
        }

        public static int Get_Latest_Order_Count(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            DateTime latestDate = DateTime.MinValue;
            int orderCount = 0;
            DateTime? currentDate = null;

            foreach (string line in lines)
            {
                if (line.StartsWith("Save Date:"))
                {
                    string dateStr = line.Replace("Save Date: ", "").Trim();
                    if (DateTime.TryParseExact(dateStr, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime saveDate))
                    {
                        if (saveDate.Date > latestDate.Date)
                        {
                            latestDate = saveDate;
                            orderCount = 0;
                            currentDate = saveDate;
                        }
                        else if (saveDate.Date == latestDate.Date)
                        {
                            currentDate = saveDate;
                        }
                        else
                        {
                            currentDate = null;
                        }
                    }
                }
                else if (!line.StartsWith("Username:") && !line.StartsWith("Name,Price,Quantity") && currentDate.HasValue && currentDate.Value.Date == latestDate.Date)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length == 3 && int.TryParse(parts[2].Replace(" ", "").Replace("$", ""), out int quantity))
                    {
                        orderCount += quantity;
                    }
                }
            }

            if (latestDate.Date < DateTime.Today)
            {
                return 0;
            }

            return orderCount;
        }

        public static string Get_Most_Popular_Meal(string filePath)
        {
            DataTable dataTable = Load_Data_From_File(filePath);

            List<clsMeal> aggregatedMeals = new List<clsMeal>();

            foreach (DataRow row in dataTable.Rows)
            {
                string mealName = row["Name"].ToString();
                string mealPrice = row["Price"].ToString();
                int quantity = row["Quantity"] != DBNull.Value ? Convert.ToInt32(row["Quantity"]) : 0;

                clsMeal existingMeal = aggregatedMeals.Find(m => m.Name == mealName);
                if (existingMeal != null)
                {
                    existingMeal.Num_Order_From_Meal += quantity;
                }
                else
                {
                    clsMeal newMeal = new clsMeal(mealName, mealPrice, "", "", enMealType.MyOrder);
                    newMeal.Num_Order_From_Meal = quantity;
                    aggregatedMeals.Add(newMeal);
                }
            }

            clsMeal mostPopularMeal = null;
            int maxQuantity = 0;
            foreach (clsMeal meal in aggregatedMeals)
            {
                if (meal.Num_Order_From_Meal > maxQuantity)
                {
                    maxQuantity = meal.Num_Order_From_Meal;
                    mostPopularMeal = meal;
                }
            }

            return mostPopularMeal != null ? mostPopularMeal.Name : string.Empty;
        }

        private static DateTime Get_Latest_Date(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            DateTime latestDate = DateTime.MinValue;

            foreach (string line in lines)
            {
                if (line.StartsWith("Save Date:"))
                {
                    string dateStr = line.Replace("Save Date: ", "").Trim();
                    if (DateTime.TryParseExact(dateStr, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime saveDate))
                    {
                        if (saveDate.Date > latestDate.Date)
                        {
                            latestDate = saveDate;
                        }
                    }
                }
            }

            return latestDate.Date;
        }

        public static double Calculate_Daily_Revenue(string filePath)
        {
            DataTable dataTable = Load_Data_From_File(filePath);
            DateTime latestDate = Get_Latest_Date(filePath);

            double totalRevenue = 0;
            foreach (DataRow row in dataTable.Rows)
            {
                string dateStr = row["Date"].ToString();
                if (DateTime.TryParseExact(dateStr, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date) && date.Date == latestDate)
                {
                    string priceStr = row["Price"].ToString().Replace("$", "").Trim();
                    if (double.TryParse(priceStr, NumberStyles.Currency, CultureInfo.InvariantCulture, out double price))
                    {
                        int quantity = (int)row["Quantity"];
                        totalRevenue += price * quantity;
                    }
                }
            }
            if (latestDate.Date < DateTime.Today)
            {
                return 0;
            }

            return totalRevenue;
        }

        public static List<clsMeal> Get_Meals_Sold_To_day(string filePath)
        {
            List<clsMeal> mealsSoldToday = new List<clsMeal>();
            DateTime today = DateTime.Today;
            DataTable dataTable = Load_Data_From_File(filePath);

            foreach (DataRow row in dataTable.Rows)
            {
                string dateStr = row["Date"].ToString();
                if (DateTime.TryParseExact(dateStr, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date)
                    && date.Date == today)
                {
                    string mealName = row["Name"].ToString();
                    
                    int quantity = row["Quantity"] != DBNull.Value ? Convert.ToInt32(row["Quantity"]) : 0;

                    clsMeal existingMeal = mealsSoldToday.Find(m => m.Name == mealName);
                    if (existingMeal != null)
                    {
                        existingMeal.Num_Order_From_Meal += quantity;
                    }
                    else
                    {
                        clsMeal newMeal = new clsMeal(mealName, row["Price"].ToString(), "", "", enMealType.MyOrder);
                        newMeal.Num_Order_From_Meal = quantity;
                        mealsSoldToday.Add(newMeal);
                    }
                }
            }
            return mealsSoldToday;
        }
    }
}