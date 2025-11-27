using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComboBoxEvent
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            if(cb.SelectedIndex > -1)
            {
                string msg = "당신이 선택한 과목은 다음과 같습니다.\n";
                msg += "▶ 선택한 과목 : ";
                msg += cb.SelectedItem.ToString();
                 
                MessageBox.Show(msg, "선택결과",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information);
            }
        }
    }
}
