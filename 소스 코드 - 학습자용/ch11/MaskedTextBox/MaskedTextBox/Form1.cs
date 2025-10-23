using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaskedTextBox
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 소스 코드 추가
            string str;

            str = "등록일 : " + maskedTextBox1.Text + "\n";
            str += "휴대폰번호 : " + maskedTextBox2.Text + "\n";
            str += "이메일주소 : " + textBox1.Text;

            DialogResult result = MessageBox.Show(str, "아이콘 표시",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Information);
        }
    }
}