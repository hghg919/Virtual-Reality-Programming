using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DateCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 소스 코드 추가
            DateTime today = DateTime.Today;
            DateTime selectdDay = dateTimePicker1.Value;

            textBox1.Text = today.Subtract(selectdDay).
                TotalDays.ToString("0");    
        }
    }
}