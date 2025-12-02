using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Restaurant__Order_Management_System
{
     public class clsLogin
    {
        private ArrayList _Login_List = new ArrayList();

        public static string _Username_For_Wellcome = "";
        private static string _Client_Account_Path = @"Main_Folder\Accounts\Client_Account.txt";
        private string _First_Name = "";
        private string _Last_Name = "";
        private string _Username = "";
        private string _Mobile_Phone = "";
        private string _Location = "";
        private string _Password = "";
        private int _Num_Of_Login = 0;



        public ArrayList Login_List
        {
            set { _Login_List = value; }
            get { return _Login_List; }
        }
        public string First_Name
        {
            set { _First_Name = value; }
            get { return _First_Name; }
        }
        public string Last_Name
        {
            set { _Last_Name = value; }
            get { return _Last_Name; }
        }
        public string Username
        {
            set { _Username = value; }
            get { return _Username; }
        }
        public string Mobile_Phone
        {
            set { _Mobile_Phone = value; }
            get { return _Mobile_Phone; }
        }
        public string Location
        {
            set { _Location = value; }
            get { return _Location; }
        }
        public string Password
        {
            set { _Password = value; }
            get { return _Password; }
        }
        public int Num_Of_Login
        {
            set { _Num_Of_Login = value; }
            get { return _Num_Of_Login; }
        }
        public static string Client_Account_Path
        {
            get { return _Client_Account_Path; }
            set { _Client_Account_Path = value; }
        }
        public static string Username_For_Wellcome
        {
            get { return _Username_For_Wellcome; }
            set { _Username_For_Wellcome = value; }
        }

        public clsLogin() { }

        public void Add_This_Account(string Path, bool Is_Admain)
        {
            List<string> lines = new List<string>(File.ReadAllLines(Path));
            bool exists = false;

            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }
                string[] data = line.Split('#');
                if (data[0] == Username)
                {
                    exists = true;
                    break;
                }
            }

            if (!exists)
            {
                using (StreamWriter writer = new StreamWriter(Path, true))
                {
                    writer.WriteLine(Is_Admain ? Username + '#' + Password : Username + '#' + Password + '#' + Location + '#' + Num_Of_Login);
                    writer.Close();
                }
            }
            else
            {
                clsMeal_Management.Note("Account already exists.");
            }
        }

        public static void Login_System(string[] record, string Path, bool isAdmain)
        {
            bool Is_Found = false;
            List<string> lines = new List<string>(File.ReadAllLines(Path));

            for (int i = 0; i < lines.Count; i++)
            {
                if (string.IsNullOrWhiteSpace(lines[i]))
                {
                    continue;
                }
                string[] Line = lines[i].Split('#');
            
                if (Line.Length >= 2 && Line[0] == record[0] && Line[1] == record[1])
                {
                    Is_Found = true;
                    if (!isAdmain && Line.Length > 3)
                    {
                        int Num_Of_Login = int.Parse(Line[3]);
                        Num_Of_Login += 1;
                        Line[3] = Num_Of_Login.ToString();
                        lines[i] = string.Join("#", Line);
                    }
                    File.WriteAllLines(Path, lines);
                    break;
                }
            }

            if (Is_Found)
            {
                if (isAdmain)
                {
                    Dashboard_For_Admain_Form dashboard_For_Admain_Form = new Dashboard_For_Admain_Form();
                    dashboard_For_Admain_Form.ShowDialog();
                }
                else
                {
                    DashboardForm dashboardForm = new DashboardForm(record[0]);
                    dashboardForm.ShowDialog();
                }
            }
            else
            {
                clsMeal_Management.Note("Username or Password is incorrect.\nPlease try again.");
            }
        }

        public static string Get_Location(string username)
        {
            using (StreamReader reader = new StreamReader(Client_Account_Path))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] data = line.Split('#');
                    if (data[0] == username)
                    {
                        return data[2];
                    }
                }
            }
            return null;
        }

        public static int Get_Num_Client_Of_Login(string username)
        {
            using (StreamReader reader = new StreamReader(Client_Account_Path))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] data = line.Split('#');
                    if (data[0] == username)
                    {
                        return int.Parse(data[3]);
                    }
                }
            }
            return 0;
        }

        public static string Get_Regular_Customer_Name()
        {
            string Regular_Customer_Name = null;
            int Max_Logins = 0;

            using (StreamReader reader = new StreamReader(Client_Account_Path))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] data = line.Split('#');
                    if (data.Length >= 4 && int.TryParse(data[3], out int Num_Logins))
                    {
                        if (Num_Logins > Max_Logins)
                        {
                            Max_Logins = Num_Logins;
                            Regular_Customer_Name = data[0];
                        }
                    }
                }
            }

            return Regular_Customer_Name;
        }

        public static int Get_Num_Of_Client()
        {
                int Non_Empty_Line_Count = 0;
                string[] lines = File.ReadAllLines(Client_Account_Path);
                foreach (string line in lines)
                {
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        Non_Empty_Line_Count++;
                    }
                }

                return Non_Empty_Line_Count;            
        }
    }
}