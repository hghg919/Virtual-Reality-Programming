using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlagEvent
{
    public partial class Form1 : Form
    {
        // 소스 코드 추가 
        private bool flag;     // 기본값은 false

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 소스 코드 추가
            if (flag == false)
            {
                label1.Text = "오늘은 어제 죽어간 이가 그토록\n" +
                    "기다리던 내일이다.";
                flag = true;
            }
            else
            {
                label1.Text = "";
                flag = false;
            }
        }
    }
}
