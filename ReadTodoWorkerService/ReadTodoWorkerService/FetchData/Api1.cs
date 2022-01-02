using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ReadTodoWorkerService.Entities;
using ReadTodoWorkerService.Manager;
using ReadTodoWorkerService.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace ReadTodoWorkerService.FetchData
{
    public class Api1 : IFetchData
    {
        public string BaseAddress { get; set; }
        public string RequestUri { get; set; }

        IBoardTaskManager _boardTaskManager;       

        public Api1(IBoardTaskManager boardTaskManager)
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
                    if (!string.IsNullOrEmpty(data))
                    {
                        var data2 = JsonConvert.DeserializeObject<List<Api1Model>>(data);
                        if(data2 != null)
                        {
                            foreach (var item in data2)
                            {
                                var boardTask = new BoardTask() { Name = item.id, Level = (short)item.zorluk, EstimatedDuration = (short)item.zorluk };
                                _boardTaskManager.Add(boardTask);
                            }
                        }
                    }
                }
            }
        }
    }
}
