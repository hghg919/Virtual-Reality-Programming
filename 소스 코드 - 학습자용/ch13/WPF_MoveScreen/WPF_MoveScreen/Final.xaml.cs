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
using System.Windows.Shapes;

namespace WPF_MoveScreen
{
    /// <summary>
    /// Final.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Final : Window
    {
        public Final()
        {
            InitializeComponent();
        }

        private void btnBeforeGo_Click(
            object sender, RoutedEventArgs e)
        {
            // 소스 코드 추가
            Welcome welcome = new Welcome();
            welcome.Show();
            this.Close();
        }

        private void btnMainGo_Click(
            object sender, RoutedEventArgs e)
        {
            // 소스 코드 추가
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }
    }
}