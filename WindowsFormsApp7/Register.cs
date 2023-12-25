using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp7
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        Login log = null;
        Form1 home = null;

        private void labelLogin_Click(object sender, EventArgs e)
        {
            if (log == null || log.IsDisposed)
            {
                log = new Login();
            }
            log.Show();
            this.Hide();
        }

        private void registerBtn_Click(object sender, EventArgs e)
        {
            if (isValidatation())
            {
                if (home == null || home.IsDisposed)
                {
                    home = new Form1(this, log);
                }
                MessageBox.Show("Successfully Registered!");
                home.Show();
                this.Hide();
            }
        }

        public bool isValidatation()
        {
            Regex checkAge = new Regex("^[0-9]{1,2}$");
            Regex checkName = new Regex("^[a-zA-z ]+$");
            
            errorProvider.Clear();

            //name
            if(!checkName.IsMatch(name.Text) || string.IsNullOrEmpty(name.Text.Trim()))
            {
                errorProvider.SetError(name,"Invalid Name");
                return false;
            }
            //name

            //username
            if (string.IsNullOrEmpty(username.Text.Trim()))
            {
                errorProvider.SetError(username, "Invalid User Name");
                MessageBox.Show("User Name Not Available");
                return false;
            }
            //username

            //password
            if (string.IsNullOrEmpty(password.Text))
            {
                errorProvider.SetError(password, "Set Password!!");
                return false;
            }
            
            if (getPassword() != getConfirmPassword() || string.IsNullOrEmpty(getPassword()))
            {
                errorProvider.SetError(confirmPassword, "Password Not Match");
                return false;
            }
            //password

            //designation
            if (designation.SelectedItem == null)
            {
                errorProvider.SetError(designation, "Select Designation");
                return false;
            }
            //designation

            //email
            if (!email.Text.Contains("@") || !email.Text.Contains(".") || string.IsNullOrEmpty(email.Text))
            {
                errorProvider.SetError(email, "format 'paulcruise12@example.com'");
                return false;
            }
            //email

            //age
            if (!checkAge.IsMatch(age.Text) || age.Text == "0" || age.Text == "00" || string.IsNullOrEmpty(age.Text))
            {
                errorProvider.SetError(age, "Age must have maximum 2 digits only");
                return false;
            }
            //age

            return true;
        }

        public string getName()
        {
            return this.name.Text;
        }

        public string getUserName()
        {
            return username.Text;
        }

        public string getPassword()
        {
            return password.Text;
        }

        public string getConfirmPassword()
        {
            return confirmPassword.Text;
        }

        public string getEmail()
        {
            return email.Text;
        }

        public string getAge()
        {
            return age.Text;
        }

        public string getDesignation()
        {
            return designation.SelectedItem.ToString();
        }
    }
}
