using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextBoxEvent
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("성명이 입력되지 않았습니다.", "경고",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            } else
            {
                label2.Text = textBox1.Text + "님을 환영합니다!";
            }
        }
    }
}
