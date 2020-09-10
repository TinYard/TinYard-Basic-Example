using TinYard;
using TinYard.API.Interfaces;
using TinYard.Extensions.Bundles;
using TinYardBasicExample.Views;

namespace TinYardBasicExample
{
    public class Program
    {
        IContext _context;

        public static void Main(string[] args)
        {
            Program program = new Program();
        }

        public Program()
        {
            _context = new Context()
                .Install(new MVCBundle())
                .Configure(new ProgramConfig());

            _context.Initialize();

            ConsoleView view = new ConsoleView();
        }
    }
}
