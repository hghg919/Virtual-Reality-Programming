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

namespace MyFirstWPF
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

        private void label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(label.Foreground != Brushes.White)
            {
               label.Foreground = Brushes.White;
                this.Background = Brushes.Blue;
            }
            else
            {
                label.Foreground = SystemColors.WindowTextBrush;
                this.Background = SystemColors.WindowTextBrush;
            }
        }
    }
}