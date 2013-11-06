
using Lucid.Framework;
namespace TestGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Debug.Attach = false;
            TGame game = new TGame(); //FIXME: Implement Using.
            game.Run();
        }
    }
}
