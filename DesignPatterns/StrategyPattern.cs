using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatterns
{
    public class StrategyPattern
    {
        public class Product
        {
            public string Name { get; set; }

            public decimal Price { get; set; }

            public int Quantity { get; set; }

            public IPromotion Promotion { get; set; }

            public void SetPromotion(IPromotion promotion)
            {
                Promotion = promotion;
            }

            public decimal CalculateDiscount()
            {
                return Promotion.Calculate(this);
            }
        }

        public interface IPromotion
        {
            decimal Calculate(Product product);
        }

        public class PriceReduction : IPromotion
        {
            public PriceReduction(int percentage)
            {
                Percentage = percentage;
            }

            public int Percentage { get; }

            //10% discount
            public decimal Calculate(Product product)
            {
                return product.Price - (product.Price * Percentage / 100);
            }
        }

        public class XForY : IPromotion
        {
            public XForY(int quantity, decimal forPrice)
            {
                Quantity = quantity;
                ForPrice = forPrice;
            }

            public int Quantity { get; }

            public decimal ForPrice { get; }


            public decimal Calculate(Product product)
            {
                var divided = product.Quantity / Quantity;

                if (divided == 0)
                    return product.Price * product.Quantity;

                var rest = product.Quantity - divided * Quantity;

                return ForPrice * divided + product.Price * rest;
            }
        }
    }
}
