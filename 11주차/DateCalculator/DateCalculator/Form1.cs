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

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime today = DateTime.Today;
            DateTime selectDay = dateTimePicker1.Value;

            textBox1.Text = today.Subtract(selectDay).TotalDays.ToString("0");
        }
    }
}
