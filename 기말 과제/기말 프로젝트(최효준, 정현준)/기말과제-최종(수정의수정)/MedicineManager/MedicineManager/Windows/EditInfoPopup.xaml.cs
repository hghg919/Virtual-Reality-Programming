using System; // DateTime 사용을 위해 필요
using System.Windows;
using System.Windows.Controls;
using System.Text.RegularExpressions; // 정규식(전화번호 숫자만 추출) 사용
using MedicineManager.Models;

namespace MedicineManager.Windows
{
    public partial class EditInfoPopup : Window
    {
        private UserInfo _currentUser;

        public EditInfoPopup()
        {
            InitializeComponent();
            LoadCurrentInfo();
        }

        // 1. 현재 정보 불러와서 화면에 채우기
        private void LoadCurrentInfo()
        {
            _currentUser = DataManager.Instance.CurrentUser;
            if (_currentUser == null) return;

            TxtID.Text = _currentUser.UserId;
            TxtName.Text = _currentUser.Name;
            TxtPW.Text = ""; // 비밀번호는 비워둠

            // DB에서 최신 정보(전화번호, 생년월일 포함)를 다시 가져옵니다.
            UserInfo fullInfo = DBHelper.GetUser(_currentUser.UserId);
            if (fullInfo != null)
            {
                TxtPhone.Text = fullInfo.Phone; // 전화번호 채우기

                // 생년월일 문자열을 날짜로 변환해서 DatePicker에 설정
                if (DateTime.TryParse(fullInfo.Birth, out DateTime birthDate))
                {
                    DpBirth.SelectedDate = birthDate;
                }
            }
        }

        // 2. [신규] 전화번호 자동 하이픈(-) 포맷팅
        private void TxtPhone_TextChanged(object sender, TextChangedEventArgs e)
        {
            // 입력된 텍스트에서 숫자만 추출
            string digits = Regex.Replace(TxtPhone.Text, @"[^0-9]", "");

            // 길이에 따라 하이픈 위치 결정 (010-xxxx-xxxx 형식)
            string formatted = digits;
            if (digits.Length > 3 && digits.Length <= 7)
            {
                formatted = $"{digits.Substring(0, 3)}-{digits.Substring(3)}";
            }
            else if (digits.Length > 7)
            {
                if (digits.Length > 11) digits = digits.Substring(0, 11); // 최대 11자리 제한
                formatted = $"{digits.Substring(0, 3)}-{digits.Substring(3, 4)}-{digits.Substring(7)}";
            }

            // 무한 루프 방지: 텍스트가 다를 때만 변경
            if (TxtPhone.Text != formatted)
            {
                TxtPhone.Text = formatted;
                TxtPhone.CaretIndex = TxtPhone.Text.Length; // 커서를 맨 뒤로 이동
            }
        }

        // 3. 저장 버튼 클릭
        // 3. 저장 버튼 클릭 (수정됨: 비밀번호 필수 체크 제거)
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            // [변경점] TxtPW.Text 체크를 뺐습니다. (이름과 생년월일만 필수)
            if (string.IsNullOrWhiteSpace(TxtName.Text) || DpBirth.SelectedDate == null)
            {
                MessageBox.Show("이름과 생년월일은 필수입니다.");
                return;
            }

            string birthStr = DpBirth.SelectedDate.Value.ToString("yyyy-MM-dd");

            // DB 업데이트 (비번이 비어있어도 DBHelper가 알아서 처리함)
            bool isSuccess = DBHelper.UpdateUserInfo(
                _currentUser.Id,
                TxtPW.Text, // 비어있으면 빈 문자열이 넘어감
                TxtName.Text,
                TxtPhone.Text,
                birthStr
            );

            if (isSuccess)
            {
                // 메모리 정보 최신화
                _currentUser.Name = TxtName.Text;

                MessageBox.Show("정보가 수정되었습니다!");
                this.DialogResult = true;
                this.Close();
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}