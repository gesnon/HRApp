﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRApp.Domain.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserModified { get; set; }
        public DateTime DateModified { get; set; }

        public override string ToString()
        {
            return  Name;
        }
    }
}
