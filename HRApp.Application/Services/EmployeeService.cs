using HRApp.Application.Interfaces;
using HRApp.Application.Models.Employees;
using HRApp.Application.Models.Posts;
using HRApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRApp.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IHRAppContext _context;


        public EmployeeService(IHRAppContext context)
        {
            _context = context;

        }

        // Метод для создания работников, в данный момент в нем нет проверок на регистры, дубликатыв базе и тд.
        public async Task<int> Create(EmployeeCreateDTO dto)
        {

            Employee emp = new Employee
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Patronymic = dto.Patronymic,
                DateModified = DateTime.Now,
                PostId = dto.PostId,
                UserModified = Environment.UserName
            };

            _context.Employees.Add(emp);

            await _context.SaveChangesAsync(CancellationToken.None);

            return emp.Id;
        }

        public async Task Delete(int id)
        {
            Employee emp = _context.Employees.FirstOrDefault(_ => _.Id == id);

            if (emp == null)
            {
                throw new Exception("Работник не найден");
            }

            _context.Employees.Remove(emp);
            await _context.SaveChangesAsync(CancellationToken.None);

        }

        public async Task<EmployeeGetDTO> GetById(int id)
        {
            EmployeeGetDTO result = await _context.Employees.Include(_ => _.Post).Where(_ => _.Id == id).Select(_ => new EmployeeGetDTO
            {
                FirstName = _.FirstName,
                LastName = _.LastName,
                Patronymic = _.Patronymic,
                DateModified = _.DateModified,
                UserModified = _.UserModified,
                Post = new PostGetDTO
                {
                    Id = _.Post.Id,
                    DateModified = _.Post.DateModified,
                    Name = _.Post.Name,
                    UserModified = _.Post.UserModified
                }
            }).FirstOrDefaultAsync();

            if (result == null)
            {
                throw new Exception("Работник не найден");
            }

            return result;
        }


        // поиск осуществляется без учета регистра, тут также не проверок на вилидность введенных данных
        public async Task<List<EmployeeGetDTO>> GetByName(string name)
        {
            var query = _context.Employees.AsQueryable();
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(
                    _ => _.FirstName.ToLower().Contains(name.ToLower())
                    || _.LastName.ToLower().Contains(name.ToLower())
                    || _.Patronymic.ToLower().Contains(name.ToLower()));
            }

            List<EmployeeGetDTO> result =  await query.Select(_ => new EmployeeGetDTO
            {
                Id=_.Id,
                FirstName = _.FirstName,
                LastName = _.LastName,
                Patronymic = _.Patronymic,
                DateModified = _.DateModified,
                UserModified = _.UserModified,
                Post=new PostGetDTO { Id = _.Post.Id, Name=_.Post.Name}
                

            }).OrderBy(_ => _.LastName).ToListAsync();

            return result;
        }

        
        public async Task Update(EmployeeCreateDTO dto, int id)
        {
            Employee emp = await _context.Employees.FirstOrDefaultAsync(_ => _.Id == id);

            if (string.IsNullOrEmpty(dto.FirstName) || string.IsNullOrEmpty(dto.LastName) || string.IsNullOrEmpty(dto.Patronymic))
            {
                throw new Exception("Необходимо заполнить все поля");
            }

            if (emp == null)
            {
                throw new Exception("Работник не найден");
            }

            emp.FirstName = dto.FirstName;
            emp.LastName = dto.LastName;
            emp.Patronymic = dto.Patronymic;
            emp.PostId = dto.PostId;
            emp.DateModified = DateTime.Now;
            emp.UserModified = Environment.UserName;

            await _context.SaveChangesAsync(CancellationToken.None);
        }

    }
}
