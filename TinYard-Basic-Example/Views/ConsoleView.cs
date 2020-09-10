using System;
using System.Collections.Generic;
using System.Linq;
using TinYard.Extensions.ViewController.Impl.Base;
using TinYardBasicExample.Events;
using TinYardBasicExample.VO;

namespace TinYardBasicExample.Views
{
    public class ConsoleView : View
    {
        private bool _exit = false;

        private Action<IEnumerable<Item>> OnReceiveLeftToDo;

        public ConsoleView()
        {
            Console.WriteLine("Welcome to your TODO holder");
            OptionsLoop();
        }

        private void Exit()
        {
            _exit = true;
        }

        private void OptionsLoop()
        {
            do
            {
                DisplayOptions();
                var input = TriggerOptionsChoice();
                
                Console.Clear();

                HandleOptionsInput(input);
                Console.WriteLine();
            }
            while (_exit == false);
        }

        private void HandleOptionsInput(ConsoleKey input)
        {
            switch(input)
            {
                case ConsoleKey.D1:
                    OnReceiveLeftToDo = DisplayLeftToDo;
                    GetLeftToDo();
                    break;

                case ConsoleKey.D2:
                    DisplayAddToToDo();
                    break;

                case ConsoleKey.D3:
                    GetCompletedItems();
                    break;

                case ConsoleKey.D4:
                    OnReceiveLeftToDo = DisplayCompleteToDo;
                    GetLeftToDo();
                    break;

                case ConsoleKey.Escape:
                    Exit();
                    break;

                default:

                    DisplayInvalidInput();

                    break;
            }
        }

        private ConsoleKey TriggerOptionsChoice()
        {
            var input = Console.ReadKey().Key;
            Console.WriteLine();
            return input;
        }

        private void DisplayOptions()
        {
            Console.WriteLine("Options:");
            Console.WriteLine("1.\tSee To Do items list");
            Console.WriteLine("2.\tAdd to To Do items");
            Console.WriteLine("3.\tSee Completed items list");
            Console.WriteLine("4.\tTick off / Complete item");
            Console.WriteLine("\t Press ESC to exit.");
            Console.WriteLine();
        }

        private void GetLeftToDo()
        {
            Dispatch(new GetToDoItemsEvent(GetToDoItemsEvent.Type.Get));
        }

        public void ReceiveLeftToDo(IEnumerable<Item> toDoItems)
        {
            OnReceiveLeftToDo?.Invoke(toDoItems);
            OnReceiveLeftToDo = null;
        }

        private void DisplayLeftToDo(IEnumerable<Item> toDoItems)
        {
            foreach(Item toDo in toDoItems)
            {
                Console.WriteLine(string.Format("{0}", toDo.Title));
            }
        }

        private void DisplayAddToToDo()
        {
            Console.Write("Title: ");
            string title = Console.ReadLine();

            Item newToDo = new Item() { Title = title };

            Dispatch(new EditToDoItemsEvent(EditToDoItemsEvent.Type.Add, newToDo));
        }

        private void GetCompletedItems()
        {
            Dispatch(new GetCompleteItemsEvent(GetCompleteItemsEvent.Type.Get));
        }

        public void GotCompletedItems(IEnumerable<Item> completedItems)
        {
            DisplayCompletedItems(completedItems);
        }

        private void DisplayCompletedItems(IEnumerable<Item> completedItems)
        {
            foreach (Item completed in completedItems)
            {
                Console.WriteLine(string.Format("{0}", completed.Title));
            }
        }

        private void DisplayCompleteToDo(IEnumerable<Item> toDoItems)
        {
            Console.WriteLine("Choose item to complete: ");
            for(int i = 0; i < toDoItems.Count(); i++)
            {
                Item item = toDoItems.ElementAt(i);
                Console.WriteLine(string.Format("{0}:\t{1}", i, item.Title));
            }
            Console.WriteLine();

            string input = Console.ReadLine();

            int itemToCompleteIndex = -1;
            if(int.TryParse(input, out itemToCompleteIndex))
            {
                Dispatch(new EditToDoItemsEvent(EditToDoItemsEvent.Type.Complete, toDoItems.ElementAt(itemToCompleteIndex)));
            }
        }

        private void DisplayInvalidInput()
        {
            Console.WriteLine("Not a valid option.");
        }
    }
}
