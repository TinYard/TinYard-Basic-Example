using TinYard.Extensions.EventSystem.Impl.Base;
using TinYardBasicExample.VO;

namespace TinYardBasicExample.Events
{
    public class EditToDoItemsEvent : Event
    {
        public enum Type
        {
            Add,
            Complete,
            Remove
        }

        public Item ItemToEdit { get; private set; }

        public EditToDoItemsEvent(Type type, Item itemToEdit) : base(type)
        {
            ItemToEdit = itemToEdit;
        }
    }
}
