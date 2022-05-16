using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TrueNorth.Core.Tasks;

namespace TrueNorth.Core.Hipsum
{
    public interface IHipsum
    {
        List<TaskItem> GetMany(HttpClient client, int count);
    }
}
