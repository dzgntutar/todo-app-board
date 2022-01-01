using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadTodoWorkerService.Entities
{
    public class BoardTask
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public short Level { get; set; }
        public short EstimatedDuration { get; set; }
    }
}
