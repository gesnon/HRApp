using HRApp.Application.Interfaces;
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
    public class PostService : IPostService
    {
        private readonly IHRAppContext _context;


        public PostService(IHRAppContext context)
        {
            _context = context;
        }

        public async Task<int> Create(PostCreateDTO dto)
        {
            Post checkPost = _context.Posts.FirstOrDefault(_ => _.Name == dto.Name);
            if (checkPost == null)
            {
                Post post = new Post
                {
                    DateModified = DateTime.Now,
                    Name = dto.Name,
                    UserModified = Environment.UserName
                };

                _context.Posts.Add(post);

                await _context.SaveChangesAsync(CancellationToken.None);

                return post.Id;
            }
            return 0;
        }

        public async Task Delete(int id)
        {
            Post post = await _context.Posts.FirstOrDefaultAsync(_ => _.Id == id);

            if (post == null)
            {
                throw new Exception("Профессия не найдена");
            }
            _context.Posts.Remove(post);

            await _context.SaveChangesAsync(CancellationToken.None);
        }

        public async Task<List<PostGetDTO>> GetAll()
        {
            List<PostGetDTO> result = await _context.Posts.Select(_ => new PostGetDTO
            {
                Id = _.Id,
                DateModified = _.DateModified,
                Name = _.Name,
                UserModified = _.UserModified
            }).OrderBy(_ => _.Name).ToListAsync();

            return result;
        }

        public async Task Update(PostCreateDTO dto, int id)
        {
            Post post = await _context.Posts.FirstOrDefaultAsync(_ => _.Id == id);

            if (post == null)
            {
                throw new Exception("Профессия не найдена");
            }

            post.Name = dto.Name;
            post.DateModified = DateTime.Now;
            post.UserModified = Environment.UserName;

            await _context.SaveChangesAsync(CancellationToken.None);
        }
    }
}
