using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Globalization;
using System.Threading;
using System.IO;

namespace PortalMySQLC969
{ 
/* TODO:
 * Make a dictionary extra public class to display quotes
 * if the user goes new > edit it doesnt populate. Minor bug.
 * Consider making a counter for how many times a user incorrectly fails a login. Log something then check for it? This is extra credit.
 */
    public partial class LoginForm : Form
    {
        public LoginForm()
        { 
            if(Thread.CurrentThread.CurrentCulture.ToString().Contains("de"))
            {
                Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("de");
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("de");
                // Just so ALL derivitives of german are covered.
            }
            InitializeComponent();
            userLabel.Text = GlobalStrings.Username;
            passLabel.Text = GlobalStrings.Password;
            quoteHeader.Text = GlobalStrings.QuoteOTD;
            QuoteSetter(); // Generates quotes.

        }

        private void QuoteSetter()
        {
            Quotes quotes = new Quotes();
            Random rand = new Random();
            quoteLabel.Text = quotes.stringArray[rand.Next(0,9)]; // Use a pseudo-random quote from Quotes.cs
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string u = userTextBox.Text;
            string p = passwordTextBox.Text;
            string earliestDate;
            int hours;
            double minutes;
            string myConnectionString = ConfigurationManager.ConnectionStrings["MySQLdB"].ConnectionString; // Make a string from App.config
            MySqlConnection conn = new MySqlConnection(myConnectionString);
            MySqlDataReader reader;

            conn.Open();
            MySqlCommand cmd = new MySqlCommand("select min(start) from appointment", conn);
            reader = cmd.ExecuteReader();
            reader.Read();
            earliestDate = reader[0].ToString();
            hours = (int)(DateTime.Parse(earliestDate).Subtract(DateTime.Now).TotalHours); // Cast the double
            minutes = (int)(hours - (DateTime.Parse(earliestDate).Subtract(DateTime.Now).TotalHours) * .6);
            conn.Close(); reader.Close(); // Don't need to close reader, but good programming.


            cmd = conn.CreateCommand();
            // This is how we generate our "does user exist and is userN/password correct" code.
            cmd.CommandText = $"select userName, password from user where userName = \"{u}\" and password = \"{p}\";";
            try
            {
                conn.Open();
            }
            catch
            {
                MessageBox.Show(GlobalStrings.ConnectionClosed); // Using localization to generate incorrect u/s in english and german.
            }
            reader = cmd.ExecuteReader(); // Effectively querrying our DB.
                                          // OVERCOMPLICATED series of if statements. They're seriously beau·ti·ful though, don't hurt them.
                                          //
            if (userTextBox.Text == "" || passwordTextBox.Text == "") // Check if textBox' are empty.
            {
                if (userTextBox.Text == "" && passwordTextBox.Text != "")
                {
                    IncorrectAnything(u);
                    MessageBox.Show(GlobalStrings.EmptyUser);
                }
                else if (userTextBox.Text != "" && passwordTextBox.Text == "")
                {
                    IncorrectAnything(u);
                    MessageBox.Show(GlobalStrings.EmptyPass);
                }
                else
                {
                    IncorrectAnything(u);
                    MessageBox.Show(GlobalStrings.EmptyBoth);
                }
            }
            else if (reader.HasRows == false)
            {
                IncorrectAnything(u);
                MessageBox.Show(GlobalStrings.IncorrectUser);
            }

            while (reader.Read()) // While there is something left to read (a row I believe) this continues reading, execing once per row. If it fetches something (a row), it should read.
            {
                File.AppendAllText("logins.txt", u + " logged in at " + DateTime.Now.ToString() + " " + TimeZoneInfo.Local.Id.ToString() + ";" + Environment.NewLine);
                //MessageBox.Show(GlobalStrings.WelcomeBack + $" {u}! \n The next scheduled appointment\n is at: {earliestDate},\n which is {hours} hours \n and {minutes} minutes from now. \n\n\n THIS IS RUBRIC H");
                this.Hide();
                MainForm mf = new MainForm();
                mf.Closed += (s, args) => this.Close(); // This lambda expression is an explicit event set to close 'this' form (which was hidden) when mf is closed. America is still the best, vote 11/06/2018
                mf.Show();
            }
            conn.Close();
        }
        private void IncorrectAnything(string username)
        {
            File.AppendAllText("logins.txt", username + " failed to login at " + DateTime.Now.ToString() + " " + TimeZoneInfo.Local.Id.ToString() + ";" + Environment.NewLine);
        }
    }
}