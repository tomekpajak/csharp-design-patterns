using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace tp.Builder
{
    enum DoughType { thin, thick }
    enum SauceType { tomato, garlic }
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
}