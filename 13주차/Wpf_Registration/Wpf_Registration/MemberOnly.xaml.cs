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

namespace Wpf_Registration
{
    /// <summary>
    /// MemberOnly.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MemberOnly : Window
    {
        public MemberOnly()
        {
            InitializeComponent();
        }

        private void btnMainGo_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void btnClsoe_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
