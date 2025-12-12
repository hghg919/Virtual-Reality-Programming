using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Media.Imaging; // 이미지 처리용

namespace MedicineManager.Models
{
    public class Medicine : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private bool _isChecked;
        private string _name;
        private string _type;
        private DateTime _expiryDate;

        // [추가됨] 메모 기능
        private string _memo;

        // [추가됨] DB 저장용 이미지 데이터 (BLOB)
        private byte[] _imageBytes;

        public string Name
        {
            get => _name;
            set { _name = value; OnPropertyChanged("Name"); }
        }

        public string Type
        {
            get => _type;
            set { _type = value; OnPropertyChanged("Type"); }
        }

        public DateTime ExpiryDate
        {
            get => _expiryDate;
            set
            {
                _expiryDate = value;
                OnPropertyChanged("ExpiryDate");
                OnPropertyChanged("IsExpired");
            }
        }

        public bool IsChecked
        {
            get => _isChecked;
            set { _isChecked = value; OnPropertyChanged("IsChecked"); }
        }

        // [추가] 메모
        public string Memo
        {
            get => _memo;
            set { _memo = value; OnPropertyChanged("Memo"); }
        }

        // [추가] 이미지 데이터 (DB 저장용)
        public byte[] ImageBytes
        {
            get => _imageBytes;
            set
            {
                _imageBytes = value;
                OnPropertyChanged("ImageBytes");
                OnPropertyChanged("DisplayImage"); // 데이터 바뀌면 화면 이미지도 갱신
            }
        }

        // [추가] 화면 표시용 이미지 (데이터 바인딩용)
        public BitmapImage DisplayImage
        {
            get
            {
                if (_imageBytes == null || _imageBytes.Length == 0) return null;
                try
                {
                    // 바이트 배열 -> 이미지 변환 로직
                    using (var ms = new MemoryStream(_imageBytes))
                    {
                        var image = new BitmapImage();
                        image.BeginInit();
                        image.CacheOption = BitmapCacheOption.OnLoad;
                        image.StreamSource = ms;
                        image.EndInit();
                        return image;
                    }
                }
                catch { return null; }
            }
        }

        public bool IsExpired => DateTime.Now.Date > ExpiryDate.Date;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}