using System;
using System.Collections.Generic;
using TinYard.Extensions.CommandSystem.API.Interfaces;
using TinYard.Extensions.EventSystem.API.Interfaces;
using TinYard.Framework.Impl.Attributes;
using TinYardBasicExample.Events;
using TinYardBasicExample.Models;
using TinYardBasicExample.VO;

namespace TinYardBasicExample.Commands
{
    public class GetToDoCommand : ICommand
    {
        [Inject]
        public IToDoModel model;

        [Inject]
        public IEventDispatcher dispatcher;

        public void Execute()
        {
            var readOnlyToDo = model.ToDoList;

            List<Item> toDo = new List<Item>();
            toDo.AddRange(readOnlyToDo);

            dispatcher.Dispatch(new GetToDoItemsEvent(GetToDoItemsEvent.Type.Got, toDo));
        }
    }
}
