using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Register reg = null;
        Login log = null;

        public Form1(Register regObj, Login logObj)
        {
            reg = regObj;
            log = logObj;
            InitializeComponent();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            if(log == null || log.IsDisposed)
            {
                log = new Login(this, reg);
            }
            log.Show();
            this.Hide();
        }

        private void createBtn_Click(object sender, EventArgs e)
        {
            if (reg == null || reg.IsDisposed)
            {
                reg = new Register();
            }
            reg.Show();
            this.Hide();
        }
    }
}
