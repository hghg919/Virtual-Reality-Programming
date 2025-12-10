using System;
using System.ComponentModel;

namespace MedicineManager.Models
{
    // INotifyPropertyChanged: 데이터 변경 시 화면 자동 갱신
    public class Medicine : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private bool _isChecked;
        private string _name;
        private string _type;
        private DateTime _expiryDate;

        // 약 이름
        public string Name
        {
            get => _name;
            set { _name = value; OnPropertyChanged("Name"); }
        }

        // 약 종류 (알약, 물약 등)
        public string Type
        {
            get => _type;
            set { _type = value; OnPropertyChanged("Type"); }
        }

        // 유통기한
        public DateTime ExpiryDate
        {
            get => _expiryDate;
            set
            {
                _expiryDate = value;
                OnPropertyChanged("ExpiryDate");
                OnPropertyChanged("IsExpired"); // 날짜 바뀌면 만료 여부도 다시 체크
            }
        }

        // 체크박스 (화면용)
        public bool IsChecked
        {
            get => _isChecked;
            set { _isChecked = value; OnPropertyChanged("IsChecked"); }
        }

        // 유통기한 만료 여부 (오늘 날짜와 비교)
        public bool IsExpired => DateTime.Now.Date > ExpiryDate.Date;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}