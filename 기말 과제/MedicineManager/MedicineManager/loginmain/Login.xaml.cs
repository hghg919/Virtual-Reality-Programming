using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using MedicineManager.Models;

namespace MedicineManager
{
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();

            txtID.Text = "아이디";
            txtID.Foreground = Brushes.Gray;

            txtPW.Password = "비밀번호";
            txtPW.Foreground = Brushes.Gray;
        }

        // ---------------------------------------------------------
        // [수정됨] 뒤로가기 버튼
        // ---------------------------------------------------------
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            // [변경 사항] 
            // new MainWindow()를 지웠습니다. (새 창 만들기 금지)
            // 현재 로그인 창만 닫으면, 뒤에 켜져 있던 원래 메인 화면이 다시 보입니다.
            this.Close();
        }

        // ---------------------------------------------------------
        // [수정됨] 로그인 버튼
        // ---------------------------------------------------------
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string id = txtID.Text;
            string pw = txtPW.Password;

            // 유효성 검사
            if (id == "아이디" || string.IsNullOrWhiteSpace(id) ||
                pw == "비밀번호" || string.IsNullOrWhiteSpace(pw))
            {
                MessageBox.Show("아이디와 비밀번호를 입력하세요.");
                return;
            }

            // DB 로그인 체크
            bool isLogin = DBHelper.CheckLogin(id, pw);

            if (isLogin)
            {
                // [추가됨] 로그인 성공했으니, 이 사람 정보를 DataManager에 저장!
                UserInfo user = DBHelper.GetUser(id);
                DataManager.Instance.CurrentUser = user;

                MessageBox.Show($"{user.Name}님 환영합니다!"); // 이름 불러주기

                // 1. 진짜 앱 메인화면(MainMainWindow) 켜기
                MainMainWindow next = new MainMainWindow();
                next.Show();

                // 2. 현재 로그인 창 닫기
                this.Close();

                // [추가됨] 3. 뒤에 켜져 있는 '시작 화면(MainWindow)' 찾아서 닫기
                // 이걸 안 하면 로그인 후에도 시작 화면이 뒤에 남아있습니다.
                foreach (Window w in Application.Current.Windows)
                {
                    // 타입이 MainWindow(시작화면)인 것만 찾아서 닫음
                    if (w is MainWindow)
                    {
                        w.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("로그인 실패! 아이디 또는 비밀번호가 틀렸습니다.");

                // 실패 시 입력창 초기화
                txtID.Text = "아이디";
                txtID.Foreground = Brushes.Gray;

                txtPW.Password = "비밀번호";
                txtPW.Foreground = Brushes.Gray;
            }
        }

        // =========================================================
        // 텍스트박스 Placeholder 로직 (기존 그대로 유지)
        // =========================================================

        private void txtID_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtID.Text == "아이디")
            {
                txtID.Text = "";
                txtID.Foreground = Brushes.Black;
            }
        }

        private void txtID_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtID.Text))
            {
                txtID.Text = "아이디";
                txtID.Foreground = Brushes.Gray;
            }
        }

        private void PasswordBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtPW.Password == "비밀번호")
            {
                txtPW.Password = "";
                txtPW.Foreground = Brushes.Black;
            }
        }

        private void PasswordBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPW.Password))
            {
                txtPW.Password = "비밀번호";
                txtPW.Foreground = Brushes.Gray;
            }
        }
    }
}