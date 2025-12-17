using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using MedicineManager.Models; // ★ 필수: DBHelper 사용을 위해

namespace MedicineManager
{
    public partial class JoinPopup : Window
    {
        public JoinPopup()
        {
            InitializeComponent();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        // ⭐ 회원가입 완료 버튼
        private void JoinConfirm_Click(object sender, RoutedEventArgs e)
        {
            string id = txtID.Text;
            string pw = txtPW.Text;
            string pw2 = txtPWCheck.Text;
            string name = txtName.Text;
            string phone = txtPhone.Text;
            var birth = dpBirth.SelectedDate;

            // 1) 비밀번호 확인
            if (pw != pw2)
            {
                MessageBox.Show("비밀번호가 일치하지 않습니다!");
                return;
            }

            // 2) 빈칸/placeholder 체크
            if (id == "아이디" || string.IsNullOrWhiteSpace(id) ||
                pw == "비밀번호" || string.IsNullOrWhiteSpace(pw) ||
                pw2 == "비밀번호 확인" || string.IsNullOrWhiteSpace(pw2) ||
                name == "이름" || string.IsNullOrWhiteSpace(name) ||
                phone == "전화번호" || string.IsNullOrWhiteSpace(phone) ||
                birth == null)
            {
                MessageBox.Show("모든 정보를 입력해주세요.");
                return;
            }

            // 3) 아이디 중복 체크
            if (DBHelper.IsUserExists(id))
            {
                MessageBox.Show("이미 존재하는 아이디입니다!");
                return;
            }

            // 4) DB 저장
            bool result = DBHelper.InsertUser(
                id,
                pw,
                name,
                phone,
                birth.Value.ToString("yyyy-MM-dd")
            );

            if (result)
            {
                MessageBox.Show("회원가입 완료!");
                this.Close();
            }
        }

        // 전화번호: 숫자만 입력
        private void Phone_NumberOnly(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, "^[0-9]+$");
        }

        // 전화번호 자동 '-' 포맷
        private void Phone_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtPhone.Foreground == Brushes.Gray) return;

            string digits = Regex.Replace(txtPhone.Text, @"[^0-9]", "");

            if (digits.Length == 0) return;

            if (digits.Length <= 3)
            {
                txtPhone.Text = digits;
            }
            else if (digits.Length <= 7)
            {
                txtPhone.Text = $"{digits.Substring(0, 3)}-{digits.Substring(3)}";
            }
            else
            {
                if (digits.Length > 11) digits = digits.Substring(0, 11);
                txtPhone.Text = $"{digits.Substring(0, 3)}-{digits.Substring(3, 4)}-{digits.Substring(7)}";
            }

            txtPhone.CaretIndex = txtPhone.Text.Length;
        }

        // placeholder 처리 (TextBox용)
        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = sender as TextBox;

            if (tb != null && tb.Foreground == Brushes.Gray)
            {
                tb.Text = "";
                tb.Foreground = Brushes.Black;
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = sender as TextBox;

            if (tb != null && string.IsNullOrWhiteSpace(tb.Text))
            {
                tb.Foreground = Brushes.Gray;

                if (tb == txtID) tb.Text = "아이디";
                else if (tb == txtPW) tb.Text = "비밀번호";
                else if (tb == txtPWCheck) tb.Text = "비밀번호 확인";
                else if (tb == txtName) tb.Text = "이름";
                else if (tb == txtPhone) tb.Text = "전화번호";
            }
        }

        // ---------------------------------------------------------
        // [수정됨] 글씨 색깔 바꾸는 기능 추가
        // ---------------------------------------------------------
        private void dpBirth_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dpBirth.SelectedDate != null)
            {
                // 날짜를 골랐을 때:
                // 1. "생년월일" 안내 문구 숨기기
                txtBirthPlaceholder.Visibility = Visibility.Hidden;

                // 2. ★중요★ 달력 글씨 색을 '검정'으로 변경 (날짜가 보이게)
                dpBirth.Foreground = Brushes.Black;
            }
            else
            {
                // 날짜를 지웠을 때:
                // 1. "생년월일" 안내 문구 보이기
                txtBirthPlaceholder.Visibility = Visibility.Visible;

                // 2. 달력 글씨 색을 '투명'으로 변경 ('날짜 선택' 숨기기)
                dpBirth.Foreground = Brushes.Transparent;
            }
        }
    }
}