using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Collections.ObjectModel;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using MedicineManager.Models;

namespace MedicineManager.Pages
{
    public partial class HomePage : Page
    {
        private ObservableCollection<Medicine> allMedicines = DataManager.Instance.Medicines;

        public HomePage()
        {
            InitializeComponent();
            this.Loaded += (s, e) =>
            {
                DrawPieChart();
                DrawBarChart();

                // 달력 강제 갱신용
                DateTime displayDate = HomeCalendar.DisplayDate;
                HomeCalendar.DisplayDate = DateTime.MinValue;
                HomeCalendar.DisplayDate = displayDate;
            };
        }

        // ... (달력 관련 이벤트 코드들은 기존과 동일, 생략) ...
        // HomeCalendar_SelectedDatesChanged, HomeCalendar_LayoutUpdated 등 기존 코드 유지하세요.

        private void HomeCalendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            if (HomeCalendar.SelectedDate.HasValue)
            {
                NavigationService.Navigate(new Uri("/Pages/CalendarPage.xaml", UriKind.Relative));
                HomeCalendar.SelectedDate = null;
            }
        }

        private void HomeCalendar_LayoutUpdated(object sender, EventArgs e)
        {
            var dayButtons = FindVisualChildren<CalendarDayButton>(HomeCalendar);
            foreach (var dayButton in dayButtons)
            {
                if (dayButton.DataContext is DateTime dayDate)
                {
                    bool hasExpiry = allMedicines.Any(m => m.ExpiryDate.Date == dayDate.Date);
                    if (hasExpiry) dayButton.Background = Brushes.Pink;
                    else if (HomeCalendar.SelectedDate != dayDate) dayButton.Background = Brushes.Transparent;
                }
            }
        }


        // [기능] 원형 차트 (범례 추가됨)
        private void DrawPieChart()
        {
            PieChartCanvas.Children.Clear();
            PieLegendPanel.Children.Clear(); // 범례 초기화
            double total = allMedicines.Count;

            if (total == 0) return;

            var groups = allMedicines.GroupBy(m => m.Type)
                                     .Select(g => new { Type = g.Key, Count = g.Count() })
                                     .ToList();

            double currentAngle = 0;
            Color[] colors = { Colors.LightGreen, Colors.SkyBlue, Colors.Orange, Colors.Violet };
            int colorIndex = 0;

            foreach (var group in groups)
            {
                double percentage = group.Count / total;
                double sliceAngle = percentage * 360;
                Color sliceColor = colors[colorIndex % colors.Length];

                // 1. 차트 그리기
                Path slice = CreatePieSlice(50, 50, 50, currentAngle, currentAngle + sliceAngle, sliceColor);
                PieChartCanvas.Children.Add(slice);

                // 2. 범례 추가 (색상 점 + 이름 + %)
                AddHomeLegend(sliceColor, group.Type, percentage);

                currentAngle += sliceAngle;
                colorIndex++;
            }
        }

        // [보조] 홈 화면용 작은 범례 만들기
        private void AddHomeLegend(Color color, string name, double percent)
        {
            // 작은 색상 원
            Ellipse dot = new Ellipse { Width = 8, Height = 8, Fill = new SolidColorBrush(color), Margin = new Thickness(0, 0, 4, 0) };
            // 텍스트 (예: 알약 20%)
            TextBlock text = new TextBlock { Text = $"{name} {percent:P0}", FontSize = 9, Foreground = Brushes.Gray, Margin = new Thickness(0, 0, 8, 0) };

            StackPanel panel = new StackPanel { Orientation = Orientation.Horizontal };
            panel.Children.Add(dot);
            panel.Children.Add(text);

            PieLegendPanel.Children.Add(panel);
        }

        // [기능] 막대 차트 (숫자 표시 추가됨)
        private void DrawBarChart()
        {
            DateTime today = DateTime.Today;
            int[] counts = new int[3];
            string[] labels = new string[3];
            int maxCount = 0;

            for (int i = 0; i < 3; i++)
            {
                DateTime targetMonth = today.AddMonths(i);
                labels[i] = $"{targetMonth.Month}월";
                counts[i] = allMedicines.Count(m => m.ExpiryDate.Year == targetMonth.Year &&
                                                    m.ExpiryDate.Month == targetMonth.Month);
                if (counts[i] > maxCount) maxCount = counts[i];
            }

            BarChartLabel.Text = $"{labels[0]} / {labels[1]} / {labels[2]}";

            double maxHeight = 50;

            // 막대 높이 설정
            BarMonth1.Height = (maxCount > 0) ? (counts[0] / (double)maxCount) * maxHeight : 0;
            BarMonth2.Height = (maxCount > 0) ? (counts[1] / (double)maxCount) * maxHeight : 0;
            BarMonth3.Height = (maxCount > 0) ? (counts[2] / (double)maxCount) * maxHeight : 0;

            // [추가] 막대 위 숫자 텍스트 설정
            CountMonth1.Text = counts[0].ToString();
            CountMonth2.Text = counts[1].ToString();
            CountMonth3.Text = counts[2].ToString();

            // 개수가 0이면 숫자도 흐리게 하거나 안보이게 하려면 아래처럼 (선택사항)
            CountMonth1.Visibility = counts[0] > 0 ? Visibility.Visible : Visibility.Hidden;
            CountMonth2.Visibility = counts[1] > 0 ? Visibility.Visible : Visibility.Hidden;
            CountMonth3.Visibility = counts[2] > 0 ? Visibility.Visible : Visibility.Hidden;
        }

        private void GoToChartPage_Click(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/ChartPage.xaml", UriKind.Relative));
        }

        private Path CreatePieSlice(double centerX, double centerY, double radius, double startAngle, double endAngle, Color fill)
        {
            if (endAngle - startAngle >= 360)
                return new Path { Fill = new SolidColorBrush(fill), Data = new EllipseGeometry(new Point(centerX, centerY), radius, radius) };

            double startRad = (startAngle - 90) * Math.PI / 180;
            double endRad = (endAngle - 90) * Math.PI / 180;
            Point startPoint = new Point(centerX + radius * Math.Cos(startRad), centerY + radius * Math.Sin(startRad));
            Point endPoint = new Point(centerX + radius * Math.Cos(endRad), centerY + radius * Math.Sin(endRad));
            PathFigure figure = new PathFigure { StartPoint = new Point(centerX, centerY), IsClosed = true };
            figure.Segments.Add(new LineSegment(startPoint, false));
            figure.Segments.Add(new ArcSegment(endPoint, new Size(radius, radius), 0, endAngle - startAngle > 180, SweepDirection.Clockwise, false));
            return new Path { Fill = new SolidColorBrush(fill), Data = new PathGeometry { Figures = { figure } } };
        }

        private static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T) yield return (T)child;
                    foreach (T childOfChild in FindVisualChildren<T>(child)) yield return childOfChild;
                }
            }
        }
    }
}