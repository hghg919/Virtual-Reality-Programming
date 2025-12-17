using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Media.Imaging;
using SQLite; // SQLite 사용 (PrimaryKey 등)

namespace MedicineManager.Models
{
    public class Medicine : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        // ★ 이 부분이 없어서 오류가 났던 것입니다! (주인 연동용)
        public string UserId { get; set; }

        private string _name;
        private string _type;
        private DateTime _expiryDate;
        private string _memo;
        private byte[] _imageBytes;
        private bool _isChecked;

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

        public string Memo
        {
            get => _memo;
            set { _memo = value; OnPropertyChanged("Memo"); }
        }

        public byte[] ImageBytes
        {
            get => _imageBytes;
            set
            {
                _imageBytes = value;
                OnPropertyChanged("ImageBytes");
                OnPropertyChanged("DisplayImage");
            }
        }

        [Ignore]
        public BitmapImage DisplayImage
        {
            get
            {
                if (_imageBytes == null || _imageBytes.Length == 0) return null;
                try
                {
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

        [Ignore]
        public bool IsChecked
        {
            get => _isChecked;
            set { _isChecked = value; OnPropertyChanged("IsChecked"); }
        }

        [Ignore]
        public bool IsExpired => DateTime.Now.Date > ExpiryDate.Date;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}