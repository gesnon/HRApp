using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPApp.Infrastructure.Persistence
{
    public class DbInitializer
    {
        private readonly HRAppContext _context;

        public DbInitializer(HRAppContext context)
        {
            _context = context;
        }


    }
}
