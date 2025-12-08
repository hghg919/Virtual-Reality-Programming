using System.IO;
using System.Data.SQLite; // 방금 설치한 도구

namespace MedicineManager.Database
{
    public class DbHelper
    {
        // 1. DB 파일 이름 정하기 (실행 파일 옆에 생김)
        private static string dbName = "MedicineApp.db";

        // 2. 연결 문구 (공식 같은 것)
        public static string ConnectionString = $"Data Source={dbName};Version=3;";

        // 3. DB와 테이블을 만드는 함수 (앱 켜질 때 딱 한 번 실행할 예정)
        public static void InitializeDB()
        {
            // 만약 파일이 없으면? 새로 만듭니다.
            if (!File.Exists(dbName))
            {
                SQLiteConnection.CreateFile(dbName);
            }

            // DB에 연결해서 테이블 만들기
            using (SQLiteConnection conn = new SQLiteConnection(ConnectionString))
            {
                conn.Open();

                // (1) 회원 테이블 (Users) 만들기
                // ID, 아이디, 비번, 이름, 생년월일, 성별, 전화번호
                string sqlUsers = @"
                    CREATE TABLE IF NOT EXISTS Users (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT, 
                        LoginId TEXT UNIQUE NOT NULL,
                        Password TEXT NOT NULL,
                        Name TEXT,
                        BirthDate TEXT,
                        Gender TEXT,
                        Phone TEXT
                    );";

                // (2) 의약품 테이블 (Medicines) 만들기
                // 약ID, 주인ID(누구 약인지), 약이름, 종류(카테고리), 유통기한, 메모
                string sqlMedicines = @"
                    CREATE TABLE IF NOT EXISTS Medicines (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        UserId INTEGER NOT NULL,
                        Name TEXT NOT NULL,
                        Category TEXT,
                        ExpiryDate TEXT,
                        Memo TEXT,
                        FOREIGN KEY(UserId) REFERENCES Users(Id)
                    );";

                // 명령 실행!
                using (SQLiteCommand cmd = new SQLiteCommand(sqlUsers, conn))
                {
                    cmd.ExecuteNonQuery();
                }
                using (SQLiteCommand cmd = new SQLiteCommand(sqlMedicines, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}