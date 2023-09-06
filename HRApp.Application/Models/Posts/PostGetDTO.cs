using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRApp.Application.Models.Posts
{
    public class PostGetDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserModified { get; set; }
        public DateTime DateModified { get; set; }
    }
}
