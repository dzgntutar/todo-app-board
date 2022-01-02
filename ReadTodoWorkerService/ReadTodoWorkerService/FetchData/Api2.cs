using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadTodoWorkerService.FetchData
{
    public class Api2 : IFetchData
    {
        public string BaseAddress { get; set; }
        public string RequestUri { get; set; }

        public void GetchDataFromApi()
        {
            throw new NotImplementedException();
        }
    }
}
