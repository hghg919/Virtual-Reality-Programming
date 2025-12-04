using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Wpf_Registration
{
    public class User
    {
        [System.ComponentModel.DataAnnotations.Key]
        public string Id { get; set; }
        public string Pw { get; set; }
    }
}
