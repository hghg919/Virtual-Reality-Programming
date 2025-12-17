using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Collections.ObjectModel; // ObservableCollection 사용
using System.Windows.Media;           // 색상(Brushes) 사용
using System.Windows.Controls.Primitives; // CalendarDayButton 탐색용
using MedicineManager.Models;         // DataManager 접근용

namespace MedicineManager.Pages
{
    public partial class CalendarPage : Page
    {
        // 싱글톤 인스턴스를 통해 데이터에 접근
        private ObservableCollection<Medicine> allMedicines = DataManager.Instance.Medicines;

        public CalendarPage()
        {
            InitializeComponent();

            // 페이지 시작 시 오늘 날짜 기준으로 리스트 초기화
            UpdateMonthlyList(DateTime.Today);
        }

        // =========================================================
        // 이벤트 1: 달력 날짜 클릭 시 (팝업 + 리스트 갱신)
        // =========================================================
        private void DetailCalendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DetailCalendar.SelectedDate.HasValue)
            {
                DateTime selectedDate = DetailCalendar.SelectedDate.Value;

                // 1. 해당 '일(Day)'에 만료되는 약 팝업
                ShowDailyPopup(selectedDate);

                // 2. 해당 '월(Month)'에 만료되는 약 리스트 갱신
                UpdateMonthlyList(selectedDate);
            }
        }

        // =========================================================
        // 이벤트 2: 달력 화면 갱신 시 (유통기한 날짜 색칠하기)
        // =========================================================
        private void DetailCalendar_LayoutUpdated(object sender, EventArgs e)
        {
            // 달력 내부의 날짜 버튼들을 모두 찾습니다.
            var dayButtons = FindVisualChildren<CalendarDayButton>(DetailCalendar);

            foreach (var dayButton in dayButtons)
            {
                if (dayButton.DataContext is DateTime dayDate)
                {
                    // 해당 날짜에 만료되는 약이 있는지 확인 (ExpiryDate 기준)
                    bool hasExpiry = allMedicines.Any(m => m.ExpiryDate.Date == dayDate.Date);

                    if (hasExpiry)
                    {
                        // 만료일이면 배경을 분홍색으로 변경
                        dayButton.Background = Brushes.Pink;
                    }
                    else
                    {
                        // 만료일이 아니고, 현재 선택된 날짜도 아니라면 배경을 투명하게 초기화
                        // (이렇게 안 하면 다른 달로 넘어갔을 때 색깔이 남을 수 있음)
                        if (DetailCalendar.SelectedDate != dayDate)
                        {
                            dayButton.Background = Brushes.Transparent;
                        }
                    }
                }
            }
        }

        // =========================================================
        // 기능 메서드: 일별 팝업
        // =========================================================
        private void ShowDailyPopup(DateTime date)
        {
            var dailyMeds = allMedicines
                            .Where(m => m.ExpiryDate.Date == date.Date)
                            .ToList();

            if (dailyMeds.Count > 0)
            {
                string msg = $"{date:yyyy-MM-dd} 만료 예정 약품:\n\n";
                foreach (var med in dailyMeds)
                {
                    msg += $"- {med.Name}\n";
                }
                MessageBox.Show(msg, "📅 유통기한 경고", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        // =========================================================
        // 기능 메서드: 월별 리스트 갱신
        // =========================================================
        private void UpdateMonthlyList(DateTime date)
        {
            // UI 초기화
            MonthExpiringListBox.Items.Clear();
            ListTitleText.Text = $"📋 {date.Month}월에 만료되는 약";

            // 해당 월의 약 찾기
            var monthlyMeds = allMedicines
                              .Where(m => m.ExpiryDate.Year == date.Year &&
                                          m.ExpiryDate.Month == date.Month)
                              .OrderBy(m => m.ExpiryDate)
                              .ToList();

            if (monthlyMeds.Count > 0)
            {
                foreach (var med in monthlyMeds)
                {
                    ListBoxItem item = new ListBoxItem();
                    item.Content = $"💊 {med.Name} ({med.ExpiryDate:yyyy-MM-dd})";
                    item.FontSize = 14;
                    item.Padding = new Thickness(10);
                    MonthExpiringListBox.Items.Add(item);
                }
            }
            else
            {
                ListBoxItem emptyItem = new ListBoxItem();
                emptyItem.Content = "이 달에는 만료되는 약이 없습니다.";
                emptyItem.Foreground = Brushes.Gray;
                emptyItem.Padding = new Thickness(10);
                MonthExpiringListBox.Items.Add(emptyItem);
            }
        }

        // =========================================================
        // 보조 메서드: 비주얼 트리에서 자식 컨트롤 찾기
        // =========================================================
        private static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }
    }
}