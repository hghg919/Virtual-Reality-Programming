using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormsTow
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

            // 소스 코드 추가
            this.ClientSize = new Size(500, 300);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // 소스 코드 추가
            CenterToParent();
        }
    }
}