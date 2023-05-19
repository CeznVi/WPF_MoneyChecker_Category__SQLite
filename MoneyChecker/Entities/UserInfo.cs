using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyChecker.Entities
{
    public class UserInfo
    {
        public int Id { get; set; }

        public string Fio { get; set; }

        public DateTime BirthDate { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }
    }
}
