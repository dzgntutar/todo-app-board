using ReadTodoWorkerService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ReadTodoWorkerService.Manager
{
    public interface IBoardTaskManager
    {
        List<BoardTask> GetList(Expression<Func<BoardTask, bool>> filter = null);
        BoardTask Get(Expression<Func<BoardTask, bool>> filter);
        BoardTask Add(BoardTask entity);
        BoardTask Update(BoardTask entity);
        void Delete(BoardTask entity);
    }
}
