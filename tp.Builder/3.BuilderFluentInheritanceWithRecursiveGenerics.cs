using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace tp.Builder
{
    class Pizza
    {
        public DoughType Dough { get; set; }
        public SauceType Sauce { get; set; }
        public IList<IngredientsType> Ingredients { get; set; }

        public Pizza() => this.Ingredients = new List<IngredientsType>();

        public override string ToString() =>
            new StringBuilder()
                .AppendLine(String.Join(',', Ingredients.Select<IngredientsType, string>(i => i.ToString())))
                .AppendLine(Sauce.ToString())
                .AppendLine(Dough.ToString())
                .AppendLine()
                .ToString();

        public class Builder : PizzaIngredientBuilder<Builder>
        {
            internal Builder() { }
        }

        public static Builder New => new Builder();
    }

    abstract class PizzaBuilder
    {
        protected Pizza pizza = new Pizza();

        public Pizza Build()
        {
            return pizza;
        }
    }

    class PizzaDoughBuilder<T> : PizzaBuilder
        where T : PizzaDoughBuilder<T>
    {
        public T WithDough(DoughType dough)
        {
            pizza.Dough = dough;
            return (T)this;
        }
    }

    class PizzaSauceBuilder<T> : PizzaDoughBuilder<PizzaSauceBuilder<T>>
        where T : PizzaSauceBuilder<T>
    {
        public T WithSauce(SauceType sauce)
        {
            pizza.Sauce = sauce;
            return (T)this;
        }
    }

    class PizzaIngredientBuilder<T> : PizzaSauceBuilder<PizzaIngredientBuilder<T>>
        where T : PizzaIngredientBuilder<T>
    {
        public T WithIngredient(IngredientsType ingredient)
        {
            pizza.Ingredients.Add(ingredient);
            return (T)this;
        }
    }
}
