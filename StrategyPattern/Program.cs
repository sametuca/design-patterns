using System;

namespace StrategyPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            PayWrapper pw = new PayWrapper(new CreditCard());
            pw.MakePayBro();
            Console.WriteLine("Hello World!");
        }
    }

    public abstract class PayStrategy
    {
        public abstract void MakePay();
    }

    public class CreditCard : PayStrategy
    {
        public override void MakePay()
        {
            Console.WriteLine("Kredi kartıyla ödendi");
        }
    }


    public class HomePay : PayStrategy
    {
        public override void MakePay()
        {
            Console.WriteLine("Üretim ");
        }
    }

    public class PayWrapper
    {
        private readonly PayStrategy _strategy;

        public PayWrapper(PayStrategy strategy)
        {
            _strategy = strategy;
        }

        public void MakePayBro()
        {
            _strategy.MakePay();
        }
    }



}
