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

            // 객체 생성
            Medicine med = new Medicine
            {
                Name = TxtName.Text,
                Type = ComboType.Text,
                ExpiryDate = DateExpiry.SelectedDate ?? DateTime.Today,
                Memo = TxtMemo.Text,
                ImageBytes = currentImageBytes
            };

            // ★ DB에 저장 (INSERT)
            int ownerId = DataManager.Instance.CurrentUser.Id;
            int newId = DBHelper.InsertMedicine(ownerId, med);

            if (newId > 0)
            {
                med.Id = newId; // DB에서 발급받은 ID 할당
                NewMedicine = med;
                DialogResult = true; // 창 닫고 성공 신호 보냄
            }
            else
            {
                // 실패 시 메시지는 DBHelper에서 띄움
            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}