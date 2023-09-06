using HRApp.Application.Models.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRApp.Application.Interfaces
{
    public interface IEmployeeService
    {
        public Task<int> Create(EmployeeCreateDTO dto);
        public Task<EmployeeGetDTO> GetById(int id);
        public Task<List<EmployeeGetDTO>> GetByName(string name);        
        public Task Delete(int id);
        public Task Update(EmployeeCreateDTO dto, int id);

    }
}
