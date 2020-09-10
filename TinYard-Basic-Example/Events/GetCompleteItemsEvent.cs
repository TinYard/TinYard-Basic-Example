using System.Collections.Generic;
using TinYard.Extensions.EventSystem.Impl.Base;
using TinYardBasicExample.VO;

namespace TinYardBasicExample.Events
{
    public class GetCompleteItemsEvent : Event
    {
        public enum Type
        {
            Get,
            Got
        }

        public List<Item> CompletedItems { get; private set; }

        public GetCompleteItemsEvent(Type type) : base(type)
        {

        }

        public GetCompleteItemsEvent(Type type, List<Item> completedItems) : base(type)
        {
            CompletedItems = completedItems;
        }
    }
}
