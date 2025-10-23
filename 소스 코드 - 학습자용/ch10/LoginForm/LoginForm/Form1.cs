using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginForm
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
            if (textBox1.Text == "space" && textBox2.Text == "123456")
            {
                string msg = "성공적으로 로그인 되었습니다!";
                MessageBox.Show(msg, "로그인 성공");
            }
            else
            {
                string msg = "아이디 또는 패스워드를 확인하세요!";
                MessageBox.Show(msg, "로그인 실패",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
        }
    }
}