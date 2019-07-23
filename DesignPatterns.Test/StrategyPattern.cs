using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using static DesignPatterns.StrategyPattern;

namespace DesignPatterns.Test
{
    public class StrategyPattern
    {
        [Fact]
        public void PriceReduction_Ten_Percent_Return_Price_With_Discount()
        {
            Product product = new Product
            {
                Price = 100
            };

            product.SetPromotion(new PriceReduction(10));
            var priceDescount = product.CalculateDiscount();

            priceDescount.Should().Be(90);
        }

        [Fact]
        public void XForY_Calculate_One_X_Return_Discount()
        {
            Product product = new Product
            {
                Price = 2,
                Quantity = 5
            };

            product.SetPromotion(new XForY(5, 10));
            var priceDescount = product.CalculateDiscount();

            priceDescount.Should().Be(10);
        }


        [Fact]
        public void XForY_Calculate_Two2_X_Return_Discount()
        {
            Product product = new Product
            {
                Price = 2,
                Quantity = 10
            };

            product.SetPromotion(new XForY(5, 10));
            var priceDescount = product.CalculateDiscount();

            priceDescount.Should().Be(20);
        }


        [Fact]
        public void XForY_Calculate_2_Half_X_Return_Discount()
        {
            Product product = new Product
            {
                Price = 2,
                Quantity = 12
            };

            product.SetPromotion(new XForY(5, 10));
            var priceDescount = product.CalculateDiscount();

            priceDescount.Should().Be(24);
        }    }
}
