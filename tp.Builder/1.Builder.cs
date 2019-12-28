using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace tp.Builder
{

    interface IPizzaBuilder
    {
        void AddDough();
        void AddSouce();
        void AddIngredient();
        PizzaProduct Build();
    }

    class MargaritaPizzaBuilder : IPizzaBuilder
    {
        private PizzaProduct pizza;
        public MargaritaPizzaBuilder() => this.pizza = new PizzaProduct();
        public void AddDough()
        {
            pizza.Dough = DoughType.thick;
        }
        public void AddIngredient()
        {
            pizza.Ingredients.Add(IngredientsType.cheese);
        }

        public void AddSouce()
        {
            pizza.Sauce = SauceType.tomato;
        }

        public PizzaProduct Build() => pizza;
    }

    class CapricossaPizzaBuilder : IPizzaBuilder
    {
        private PizzaProduct pizza;
        public CapricossaPizzaBuilder() => this.pizza = new PizzaProduct();
        public void AddDough()
        {
            pizza.Dough = DoughType.thin;
        }
        public void AddIngredient()
        {
            pizza.Ingredients.Add(IngredientsType.cheese);
            pizza.Ingredients.Add(IngredientsType.ham);
            pizza.Ingredients.Add(IngredientsType.mushrooms);
        }
        public void AddSouce()
        {
            pizza.Sauce = SauceType.garlic;
        }
        public PizzaProduct Build() => pizza;
    }

    class CookDirector
    {
        private IPizzaBuilder pizzaBuilder;
        public CookDirector(IPizzaBuilder pizzaBuilder)
        {
            this.pizzaBuilder = pizzaBuilder;
        }
        public void MakePizza()
        {
            pizzaBuilder.AddDough();
            pizzaBuilder.AddSouce();
            pizzaBuilder.AddIngredient();
        }
        public PizzaProduct GetPizza() => pizzaBuilder.Build();
    }

    public static class HelperBuilder
    {
        public static void Call()
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
    }
}
