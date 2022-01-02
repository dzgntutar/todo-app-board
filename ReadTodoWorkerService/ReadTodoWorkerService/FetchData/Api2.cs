using Newtonsoft.Json;
using ReadTodoWorkerService.Entities;
using ReadTodoWorkerService.Manager;
using ReadTodoWorkerService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ReadTodoWorkerService.FetchData
{
    public class Api2 : IFetchData
    {
        public string BaseAddress { get; set; }
        public string RequestUri { get; set; }

        IBoardTaskManager _boardTaskManager;

        public Api2(IBoardTaskManager boardTaskManager)
        {
            _boardTaskManager = boardTaskManager;
        }

        public void Fetch()
        {
            using (var httpClient = new HttpClient())
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(BaseAddress);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync(RequestUri).Result;
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    var data2 = JsonConvert.DeserializeObject<List<object>>(data);


                    foreach (var item2 in data2)
                    {
                        var _jsonObj = item2 as Newtonsoft.Json.Linq.JObject;
                        if (_jsonObj == null || _jsonObj.First == null)
                        {
                            continue;
                        }
                        var _firstProp = _jsonObj.First as Newtonsoft.Json.Linq.JProperty;
                        if (_firstProp == null || _firstProp.First == null)
                        {
                            continue;
                        }
                        var newItem = _firstProp.First.ToObject<Api2Model>();
                        newItem.Name = _firstProp.Name;


                        var boardTask = new BoardTask() { Name = newItem.Name, Level = short.Parse(newItem.level), EstimatedDuration = short.Parse(newItem.estimated_duration) };
                        _boardTaskManager.Add(boardTask);
                    }
                }
            }
        }
    }
}
