using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRApp.Domain.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Patronymic { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }
        public string UserModified { get; set; }
        public DateTime DateModified { get; set; }

    }
}
