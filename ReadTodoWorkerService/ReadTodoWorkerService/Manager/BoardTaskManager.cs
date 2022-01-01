using ReadTodoWorkerService.Entities;
using ReadTodoWorkerService.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ReadTodoWorkerService.Manager
{
    public class BoardTaskManager : IBoardTaskManager
    {
        IRepository<BoardTask> _repository;

        public BoardTaskManager(IRepository<BoardTask> repository)
        {
            _repository = repository;
        }

        public BoardTask Add(BoardTask entity)
        {
           var newBoardTask = _repository.Add(entity);
            return newBoardTask;
        }

        public void Delete(BoardTask entity)
        {
            throw new NotImplementedException();
        }

        public BoardTask Get(Expression<Func<BoardTask, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<BoardTask> GetList(Expression<Func<BoardTask, bool>> filter = null)
        {
            return _repository.GetList();
        }

        public BoardTask Update(BoardTask entity)
        {
            throw new NotImplementedException();
        }
    }
}
