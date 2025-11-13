using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RadioButtonEvent
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string result = "";
            if (radioButton1.Checked)
                result += "학과 : 소프트웨어학과\n";
            else if (radioButton2.Checked)
                result += "학과 : 행정학과\n";
            else if (radioButton3.Checked)
                result +="학과 : 빅데이터분석학과\n";

            if (radioButton4.Checked)
                result += "성별 : 남성";
            else if (radioButton5.Checked)
                result += "성별 : 여성";

            MessageBox.Show(result, "학과와 성별",
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);

        }
    }
}
