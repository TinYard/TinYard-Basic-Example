using System.Collections.Generic;
using TinYard.Extensions.CommandSystem.API.Interfaces;
using TinYard.Extensions.EventSystem.API.Interfaces;
using TinYard.Framework.Impl.Attributes;
using TinYardBasicExample.Events;
using TinYardBasicExample.Models;
using TinYardBasicExample.VO;

namespace TinYardBasicExample.Commands
{
    public class GetCompletedItemsCommand : ICommand
    {
        [Inject]
        public IEventDispatcher eventDispatcher;

        [Inject]
        public IToDoModel toDoModel;

        public void Execute()
        {
            var readOnly = toDoModel.CompletedToDoList;

            List<Item> items = new List<Item>();
            items.AddRange(readOnly);

            eventDispatcher.Dispatch(new GetCompleteItemsEvent(GetCompleteItemsEvent.Type.Got, items));
        }
    }
}
