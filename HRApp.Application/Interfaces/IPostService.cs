using HRApp.Application.Models.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRApp.Application.Interfaces
{
    public interface IPostService
    {
        public Task<int> Create(PostCreateDTO dto);
        public Task Delete(int id);
        public Task Update(PostCreateDTO dto, int id);
        public Task<List<PostGetDTO>> GetAll();
    }
}
