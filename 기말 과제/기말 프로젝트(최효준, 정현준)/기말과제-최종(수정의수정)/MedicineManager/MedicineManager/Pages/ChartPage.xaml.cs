using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using MedicineManager.Models;

namespace MedicineManager.Pages
{
    public partial class ChartPage : Page
    {
        public ChartPage()
        {
            InitializeComponent();
            this.Loaded += (s, e) =>
            {
                DrawPieChart();
                DrawBarChart();
            };
        }

        // DrawPieChart는 기존과 동일하게 두거나, HomePage처럼 꾸미고 싶으면 비슷하게 수정 가능
        // ... (DrawPieChart 생략, 기존 코드 사용) ...
        private void DrawPieChart()
        {
            // (기존 코드 유지)
            PieChartCanvas.Children.Clear();
            PieLegendPanel.Children.Clear();
            var medicines = DataManager.Instance.Medicines;
            double total = medicines.Count;
            if (total == 0) return;
            var groups = medicines.GroupBy(m => m.Type).Select(g => new { Type = g.Key, Count = g.Count() }).OrderByDescending(g => g.Count).ToList();
            double currentAngle = 0;
            Color[] colors = { Colors.MediumSeaGreen, Colors.DodgerBlue, Colors.Orange, Colors.MediumPurple, Colors.Tomato };
            int colorIndex = 0;
            foreach (var group in groups)
            {
                double percentage = (group.Count / total);
                double sliceAngle = percentage * 360;
                Color sliceColor = colors[colorIndex % colors.Length];
                Path slice = CreatePieSlice(100, 100, 100, currentAngle, currentAngle + sliceAngle, sliceColor);
                PieChartCanvas.Children.Add(slice);
                AddLegendItem(group.Type, sliceColor, percentage);
                currentAngle += sliceAngle;
                colorIndex++;
            }
        }

        private void AddLegendItem(string typeName, Color color, double percentage)
        {
            StackPanel panel = new StackPanel { Orientation = Orientation.Horizontal, Margin = new Thickness(5) };
            Rectangle colorBox = new Rectangle { Width = 10, Height = 10, Fill = new SolidColorBrush(color), RadiusX = 2, RadiusY = 2, Margin = new Thickness(0, 0, 5, 0) };
            TextBlock text = new TextBlock { Text = $"{typeName} ({percentage:P0})", FontSize = 12, Foreground = Brushes.Gray };
            panel.Children.Add(colorBox); panel.Children.Add(text);
            PieLegendPanel.Children.Add(panel);
        }


        // [수정됨] 막대 위에 숫자 표시 기능 추가
        private void DrawBarChart()
        {
            BarsContainer.Children.Clear();
            LabelsContainer.Children.Clear();

            var medicines = DataManager.Instance.Medicines;
            DateTime today = DateTime.Today;
            int[] counts = new int[6];
            int maxCount = 0;

            for (int i = 0; i < 6; i++)
            {
                DateTime target = today.AddMonths(i);
                counts[i] = medicines.Count(m => m.ExpiryDate.Year == target.Year &&
                                                 m.ExpiryDate.Month == target.Month);
                if (counts[i] > maxCount) maxCount = counts[i];
            }

            double maxBarHeight = 150;

            for (int i = 0; i < 6; i++)
            {
                DateTime target = today.AddMonths(i);

                // 1. 컨테이너 생성 (StackPanel: 숫자 + 막대를 수직으로 쌓음)
                StackPanel barStack = new StackPanel();
                barStack.VerticalAlignment = VerticalAlignment.Bottom; // 바닥부터 쌓기

                // 2. 숫자 텍스트 생성
                TextBlock countText = new TextBlock();
                countText.Text = counts[i].ToString();
                countText.HorizontalAlignment = HorizontalAlignment.Center;
                countText.FontSize = 14;
                countText.FontWeight = FontWeights.Bold;
                countText.Foreground = Brushes.DimGray;
                countText.Margin = new Thickness(0, 0, 0, 5); // 막대와 간격
                // 개수가 0이면 숨김 (선택사항)
                countText.Visibility = counts[i] > 0 ? Visibility.Visible : Visibility.Hidden;

                // 3. 막대 생성
                Rectangle bar = new Rectangle();
                bar.Height = (maxCount > 0) ? (counts[i] / (double)maxCount) * maxBarHeight : 0;
                bar.Fill = new SolidColorBrush(i == 0 ? Colors.Salmon : Colors.Crimson);
                bar.Margin = new Thickness(5, 0, 5, 0);
                bar.RadiusX = 4; bar.RadiusY = 4;

                // 4. 쌓기 (숫자 -> 막대 순서)
                barStack.Children.Add(countText);
                barStack.Children.Add(bar);

                // 5. 그리드에 추가
                Grid.SetColumn(barStack, i);
                BarsContainer.Children.Add(barStack);

                // 6. 월 텍스트 (기존 동일)
                TextBlock label = new TextBlock();
                label.Text = $"{target.Month}월";
                label.HorizontalAlignment = HorizontalAlignment.Center;
                label.FontSize = 12;
                label.Foreground = Brushes.DarkGray;
                Grid.SetColumn(label, i);
                LabelsContainer.Children.Add(label);
            }
        }

        // (CreatePieSlice 함수는 HomePage와 동일하게 아래에 있어야 합니다. 없으면 추가하세요)
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
    }
}