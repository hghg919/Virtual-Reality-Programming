﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormsTow
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // 소스 코드 추가
            this.ClientSize = new Size(800, 500);
            Form f2 = new Form2();
            this.AddOwnedForm(f2);
            f2.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
