using System;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Restaurant__Order_Management_System
{
    public enum enMealType
    {
        MiddleEasternCuisine = 0, FastFood = 1, AsianCuisine = 2
      , HotDrink = 3, ColdDrink = 4, MyOrder = 5
    }


    public class clsMeal
    {
        private string _Name;
        private string _Price;
        private string _Image_Path;
        private string _Information;
        private enMealType _MealType;
        private int _OrderID;
        private int _Num_Order_From_Meal = 0;
        private string _Status = "Pending";


        public string Name
        {
            set { _Name = value; }
            get { return _Name; }
        }
        public string Price
        {
            set { _Price = value; }
            get { return _Price; }
        }
        public string Image_Path
        {
            set { _Image_Path = value; }
            get { return _Image_Path; }
        }
        public string Information
        {
            set { _Information = value; }
            get { return _Information; }
        }
        public int Num_Order_From_Meal
        {
            set { _Num_Order_From_Meal = value; }
            get { return _Num_Order_From_Meal; }
        }
        public enMealType MealType
        {
            set { _MealType = value; }
            get { return _MealType; }
        }
        public int OrderID
        {
            set { _OrderID = value; }
            get { return _OrderID; }
        }
        public string Status
        {
            set { _Status = value; }
            get { return _Status; }
        }

        public clsMeal(string Name, string Price, string Image_Path, string Information, enMealType MealType)
        {
            this.Name = Name;
            this.Price = Price;
            this.Image_Path = Image_Path;
            this.Information = Information;
            this.MealType = MealType;
            this.Num_Order_From_Meal = 0;
        }
    }
}