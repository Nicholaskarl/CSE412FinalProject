using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CSE412FinalProject
{
    public partial class About : Page
    {
        static bool itemName = false;
        static bool itemOrigin = false;
        static bool itemPrice = false;
        static bool itemIngredients = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            //This is just in place to check that the connection is viable and the database is the correct one
            var cs = "Host=localhost;Port=5450;Username=postgres;Password=thisisthepassword;Database=CSEFINALV2";
            try
            {
                var con = new NpgsqlConnection(cs);
                con.Open();

                var cmd = new NpgsqlCommand();
                cmd.Connection = con;

                //cmd.CommandText = "SELECT * FROM restraunt";
                //cmd.ExecuteNonQuery();
                //cmd.CommandText = @"CREATE TABLE cars(id SERIAL PRIMARY KEY, name VARCHAR(255), price INT)";
                //cmd.ExecuteNonQuery();
                string sql = "SELECT * FROM restraunt";
                cmd = new NpgsqlCommand(sql, con);

                /*NpgsqlDataReader rdr = cmd.ExecuteReader();
                string holder = "";
                while (rdr.Read())
                {
                    holder = holder + rdr.GetInt32(0) + " " + rdr.GetString(1) + " " + rdr.GetString(2) + "<br/>";
                }*/
                con.Close();
                Result2.Text =  "Good to go";
            }
            catch (Exception ex)
            {
                Result2.Text = "Mistakes";
            }
            
        }
        protected void ItemName_CheckedChanged(object sender, EventArgs e)
        {
            if (itemName)
            {
                itemName = false;
                panel1.Controls.Add(new Label { Text = "Contact Selected excluded" });
            }
            else
            {
                itemName = true;
                panel1.Controls.Add(new Label { Text = "Contact Selected Included" });
            }
        }
        protected void ItemOrigin_CheckedChanged(object sender, EventArgs e)
        {
            if (itemOrigin)
            {
                itemOrigin = false;
                panel1.Controls.Add(new Label { Text = "Address excluded" });
            }
            else
            {
                itemOrigin = true;
                panel1.Controls.Add(new Label { Text = "Address Included" });
            }
        }
        protected void ItemPrice_CheckedChanged(object sender, EventArgs e)
        {
            if (itemPrice)
            {
                itemPrice = false;
                panel1.Controls.Add(new Label { Text = "Dining Type excluded" });
            }
            else
            {
                itemPrice = true;
                panel1.Controls.Add(new Label { Text = "Dining Type Included" });
            }
        }
        protected void ItemIngredients_CheckedChanged(object sender, EventArgs e)
        {
            if (itemIngredients)
            {
                itemIngredients = false;
                panel1.Controls.Add(new Label { Text = "Parent Company excluded" });
            }
            else
            {
                itemIngredients = true;
                panel1.Controls.Add(new Label { Text = "Parent Company Included" });
            }
        }
        protected void GenerateButton_Click(object sender, EventArgs e)
        {
            string selectStatement = "SELECT r_name,";
           
            if (itemName) { selectStatement = selectStatement + "i_name,"; }
            if (itemOrigin) { selectStatement = selectStatement + "i_origin,"; }
            if (itemPrice) { selectStatement = selectStatement + "i_price,"; }
            if (itemIngredients) { selectStatement = selectStatement + "i_items,"; }
            
            selectStatement = selectStatement.Remove(selectStatement.Length - 1) + " FROM restraunt, menu, items";
            
            selectStatement = selectStatement + " WHERE r_restrauntid = m_restrauntid AND m_itemid = i_itemid AND";
            

            if (DropDownList1.Text != "Please Select")
            {
                selectStatement = selectStatement + " i_origin = \'" + DropDownList1.Text + "\' AND";
            }

            if (minPrice.Text != "")
            {
                selectStatement = selectStatement + " i_price >= " + Double.Parse(minPrice.Text) + " AND";
            }
            if (maxPrice.Text != "")
            {
                selectStatement = selectStatement + " i_price <= " + Double.Parse(maxPrice.Text) + " AND";
            }

            if (DesiredIngredients.Text != "") 
            {
                string[] words = DesiredIngredients.Text.Split(',');
                foreach (string word in words)
                {
                    selectStatement = selectStatement + " \'" + word + "\' = ANY(i_items) AND";
                }
            }


            if (undesireableIngredients.Text != "")
            {
                string[] words = undesireableIngredients.Text.Split(',');
                foreach (string word in words)
                {
                    selectStatement = selectStatement + " \'" + word + "\' != ALL(i_items) AND";
                }
            }

            if (RestaurantTextBox.Text != "")
            {
                string[] words = RestaurantTextBox.Text.Split(',');
                foreach (string word in words)
                {
                    selectStatement = selectStatement + " \'" + word + "\' = r_name AND";
                }
            }

            if (selectStatement.Last() == 'E') { selectStatement = selectStatement.Remove(selectStatement.Length - 5, 5); }
            else if (selectStatement.Last() == 'D') { selectStatement = selectStatement.Remove(selectStatement.Length - 3, 3); }

            Console.WriteLine(selectStatement);
            var cs = "Host=localhost;Port=5450;Username=postgres;Password=thisisthepassword;Database=CSEFINALV2";
            try
            {
                var con = new NpgsqlConnection(cs);
                con.Open();

                var cmd = new NpgsqlCommand();
                cmd.Connection = con;
                cmd = new NpgsqlCommand(selectStatement, con);

                NpgsqlDataReader rdr = cmd.ExecuteReader();

                string holder = "<table style=\"width:1600px\">";
                int currentCol = 0;
                int numRows = 1;
                string sectionHolder = "";
                sectionHolder = sectionHolder + "<th>" + "<td>" + "Restaurant Name" + "</td>";
                if (itemName) { sectionHolder = sectionHolder + "<td>" + "Dish Name" + "</td>"; }
                if (itemOrigin) { sectionHolder = sectionHolder + "<td>" + "Origin" + "</td>"; }
                if (itemPrice) { sectionHolder = sectionHolder + "<td>" + "Price" + "</td>"; }
                if (itemIngredients) {sectionHolder = sectionHolder + "<td>" + "Ingredients" + "</td>";}
                sectionHolder = sectionHolder + "</th>";
                while (rdr.Read())
                {
                    currentCol = 0;
                    sectionHolder = "";
                    sectionHolder = sectionHolder + "<tr><td>"+numRows+"</td><td>"+ rdr.GetString(currentCol++)+"</td>";
                    if (itemName) { sectionHolder = sectionHolder + "<td>" + rdr.GetString(currentCol++) + "</td>"; }
                    if (itemOrigin) { sectionHolder = sectionHolder +"<td>"+ rdr.GetString(currentCol++)+"</td>"; }
                    if (itemPrice) { sectionHolder = sectionHolder +"<td>"+ rdr.GetDouble(currentCol++) + "</td>"; }
                    if (itemIngredients) {
                        string[] myArray = (string[])rdr.GetValue(currentCol++);
                        sectionHolder = sectionHolder + "<td> Ingredients: ";
                        foreach (string str in myArray) { 
                            sectionHolder = sectionHolder + " "+str;
                        }
                        sectionHolder = sectionHolder +"</td>"; 

                    }
                    numRows++;
                    sectionHolder = sectionHolder + "</tr>";
                    holder = holder + sectionHolder;
                   
                }
                holder = holder + "</table>";
                con.Close();
                Result2.Text = holder;
            }
            catch (Exception ex)
            {
                Result2.Text = selectStatement;
            }
        }
    }
}