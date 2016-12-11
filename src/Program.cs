using System;

namespace netcoregame
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var game = new Game(640, 480);
            game.Run();
        }
    }
}
