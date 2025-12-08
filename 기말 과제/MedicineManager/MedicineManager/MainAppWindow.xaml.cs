using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
// System.Globalization과 겹치지 않게 주의

namespace MedicineManager  // ★ 여기를 프로젝트 이름과 똑같이 맞췄습니다.
{
    public partial class MainAppWindow : Window
    {
        // 가짜 데이터
        public static Dictionary<DateTime, string> DangerDates = new Dictionary<DateTime, string>();

        public MainAppWindow()
        {
            InitializeComponent();
            LoadMockData();
        }

        private void LoadMockData()
        {
            if (DangerDates.Count == 0)
            {
                DangerDates.Add(new DateTime(2025, 12, 10), "아스피린 (유통기한 만료)");
                DangerDates.Add(new DateTime(2025, 12, 15), "타이레놀 (폐기 필요)");
                DangerDates.Add(DateTime.Today, "비타민C (오늘 만료!)");
            }
        }

        // 이벤트 핸들러
        private void Calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            // ★ 에러 수정: 'Calendar'가 뭔지 헷갈려해서 명확하게 지정했습니다.
            System.Windows.Controls.Calendar calendar = sender as System.Windows.Controls.Calendar;

            if (calendar.SelectedDate.HasValue == false) return;

            DateTime selectedDate = calendar.SelectedDate.Value;

            if (DangerDates.ContainsKey(selectedDate))
            {
                string medicineName = DangerDates[selectedDate];
                MessageBox.Show($"⚠️ 위험 경고!\n\n날짜: {selectedDate.ToShortDateString()}\n내용: {medicineName}",
                                "약품 폐기 알림", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}