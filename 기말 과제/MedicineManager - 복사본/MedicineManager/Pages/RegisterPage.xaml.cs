using System;
using System.Collections.Generic; // List<T> 사용을 위해 추가
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

using MedicineManager.Models;
using MedicineManager.Windows;

namespace MedicineManager.Pages
{
    public partial class RegisterPage : Page
    {
        private ObservableCollection<Medicine> _medicines;
        private ICollectionView _filteredView;

        // [추가됨] 정렬 상태 관리 변수 (true: 오름차순, false: 내림차순)
        private bool isNameAsc = true;
        private bool isTypeAsc = true;
        private bool isDateAsc = true;

        public RegisterPage()
        {
            InitializeComponent();

            // DataManager에서 데이터 가져오기
            _medicines = DataManager.Instance.Medicines;

            if (_medicines.Count == 0)
            {
                _medicines.Add(new Medicine { Name = "타이레놀", Type = "알약", ExpiryDate = DateTime.Now.AddYears(1) });
                _medicines.Add(new Medicine { Name = "유통기한 지난 약", Type = "물약", ExpiryDate = DateTime.Now.AddDays(-10) });
            }

            MedicineListView.ItemsSource = _medicines;

            _filteredView = CollectionViewSource.GetDefaultView(_medicines);
            _filteredView.Filter = UserFilter;
        }

        // ---------------------------------------------------------
        // [추가된 기능] 헤더 클릭 시 정렬 로직
        // ---------------------------------------------------------

        // 1. 제품명 정렬
        private void SortByName_Click(object sender, MouseButtonEventArgs e)
        {
            var list = _medicines.ToList(); // 현재 리스트 복사

            if (isNameAsc)
                list = list.OrderBy(m => m.Name).ToList();      // 가나다순
            else
                list = list.OrderByDescending(m => m.Name).ToList(); // 역순

            isNameAsc = !isNameAsc; // 상태 반전 (토글)
            UpdateList(list);       // 화면 갱신
        }

        // 2. 종류 정렬
        private void SortByType_Click(object sender, MouseButtonEventArgs e)
        {
            var list = _medicines.ToList();

            if (isTypeAsc)
                list = list.OrderBy(m => m.Type).ToList();
            else
                list = list.OrderByDescending(m => m.Type).ToList();

            isTypeAsc = !isTypeAsc;
            UpdateList(list);
        }

        // 3. 유통기한 정렬
        private void SortByDate_Click(object sender, MouseButtonEventArgs e)
        {
            var list = _medicines.ToList();

            if (isDateAsc)
                list = list.OrderBy(m => m.ExpiryDate).ToList(); // 날짜 빠른 순
            else
                list = list.OrderByDescending(m => m.ExpiryDate).ToList(); // 날짜 느린 순

            isDateAsc = !isDateAsc;
            UpdateList(list);
        }

        // [공통] 정렬된 리스트를 화면에 반영하는 함수
        private void UpdateList(List<Medicine> sortedList)
        {
            // ObservableCollection을 비우고 다시 채워야 UI가 갱신됩니다.
            _medicines.Clear();
            foreach (var item in sortedList)
            {
                _medicines.Add(item);
            }
        }

        // ---------------------------------------------------------
        // 기존 기능 유지 (검색, 추가, 삭제, 더블클릭)
        // ---------------------------------------------------------

        private bool UserFilter(object item)
        {
            if (string.IsNullOrEmpty(SearchBox.Text)) return true;
            var med = (Medicine)item;
            return med.Name.IndexOf(SearchBox.Text, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            _filteredView.Refresh();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            AddMedicineWindow popup = new AddMedicineWindow();
            if (popup.ShowDialog() == true)
            {
                _medicines.Add(popup.NewMedicine);
            }
        }

        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {
            var targets = _medicines.Where(x => x.IsChecked).ToList();
            if (targets.Count > 0)
            {
                if (MessageBox.Show($"{targets.Count}개를 삭제하시겠습니까?", "삭제 확인", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    foreach (var item in targets)
                    {
                        _medicines.Remove(item);
                    }
                }
            }
            else
            {
                MessageBox.Show("삭제할 약을 선택해주세요.");
            }
        }

        private void MedicineListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var selectedMedicine = MedicineListView.SelectedItem as Medicine;
            if (selectedMedicine != null)
            {
                DetailMedicineWindow detailWindow = new DetailMedicineWindow(selectedMedicine);
                detailWindow.ShowDialog();
                MedicineListView.Items.Refresh();
            }
        }
    }
}