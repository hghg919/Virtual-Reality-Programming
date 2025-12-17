using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.Win32;
using MedicineManager.Models;

namespace MedicineManager.Windows
{
    public partial class DetailMedicineWindow : Window
    {
        private Medicine _targetMedicine;

        public DetailMedicineWindow(Medicine medicine)
        {
            InitializeComponent();
            _targetMedicine = medicine;
            this.DataContext = _targetMedicine; // 데이터 바인딩

            ComboPreset.ItemsSource = DataManager.Instance.StandardMedicines;
            ComboPreset.SelectedIndex = -1;
        }

        private void ComboPreset_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selected = ComboPreset.SelectedItem as Medicine;
            if (selected != null && selected.Name != "직접 입력")
            {
                _targetMedicine.Name = selected.Name;
                _targetMedicine.Type = selected.Type;
                _targetMedicine.Memo = selected.Memo;
                // 바인딩 때문에 화면도 자동으로 바뀜
            }
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

            if (dlg.ShowDialog() == true)
            {
                _targetMedicine.ImageBytes = File.ReadAllBytes(dlg.FileName);
                // INotifyPropertyChanged에 의해 이미지 갱신됨
            }
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            // ★ DB 업데이트 (UPDATE)
            if (DBHelper.UpdateMedicine(_targetMedicine))
            {
                MessageBox.Show("수정되었습니다.");
                DialogResult = true;
            }
            // 실패 메시지는 DBHelper에서 처리
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}