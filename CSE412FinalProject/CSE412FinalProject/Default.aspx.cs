using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CSE412FinalProject
{
    public partial class _Default : Page
    {
        static bool contactSelected = false;
        static bool addressSelected = false;
        static bool diningTypeSelected = false;
        static bool parentCompSelected=false;
        static bool suppContactSelected=false;
        static bool gRateSelected=false;
        static bool mPriceSelected=false;
        static bool gPriceSelected=false;
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
                Result2.Text = "Good to go";
            }
            catch (Exception ex)
            {
                Result2.Text = "Mistakes";
            }

        }
        protected void ContactInfo_CheckedChanged(object sender, EventArgs e)
        {
            if (contactSelected) { 
                contactSelected= false;
                panel1.Controls.Add(new Label { Text = "Contact Selected excluded" });
            }
            else
            {
                contactSelected = true;
                panel1.Controls.Add(new Label { Text = "Contact Selected Included" });
            }
        }
        protected void Address_CheckedChanged(object sender, EventArgs e)
        {
            if (addressSelected)
            {
                addressSelected = false;
                panel1.Controls.Add(new Label { Text = "Address excluded" });
            }
            else
            {
                addressSelected = true;
                panel1.Controls.Add(new Label { Text = "Address Included" });
            }
        }
        protected void DiningType_CheckedChanged(object sender, EventArgs e)
        {
            if (diningTypeSelected)
            {
                diningTypeSelected = false;
                panel1.Controls.Add(new Label { Text = "Dining Type excluded" });
            }
            else
            {
                diningTypeSelected = true;
                panel1.Controls.Add(new Label { Text = "Dining Type Included" });
            }
        }
        protected void ParentCompany_CheckedChanged(object sender, EventArgs e)
        {
            if (parentCompSelected)
            {
                parentCompSelected = false;
                panel1.Controls.Add(new Label { Text = "Parent Company excluded" });
            }
            else
            {
                parentCompSelected = true;
                panel1.Controls.Add(new Label { Text = "Parent Company Included" });
            }
        }
        protected void SupplierContactInfo_CheckedChanged(object sender, EventArgs e)
        {
            if (suppContactSelected)
            {
                suppContactSelected= false;
                panel1.Controls.Add(new Label { Text = "Supplier Contact Selected excluded" });
            }
            else
            {
                suppContactSelected = true;
                panel1.Controls.Add(new Label { Text = "Supplier Contact Selected Included" });
            }
        }
        protected void GoogleRating_CheckedChanged(object sender, EventArgs e)
        {
            if (gRateSelected)
            {
                gRateSelected = false;
                panel1.Controls.Add(new Label { Text = "Google Rating excluded" });
            }
            else
            {
                gRateSelected = true;
                panel1.Controls.Add(new Label { Text = "Google Rating Included" });
            }
        }
        protected void MedianPriceRating_CheckedChanged(object sender, EventArgs e)
        {
            if (mPriceSelected)
            {
                mPriceSelected = false;
                panel1.Controls.Add(new Label { Text = "Median Price Rating excluded" });
            }
            else
            {
                mPriceSelected = true;
                panel1.Controls.Add(new Label { Text = "Median Price Rating Included" });
            }
        }
        protected void GooglePriceRating_CheckedChanged(object sender, EventArgs e)
        {
            if (gPriceSelected)
            {
                gPriceSelected = false;
                panel1.Controls.Add(new Label { Text = "Google Price Rating excluded" });
            }
            else
            {
                gPriceSelected = true;
                panel1.Controls.Add(new Label { Text = "Google Price Rating Included" });
            }
        }
        protected void GenerateButton_Click(object sender, EventArgs e) {
            string selectStatement = "SELECT r_name,";
            bool includeSupplier = false, includeRating = false;
            if (contactSelected) { selectStatement = selectStatement + "r_contactinfo,"; }
            if(addressSelected) { selectStatement = selectStatement + "r_address,"; }
            if (diningTypeSelected){ selectStatement = selectStatement + "r_diningtype,"; }
            if(parentCompSelected) { selectStatement = selectStatement + "r_parentcompany,"; }
            if(suppContactSelected){ selectStatement = selectStatement + "s_contactinfo,"; includeSupplier = true; }
            if(gRateSelected){ selectStatement = selectStatement + "ra_googlerating,";  includeRating = true; }
            if(mPriceSelected) { selectStatement = selectStatement + "ra_medianpricerating,"; includeRating = true; }
            if(gPriceSelected) { selectStatement = selectStatement + "ra_meanpricerating,";includeRating = true; }

            selectStatement = selectStatement.Remove(selectStatement.Length-1)+" FROM restraunt, supplier, rating";
            selectStatement = selectStatement + " WHERE r_suppid = s_suppid AND r_restrauntid = ra_restrauntid AND";
            
            if (DropDownList1.Text != "Please Select") {
                selectStatement = selectStatement + " r_diningtype = \'"+DropDownList1.Text+"\' AND" ;
            }

            if (ParentCompanyDropDownList.Text != "Please Select")
            {
                selectStatement = selectStatement + " r_parentcompany = \'" + ParentCompanyDropDownList.Text + "\' AND";
            }

            if (minGoogleInputData.Text != "") {
                selectStatement = selectStatement + " ra_googlerating >= " + Double.Parse(minGoogleInputData.Text)+ " AND";
            }
            if (maxGoogleInputData.Text != "")
            {
                selectStatement = selectStatement + " ra_googlerating <= " + Double.Parse(maxGoogleInputData.Text) + " AND";
            }

            if (minMedianInputData.Text != "")
            {
                selectStatement = selectStatement + " ra_medianpricerating >= " + Double.Parse(minMedianInputData.Text) + " AND";
            }
            if (maxMedianInputData.Text != "")
            {
                selectStatement = selectStatement + " ra_medianpricerating <= " + Double.Parse(maxMedianInputData.Text) + " AND";
            }

            if (minGoogelPriceInputData.Text != "")
            {
                selectStatement = selectStatement + " ra_meanpricerating >= " + Double.Parse(minGoogelPriceInputData.Text) + " AND";
            }
            if (maxGoogelPriceInputData.Text != "")
            {
                selectStatement = selectStatement + " ra_meanpricerating <= " + Double.Parse(maxGoogelPriceInputData.Text) + " AND";
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
                if (contactSelected) { sectionHolder = sectionHolder + "<td>" + "Restaurant Address" + "</td>"; }
                if (addressSelected) { sectionHolder = sectionHolder + "   " + "<td>" + "Restaurant Contact" + "</td>"; }
                if (diningTypeSelected) { sectionHolder = sectionHolder + "   " + "<td>" + "Dining Type" + "</td>"; }
                if (parentCompSelected) { sectionHolder = sectionHolder + "   " + "<td>" + "Parent Company"+ "</td>"; }
                if (suppContactSelected) { sectionHolder = sectionHolder + "   " + "<td>" + "Supplier Contact Info"+ "</td>"; }
                if (gRateSelected) { sectionHolder = sectionHolder + "   " + "<td>" +"Google Rating" + "</td>"; }
                if (mPriceSelected) { sectionHolder = sectionHolder + "   " + "<td>" + "Median Price" + "</td>"; }
                if (gPriceSelected) { sectionHolder = sectionHolder + "   " + "<td>" + "Google Price Rating" + "</td>"; }
                sectionHolder = sectionHolder + "</th>";
                holder = holder + sectionHolder;
                while (rdr.Read())
                {
                    sectionHolder = "";
                    currentCol = 0;
                    sectionHolder = sectionHolder+"<tr>"+"<td>"+numRows+"</td> <td>" + rdr.GetString(currentCol++) + "</td>";
                    if (contactSelected) { sectionHolder = sectionHolder +"<td>" +rdr.GetString(currentCol++)+"</td>"; }
                    if (addressSelected) { sectionHolder = sectionHolder + "   " + "<td>" + rdr.GetString(currentCol++) + "</td>"; }
                    if (diningTypeSelected) { sectionHolder = sectionHolder + "   " + "<td>" + rdr.GetString(currentCol++) + "</td>"; }
                    if (parentCompSelected) { sectionHolder = sectionHolder + "   " + "<td>" + rdr.GetString(currentCol++) + "</td>"; }
                    if (suppContactSelected) { sectionHolder = sectionHolder + "   " + "<td>" + rdr.GetString(currentCol++) + "</td>"; }
                    if (gRateSelected) { sectionHolder = sectionHolder + "   " + "<td>" + rdr.GetDouble(currentCol++) + "</td>"; }
                    if (mPriceSelected) { sectionHolder = sectionHolder + "   " + "<td>" + rdr.GetDouble(currentCol++) + "</td>"; }
                    if (gPriceSelected) { sectionHolder = sectionHolder + "   " + "<td>" + rdr.GetDouble(currentCol++) + "</td>"; }
                    sectionHolder = sectionHolder + "</tr>";
                    holder = holder + sectionHolder;
                    numRows++;
                }
                con.Close();
                Result2.Text = holder+"</table>";
            }
            catch (Exception ex)
            {
                Result2.Text = selectStatement;
            }
        }
    }
}