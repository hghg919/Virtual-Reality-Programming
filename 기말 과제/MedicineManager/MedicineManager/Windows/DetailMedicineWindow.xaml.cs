using System;
using System.IO;
using System.Windows;
using System.Windows.Input;
using Microsoft.Win32;
using MedicineManager.Models;
using System.Windows.Controls; // SelectionChangedEventArgs 사용

namespace MedicineManager.Windows
{
    public partial class DetailMedicineWindow : Window
    {
        private Medicine _targetMedicine;

        public DetailMedicineWindow(Medicine medicine)
        {
            InitializeComponent();
            _targetMedicine = medicine;
            this.DataContext = _targetMedicine;

            // 1. 템플릿(프리셋) 목록 불러오기
            ComboPreset.ItemsSource = DataManager.Instance.StandardMedicines;

            // 주의: 상세창에서는 기존 데이터가 유지되어야 하므로 
            // 콤보박스를 강제로 '직접 입력'으로 선택해두거나 선택을 안 한 상태로 둡니다.
            ComboPreset.SelectedIndex = -1;
        }

        // [추가된 기능] 템플릿 선택 시 -> 현재 보고 있는 약 정보 갱신
        private void ComboPreset_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selected = ComboPreset.SelectedItem as Medicine;

            // '직접 입력'이 아니고 실제 약을 선택했을 때만 덮어쓰기
            if (selected != null && selected.Name != "직접 입력")
            {
                // INotifyPropertyChanged 덕분에 변수 값만 바꾸면 화면도 바뀝니다.
                _targetMedicine.Name = selected.Name;
                _targetMedicine.Type = selected.Type;
                _targetMedicine.Memo = selected.Memo;

                // 만약 템플릿에 이미지도 있다면 _targetMedicine.ImageBytes = selected.ImageBytes; 도 가능
            }
        }

        // 사진 변경
        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

            if (dlg.ShowDialog() == true)
            {
                _targetMedicine.ImageBytes = File.ReadAllBytes(dlg.FileName);
            }
        }

        // 수정 완료
        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("수정되었습니다.");
            DialogResult = true;
        }

        // 닫기
        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}