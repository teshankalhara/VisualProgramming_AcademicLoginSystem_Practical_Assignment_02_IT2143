﻿using System;
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
    public partial class Teacher : Form
    {
        public Teacher()
        {
            InitializeComponent();
        }

        Form1 home = null;

        private void label2_Click(object sender, EventArgs e)
        {
            if (home == null || home.IsDisposed)
            {
                home = new Form1();
            }
            home.Show();
            this.Hide();
        }
    }
}
