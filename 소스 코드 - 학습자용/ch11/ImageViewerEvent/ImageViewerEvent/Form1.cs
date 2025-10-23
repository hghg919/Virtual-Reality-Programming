using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageViewerEvent
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // 소스 코드 추가
            this.Text = "이미지 뷰어";
            pictureBox1.BackColor = Color.White;
        }

        private void 파일열기ToolStripMenuItem_Click(
            object sender, EventArgs e)
        {
            // 소스 코드 추가
            openFileDialog1.Filter = "이미지 파일(.jpg)|" +
                "*.jpg|모든 파일(*.*)|*.*";
            openFileDialog1.Title = "이미지 열기";
            openFileDialog1.FileName = "";
            openFileDialog1.ShowDialog();

            if(openFileDialog1.FileName != "")
            {
                pictureBox1.Image = new Bitmap(
                    openFileDialog1.FileName);
            }
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void normalToolStripMenuItem_Click(
            object sender, EventArgs e)
        {
            // 소스 코드 추가
            pictureBox1.SizeMode=PictureBoxSizeMode.Normal;
        }

        private void stretchImageToolStripMenuItem_Click(
            object sender, EventArgs e)
        {
            // 소스 코드 추가
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void autoSizeToolStripMenuItem_Click(
            object sender, EventArgs e)
        {
            // 소스 코드 추가
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
        }

        private void centerImageToolStripMenuItem_Click(
            object sender, EventArgs e)
        {
            // 소스 코드 추가
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
        }

        private void zoomToolStripMenuItem_Click(
            object sender, EventArgs e)
        {
            // 소스 코드 추가
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        }

        // 소스 코드 추가 : 폼 크기 변화를 연동하기 위한 메서드
        protected override void OnPrint(PaintEventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void 프로그램종료ToolStripMenuItem_Click(
            object sender, EventArgs e)
        {
            // 소스 코드 추가
            Close();
        }
    }
}