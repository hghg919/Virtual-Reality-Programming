using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MessageBoxShow
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 소스 코드 추가
            MessageBox.Show("가장 단순한 메시지박스 입니다", "기본");

            MessageBox.Show("약속시간이 늦었습니다. ", "일정",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

            MessageBox.Show("느낌표와 알림을 보여줍니다.", "안내",
               MessageBoxButtons.OK,
               MessageBoxIcon.Exclamation);

            DialogResult result1 = MessageBox.Show(
                "2개의 버튼을 보여줍니다.",
                "버튼 표시", MessageBoxButtons.YesNo);

            DialogResult result2 = MessageBox.Show(
                "3개의 버튼과 물음표 아이콘을 보여줍니다.",
                "아이콘 표시",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question);

            DialogResult result3 = MessageBox.Show(
                "기본 버튼을 두 번째 버튼으로\n지정한 메시지박스입니다.",
                "기본 버튼",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);

            string msg = string.Format(
                "2개이상의 메시지박스에서 당신이 선택한 버튼의\n" +
                "결과는 다음과 같습니다 : {0} {1} {2}",
                result1.ToString(),
                result2.ToString(),
                result3.ToString());
            MessageBox.Show(msg, "선택 결과",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Information);
        }
    }
}