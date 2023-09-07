using HRApp.Application.Models.Posts;
using HRApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRApp.Application.Models.Employees
{
    public class EmployeeGetDTO
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Patronymic { get; set; }
        public PostGetDTO Post { get; set; }      
        public string UserModified { get; set; }
        public DateTime DateModified { get; set; }
    }
}
