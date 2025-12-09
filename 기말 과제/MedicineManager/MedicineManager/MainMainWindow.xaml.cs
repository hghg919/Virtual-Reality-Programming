using System.Windows;
using MedicineManager.Pages;

namespace MedicineManager
{
    public partial class MainMainWindow : Window
    {
        public MainMainWindow()
        {
            InitializeComponent();

            // 앱이 켜지면 처음에 '홈 페이지'를 보여준다.
            MainFrame.Navigate(new HomePage()); // 이제 빨간줄이 사라집니다!
        }

        // 등록 버튼
        private void BtnRegister_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new RegisterPage());
        }

        // 달력 버튼
        private void BtnCalendar_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new CalendarPage());
        }

        // 홈 버튼
        private void BtnHome_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new HomePage());
        }

        // 차트 버튼
        private void BtnChart_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ChartPage());
        }

        // My 버튼
        private void BtnMy_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new MyPage());
        }
    }
}