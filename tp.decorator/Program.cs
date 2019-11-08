using System;

namespace tp.Decorator
{
    interface IPizza
    {
        decimal GetCost();
    }
    class BasicPizza : IPizza
    {
        public decimal GetCost() => 5m;
    }
    class HamDecorator : IPizza
    {
        private IPizza decoratedPizza;
        public HamDecorator(IPizza decoratedPizza) => this.decoratedPizza = decoratedPizza;
        public decimal GetCost() => decoratedPizza.GetCost() + 3m;
    }
    class MushroomsDecorator : IPizza
    {
        private IPizza decoratedPizza;
        public MushroomsDecorator(IPizza decoratedPizza) => this.decoratedPizza = decoratedPizza;
        public decimal GetCost() => decoratedPizza.GetCost() + 2.5m;
    }

    class LogDecorator : IPizza
    {
        private IPizza decoratedPizza;
        public LogDecorator(IPizza decoratedPizza) => this.decoratedPizza = decoratedPizza;
        public decimal GetCost()
        {
            var cost = decoratedPizza.GetCost();
            Console.WriteLine($"{decoratedPizza.GetType().Name} {cost}");
            return cost;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IPizza myPizza = new MushroomsDecorator(new HamDecorator(new BasicPizza()));
            Console.WriteLine(myPizza.GetCost());

            IPizza myPizzaWithLog = new LogDecorator(new BasicPizza());
            myPizzaWithLog = new LogDecorator(new HamDecorator(myPizzaWithLog));
            myPizzaWithLog = new LogDecorator(new MushroomsDecorator(myPizzaWithLog));
        }
    }
}
