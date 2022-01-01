
namespace ReadTodoWorkerService.Entities
{
    public class BoardTask : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public short Level { get; set; }
        public short EstimatedDuration { get; set; }
    }
}
