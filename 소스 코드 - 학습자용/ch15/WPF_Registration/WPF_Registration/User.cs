using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;  // 소스 코드 추가

namespace WPF_Registration
{
    public class User
    {
        // 소스 코드 추가
        [System.ComponentModel.DataAnnotations.Key]
        public string Id { get; set; }
        public string Pw { get; set; }
    }
}