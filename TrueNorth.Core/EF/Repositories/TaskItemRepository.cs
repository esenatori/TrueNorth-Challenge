using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrueNorth.Core.EF.Context;
using TrueNorth.Core.EF.Repositories.Base;
using TrueNorth.Core.Tasks;

namespace TrueNorth.Core.EF.Repositories
{
    internal class TaskItemRepository : AsyncRepositoryBase<TaskItem, AppDb>, ITaskItemRepository
    {
        public AppDb context { get; }

        public TaskItemRepository(AppDb Context) : base(Context)
        {
            this.context = Context;
        }

        async Task<string> ITaskItemRepository.Create(TaskItem _task)
        {
            var a = context.TaskItems.Add(_task);
            context.SaveChanges(); 
            return a.Entity.UUID;
        }

        public Task<bool> Exist(string id)
        {
            throw new NotImplementedException();
        }

        public Task<TaskItem> Get(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<TaskItem>> List()
        {
            return Context.TaskItems.Select(x => new TaskItem { UUID = x.UUID,  Title = x.Title }).ToList();
        }

        Task<bool> ITaskItemRepository.Update(TaskItem _task)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(string id)
        {
            throw new NotImplementedException();
        }
    }
}