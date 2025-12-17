using System;
using System.Collections.Generic;
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

        private bool isNameAsc = true;
        private bool isTypeAsc = true;
        private bool isDateAsc = true;

        public RegisterPage()
        {
            InitializeComponent();

            // DataManager에는 이미 MainMainWindow에서 로드한 DB 데이터가 들어있음
            _medicines = DataManager.Instance.Medicines;
            MedicineListView.ItemsSource = _medicines;

            _filteredView = CollectionViewSource.GetDefaultView(_medicines);
            _filteredView.Filter = UserFilter;
        }

        // --- 정렬 로직 (기존 유지) ---
        private void SortByName_Click(object sender, MouseButtonEventArgs e)
        {
            SortList(m => m.Name, ref isNameAsc);
        }
        private void SortByType_Click(object sender, MouseButtonEventArgs e)
        {
            SortList(m => m.Type, ref isTypeAsc);
        }
        private void SortByDate_Click(object sender, MouseButtonEventArgs e)
        {
            SortList(m => m.ExpiryDate, ref isDateAsc);
        }

        private void SortList<TKey>(Func<Medicine, TKey> keySelector, ref bool isAsc)
        {
            var list = _medicines.ToList();
            if (isAsc) list = list.OrderBy(keySelector).ToList();
            else list = list.OrderByDescending(keySelector).ToList();

            isAsc = !isAsc;
            UpdateList(list);
        }

        private void UpdateList(List<Medicine> sortedList)
        {
            _medicines.Clear();
            foreach (var item in sortedList) _medicines.Add(item);
        }

        // --- 검색/추가/삭제 로직 ---

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
            // 팝업이 닫힐 때 DB 저장이 완료된 상태임 (NewMedicine에 ID가 있음)
            if (popup.ShowDialog() == true)
            {
                _medicines.Add(popup.NewMedicine); // 리스트에만 추가해주면 됨
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
                        // ★ DB에서 삭제 (DELETE)
                        if (DBHelper.DeleteMedicine(item.Id))
                        {
                            _medicines.Remove(item); // 성공 시 화면에서도 제거
                        }
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
                MedicineListView.Items.Refresh(); // 수정된 내용 반영
            }
        }
    }
}