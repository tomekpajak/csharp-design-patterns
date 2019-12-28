using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace tp.Builder.fluent
{
    //Example of fluent builder
    //StringBuilder sb = new StringBuilder();
    //sb.Append <- public StringBuilder Append(bool value);

    interface IPizzaBuilderFluent
    {
        IPizzaBuilderFluent AddDough();
        IPizzaBuilderFluent AddSouce();
        IPizzaBuilderFluent AddIngredient();
        PizzaProduct Build();
    }

    class MargaritaPizzaBuilderFluent : IPizzaBuilderFluent
    {
        private PizzaProduct pizza;
        public MargaritaPizzaBuilderFluent() => this.pizza = new PizzaProduct();
        public IPizzaBuilderFluent AddDough()
        {
            pizza.Dough = DoughType.thick;
            return this;
        }
        public IPizzaBuilderFluent AddIngredient()
        {
            pizza.Ingredients.Add(IngredientsType.cheese);
            return this;
        }
        public IPizzaBuilderFluent AddSouce()
        {
            pizza.Sauce = SauceType.tomato;
            return this;
        }
        public PizzaProduct Build() => pizza;
    }

    class CapricossaPizzaBuilderFluent : IPizzaBuilderFluent
    {
        private PizzaProduct pizza;
        public CapricossaPizzaBuilderFluent() => this.pizza = new PizzaProduct();
        public IPizzaBuilderFluent AddDough()
        {
            pizza.Dough = DoughType.thin;
            return this;
        }
        public IPizzaBuilderFluent AddIngredient()
        {
            pizza.Ingredients.Add(IngredientsType.cheese);
            pizza.Ingredients.Add(IngredientsType.ham);
            pizza.Ingredients.Add(IngredientsType.mushrooms);
            return this;
        }
        public IPizzaBuilderFluent AddSouce()
        {
            pizza.Sauce = SauceType.garlic;
            return this;
        }
        public PizzaProduct Build() => pizza;
    }

    class CookDirectorFluent
    {
        private IPizzaBuilderFluent pizzaBuilder;
        public CookDirectorFluent(IPizzaBuilderFluent pizzaBuilder)
        {
            this.pizzaBuilder = pizzaBuilder;
        }
        public void MakePizza()
        {
            pizzaBuilder
                .AddDough()
                .AddSouce()
                .AddIngredient();
        }
        public PizzaProduct GetPizza() => pizzaBuilder.Build();
    }

    public static class HelperBuilderFluent
    {
        public static void Call()
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
    }
}
