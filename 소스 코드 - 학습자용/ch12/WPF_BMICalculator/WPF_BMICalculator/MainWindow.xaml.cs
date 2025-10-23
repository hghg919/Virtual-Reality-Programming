using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_BMICalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            // 소스 코드 추가
            if(textBox.Text == "" || textBox1.Text == "")
            {
                MessageBoxResult res = MessageBox.Show(
                    "키와 체중을 입력하세요!",
                    "경고",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning);
                
                return;
            }
            
            double h = Convert.ToDouble(textBox.Text) / 100.0;
            double w = Double.Parse(textBox1.Text);
            double bmi = w / (h * h);
            textBox2.Text = string.Format("{0:F2}", bmi);

            if (bmi > 35)
                textBox3.Text = "3단계 비만";
            else if (bmi < 35 && bmi >= 30)
                textBox3.Text = "2단계 비만";
            else if (bmi < 30 && bmi >= 25)
                textBox3.Text = "1단계 비만";
            else if (bmi < 25 && bmi >= 23)
                textBox3.Text = "비만 전 단계";
            else
                textBox3.Text = "정상 체중";
        }
    }
}