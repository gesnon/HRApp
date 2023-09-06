using HRApp.Application.Interfaces;
using HRApp.Application.Models.Employees;
using HRApp.Application.Models.Posts;
using HRApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRApp.Application.Services
{
    public class DataService : IDataService
    {
        private readonly IHRAppContext _context;
        private readonly IEmployeeService _employeeService;
        private readonly IPostService _postService;

        public DataService(IHRAppContext context, IEmployeeService employeeService, IPostService postService)
        {
            _context = context;
            _employeeService = employeeService;
            _postService = postService;
        }

        public async Task FillData()
        {
            await _postService.Create(new PostCreateDTO { Name = "Охранник" });
            await _postService.Create(new PostCreateDTO { Name = "Завхоз" });
            await _postService.Create(new PostCreateDTO { Name = "Уборщик" });
            await _postService.Create(new PostCreateDTO { Name = "Программист" });
            await _postService.Create(new PostCreateDTO { Name = "Мастер" });

            List<Post> posts = _context.Posts.ToList();

            await _employeeService.Create(new EmployeeCreateDTO
            {
                FirstName = "Иванов",
                LastName = "Иван",
                Patronymic = "Иванович",
                PostId = posts[posts.Count - 1].Id
            });
            await _employeeService.Create(new EmployeeCreateDTO
            {
                FirstName = "Сергеев",
                LastName = "Сергей",
                Patronymic = "Сергеевич",
                PostId = posts[posts.Count - 2].Id
            });
            await _employeeService.Create(new EmployeeCreateDTO
            {
                FirstName = "Петров",
                LastName = "Петр",
                Patronymic = "Петрович",
                PostId = posts[posts.Count - 3].Id
            });
            await _employeeService.Create(new EmployeeCreateDTO
            {
                FirstName = "Викторов",
                LastName = "Виктор",
                Patronymic = "Викторович",
                PostId = posts[posts.Count - 4].Id
            });
            await _employeeService.Create(new EmployeeCreateDTO
            {
                FirstName = "Игорев",
                LastName = "Игорь",
                Patronymic = "Игоревич",
                PostId = posts[posts.Count - 5].Id
            });
            await _context.SaveChangesAsync(CancellationToken.None);
        }
    
        public async Task RemoveAllData()
        {            
            _context.Employees.RemoveRange(_context.Employees);
            _context.Posts.RemoveRange(_context.Posts);

            await _context.SaveChangesAsync(CancellationToken.None);
        }
    }
}
