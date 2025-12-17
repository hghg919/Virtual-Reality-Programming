using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MedicineManager.Models
{
    // [수정됨] 사용자 정보를 담는 그릇 (Phone, Birth 추가됨)
    public class UserInfo
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }

        // ★ 이 두 줄이 없어서 오류가 났던 것입니다.
        public string Phone { get; set; }
        public string Birth { get; set; }

        public byte[] ProfileImage { get; set; }
    }

    public class DataManager
    {
        private static DataManager _instance;
        public static DataManager Instance => _instance ?? (_instance = new DataManager());

        public ObservableCollection<Medicine> Medicines { get; set; }
        public List<Medicine> StandardMedicines { get; set; }

        // 현재 로그인한 사용자 정보
        public UserInfo CurrentUser { get; set; }

        private DataManager()
        {
            Medicines = new ObservableCollection<Medicine>();

            // 자주 쓰는 약 프리셋
            StandardMedicines = new List<Medicine>
            {
                new Medicine { Name = "직접 입력", Type = "" },
                new Medicine { Name = "타이레놀", Type = "알약", Memo = "두통, 치통, 생리통" },
                new Medicine { Name = "게보린", Type = "알약", Memo = "진통제" },
                new Medicine { Name = "후시딘", Type = "연고", Memo = "상처 난 곳" },
                new Medicine { Name = "판피린", Type = "물약", Memo = "감기 조심하세요" },
                new Medicine { Name = "마데카솔", Type = "연고", Memo = "새살이 솔솔" }
            };
        }
    }
}