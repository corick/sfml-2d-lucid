using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lux
{
    public class Program
    {
        public static void Main(string[] args)
        {
            LuxGame game;
            if (args.Length >= 1)
                game = new LuxGame(args[0]);
            else game = new LuxGame();
            game.Run();
            game.Dispose();
        }

        public static void Launch(string configPath)
        {
            LuxGame game = new LuxGame(configPath);
            game.Run();
            game.Dispose();
        }
    }
}
