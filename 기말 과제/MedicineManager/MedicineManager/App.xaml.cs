using System.Windows;
using MedicineManager.Database;
using System; // 이게 있어야 Exception을 잡습니다.

namespace MedicineManager
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            try
            {
                // DB 만들기 시도
                DbHelper.InitializeDB();
            }
            catch (Exception ex)
            {
                // 만약 DB 만들다가 에러나면 여기서 이유를 알려줌!
                MessageBox.Show("DB 연결 실패: " + ex.Message);
            }
        }
    }
}