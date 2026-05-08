using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeEF.DbService
{
    class AppContext
    {
        public static ApplicationContext dbContext { get; set; } = new ApplicationContext();
    }
}
