using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;  // 소스 코드 추가

namespace WPF_Registration
{
    // 소스 코드 추가
    public class UserDataContext : DbContext     // 클래스 상속
    {
        // override on 입력 후 선택하여 소스 코드 추가
        // 데이터베이스 공급자 구성
        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = membersDB.db");
        }

        public DbSet<User>? Users { get; set; }
    }
}