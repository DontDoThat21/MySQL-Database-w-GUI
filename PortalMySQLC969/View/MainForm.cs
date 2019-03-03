using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Controls;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Globalization;

namespace PortalMySQLC969
{
    public partial class MainForm : Form
    {
        // Below is all of our instance varriables

        public DataTable SalesTable; // Pretty perfect solution to "how can I give my user data without putting it on the DGV". This is a global table. InnerJoinAll(); sets it.
        public DataTable Customers;
        public DataTable Products;
        public static string myConnectionString = ConfigurationManager.ConnectionStrings["MySQLdB"].ConnectionString;

        public MySqlConnection conn = new MySqlConnection(myConnectionString); // Let's have this as public since nearly every method uses it.

        public static string[,] ApptStringArray = new string[5, 3];

        public static string selectFromProducts = "SELECT product_id \"Prod ID\", product_name \"Product Name\", price \"Price\", merchant \"Vndr\" FROM ll_products ORDER BY 1;";
        public static string selectFromSales = "SELECT customer_id \"Customer ID\", product_id \"Prod ID\", saledate \"Sales-date\" FROM ll_sales";
        public static string selectFromCustomers = "SELECT customer_id \"Cust ID\", name \"Customer Name\", address \"Address\", phone \"Phone Number\" FROM ll_customers";

        // ^ All of our select statements.

