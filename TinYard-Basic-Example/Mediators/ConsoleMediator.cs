using TinYard.Extensions.MediatorMap.API.Base;
using TinYard.Framework.Impl.Attributes;
using TinYardBasicExample.Events;
using TinYardBasicExample.Views;

namespace TinYardBasicExample.Mediators
{
    public class ConsoleMediator : Mediator
    {
        [Inject]
        public ConsoleView view;

        public override void Configure()
        {
            AddViewListener<GetToDoItemsEvent>(GetToDoItemsEvent.Type.Get, Dispatch);
            AddViewListener<GetCompleteItemsEvent>(GetCompleteItemsEvent.Type.Get, Dispatch);
            AddViewListener<EditToDoItemsEvent>(EditToDoItemsEvent.Type.Add, Dispatch);
            AddViewListener<EditToDoItemsEvent>(EditToDoItemsEvent.Type.Complete, Dispatch);

            AddContextListener<GetToDoItemsEvent>(GetToDoItemsEvent.Type.Got, OnReceivedToDoItems);
        }

        private void OnReceivedToDoItems(GetToDoItemsEvent evt)
        {
            view.ReceiveLeftToDo(evt.ToDoItems);
        }
    }
}
