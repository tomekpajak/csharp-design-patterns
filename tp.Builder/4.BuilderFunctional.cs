using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace tp.Builder
{
    class PizzaWithPrice
    {
        public DoughType Dough { get; set; }
        public SauceType Sauce { get; set; }
        public IList<IngredientsType> Ingredients { get; set; }
        public decimal Price { get; set; }
        public PizzaWithPrice() => this.Ingredients = new List<IngredientsType>();

        public override string ToString() =>
            new StringBuilder()
                .AppendLine(String.Join(',', Ingredients.Select<IngredientsType, string>(i => i.ToString())))
                .AppendLine(Sauce.ToString())
                .AppendLine(Dough.ToString())
                .AppendLine()
                .ToString();
    }
    class BuilderFunctional
    {
        public readonly List<Action<PizzaWithPrice>> Actions = new List<Action<PizzaWithPrice>>();

        public PizzaWithPrice Build()
        {
            var pizza = new PizzaWithPrice();
            Actions.ForEach(action => action(pizza));
            return pizza;
        }
        public BuilderFunctional WithDough(DoughType dough)
        {
            Actions.Add(pizza => pizza.Dough = dough);
            return this;
        }
        public BuilderFunctional WithSauce(SauceType sauce)
        {
            Actions.Add(pizza => pizza.Sauce = sauce);
            return this;
        }
        public BuilderFunctional WithIngredient(IngredientsType ingredient)
        {
            Actions.Add(pizza => pizza.Ingredients.Add(ingredient));
            return this;
        }

    }

    static class BuilderFunctionalPriceExtension
    {
        public static BuilderFunctional Price(this BuilderFunctional builder, decimal price)
        {
            builder.Actions.Add(pizza => pizza.Price = price);
            return builder;
        }
    }
}
