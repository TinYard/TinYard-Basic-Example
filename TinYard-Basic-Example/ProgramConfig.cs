using TinYard.API.Interfaces;
using TinYard.Extensions.CommandSystem.API.Interfaces;
using TinYard.Extensions.MediatorMap.API.Interfaces;
using TinYard.Extensions.ViewController.API.Interfaces;
using TinYard.Framework.Impl.Attributes;
using TinYardBasicExample.Commands;
using TinYardBasicExample.Events;
using TinYardBasicExample.Mediators;
using TinYardBasicExample.Models;
using TinYardBasicExample.Views;

namespace TinYardBasicExample
{
    public class ProgramConfig : IConfig
    {
        [Inject]
        public IContext context;

        public void Configure()
        {
            context.PostConfigsInstalled += PostConfigs;
        }

        private void PostConfigs()
        {
            ICommandMap commandMap = context.Mapper.GetMappingValue<ICommandMap>() as ICommandMap;
            IMediatorMapper mediatorMap = context.Mapper.GetMappingValue<IMediatorMapper>() as IMediatorMapper;
            
            //Commands
            commandMap.Map<GetToDoItemsEvent>(GetToDoItemsEvent.Type.Get).ToCommand<GetToDoCommand>();
            commandMap.Map<GetCompleteItemsEvent>(GetCompleteItemsEvent.Type.Get).ToCommand<GetCompletedItemsCommand>();
            commandMap.Map<EditToDoItemsEvent>(EditToDoItemsEvent.Type.Add).ToCommand<AddItemCommand>();
            commandMap.Map<EditToDoItemsEvent>(EditToDoItemsEvent.Type.Complete).ToCommand<CompleteItemCommand>();

            //Mediators
            mediatorMap.Map<ConsoleView>().ToMediator<ConsoleMediator>();

            //Models
            context.Mapper.Map<IToDoModel>().ToValue(new ToDoModel());
        }
    }
}
