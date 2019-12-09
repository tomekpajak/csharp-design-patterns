using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace tp.Builder
{
    enum DoughType { thin, thick }
    enum SauceType { tomato, garlic}
    enum IngredientsType { ham, mushrooms, cheese }

    class PizzaProduct
    {
        public DoughType Dough { get; set; }
        public SauceType Sauce { get; set; }
        public IList<IngredientsType> Ingredients { get; set; }
     
        public PizzaProduct() => this.Ingredients = new List<IngredientsType>();

        public override string ToString() =>
            new StringBuilder()
                .AppendLine(String.Join(',', Ingredients.Select<IngredientsType, string>(i => i.ToString())))
                .AppendLine(Sauce.ToString())
                .AppendLine(Dough.ToString())
                .AppendLine()
                .ToString();
    }

    class Program
    {
        static void UseBuilder()
        {
            PizzaProduct pizza = null;
            CookDirector cook = null;

            IPizzaBuilder margaritaPizzaBuilder = new MargaritaPizzaBuilder();
            IPizzaBuilder capricossaPizzaBuilder = new CapricossaPizzaBuilder();

            Console.WriteLine("margarita builder...");
            cook = new CookDirector(margaritaPizzaBuilder);
            cook.MakePizza();
            pizza = cook.GetPizza();
            Console.WriteLine(pizza.ToString());

            Console.WriteLine("capricossa builder...");
            cook = new CookDirector(capricossaPizzaBuilder);
            cook.MakePizza();
            pizza = cook.GetPizza();
            Console.WriteLine(pizza.ToString());
        }

        static void UseBuilderFluent()
        {
            PizzaProduct pizza = null;
            CookDirectorFluent cook = null;

            IPizzaBuilderFluent margaritaPizzaBuilderFluent = new MargaritaPizzaBuilderFluent();
            IPizzaBuilderFluent capricossaPizzaBuilderFluent = new CapricossaPizzaBuilderFluent();

            Console.WriteLine("margarita fluent builder...");
            cook = new CookDirectorFluent(margaritaPizzaBuilderFluent);
            cook.MakePizza();
            pizza = cook.GetPizza();
            Console.WriteLine(pizza.ToString());

            Console.WriteLine("capricossa fluent builder...");
            cook = new CookDirectorFluent(capricossaPizzaBuilderFluent);
            cook.MakePizza();
            pizza = cook.GetPizza();
            Console.WriteLine(pizza.ToString());
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Using builder...");
            UseBuilder();

            Console.WriteLine("Using fluent builder");
            UseBuilderFluent();
        }
    }
}
