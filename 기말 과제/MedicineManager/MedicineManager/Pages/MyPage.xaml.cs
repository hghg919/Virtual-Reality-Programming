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
using MedicineManager.Models;  // Medicine 클래스를 쓰기 위해 필요
using MedicineManager.Windows; // 팝업창들을 쓰기 위해 필요

namespace MedicineManager.Pages
{
    /// <summary>
    /// MyPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MyPage : Page
    {
        public MyPage()
        {
            InitializeComponent();
        }
    }
}
