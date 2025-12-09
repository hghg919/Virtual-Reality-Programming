using System.Windows;
using System.Windows.Controls;

namespace MedicineManager.Pages
{
    public partial class RegisterPage : Page
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            // 1. 입력값 가져오기
            string name = TxtName.Text;
            string type = CboType.Text;

            // 날짜가 선택되지 않았으면 오늘 날짜로 방어
            string date = DpExpiryDate.SelectedDate.HasValue
                          ? DpExpiryDate.SelectedDate.Value.ToString("yyyy-MM-dd")
                          : "날짜 미선택";

            // 2. (임시) 메시지 박스로 확인
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("약 이름을 입력해주세요!", "경고");
                return;
            }

            MessageBox.Show($"[등록 완료]\n이름: {name}\n종류: {type}\n유통기한: {date}");

            // 3. 입력창 초기화
            TxtName.Text = "";
            DpExpiryDate.SelectedDate = null;
        }
    }
}