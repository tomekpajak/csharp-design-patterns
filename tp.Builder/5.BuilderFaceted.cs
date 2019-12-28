using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace tp.Builder
{
    enum SizeType { small, big };
    class PizzaWithSize
    {
        public DoughType Dough { get; set; }
        public SizeType Size { get; set; }
        public SauceType Sauce { get; set; }
        public IList<IngredientsType> Ingredients { get; set; }

        public PizzaWithSize() => this.Ingredients = new List<IngredientsType>();

        public override string ToString() =>
            new StringBuilder()
                .AppendLine(String.Join(',', Ingredients.Select<IngredientsType, string>(i => i.ToString())))
                .AppendLine(Sauce.ToString())
                .AppendLine(Dough.ToString())
                .AppendLine()
                .ToString();
    }

    class PizzaBuilderFaceted
    {
        protected PizzaWithSize pizza = new PizzaWithSize();

        public static implicit operator PizzaWithSize(PizzaBuilderFaceted builder) => builder.pizza;

        public PizzaBuilderDough Dough => new PizzaBuilderDough(pizza);
        public PizzaBuilderComposition Composition => new PizzaBuilderComposition(pizza);
    }

    class PizzaBuilderDough : PizzaBuilderFaceted
    {
        public PizzaBuilderDough(PizzaWithSize pizza) => this.pizza = pizza;

        public PizzaBuilderDough WithDough(DoughType dough)
        {
            pizza.Dough = dough;
            return this;
        }

        public PizzaBuilderDough Size(SizeType size)
        {
            pizza.Size = size;
            return this;
        }
    }

    class PizzaBuilderComposition : PizzaBuilderFaceted
    {
        public PizzaBuilderComposition(PizzaWithSize pizza) => this.pizza = pizza;

        public PizzaBuilderComposition WithIngredient(IngredientsType ingredient)
        {
            pizza.Ingredients.Add(ingredient);
            return this;
        }
        public PizzaBuilderComposition WithSauce(SauceType sauce)
        {
            pizza.Sauce = sauce;
            return this;
        }

    }
}
