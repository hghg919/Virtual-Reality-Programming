using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

// [중요] 모델과 윈도우(팝업), 데이터매니저를 사용하기 위해 추가
using MedicineManager.Models;
using MedicineManager.Windows;

namespace MedicineManager.Pages
{
    public partial class RegisterPage : Page
    {
        // 데이터를 담을 리스트 변수
        private ObservableCollection<Medicine> _medicines;
        // 검색 필터링을 위한 뷰
        private ICollectionView _filteredView;

        public RegisterPage()
        {
            InitializeComponent();

            // =========================================================
            // [수정된 부분] DataManager(공용 저장소)에서 데이터 가져오기
            // =========================================================
            _medicines = DataManager.Instance.Medicines;

            // (테스트용) 만약 데이터가 하나도 없으면 샘플 데이터 2개 추가
            if (_medicines.Count == 0)
            {
                _medicines.Add(new Medicine { Name = "타이레놀", Type = "알약", ExpiryDate = DateTime.Now.AddYears(1) });
                _medicines.Add(new Medicine { Name = "유통기한 지난 약", Type = "물약", ExpiryDate = DateTime.Now.AddDays(-10) });
            }

            // 리스트뷰에 데이터 연결
            MedicineListView.ItemsSource = _medicines;

            // 검색 필터 설정 (기존과 동일)
            _filteredView = CollectionViewSource.GetDefaultView(_medicines);
            _filteredView.Filter = UserFilter;
        }

        // ---------------------------------------------------------
        // 아래 기능들은 기존과 똑같습니다. (데이터 저장소가 바뀐 것만 적용됨)
        // ---------------------------------------------------------

        // [검색 로직]
        private bool UserFilter(object item)
        {
            if (string.IsNullOrEmpty(SearchBox.Text)) return true;
            var med = (Medicine)item;
            // 대소문자 무시하고 이름에 검색어 포함되는지 확인
            return med.Name.IndexOf(SearchBox.Text, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        // [검색창 입력 시]
        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            _filteredView.Refresh(); // 목록 새로고침
        }

        // [추가 버튼] 팝업 열기
        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            AddMedicineWindow popup = new AddMedicineWindow();

            // 팝업이 '확인'을 누르고 닫혔다면
            if (popup.ShowDialog() == true)
            {
                // 여기서 _medicines에 추가하면, DataManager에도 자동으로 추가됨 (참조 연결)
                _medicines.Add(popup.NewMedicine);
            }
        }

        // [제거 버튼] 체크된 항목 삭제
        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {
            // 체크된 항목만 찾아서 리스트로 만듦
            var targets = _medicines.Where(x => x.IsChecked).ToList();

            if (targets.Count > 0)
            {
                // 정말 삭제할지 물어보기 (선택 사항)
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

        // [상세보기] 더블 클릭 시 상세 창 열기
        private void MedicineListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var selectedMedicine = MedicineListView.SelectedItem as Medicine;

            // 빈 공간 클릭이 아닐 때만 실행
            if (selectedMedicine != null)
            {
                DetailMedicineWindow detailWindow = new DetailMedicineWindow(selectedMedicine);
                detailWindow.ShowDialog();

                // 수정하고 돌아오면 리스트 갱신
                MedicineListView.Items.Refresh();
            }
        }
    }
}