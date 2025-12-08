using System.Windows;
using System.Windows.Controls;

namespace MedicineManager.Views
{
    public partial class HomeView : UserControl
    {
        // ★ 핵심: static을 붙여서 프로그램이 꺼질 때까지 '한 번이라도 떴는지' 기억하게 함
        private static bool _hasShownWarning = false;

        public HomeView()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            // 만약 이미 경고창을 보여줬다면(_hasShownWarning이 true라면) 
            // 아래 코드를 실행하지 않고 그냥 끝냄(return)
            if (_hasShownWarning == true)
            {
                return;
            }

            // --- 여기서부터는 처음 한 번만 실행됨 ---

            // 실제 앱에서는 여기서 DB를 검사합니다.
            bool hasExpiredMedicine = true;

            if (hasExpiredMedicine)
            {
                MessageBox.Show("🚨 유통기한이 지난 약이 발견되었습니다!",
                                "경고",
                                MessageBoxButton.OK,
                                MessageBoxImage.Warning);
            }

            // ★ 다 보여줬으니 "보여줬음"으로 상태 변경 (이제 위쪽 if문에 걸려서 실행 안 됨)
            _hasShownWarning = true;
        }
    }
}