
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TrueNorth.Core.Rest;
using TrueNorth.Core.Tasks;

namespace TrueNorth.Core.Hipsum
{
    public class Hipsum : IHipsum
    {
        public List<TaskItem> GetMany(HttpClient client, int count)
        {
            var _list = new List<TaskItem>();

            for (int i = 0; i < count; i++)
            {
                var _taskname = RestClient<HipsumResponse>.GetValue(client, client.BaseAddress + "/api/?type=hipster-centric&sentences=1", HttpMethod.Post);
                _list.Add(new TaskItem { UUID = Guid.NewGuid().ToString(), Title = _taskname  });
            }
              
            return _list;
        }
    }
}
