using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadTodoWorkerService.FetchData
{
    public interface IFetchData
    {
        string BaseAddress { get; set; }
        string RequestUri { get; set; }

        public void Fetch();
    }
}
