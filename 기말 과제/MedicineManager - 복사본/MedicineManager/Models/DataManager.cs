using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MedicineManager.Models
{
    public class DataManager
    {
        private static DataManager _instance;
        public static DataManager Instance => _instance ?? (_instance = new DataManager());

        public ObservableCollection<Medicine> Medicines { get; set; }

        // 시판 약 프리셋 리스트
        public List<Medicine> StandardMedicines { get; set; }

        // [삭제함] public User CurrentUser { get; set; }  <-- 이 줄을 지우세요!

        private DataManager()
        {
            Medicines = new ObservableCollection<Medicine>();

            // 자주 쓰는 약 미리 등록
            StandardMedicines = new List<Medicine>
            {
                new Medicine { Name = "직접 입력", Type = "" },
                new Medicine { Name = "타이레놀", Type = "알약", Memo = "두통, 치통, 생리통" },
                new Medicine { Name = "게보린", Type = "알약", Memo = "진통제" },
                new Medicine { Name = "후시딘", Type = "연고", Memo = "상처 난 곳" },
                new Medicine { Name = "판피린", Type = "물약", Memo = "감기 조심하세요" },
                new Medicine { Name = "마데카솔", Type = "연고", Memo = "새살이 솔솔" }
            };

            // 테스트 데이터는 필요하면 넣고, 아니면 빼도 됩니다.
            if (Medicines.Count == 0)
            {
                Medicines.Add(new Medicine { Name = "타이레놀", Type = "알약", ExpiryDate = DateTime.Now.AddYears(1) });
            }
        }
    }
}