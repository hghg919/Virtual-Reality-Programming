using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_Registration
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(
            object sender, RoutedEventArgs e)
        {
            // 소스 코드 추가
            var Uid = txtID.Text;
            var Upw = txtPW.Password;

            using (UserDataContext context = 
                new UserDataContext())
            {
                bool userfound = context.Users.Any(
                    user => user.Id == Uid && 
                    user.Pw == Upw);

                if (userfound)
                {
                    GrantAccess();
                    Close();
                }
                else
                {
                    MessageBox.Show("미등록 회원입니다.", "알림",
                        MessageBoxButton.OK, 
                        MessageBoxImage.Warning);
                }
            }

        }

        // 소스 코드 추가
        private object UserDataContext()
        {
            throw new NotImplementedException();
        }

        public void GrantAccess()
        {
            MembersOnly membersOnly = new MembersOnly();
            membersOnly.Show();
        }

        private void btnCancel_Click(
            object sender, RoutedEventArgs e)
        {
            txtID.Text = "";
            txtPW.Password = "";
        }
    }
}