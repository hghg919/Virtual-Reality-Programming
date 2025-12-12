using System;
using System.Data.SQLite;

namespace MedicineManager.Models
{
    public static class DBHelper
    {
        private static string dbPath = "Data Source=medicine.db;Version=3;";

        // 1. 초기화
        public static void Initialize()
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(dbPath))
                {
                    conn.Open();

                    string createUsersTable =
                        @"CREATE TABLE IF NOT EXISTS Users (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            UserID TEXT NOT NULL UNIQUE,
                            Password TEXT NOT NULL,
                            Name TEXT,
                            Phone TEXT,
                            Birth TEXT,
                            ProfileImage BLOB
                        );";
                    SQLiteCommand cmdUser = new SQLiteCommand(createUsersTable, conn);
                    cmdUser.ExecuteNonQuery();

                    string createMedicinesTable =
                        @"CREATE TABLE IF NOT EXISTS Medicines (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            OwnerId INTEGER NOT NULL,
                            Name TEXT NOT NULL,
                            DailyCount INTEGER,
                            Memo TEXT,
                            FOREIGN KEY(OwnerId) REFERENCES Users(Id)
                        );";
                    SQLiteCommand cmdMedi = new SQLiteCommand(createMedicinesTable, conn);
                    cmdMedi.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("DB 초기화 오류: " + ex.Message);
            }
        }

        // 2. 회원가입
        public static bool InsertUser(string userId, string password, string name, string phone, string birth)
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(dbPath))
                {
                    conn.Open();
                    string sql = @"INSERT INTO Users (UserID, Password, Name, Phone, Birth)
                                   VALUES (@userId, @password, @name, @phone, @birth)";

                    SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@userId", userId);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@phone", phone);
                    cmd.Parameters.AddWithValue("@birth", birth);
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("회원가입 오류: " + ex.Message);
                return false;
            }
        }

        // 3. 로그인 확인
        public static bool CheckLogin(string userId, string password)
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(dbPath))
                {
                    conn.Open();
                    string sql = "SELECT COUNT(*) FROM Users WHERE UserID = @userId AND Password = @password";
                    SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@userId", userId);
                    cmd.Parameters.AddWithValue("@password", password);
                    long count = (long)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("로그인 확인 오류: " + ex.Message);
                return false;
            }
        }

        // 4. 아이디 중복 확인
        public static bool IsUserExists(string userId)
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(dbPath))
                {
                    conn.Open();
                    string sql = "SELECT COUNT(*) FROM Users WHERE UserID = @userId";
                    SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@userId", userId);
                    long count = (long)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("ID 중복 확인 오류: " + ex.Message);
                return false;
            }
        }

        // 5. [수정됨] 유저 정보 가져오기 (전화번호, 생년월일 추가)
        public static UserInfo GetUser(string userId)
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(dbPath))
                {
                    conn.Open();
                    string sql = "SELECT * FROM Users WHERE UserID = @userId";
                    SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@userId", userId);

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            UserInfo user = new UserInfo
                            {
                                Id = int.Parse(reader["Id"].ToString()),
                                UserId = reader["UserID"].ToString(),
                                Name = reader["Name"].ToString(),

                                // ★ DB 값을 UserInfo에 채워넣는 부분 추가
                                Phone = reader["Phone"].ToString(),
                                Birth = reader["Birth"].ToString()
                            };

                            if (reader["ProfileImage"] != DBNull.Value)
                            {
                                user.ProfileImage = (byte[])reader["ProfileImage"];
                            }
                            return user;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("정보 로드 오류: " + ex.Message);
            }
            return null;
        }

        // 6. 프로필 사진 업데이트
        public static bool UpdateProfileImage(int userId, byte[] imageBytes)
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(dbPath))
                {
                    conn.Open();
                    string sql = "UPDATE Users SET ProfileImage = @img WHERE Id = @id";
                    SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@img", imageBytes);
                    cmd.Parameters.AddWithValue("@id", userId);
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("사진 저장 오류: " + ex.Message);
                return false;
            }
        }

        // 7. 개인정보 수정 (비번, 이름, 전화번호, 생년월일)
// 7. [수정됨] 개인정보 수정 (비번이 비어있으면 기존 비번 유지)
        public static bool UpdateUserInfo(int id, string newPw, string newName, string newPhone, string newBirth)
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(dbPath))
                {
                    conn.Open();
                    string sql;
                    SQLiteCommand cmd = new SQLiteCommand(conn);

                    // 1) 비밀번호 칸이 비어있으면 -> 비밀번호 빼고 업데이트
                    if (string.IsNullOrWhiteSpace(newPw))
                    {
                        sql = @"UPDATE Users 
                                SET Name = @name, Phone = @phone, Birth = @birth
                                WHERE Id = @id";
                    }
                    // 2) 비밀번호가 있으면 -> 비밀번호 포함해서 업데이트
                    else
                    {
                        sql = @"UPDATE Users 
                                SET Password = @pw, Name = @name, Phone = @phone, Birth = @birth
                                WHERE Id = @id";
                        cmd.Parameters.AddWithValue("@pw", newPw); // 비번 파라미터 추가
                    }

                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@name", newName);
                    cmd.Parameters.AddWithValue("@phone", newPhone);
                    cmd.Parameters.AddWithValue("@birth", newBirth);
                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("정보 수정 오류: " + ex.Message);
                return false;
            }
        }
    }
}