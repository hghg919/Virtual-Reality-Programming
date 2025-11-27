using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheckedListBoxEvent
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            checkedListBox1.Items.Add("심리학");
            checkedListBox1.Items.Add("경제학");
            checkedListBox1.Items.Add("행정학");
            checkedListBox1.Items.Add("컴퓨터학");
            checkedListBox1.Items.Add("법학");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach(var dept in checkedListBox1.CheckedItems)
                listBox1.Items.Add(dept);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (var dept in checkedListBox1.Items)
                listBox1.Items.Add(dept);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<string> lstRemove = new List<string>();

            foreach (string dept in checkedListBox1.SelectedItems)
                lstRemove.Add(dept);

            foreach (string dept in lstRemove)
                listBox1.Items.Remove(dept);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }
    }
}
