using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using MedicineManager.Pages; // Pages 폴더 연결

namespace MedicineManager
{
    public partial class MainMainWindow : Window
    {
        // 색상 정의 (파란색: 선택됨 / 회색: 선택 안 됨)
        private readonly Brush ActiveColor = new SolidColorBrush(Color.FromRgb(64, 152, 255)); // #4098FF
        private readonly Brush InactiveColor = new SolidColorBrush(Color.FromRgb(85, 85, 85)); // #555555

        public MainMainWindow()
        {
            InitializeComponent();

            // 1. 앱 켜지면 '홈' 화면부터 시작
            NavigateTo("Home");
        }

        // 통합 버튼 클릭 이벤트 핸들러
        private void NavButton_Click(object sender, RoutedEventArgs e)
        {
            // 클릭된 버튼의 Tag 값(Register, Home 등)을 가져옴
            if (sender is Button btn && btn.Tag is string tag)
            {
                NavigateTo(tag);
            }
        }

        // 페이지 이동 및 UI 갱신 로직
        private void NavigateTo(string pageTag)
        {
            // 1. 모든 메뉴의 색상을 '회색(Inactive)'으로 초기화
            ResetNavUI();

            // 2. 선택된 페이지로 이동 & 해당 버튼 색상 변경
            switch (pageTag)
            {
                case "Register":
                    MainFrame.Navigate(new RegisterPage());
                    SetTextActive(TxtRegister);
                    break;

                case "Calendar":
                    MainFrame.Navigate(new CalendarPage());
                    SetTextActive(TxtCalendar);
                    break;

                case "Home":
                    MainFrame.Navigate(new HomePage());
                    IconHome.Fill = ActiveColor; // 아이콘은 Fill 속성 변경
                    break;

                case "Chart":
                    MainFrame.Navigate(new ChartPage());
                    SetTextActive(TxtChart);
                    break;

                case "My":
                    MainFrame.Navigate(new MyPage());
                    SetTextActive(TxtMy);
                    break;
            }
        }

        // [UI 헬퍼] 모든 버튼을 기본 상태(회색, 보통 굵기)로 되돌림
        private void ResetNavUI()
        {
            // 텍스트들
            TxtRegister.Foreground = InactiveColor;
            TxtRegister.FontWeight = FontWeights.Normal;

            TxtCalendar.Foreground = InactiveColor;
            TxtCalendar.FontWeight = FontWeights.Normal;

            TxtChart.Foreground = InactiveColor;
            TxtChart.FontWeight = FontWeights.Normal;

            TxtMy.Foreground = InactiveColor;
            TxtMy.FontWeight = FontWeights.Normal;

            // 아이콘
            IconHome.Fill = InactiveColor;
        }

        // [UI 헬퍼] 특정 텍스트블록을 활성 상태(파란색, 굵게)로 변경
        private void SetTextActive(TextBlock txt)
        {
            txt.Foreground = ActiveColor;
            txt.FontWeight = FontWeights.Bold;
        }
    }
}