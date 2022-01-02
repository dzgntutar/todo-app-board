using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadTodoWorkerService.FetchData
{
    public class StartFetching
    {
        List<IFetchData> Apis = new List<IFetchData>();

        public void AddApi(IFetchData api )
        {
            Apis.Add(api);
        }

        public void Run()
        {
            foreach (var api in Apis)
            {
                api.Fetch();
            }
        }
    }
}
