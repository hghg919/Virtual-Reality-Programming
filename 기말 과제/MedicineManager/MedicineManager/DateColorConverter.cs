using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace MedicineManager // ★ 프로젝트 이름으로 통일
{
    public class DateColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime date = (DateTime)value;

            // 이제 같은 namespace 안에 있으니 에러 없이 찾을 겁니다.
            if (MainAppWindow.DangerDates.ContainsKey(date))
            {
                return new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF8A80"));
            }

            return Brushes.Transparent;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}