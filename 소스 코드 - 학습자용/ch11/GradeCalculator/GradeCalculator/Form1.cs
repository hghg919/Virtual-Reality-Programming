using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GradeCalculator
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
            if (textBox1.Text == "" || textBox2.Text == "" ||
                textBox3.Text == "")
            {
                MessageBox.Show("누락된 점수 발생!!\n" + 
                    "프로그램을 다시 시작합니다.", "경고",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                Application.Restart();  // 프로그램 재시작
                // Close();  프로그램을 종료할 때 선언
            }

            double d1, d2, d3, avg, sum;
            d1 = Convert.ToDouble(textBox1.Text);
            d2 = Convert.ToDouble(textBox2.Text);
            d3 = Convert.ToDouble(textBox3.Text);

            if ((d1 > 100 || d1 < 0) || (d2 > 100 || d2 < 0) ||
                (d3 > 100 || d3 < 0))
            {
                MessageBox.Show("점수 입력 과정에서 오류 발생!!\n" +
                    "점수를 다시 입력하세요.", "입력 오류",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Error);

                textBox1.Text = String.Empty;
                textBox2.Text = String.Empty;
                textBox3.Text = String.Empty;
                textBox4.Text = String.Empty;
                textBox5.Text = String.Empty;

                label6.Text = String.Empty;
            }
            else
            {
                sum = d1 + d2 + d3;
                avg = sum / 3;

                textBox4.Text = sum.ToString();
                textBox5.Text = avg.ToString("0.0");

                string grade = "";
                if (avg >= 90)
                    grade = "A";
                else if (avg >= 80)
                    grade = "B";
                else if (avg >= 70)
                    grade = "C";
                else if (avg >= 60)
                    grade = "D";
                else
                    grade = "F";

                label6.Text = grade + "학점";

                string str = "";
                str += "최종 성적은 다음과 같습니다." + "\n";
                str += "▶ 총점 : " + sum + "\n";
                str += "▶ 평균 : " + avg + "\n";
                str += "▶ 등급 : " + grade + "학점";

                MessageBox.Show(str, "성적 결과",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // 소스 코드 추가 : 텍스트박스와 레이블의 문자열을 모두 비움
            textBox1.Text = String.Empty;
            textBox2.Text = String.Empty;
            textBox3.Text = String.Empty;
            textBox4.Text = String.Empty;
            textBox5.Text = String.Empty;
            label6.Text = String.Empty;
        }

    }
}