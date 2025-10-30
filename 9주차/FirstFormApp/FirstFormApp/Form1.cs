using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FirstFormApp
{
    public partial class Form1 : Form
    {
        private bool flag;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (flag == false)
            {
                label1.Text = "첫 방문을 환영합니다. 이제 나가세요! 아 집에 가고 싶다.";
                label2.Text = "첫 방문을 환영합니다. 이제 나가세요! 아 집에 가고 싶다.";
                flag = true;
            } else {
                label1.Text = "";
                label2.Text = "";
                flag = false;
            }
            


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = "";
            label2.Text = "";
        }
    }
}
