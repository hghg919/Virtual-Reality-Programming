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

namespace WPF_Registration
{
    /// <summary>
    /// MembersOnly.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MembersOnly : Window
    {
        public MembersOnly()
        {
            InitializeComponent();
        }

        private void btnMainGo_Click(
            object sender, RoutedEventArgs e)
        {
            // 소스 코드 추가
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void btnClose_Click_1(
            object sender, RoutedEventArgs e)
        {
            // 소스 코드 추가
            this.Close();
        }

    }
}