using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheckedBoxEvent
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
            string checkStates = "";
            CheckBox[] cBox
                = { checkBox1, checkBox2, checkBox3 };

            foreach (var item in cBox)
            {
                checkStates += string.Format("{0} : {1}\n",
                   item.Text, item.Checked);
            }
            MessageBox.Show(checkStates, "항목 선택");

            string selectcBox = string.Format("선호하는 분야 : ");
            foreach (var item in cBox)
            {
                if (item.Checked == true)
                    selectcBox += item.Text + " ";
            }
            MessageBox.Show(selectcBox, "관심 분야",
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
        }
    }
}
