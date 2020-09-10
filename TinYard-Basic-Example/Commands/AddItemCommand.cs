using System;
using TinYard.Extensions.CommandSystem.API.Interfaces;
using TinYard.Framework.Impl.Attributes;
using TinYardBasicExample.Events;
using TinYardBasicExample.Models;

namespace TinYardBasicExample.Commands
{
    public class AddItemCommand : ICommand
    {
        [Inject]
        public EditToDoItemsEvent evt;

        [Inject]
        public IToDoModel toDoModel;

        public void Execute()
        {
            toDoModel.AddToDo(evt.ItemToEdit);
        }
    }
}
