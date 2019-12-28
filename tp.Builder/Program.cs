using System;
using System.Collections.Generic;
using System.Text;
using tp.Builder.fluent;

namespace tp.Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1. Using builder...");
            HelperBuilder.Call();

            Console.WriteLine("2. Using fluent builder");
            HelperBuilderFluent.Call();

            Console.WriteLine("3. Using fluent builder with inheritance with recursive generics");
            var pizza = Pizza.New
                             .WithDough(DoughType.thick)
                             .WithSauce(SauceType.tomato)
                             .WithIngredient(IngredientsType.cheese)
                             .WithIngredient(IngredientsType.ham)
                             .Build();
            Console.WriteLine(pizza.ToString());

            Console.WriteLine("4. Using functional builder");
            var pizzaBuilderFunctional = new BuilderFunctional();
            var pizza2 = pizzaBuilderFunctional.WithDough(DoughType.thick)
                                               .WithSauce(SauceType.garlic)
                                               .WithIngredient(IngredientsType.cheese)
                                               .WithIngredient(IngredientsType.mushrooms)
                                               .Price(10.1m)
                                               .Build();
            Console.WriteLine(pizza2.ToString());

            Console.WriteLine("5. Using faceted builder");
            var pizzaBuilderFaceted = new PizzaBuilderFaceted();
            PizzaWithSize pizza3 = pizzaBuilderFaceted.Dough
                                                          .Size(SizeType.big)
                                                          .WithDough(DoughType.thick)
                                                      .Composition
                                                          .WithIngredient(IngredientsType.cheese)
                                                          .WithIngredient(IngredientsType.ham)
                                                          .WithSauce(SauceType.garlic);
            Console.WriteLine(pizza3.ToString());
        }
    }
}
