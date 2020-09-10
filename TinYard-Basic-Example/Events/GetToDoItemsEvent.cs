using System.Collections.Generic;
using TinYard.Extensions.EventSystem.Impl.Base;
using TinYardBasicExample.VO;

namespace TinYardBasicExample.Events
{
    public class GetToDoItemsEvent : Event
    {
        public enum Type
        {
            Get,
            Got
        }

        public List<Item> ToDoItems
        {
            get
            {
                return _toDoItems;
            }
        }

        private List<Item> _toDoItems;

        public GetToDoItemsEvent(Type type) : base(type)
        {

        }

        public GetToDoItemsEvent(Type type, List<Item> toDoItems) : base(type)
        {
            _toDoItems = toDoItems;
        }
    }
}
