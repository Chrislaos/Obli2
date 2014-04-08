using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication5
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime passExpires { get; set; }
        public string accountStatus { get; set; }
    }
}
