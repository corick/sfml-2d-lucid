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
            LuxGame game = new LuxGame();
            game.Run();
            game.Dispose();
        }
    }
}