        public MainForm()
        {
            InitializeComponent();
            //tableSelectionHandler();
            //mainDGV.DataSource = GetData(selectFromProducts);
            //SalesTable = InnerJoinAll("Sales");
            //tableSelectionCBox.Text = "Sales"; // 1 of 2
            //Customers = InnerJoinAll("Customers");
            //tableSelectionCBox.Text = "Customers";
            //Products = InnerJoinAll("Products");
            //tableSelectionCBox.Text = "Products";// 2 of 2 These are cleverly populating our background tables up and into memory appropriately. Con: Slower app launch time. Pro: Quicker app responsiveness later
            SetTimeCodeLabel();
        }
        private DataTable GetData(string Query)
        {
            DataTable data = new DataTable();
            using (MySqlCommand cmd = new MySqlCommand(Query, conn)) // This is our DGV populating cmd.
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                } else { }; // Assure it's open
                MySqlDataReader reader = cmd.ExecuteReader();
                data.Load(reader);
                mainDGV.DataSource = data;
            }
            conn.Close();
            return data;
        }

        private void MainDGV_CellEnter(object sender, DataGridViewCellEventArgs e) // Every time the user changes their selected row, lets populate our fields incase they want to edit them!
        {

            if (tableSelectionCBox.Text == "Customers")
            {
                label1.Text = " Address:";
                label2.Text = "Customer ID:";
                label3.Text = "Customer Name:";
                label4.Text = "Phone Number:";
                box1.Location = new Point(617, 55);
                box1.Width = 200;
                box3.Location = new Point(648, 190);
                box3.Width = 135;
                box1.Text = mainDGV.CurrentRow.Cells[2].Value.ToString();
                box2.Text = mainDGV.CurrentRow.Cells[0].Value.ToString();
                box3.Text = mainDGV.CurrentRow.Cells[1].Value.ToString();
                box4.Text = mainDGV.CurrentRow.Cells[3].Value.ToString();
                box4.Visible = true; label4.Visible = true;
                box1.Enabled = false; box2.Enabled = false; box3.Enabled = false; box4.Enabled = false; saveButton.Enabled = false; editBtn.Enabled = true;
            }
            else if (tableSelectionCBox.Text == "Sales")
            {
                label1.Text = "Cust ID:";
                label2.Text = "  Prod ID:";
                label3.Text = "  Sales Date:";
                box1.Location = new Point(682, 55);
                box1.Width = 61;
                box3.Location = new Point(612, 190);
                box3.Width = 200;
                box4.Visible = false; label4.Visible = false;
                box1.Text = mainDGV.CurrentRow.Cells[0].Value.ToString(); // Remember this is using the DGV's already existing instance. Causes issues if not set first.
                box2.Text = mainDGV.CurrentRow.Cells[1].Value.ToString();
                box3.Text = mainDGV.CurrentRow.Cells[2].Value.ToString();
                box1.Enabled = false; box2.Enabled = false; box3.Enabled = false; descriptionBox.Enabled = false; saveButton.Enabled = false; editBtn.Enabled = false;
            }
            else if (tableSelectionCBox.Text == "Products")
            {
                label1.Text = " Prod ID:";
                label2.Text = "    Price:";
                label3.Text = "Manufacturer:";
                label4.Text = "Product Name:";
                box1.Location = new Point(682, 55);
                box1.Width = 61;
                box3.Location = new Point(648, 190);
                box3.Width = 135;
                box1.Text = mainDGV.CurrentRow.Cells[0].Value.ToString(); // Remember this is using the DGV's already existing instance. Causes issues if not set first.
                box2.Text = mainDGV.CurrentRow.Cells[2].Value.ToString();
                box3.Text = mainDGV.CurrentRow.Cells[3].Value.ToString();
                box4.Text = mainDGV.CurrentRow.Cells[1].Value.ToString();
                box1.Enabled = false; box2.Enabled = false; box3.Enabled = false; box4.Enabled = false; box4.Visible = true; label4.Visible = true; saveButton.Enabled = false; descriptionBox.Enabled = false; editBtn.Enabled = true;
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                else
                {} // we need the conn open. We close later.
                DataTable data = new DataTable();
                MySqlCommand cmd = new MySqlCommand($"SELECT item_desc FROM ll_products WHERE product_id = {box1.Text}", conn);
                data.Load(cmd.ExecuteReader());
                descriptionBox.Text = data.Rows[0][0].ToString();
                conn.Close();
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (tableSelectionCBox.Text == "Customers")
            {
                if (mainDGV.Rows.Count >= int.Parse(box2.Text)) // If the total ammount of rows in the existing table is 3, a new click would set custIdBox to 3. This lets us know if user clicked new, or edit.
                {
                    string QueryCstmrTbl = $"update ll_customers set name = '{box3.Text}', address = '{box1.Text}', phone = '{box4.Text}' WHERE customer_id = {int.Parse(box2.Text)};";
                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Open();
                    }
                    else { }; // Assure connection is open

                    MySqlCommand addCmd = new MySqlCommand(QueryCstmrTbl, conn); // Executing second query, also.
                    addCmd.ExecuteNonQuery();

                    conn.Close();
                    Customers = InnerJoinAll("Customers");
                    GetData(selectFromCustomers);
                }
                // Updating new customerstring QueryCstmrTbl = $"update ll_customers set name = '{box3.Text}', address = '{box1.Text}', phone = '{box4.Text}' WHERE customer_id = {int.Parse(box2.Text)};";
                else
                {
                    string QryNewCstmrToDb = $"insert into ll_customers values({int.Parse(box2.Text)}, '{box3.Text}', '{box1.Text}', '{box4.Text}')";
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(QryNewCstmrToDb, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    conn.Close();
                    Customers = InnerJoinAll("Customers");
                    GetData(selectFromCustomers);
                }
            }
            // Modifying a sales record.
            else if (tableSelectionCBox.Text == "Sales")
            {
                string QryNewSaleToDB;
                try
                {
                    QryNewSaleToDB = $"insert into ll_sales values({int.Parse(box1.Text)}, {int.Parse(box2.Text)}, str_to_date('{DateTime.Parse(box3.Text).ToString()}', '%m/%d/%Y %h:%i:%s%p'))";
                    conn.Open();
                    MySqlCommand aptCmd = new MySqlCommand(QryNewSaleToDB, conn);
                    MySqlDataReader reader = aptCmd.ExecuteReader();
                    conn.Close();
                    SalesTable = InnerJoinAll("Sales");
                    GetData(selectFromSales);
                }
                catch
                {
                    MessageBox.Show("Can't insert letters as IDs. " +
                        "\nFollow the data format YYYY-MM-DD HH:MM:SS AM");
                }
            }

            else if (tableSelectionCBox.Text == "Products")
            {
                if (mainDGV.Rows.Count >= int.Parse(box1.Text))
                {
                    string QueryCstmrTbl = $"update ll_products set product_name = '{box4.Text}', price = '{box2.Text}', merchant = '{box3.Text}', item_desc = '{descriptionBox.Text}' WHERE product_id = {int.Parse(box1.Text)};";
                    conn.Open();

                    MySqlCommand addCmd = new MySqlCommand(QueryCstmrTbl, conn); // Executing second query, also.
                    addCmd.ExecuteNonQuery();

                    conn.Close();
                    Products = InnerJoinAll("Products");
                    GetData(selectFromProducts);
                }
                else
                {
                    string QryNewApptToDB = $"insert into ll_products values({box1.Text}, '{box4.Text}', '{box2.Text}', '{box3.Text}', '{descriptionBox.Text}');";
                    conn.Open();

                    MySqlCommand aptCmd = new MySqlCommand(QryNewApptToDB, conn);
                    MySqlDataReader reader = aptCmd.ExecuteReader();

                    conn.Close();
                    Products = InnerJoinAll("Products");
                    GetData(selectFromProducts);
                }
            }
            mainDGV.ClearSelection();
            mainDGV.Rows[0].Selected = true;
        }

        private void NewBtn_Click(object sender, EventArgs e)
        {
            mainDGV.ClearSelection();
            if (tableSelectionCBox.Text == "Customers")
            {
                conn.Open();
                MySqlCommand cmd1 = new MySqlCommand("select max(customer_id) from ll_customers;", conn);
                MySqlDataReader reader = cmd1.ExecuteReader(); reader.Read();
                int customerIdCount = int.Parse(reader.GetValue(0).ToString()) + 1;
                reader.Close();
                reader.Dispose();
                conn.Close();

                box1.Text = ""; box1.Enabled = true;
                box2.Text = $"{customerIdCount}"; box2.Enabled = false;
                box3.Text = ""; box3.Enabled = true;
                box4.Text = ""; box4.Enabled = true;

                descriptionBox.Text = "";
                saveButton.Enabled = true;
            }
            else if (tableSelectionCBox.Text == "Products")
            {
                conn.Open();
                MySqlCommand cmd1 = new MySqlCommand("select max(product_id) from ll_products;", conn);
                MySqlDataReader reader = cmd1.ExecuteReader(); reader.Read();
                int productIdCount = int.Parse(reader.GetValue(0).ToString()) + 1;
                reader.Close();

                reader.Dispose();

                conn.Close();

                box1.Text = $"{productIdCount}"; box1.Enabled = false;
                box2.Text = ""; box2.Enabled = true;
                box3.Text = ""; box3.Enabled = true;
                box4.Text = ""; box4.Enabled = true;
                descriptionBox.Text = ""; descriptionBox.Enabled = true;
                saveButton.Enabled = true;

            }
            else if (tableSelectionCBox.Text == "Sales")
            {
                conn.Open();
                MySqlCommand cmd1 = new MySqlCommand("select max(customer_id) from ll_sales;", conn);
                MySqlDataReader reader = cmd1.ExecuteReader(); reader.Read();
                int customerIdCount = int.Parse(reader.GetValue(0).ToString()) + 1;
                reader.Close();

                MySqlCommand cmd2 = new MySqlCommand("select max(product_id) from ll_sales", conn);
                reader = cmd2.ExecuteReader(); reader.Read();
                int salesIdCount = int.Parse(reader.GetValue(0).ToString()) + 1;
                reader.Close();

                reader.Dispose();

                conn.Close();

                box1.Text = ""; box1.Enabled = true;
                box2.Text = ""; box2.Enabled = true;
                box3.Text = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"); box3.Enabled = true;
                saveButton.Enabled = true;

            }
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            // Depending on which table we're going to edit.. enable fields accordingly. (Mostly the same but.. yea.)
            if (tableSelectionCBox.Text == "Customers")
            {
                box1.Enabled = true; box2.Enabled = false; box3.Enabled = true; box4.Enabled = true; saveButton.Enabled = true;
            }
            else if (tableSelectionCBox.Text == "Sales")
            {
                box1.Enabled = true; box2.Enabled = true; box3.Enabled = true; descriptionBox.Enabled = true; saveButton.Enabled = true;
            }
            else if (tableSelectionCBox.Text == "Products")
            {
                box1.Enabled = false; box2.Enabled = true; box3.Enabled = true; box4.Enabled = true; descriptionBox.Enabled = true; saveButton.Enabled = true;
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (box2.Text != "") // If it's empty, don't delete.
            {
                conn.Open();
                if (tableSelectionCBox.Text == "Customers")
                {
                    DialogResult dialogResult = MessageBox.Show("Really delete customer? This cascades and " +
                        "deletes corresponding sales records as well!", "Confirm deletion.", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        string Query = $"delete from ll_customers where customer_id = {int.Parse(box2.Text)}; " +
                            $"delete from ll_sales where customer_id = {int.Parse(box2.Text)};";
                        MySqlCommand cmd = new MySqlCommand(Query, conn);
                        MySqlDataReader reader = cmd.ExecuteReader();
                        conn.Close();
                        GetData(selectFromCustomers);
                    }
                    else if (dialogResult == DialogResult.No)
                    { } // Do nothing, they cancelled deletion.
                }
                else if (tableSelectionCBox.Text == "Products")
                {
                    DialogResult dialogResult = MessageBox.Show("Really delete product? This cascades and " +
                        "deletes corresponding sales records as well!", "Confirm deletion.", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        string Query = $"delete from ll_products where product_id = {int.Parse(box1.Text)};" +
                            $"delete from ll_sales where product_id = {int.Parse(box1.Text)};";
                        MySqlCommand cmd = new MySqlCommand(Query, conn);
                        MySqlDataReader reader = cmd.ExecuteReader();
                        conn.Close();
                        GetData(selectFromProducts);
                    }
                    else if (dialogResult == DialogResult.No)
                    { } // Do nothing, they cancelled deletion.
                }
                else if (tableSelectionCBox.Text == "Sales")
                {
                    DialogResult dialogResult = MessageBox.Show("There is rarely a good reason to delete a specific" +
                        "sale. This will not delete products, or customers. Only this specific sales record. \n\n Art thou sureth?", "Confirm deletion.", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        string Query = $"delete from ll_sales where customer_id = {int.Parse(box1.Text)};" +
                            $"delete from ll_sales where product_id = {int.Parse(box2.Text)};";
                        MySqlCommand cmd = new MySqlCommand(Query, conn);
                        MySqlDataReader reader = cmd.ExecuteReader();
                        conn.Close();
                        GetData(selectFromSales);
                    }
                    else if (dialogResult == DialogResult.No)
                    { } // Do nothing, they cancelled deletion.
                }
            }
            else if (box2.Text == "") // If it's not empty.
            {
                MessageBox.Show("Select something to delete.");
            }
        }

        // End of all click buttons, and most of the ui element methods

        private void popBtn_Click(object sender, EventArgs e)
        {
            GetData(selectFromProducts);
        }

        private DataTable InnerJoinAll(string tableName) // Responsible for instantiating data from queries into memory.
        {
            if (tableName == "Customers")
            {
                string select = "SELECT * FROM ll_customers";
                DataTable data = new DataTable();
                MySqlCommand cmd = new MySqlCommand(select, conn);
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                data.Load(reader);
                conn.Close();
                return data;
            }
            else if (tableName == "Sales")
            {
                string select = "SELECT * from ll_sales";
                DataTable data = new DataTable();
                MySqlCommand cmd = new MySqlCommand(select, conn);
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                data.Load(reader);
                conn.Close();
                return data;
            }
            else if (tableName == "Products")
            {
                string select = "SELECT * from ll_products";
                DataTable data = new DataTable();
                MySqlCommand cmd = new MySqlCommand(select, conn);
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                data.Load(reader);
                conn.Close();
                return data;
            }
            else
            {
                return null;
            }
        }

        private void tableSelectionCBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            idCBox.Checked = false; nameCBox.Checked = false; mrchntCBox.Checked = false;
            tableSelectionHandler();
        }

        private void tableSelectionHandler()
        {
            if (tableSelectionCBox.Text == "Sales")
            {
                descriptionBox.Visible = false; timezoneIsPDTPSTUserLabel.Visible = true; timezoneLabel.Visible = true; filtersPanel.Visible = false;
                mainDGV.DataSource = GetData(selectFromSales);
                try
                {
                    mainDGV.Columns[0].Width = 90;
                    mainDGV.Columns[1].Width = 90;
                } catch { };
            }
            else if (tableSelectionCBox.Text == "Customers")
            {
                box1.Enabled = false;
                box2.Enabled = false;
                box3.Enabled = false;
                box4.Enabled = false;
                descriptionBox.Visible = false; timezoneIsPDTPSTUserLabel.Visible = false; timezoneLabel.Visible = false; filtersPanel.Visible = true;
                mainDGV.DataSource = GetData(selectFromCustomers);
                mrchntCBox.Text = "Address";
                try
                {
                    mainDGV.Columns[0].Width = 50;
                } catch { };
            }
            else if (tableSelectionCBox.Text == "Products")
            {
                descriptionBox.Visible = true; timezoneIsPDTPSTUserLabel.Visible = false; timezoneLabel.Visible = false; filtersPanel.Visible = true;
                mainDGV.DataSource = GetData(selectFromProducts);
                mrchntCBox.Text = "Mnfctr";
                try
                {
                    mainDGV.Columns[0].Width = 50;
                    mainDGV.Columns[2].Width = 50;
                    mainDGV.Columns[3].Width = 50;
                } catch { };
            }
        }

        private void apptCalendar_DateChanged(object sender, DateRangeEventArgs e)
        { CalendarAppartmentBoxPopulate(); }

        public delegate void DelName(string str);

        private void CalendarAppartmentBoxPopulate()
        {
            editBtn.Enabled = false;
            try
            {
                if (ApptStringArray[0, 0].Length == 15)
                {
                    // Do nothing, we just wanted to know if this object was instantiated yet.
                }
            }
            catch
            {
                GenerateOurAppts(); // Since the above try will error out when our tables arent in memory.. we need to instantiate them.
            }
            // Used by all for conversion.
            foreach (DataRow row in Customers.Rows)
            {
                DateTime dt = DateTime.Now;
                try { dt = DateTime.Parse(row[7].ToString()); } catch { }
                string str = dt.ToString();
            }
            // A bunch of sets. When a confirmation for a time is made from the client, the form below are affected, inversely.
        }

        private void GenerateOurAppts()
        {
            RndmApptAvlblTimeGen rndm = new RndmApptAvlblTimeGen();
            int y = 0;
            int x = 0;
            try
            {
                int temp = ApptStringArray[0, 0].Length;
            }
            catch (System.NullReferenceException) // If we try to do any work on the above int temp, it will only nullref IF it doesnt exist.
            {
                while (y < (ApptStringArray.Length / 3)) //While x < total/y which is really just the y of the static array. if 5x3 is 15, then 15/3 = 5 so we know X == 5! :)
                {
                    while (x < (ApptStringArray.Length / 5)) // While y < total/x which is really just the y of the static array. 
                    {
                        ApptStringArray[y, x] = rndm.ReturnAppointment(); // Sets the appts when none exists.
                        x++;
                    }
                    x = 0;
                    y++;
                }
                y = 0;
            }

            while (y < (ApptStringArray.Length / 3))
            {
                while (x < (ApptStringArray.Length / 5))
                {
                    x++;
                }
                x = 0;
                y++;
            }
            y = 0;
        }

        private void SetTimeCodeLabel()
        {
            string uppers = null;

            foreach (char c in TimeZone.CurrentTimeZone.StandardName)
            {
                if (char.IsUpper(c))
                {
                    uppers = uppers + c;
                }
            }
            // Were going through all uppercase letters in users timzeone. Then we save to string, basically making an tzone accronym.
            timezoneLabel.Text = timezoneLabel.Text + uppers;
            timezoneIsPDTPSTUserLabel.Text = timezoneIsPDTPSTUserLabel.Text + uppers;
        }

        private void sendFiltersToBack(object sender, EventArgs e)
        {
            filtersPanel.SendToBack();
            filtersPanel.BorderStyle = BorderStyle.None;
        }
        private void filtersToFront(object sender, EventArgs e)
        {
            if(filtersPanel.BorderStyle == BorderStyle.FixedSingle)
            {
                filtersPanel.SendToBack();
                filtersPanel.BorderStyle = BorderStyle.None;
            }
            else if(filtersPanel.BorderStyle == BorderStyle.None)
            {
                filtersPanel.BringToFront();
                filtersPanel.BorderStyle = BorderStyle.FixedSingle;
            }            
        }

        private void panelCheckBoxesHandler(object sender, EventArgs e)
        {
            int checkedTotal = 0;

            if(idCBox.Checked == true)
            {
                checkedTotal++;
                idUpDown.Enabled = true;
            }
            else if (idCBox.Checked == false)
            {
                checkedTotal--;
                idUpDown.Enabled = false;
            }

            if (nameCBox.Checked == true)
            {
                checkedTotal++;
                nameTextBox.Enabled = true;
            }
            else if (nameCBox.Checked == false)
            {
                checkedTotal--;
                nameTextBox.Text = "";
                nameTextBox.Enabled = false;
            }

            if (mrchntCBox.Checked == true)
            {
                checkedTotal++;
                mrchntTextBox.Enabled = true;
            }
            else if (mrchntCBox.Checked == false)
            {
                checkedTotal--;
                mrchntTextBox.Text = "";
                mrchntTextBox.Enabled = false;
            }
            panelCheckBoxesLogic();
            // This method could probably be cleaner but.. switch logic always requires code :(
        }

        private void panelCheckBoxesLogic()
        {
            string[] tableName = null;
            if (tableSelectionCBox.Text == "Products")
            {
                // Used for swapping, and creation of appropriate column names.
                tableName = new string[] { "product_id", "Prod ID", "product_name", "Product Name",
                "price", "Price", "merchant", "Vndr", "ll_products"};
            }
            else if (tableSelectionCBox.Text == "Customers")
            {
                // Used for swapping, and creation of appropriate column names.
                tableName = new string[] { "customer_id", "Cust ID", "name", "Customer Name",
                "address", "Address", "phone", "Phone Number", "ll_customers"};
            }
            string query = "";
            if (idCBox.Checked == false && nameCBox.Checked == false && mrchntCBox.Checked == false)
            {
                query = $"SELECT {tableName[0]} \"{tableName[1]}\", {tableName[2]} \"{tableName[3]}\", {tableName[4]} \"{tableName[5]}\", {tableName[6]} \"{tableName[7]}\" FROM {tableName[8]} ORDER BY 1;";
            }
            else if (idCBox.Checked == true && nameCBox.Checked == false && mrchntCBox.Checked == false)
            {
                query = $"SELECT {tableName[0]} \"{tableName[1]}\", {tableName[2]} \"{tableName[3]}\", {tableName[4]} \"{tableName[5]}\", {tableName[6]} \"{tableName[7]}\" FROM {tableName[8]} " +
                      $"WHERE {tableName[0]} = {idUpDown.Value} ORDER BY 1;";
            }
            else if (idCBox.Checked == true && nameCBox.Checked == false && mrchntCBox.Checked == true)
            {
                query = $"SELECT {tableName[0]} \"{tableName[1]}\", {tableName[2]} \"{tableName[3]}\", {tableName[4]} \"{tableName[5]}\", {tableName[6]} \"{tableName[7]}\" FROM {tableName[8]} " +
                      $"WHERE {tableName[0]} = {idUpDown.Value} AND {tableName[4]} LIKE '%{mrchntTextBox.Text}%' ORDER BY 1;";
            }
            else if (idCBox.Checked == true && nameCBox.Checked == true && mrchntCBox.Checked == false)
            {
                query = $"SELECT {tableName[0]} \"{tableName[1]}\", {tableName[2]} \"{tableName[3]}\", {tableName[4]} \"{tableName[5]}\", {tableName[6]} \"{tableName[7]}\" FROM {tableName[8]} " +
                      $"WHERE {tableName[0]} = {idUpDown.Value} AND {tableName[2]} LIKE '%{nameTextBox.Text}%' ORDER BY 1;";
            }
            else if (idCBox.Checked == true && nameCBox.Checked == true && mrchntCBox.Checked == true)
            {
                query = $"SELECT {tableName[0]} \"{tableName[1]}\", {tableName[2]} \"{tableName[3]}\", {tableName[4]} \"{tableName[5]}\", {tableName[6]} \"{tableName[7]}\" FROM {tableName[8]} " +
                      $"WHERE {tableName[0]} = {idUpDown.Value} AND {tableName[2]} LIKE '%{nameTextBox.Text}%' AND {tableName[4]} LIKE '%{mrchntTextBox.Text}%' ORDER BY 1;";
            }
            else if (idCBox.Checked == false && nameCBox.Checked == true && mrchntCBox.Checked == true)
            {
                query = $"SELECT {tableName[0]} \"{tableName[1]}\", {tableName[2]} \"{tableName[3]}\", {tableName[4]} \"{tableName[5]}\", {tableName[6]} \"{tableName[7]}\" FROM {tableName[8]} " +
                      $"WHERE {tableName[2]} LIKE '%{nameTextBox.Text}%' AND {tableName[4]} LIKE '%{mrchntTextBox.Text}%' ORDER BY 1;";
            }
            else if (idCBox.Checked == false && nameCBox.Checked == false && mrchntCBox.Checked == false)
            {
                query = $"SELECT {tableName[0]} \"{tableName[1]}\", {tableName[2]} \"{tableName[3]}\", {tableName[4]} \"{tableName[5]}\", {tableName[6]} \"{tableName[7]}\" FROM {tableName[8]} ORDER BY 1;";
            }
            else if (idCBox.Checked == false && nameCBox.Checked == true && mrchntCBox.Checked == false)
            {
                query = $"SELECT {tableName[0]} \"{tableName[1]}\", {tableName[2]} \"{tableName[3]}\", {tableName[4]} \"{tableName[5]}\", {tableName[6]} \"{tableName[7]}\" FROM {tableName[8]} " +
                      $"WHERE {tableName[2]} LIKE '%{nameTextBox.Text}%' ORDER BY 1;";
            }
            else if (idCBox.Checked == false && nameCBox.Checked == false && mrchntCBox.Checked == true)
            {
                query = $"SELECT {tableName[0]} \"{tableName[1]}\", {tableName[2]} \"{tableName[3]}\", {tableName[4]} \"{tableName[5]}\", {tableName[6]} \"{tableName[7]}\" FROM {tableName[8]} " +
                      $"WHERE {tableName[4]} LIKE '%{mrchntTextBox.Text}%' ORDER BY 1;";
            } // If I'm being honest, this method disgusts me and is only so poor because I wasnt
            // competent w/ LINQ when writing this. Tell you what, it works though.
            // TODO: Refactor this method, using linq. Probably would halve the lines of code.
            // --Right now, it's essentially a huge query builder.--

            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            else { } // Make sure the conn is available.
            DataTable data = new DataTable();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            data.Load(reader);
            mainDGV.DataSource = data; // set our DGV's source to our new conditionally selected data.
        }

        private void mainDGV_Click(object sender, EventArgs e)
        {
            if (mainDGV.DataSource == null)
            {
                MessageBox.Show("Please select a table with the drop down menu.");
            }
        }
    }
}
