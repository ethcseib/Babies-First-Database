﻿/*Ethan Seiber
 * Date: 2/11/19
 * File: MainWindow.xaml.cs
 * Description: Connects with a database and prints the contents
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.OleDb;

namespace Classwork_6_database
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        OleDbConnection cn;

        public MainWindow()
        {
            cn = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = |DataDirectory|Classwork database1.accdb");
            InitializeComponent();
        }

        private void SeeAssets_Click_1(object sender, RoutedEventArgs e)//See the assets in TextBoxes1, 2, 3
        {
            string query = "select* from Assets";
            OleDbCommand cmd = new OleDbCommand(query, cn);

            cn.Open();

            OleDbDataReader reader = cmd.ExecuteReader();

            string Asset = "AssetID\n";
            string Desc = "Description\n";
            string EmployeeID = "EmployeeID\n";

            while (reader.Read())//gathers asset information
            {
                Asset += reader[0].ToString() + "\n\n\n";
                Desc += reader[1].ToString() + "\n\n";
                EmployeeID += reader[2].ToString() + "\n\n\n";
            }
            TextBox1.Text = Asset;//prints asset information
            TextBox2.Text = Desc;
            TextBox3.Text = EmployeeID;

            cn.Close();
        }


        private void SeeEmployees_Click(object sender, RoutedEventArgs e)//Prints All Employee information
        {

            string query = "select* from Employees";
            OleDbCommand cmd = new OleDbCommand(query, cn);

            cn.Open();

            OleDbDataReader reader = cmd.ExecuteReader();

            string ID = "EmployeeID\n";
            string FirstName = "FirstName\n";
            string LastName = "LastName\n";

            while (reader.Read())//Gathers the Employee information
            {
                ID += reader[0].ToString() + "\n\n";
                FirstName += reader[1].ToString() + "\n\n";
                LastName += reader[2].ToString() + "\n\n";
            }

            TextBox4.Text = ID;//Prints the Employee information to the textbox
            TextBox5.Text = FirstName;
            TextBox6.Text = LastName;

            cn.Close();
        }

        private void TextBox1_TextChanged(object sender, TextChangedEventArgs e)//after this point is just a lot of textbox declaration with no content because it was needed
        {

        }

        private void TextBox2_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox3_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox4_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox5_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox6_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
