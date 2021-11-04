using System;

namespace FactoryPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            GameFactory gf = new GameFactory();
            Game game = gf.FactoryMethod(GameName.GodOfWar);
            game.Platform();
        }
    }

    public interface Game
    {
        public abstract void Platform();
    }

    public class GodOfWar : Game
    {
        public void Platform()
        {
            Console.WriteLine("Bu oyun ATARİ platformunda çalışmaktadır.");
        }
    }

    public class GrandTheftAutoFive : Game
    {
        public void Platform()
        {
            Console.WriteLine("Bu oyun PC platformunda çalışmaktadır.");
        }
    }

    public class RedDeadRedemptionTwo : Game
    {
        public void Platform()
        {
            Console.WriteLine("Bu oyun PS platformunda çalışmaktadır.");
        }
    }

    public enum GameName
    {
        GodOfWar,
        RedDeadRedemptionTwo,
        GrandTheftAutoFive
    }
    public class GameFactory
    {
        public Game FactoryMethod(GameName OyunTipi)
        {
            Game oyun = null;
            switch (OyunTipi)
            {
                case GameName.GodOfWar:
                    oyun = new GodOfWar();
                    break;
                case GameName.RedDeadRedemptionTwo:
                    oyun = new RedDeadRedemptionTwo();
                    break;
                case GameName.GrandTheftAutoFive:
                    oyun = new GrandTheftAutoFive();
                    break;
            }
            return oyun;
        }
    }
}
