using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeEF.DbService;
using AppContext = EmployeeEF.DbService.AppContext;

namespace EmployeeEF.Models
{
   public class TitleList: ObservableCollection<Title>
    {
        public TitleList()
        {
            var queryTitle = from title in AppContext.dbContext.title select title;
            foreach (var item in queryTitle)
            {
                this.Add(item);
            }
        }
    }
}
