using System;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using MedicineManager.Models;

namespace MedicineManager.Windows
{
    public partial class AddMedicineWindow : Window
    {
        public Medicine NewMedicine { get; private set; }
        private byte[] currentImageBytes = null;

        public AddMedicineWindow()
        {
            InitializeComponent();
            ComboPreset.ItemsSource = DataManager.Instance.StandardMedicines;
            ComboPreset.SelectedIndex = 0;
            DateExpiry.SelectedDate = DateTime.Today;
        }

        private void ComboPreset_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            var selected = ComboPreset.SelectedItem as Medicine;
            if (selected != null && selected.Name != "직접 입력")
            {
                TxtName.Text = selected.Name;

                // [수정] 콤보박스의 텍스트를 자동으로 바꿔줍니다.
                // IsEditable="True"이기 때문에 Text 속성에 넣으면 알아서 선택되거나 입력됩니다.
                ComboType.Text = selected.Type;

                TxtMemo.Text = selected.Memo;
            }
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

            if (dlg.ShowDialog() == true)
            {
                currentImageBytes = File.ReadAllBytes(dlg.FileName);
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.StreamSource = new MemoryStream(currentImageBytes);
                bitmap.CacheOption = BitmapCacheOption.OnLoad;
                bitmap.EndInit();
                ImgPreview.Source = bitmap;
            }
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtName.Text))
            {
                MessageBox.Show("약 이름을 입력해주세요.");
                return;
            }

            NewMedicine = new Medicine
            {
                Name = TxtName.Text,
                Type = ComboType.Text, // [수정] 콤보박스 값을 가져옴
                ExpiryDate = DateExpiry.SelectedDate ?? DateTime.Today,
                Memo = TxtMemo.Text,
                ImageBytes = currentImageBytes
            };

            DialogResult = true;
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}