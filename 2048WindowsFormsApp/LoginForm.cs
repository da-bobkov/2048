﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary;


namespace _2048WindowsFormsApp
{
    public partial class LoginForm : Form
    {
        
        public LoginForm()
        {
            InitializeComponent();
            chooseSizeBox.SelectedItem = "4x4";
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

    }
}
