using CodeCool.SeasonalProductDiscounter.Model.Discounts;
using CodeCool.SeasonalProductDiscounter.Model.Offers;
using CodeCool.SeasonalProductDiscounter.Model.Products;

namespace CodeCool.SeasonalProductDiscounter.Service.Discounts;

public class DiscounterService:IDiscounterService
{
    public Offer GetOffer(Product product, DateTime date)
    {
        IDiscountProvider discountProvider = new DiscountProvider();
        List<IDiscount> availableDiscounts = new List<IDiscount>();
        double price = product.Price;
      
        foreach (var discount in discountProvider.Discounts)
        {
            if (discount.Accepts(product, date))
            {
                availableDiscounts.Add(discount);
                price-= price*(discount.Rate/100);
                
                Console.WriteLine(discount.Rate);
            }
        }

        return new Offer(product, date, availableDiscounts, price);

    }
}