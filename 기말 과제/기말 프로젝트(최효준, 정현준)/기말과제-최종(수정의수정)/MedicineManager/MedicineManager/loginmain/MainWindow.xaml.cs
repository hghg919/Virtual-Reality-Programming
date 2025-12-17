using System;
using System.Windows;
using MedicineManager.Models; // ★ [추가됨] 필수!

namespace MedicineManager
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // 프로그램이 켜질 때 DB와 테이블 생성
            DBHelper.Initialize();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            Login loginWindow = new Login();
            loginWindow.Show();
        }

        private void Join_Click(object sender, RoutedEventArgs e)
        {
            JoinPopup popup = new JoinPopup();
            popup.Owner = this;
            popup.ShowDialog();
        }
    }
}