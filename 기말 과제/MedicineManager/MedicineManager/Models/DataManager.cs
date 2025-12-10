using System.Collections.ObjectModel;

namespace MedicineManager.Models
{
    public class DataManager
    {
        // 싱글톤 패턴: 앱 전체에서 딱 하나만 존재하는 인스턴스
        private static DataManager _instance;
        public static DataManager Instance => _instance ?? (_instance = new DataManager());

        // 모든 페이지가 공유할 약 데이터 리스트
        public ObservableCollection<Medicine> Medicines { get; set; }

        private DataManager()
        {
            Medicines = new ObservableCollection<Medicine>();
            // (테스트용) 더미 데이터가 필요하면 여기서 추가
        }
    }
}