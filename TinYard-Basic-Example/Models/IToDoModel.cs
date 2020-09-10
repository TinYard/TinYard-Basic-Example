using System.Collections.Generic;
using TinYardBasicExample.VO;

namespace TinYardBasicExample.Models
{
    public interface IToDoModel
    {
        IReadOnlyList<Item> CompletedToDoList { get; }
        IReadOnlyList<Item> ToDoList { get; }

        void AddToDo(Item toDo);

        void CompleteToDo(Item toDo);
    }
}
