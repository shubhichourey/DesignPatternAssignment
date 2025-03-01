using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    public interface IInvestor
    {
        void Update(string stock, double price);
    }
    public class Stock
    {
        private readonly List<IInvestor> investors = new List<IInvestor>();
        private double price;
        public string Symbol { get; }

        public Stock(string symbol, double prices)
        {
            Symbol = symbol;
            price = prices;
        }

        public void Attach(IInvestor investor) => investors.Add(investor);
        public void Detach(IInvestor investor) => investors.Remove(investor);

        public void SetPrice(double prices)
        {
            price = prices;
            Notify();
        }

        private void Notify()
        {
            foreach (var investor in investors)
            {
                investor.Update(Symbol, price);
            }
        }
    }

    public class Investor : IInvestor
    {
        private readonly string name;
        public Investor(string names) => name = names;

        public void Update(string stock, double price)
        {
            Console.WriteLine($"{name} notified: {stock} is now ${price}");
        }
    }
    class Program
    {
        static void Main()
        {
            Stock appleStock = new Stock("Apple", 150.00);
            Stock SamsungStock = new Stock("Samsung", 150.00);

            Investor investor1 = new Investor("Alice");
            Investor investor2 = new Investor("Bob");

            appleStock.Attach(investor1);
            appleStock.Attach(investor2);

            appleStock.Detach(investor1);
            
            SamsungStock.Attach(investor1);
            SamsungStock.Attach(investor2);

            SamsungStock.Detach(investor2);

            Console.WriteLine("Updating stock price...");
            appleStock.SetPrice(155.55);
            SamsungStock.SetPrice(188.75);
        }
    }
}
