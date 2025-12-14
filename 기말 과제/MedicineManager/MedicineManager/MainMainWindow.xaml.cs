using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using MedicineManager.Models;
using MedicineManager.Pages;

namespace MedicineManager
{
    public partial class MainMainWindow : Window
    {
        private readonly Brush ActiveColor = new SolidColorBrush(Color.FromRgb(64, 152, 255));
        private readonly Brush InactiveColor = new SolidColorBrush(Color.FromRgb(85, 85, 85));

        public MainMainWindow()
        {
            InitializeComponent();

            // ★ 핵심: 프로그램 시작 시 DB에서 데이터 불러오기
            LoadDataFromDB();

            // 처음엔 홈 화면
            NavigateTo("Home");
        }

        private void LoadDataFromDB()
        {
            var currentUser = DataManager.Instance.CurrentUser;
            if (currentUser == null) return;

            // 1. 메모리에 있던 가짜 데이터 비우기
            DataManager.Instance.Medicines.Clear();

            // 2. DB에서 진짜 데이터 가져오기
            List<Medicine> myMeds = DBHelper.GetMedicines(currentUser.Id);

            // 3. 메모리(DataManager)에 채워넣기 -> 모든 페이지 자동 반영
            foreach (var m in myMeds)
            {
                DataManager.Instance.Medicines.Add(m);
            }
        }

        private void NavButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.Tag is string tag)
            {
                NavigateTo(tag);
            }
        }

        private void NavigateTo(string pageTag)
        {
            ResetNavUI();

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
                    IconHome.Fill = ActiveColor;
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

        private void ResetNavUI()
        {
            TxtRegister.Foreground = InactiveColor;
            TxtRegister.FontWeight = FontWeights.Normal;
            TxtCalendar.Foreground = InactiveColor;
            TxtCalendar.FontWeight = FontWeights.Normal;
            TxtChart.Foreground = InactiveColor;
            TxtChart.FontWeight = FontWeights.Normal;
            TxtMy.Foreground = InactiveColor;
            TxtMy.FontWeight = FontWeights.Normal;
            IconHome.Fill = InactiveColor;
        }

        private void SetTextActive(TextBlock txt)
        {
            txt.Foreground = ActiveColor;
            txt.FontWeight = FontWeights.Bold;
        }
    }
}