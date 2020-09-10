using System.Collections.Generic;
using TinYardBasicExample.VO;

namespace TinYardBasicExample.Models
{
    public class ToDoModel : IToDoModel
    {
        public IReadOnlyList<Item> ToDoList { get { return _toDoList.AsReadOnly(); } }
        private List<Item> _toDoList = new List<Item>();

        public IReadOnlyList<Item> CompletedToDoList { get { return _completedToDoList.AsReadOnly(); } }
        private List<Item> _completedToDoList = new List<Item>();

        public ToDoModel()
        {
            for (int i = 0; i < 5; i++)
                _toDoList.Add(new Item() { Title = i.ToString() });
        }

        public void AddToDo(Item toDo)
        {
            _toDoList.Add(toDo);
        }

        public void CompleteToDo(Item toDo)
        {
            if (toDo.Completed == false)
                toDo.Completed = true;

            _toDoList.Remove(toDo);

            _completedToDoList.Add(toDo);
        }
    }
}
