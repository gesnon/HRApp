using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRApp.Application.Interfaces
{
    public  interface IDataService
    {
        public Task FillData();
        public Task RemoveAllData();
    }
}
