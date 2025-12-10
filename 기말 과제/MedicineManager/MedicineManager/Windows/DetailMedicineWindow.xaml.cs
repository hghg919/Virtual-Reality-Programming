using System.Windows;
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

            // 기존 정보 불러오기
            NameBox.Text = medicine.Name;
            TypeCombo.Text = medicine.Type;
            DatePicker.SelectedDate = medicine.ExpiryDate;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            // 정보 업데이트 (참조된 객체라 리스트에도 자동 반영됨)
            _targetMedicine.Name = NameBox.Text;
            _targetMedicine.Type = TypeCombo.Text;
            _targetMedicine.ExpiryDate = DatePicker.SelectedDate ?? System.DateTime.Now;

            MessageBox.Show("수정되었습니다.");
            Close();
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}