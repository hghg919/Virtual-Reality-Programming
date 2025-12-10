using System;
using System.Windows;
using MedicineManager.Models; // Medicine 클래스 사용

namespace MedicineManager.Windows
{
    public partial class AddMedicineWindow : Window
    {
        public Medicine NewMedicine { get; private set; }

        public AddMedicineWindow()
        {
            InitializeComponent();
            DatePicker.SelectedDate = DateTime.Now;
        }

        private void ConfirmBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameBox.Text))
            {
                MessageBox.Show("약 이름을 입력해주세요.");
                return;
            }

            NewMedicine = new Medicine
            {
                Name = NameBox.Text,
                Type = TypeCombo.Text,
                ExpiryDate = DatePicker.SelectedDate ?? DateTime.Now
            };

            DialogResult = true; // 창 닫기 및 성공 신호
            Close();
        }
    }
}