using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using MedicineManager.Models;
using MedicineManager.Windows; // ★ [중요] Windows 폴더 안의 팝업창을 쓰기 위해 필수!

namespace MedicineManager.Pages
{
    public partial class MyPage : Page
    {
        public MyPage()
        {
            InitializeComponent();
            LoadUserInfo();
        }

        // 유저 정보 화면에 띄우기
        private void LoadUserInfo()
        {
            var user = DataManager.Instance.CurrentUser;
            if (user != null)
            {
                TxtName.Text = $"{user.Name} 님";
                TxtInfo.Text = $"ID: {user.UserId}  |  No.{user.Id:D3}";

                // 사진이 있으면 보여주고 없으면 회색
                if (user.ProfileImage != null && user.ProfileImage.Length > 0)
                {
                    ProfileBrush.ImageSource = ByteToImage(user.ProfileImage);
                }
                else
                {
                    ProfileBrush.ImageSource = null;
                    ProfileEllipse.Fill = Brushes.LightGray;
                }
            }
        }

        // 1. 프로필 사진 클릭 (변경)
        private void ProfileImage_Click(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "이미지 파일 (*.jpg, *.png)|*.jpg;*.png";

            if (dlg.ShowDialog() == true)
            {
                try
                {
                    byte[] imageBytes = File.ReadAllBytes(dlg.FileName);
                    var user = DataManager.Instance.CurrentUser;

                    // DB 저장 성공 시 화면도 갱신
                    if (DBHelper.UpdateProfileImage(user.Id, imageBytes))
                    {
                        user.ProfileImage = imageBytes;
                        ProfileEllipse.Fill = new ImageBrush(ByteToImage(imageBytes));
                        MessageBox.Show("프로필 사진이 변경되었습니다.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("사진 변경 실패: " + ex.Message);
                }
            }
        }

        // [수정됨] 개인정보 변경 버튼 클릭
        private void EditInfo_Click(object sender, RoutedEventArgs e)
        {
            EditInfoPopup popup = new EditInfoPopup();

            // ★ 이 부분이 중요합니다! ★
            // 현재 이 페이지를 담고 있는 부모 창(MainMainWindow)을 찾아서 팝업의 주인으로 설정합니다.
            // 그래야 WindowStartupLocation="CenterOwner"가 작동합니다.
            popup.Owner = Window.GetWindow(this);

            if (popup.ShowDialog() == true)
            {
                LoadUserInfo(); // 정보 갱신
            }
        }

        // 3. 로그아웃 (시작 화면으로 이동)
        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("로그아웃 하시겠습니까?", "확인", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                DataManager.Instance.CurrentUser = null;

                // 메인화면(로그인창) 먼저 켜고 -> 현재 창 닫기 (순서 중요)
                MainWindow start = new MainWindow();
                start.Show();

                Window.GetWindow(this)?.Close();
            }
        }

        // [도구] 바이트 배열 -> 이미지 변환
        private BitmapImage ByteToImage(byte[] blob)
        {
            if (blob == null || blob.Length == 0) return null;
            using (var ms = new MemoryStream(blob))
            {
                var image = new BitmapImage();
                image.BeginInit();
                image.StreamSource = ms;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.EndInit();
                return image;
            }
        }
    }
}