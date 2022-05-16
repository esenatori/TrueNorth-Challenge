using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrueNorth.Core.Tasks;

namespace TrueNorth.Core.EF.Repositories
{
    public interface ITaskItemRepository
    { 
        Task<string> Create(TaskItem _task);
         
        Task<bool> Exist(string id);  

        Task<TaskItem> Get(string id);
         
        Task<List<TaskItem>> List();
         
        Task<bool> Update(TaskItem _task);

        Task<bool> Delete(string id);
    }
}