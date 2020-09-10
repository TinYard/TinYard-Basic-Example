using TinYard.Extensions.CommandSystem.API.Interfaces;
using TinYard.Framework.Impl.Attributes;
using TinYardBasicExample.Events;
using TinYardBasicExample.Models;

namespace TinYardBasicExample.Commands
{
    public class CompleteItemCommand : ICommand
    {
        [Inject]
        public EditToDoItemsEvent evt;

        [Inject]
        public IToDoModel toDoModel;

        public void Execute()
        {
            var completedItem = evt.ItemToEdit;

            toDoModel.CompleteToDo(completedItem);
        }
    }
}
