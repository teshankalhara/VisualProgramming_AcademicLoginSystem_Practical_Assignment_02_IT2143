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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;

namespace WindowsFormsApp7
{
    public partial class Login : Form
    {
        Form1 home = null;
        Register reg = null;
        Teacher teacher = null;
        LabAssistant labAssistant = null;

        string selectType;
        string userPassword;
        string userUName;

        public Login()
        {
            InitializeComponent();
        }

        public Login(Register regObj)
        {
            reg = regObj;
            InitializeComponent();
        }

        public Login(Form1 homeObj, Register regObj)
        {
            home = homeObj;
            reg = regObj;
            InitializeComponent();
            selectType = reg.getDesignation();
            userPassword = reg.getName();
            userUName = reg.getUserName();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            if (isValidatation())
            {
                if (selectType == "Teacher")
                {
                    if (teacher == null || teacher.IsDisposed)
                    {
                        teacher = new Teacher();
                    }
                    teacher.Show();
                    this.Hide();
                }
                if (selectType == "Lab-Assistant")
                {
                    if (labAssistant == null || labAssistant.IsDisposed)
                    {
                        labAssistant = new LabAssistant();
                    }
                    labAssistant.Show();
                    this.Hide();
                }
            }
        }

        public string getUserName()
        {
            return this.username.Text;
        }

        public string getPassword()
        {
            return this.password.Text;
        }

        private void labelReg_Click(object sender, EventArgs e)
        {
            if (register == null || register.IsDisposed)
            {
                reg = new Register();
            }
            reg.Show();
            this.Hide();
        }
        public bool isValidatation()
        {
            errorProviderLogin.Clear();

            if(!(userPassword == getPassword() && userUName == getUserName()))
            {
                errorProviderLogin.SetError(password, "Incorrect Password");
                MessageBox.Show("Check Password or Username");
                return false;
            }

            if (string.IsNullOrEmpty(username.Text.Trim()) && string.IsNullOrEmpty(password.Text))
            {
                errorProviderLogin.SetError(username, "Please Enter Username");
                errorProviderLogin.SetError(password, "Please Enter Password");
                MessageBox.Show("Enter Username and Password!!");
                return false;
            }

            if (string.IsNullOrEmpty(username.Text.Trim()))
            {
                errorProviderLogin.SetError(username, "Please Enter Username");
                return false;
            }

            if (string.IsNullOrEmpty(password.Text))
            {
                errorProviderLogin.SetError(password, "Check Password or Username");
                return false;
            }

            return true;
        }
    }
}
