using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;

namespace MedicineManager.Models
{
    public static class DBHelper
    {
        // 실행 파일 위치에 medicine.db 생성
        private static string dbPath = "Data Source=medicine.db;Version=3;";

        // 1. 초기화: 테이블이 없으면 생성
        public static void Initialize()
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(dbPath))
                {
                    conn.Open();

                    // (1) 유저 테이블
                    string createUsers = @"CREATE TABLE IF NOT EXISTS Users (
                                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                            UserID TEXT NOT NULL UNIQUE,
                                            Password TEXT NOT NULL,
                                            Name TEXT,
                                            Phone TEXT,
                                            Birth TEXT,
                                            ProfileImage BLOB
                                         );";
                    SQLiteCommand cmdUser = new SQLiteCommand(createUsers, conn);
                    cmdUser.ExecuteNonQuery();

                    // (2) 약품 테이블 (프로그램 UI에 맞춰 수정됨)
                    // OwnerId: 누구의 약인지 구분하기 위한 외래키
                    string createMedicines = @"CREATE TABLE IF NOT EXISTS Medicines (
                                                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                                OwnerId INTEGER NOT NULL,
                                                Name TEXT NOT NULL,
                                                Type TEXT,
                                                ExpiryDate TEXT,
                                                Memo TEXT,
                                                ImageBytes BLOB,
                                                FOREIGN KEY(OwnerId) REFERENCES Users(Id)
                                             );";
                    SQLiteCommand cmdMedi = new SQLiteCommand(createMedicines, conn);
                    cmdMedi.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("DB 초기화 오류: " + ex.Message);
            }
        }

        // =========================================================
        // [유저 관련 기능] (로그인, 회원가입 등)
        // =========================================================
        public static bool InsertUser(string userId, string password, string name, string phone, string birth)
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(dbPath))
                {
                    conn.Open();
                    string sql = "INSERT INTO Users (UserID, Password, Name, Phone, Birth) VALUES (@u, @p, @n, @ph, @b)";
                    SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@u", userId);
                    cmd.Parameters.AddWithValue("@p", password);
                    cmd.Parameters.AddWithValue("@n", name);
                    cmd.Parameters.AddWithValue("@ph", phone);
                    cmd.Parameters.AddWithValue("@b", birth);
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch { return false; }
        }

        public static bool CheckLogin(string userId, string password)
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(dbPath))
                {
                    conn.Open();
                    string sql = "SELECT COUNT(*) FROM Users WHERE UserID = @u AND Password = @p";
                    SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@u", userId);
                    cmd.Parameters.AddWithValue("@p", password);
                    return (long)cmd.ExecuteScalar() > 0;
                }
            }
            catch { return false; }
        }

        public static bool IsUserExists(string userId)
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(dbPath))
                {
                    conn.Open();
                    string sql = "SELECT COUNT(*) FROM Users WHERE UserID = @u";
                    SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@u", userId);
                    return (long)cmd.ExecuteScalar() > 0;
                }
            }
            catch { return false; }
        }

        public static UserInfo GetUser(string userId)
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(dbPath))
                {
                    conn.Open();
                    string sql = "SELECT * FROM Users WHERE UserID = @u";
                    SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@u", userId);
                    using (SQLiteDataReader r = cmd.ExecuteReader())
                    {
                        if (r.Read())
                        {
                            UserInfo u = new UserInfo
                            {
                                Id = Convert.ToInt32(r["Id"]),
                                UserId = r["UserID"].ToString(),
                                Name = r["Name"].ToString(),
                                Phone = r["Phone"].ToString(),
                                Birth = r["Birth"].ToString()
                            };
                            if (r["ProfileImage"] != DBNull.Value)
                                u.ProfileImage = (byte[])r["ProfileImage"];
                            return u;
                        }
                    }
                }
            }
            catch { }
            return null;
        }

        public static bool UpdateProfileImage(int id, byte[] img)
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(dbPath))
                {
                    conn.Open();
                    string sql = "UPDATE Users SET ProfileImage = @img WHERE Id = @id";
                    SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@img", img);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch { return false; }
        }

        public static bool UpdateUserInfo(int id, string pw, string name, string phone, string birth)
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(dbPath))
                {
                    conn.Open();
                    string sql;
                    SQLiteCommand cmd = new SQLiteCommand(conn);

                    if (string.IsNullOrWhiteSpace(pw))
                        sql = "UPDATE Users SET Name=@n, Phone=@ph, Birth=@b WHERE Id=@id";
                    else
                    {
                        sql = "UPDATE Users SET Password=@p, Name=@n, Phone=@ph, Birth=@b WHERE Id=@id";
                        cmd.Parameters.AddWithValue("@p", pw);
                    }
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@n", name);
                    cmd.Parameters.AddWithValue("@ph", phone);
                    cmd.Parameters.AddWithValue("@b", birth);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch { return false; }
        }

        // =========================================================
        // [약품 관련 기능] (조회, 추가, 수정, 삭제)
        // =========================================================

        // 1. 조회: 로그인한 사용자의 약만 가져옴
        public static List<Medicine> GetMedicines(int ownerId)
        {
            List<Medicine> list = new List<Medicine>();
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(dbPath))
                {
                    conn.Open();
                    string sql = "SELECT * FROM Medicines WHERE OwnerId = @oid";
                    SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@oid", ownerId);

                    using (SQLiteDataReader r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            Medicine m = new Medicine
                            {
                                Id = Convert.ToInt32(r["Id"]),
                                Name = r["Name"].ToString(),
                                Type = r["Type"].ToString(),
                                Memo = r["Memo"].ToString(),
                                ExpiryDate = DateTime.Parse(r["ExpiryDate"].ToString())
                            };
                            if (r["ImageBytes"] != DBNull.Value)
                            {
                                m.ImageBytes = (byte[])r["ImageBytes"];
                            }
                            list.Add(m);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("약 목록 로드 오류: " + ex.Message);
            }
            return list;
        }

        // 2. 추가: DB에 약 저장하고 생성된 ID 반환
        public static int InsertMedicine(int ownerId, Medicine med)
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(dbPath))
                {
                    conn.Open();
                    string sql = @"INSERT INTO Medicines (OwnerId, Name, Type, ExpiryDate, Memo, ImageBytes) 
                                   VALUES (@oid, @name, @type, @date, @memo, @img);
                                   SELECT last_insert_rowid();";

                    SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@oid", ownerId);
                    cmd.Parameters.AddWithValue("@name", med.Name);
                    cmd.Parameters.AddWithValue("@type", med.Type);
                    cmd.Parameters.AddWithValue("@date", med.ExpiryDate.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@memo", med.Memo ?? "");
                    cmd.Parameters.AddWithValue("@img", med.ImageBytes);

                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("약 등록 오류: " + ex.Message);
                return -1;
            }
        }

        // 3. 수정: 약 정보 업데이트
        public static bool UpdateMedicine(Medicine med)
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(dbPath))
                {
                    conn.Open();
                    string sql = @"UPDATE Medicines 
                                   SET Name=@name, Type=@type, ExpiryDate=@date, Memo=@memo, ImageBytes=@img
                                   WHERE Id=@id";

                    SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@name", med.Name);
                    cmd.Parameters.AddWithValue("@type", med.Type);
                    cmd.Parameters.AddWithValue("@date", med.ExpiryDate.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@memo", med.Memo ?? "");
                    cmd.Parameters.AddWithValue("@img", med.ImageBytes);
                    cmd.Parameters.AddWithValue("@id", med.Id);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("약 수정 오류: " + ex.Message);
                return false;
            }
        }

        // 4. 삭제: 약 제거
        public static bool DeleteMedicine(int id)
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(dbPath))
                {
                    conn.Open();
                    string sql = "DELETE FROM Medicines WHERE Id = @id";
                    SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("삭제 오류: " + ex.Message);
                return false;
            }
        }
    }
}