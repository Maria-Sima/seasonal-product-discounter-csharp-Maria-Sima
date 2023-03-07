using CodeCool.SeasonalProductDiscounter.Model.Products;
using CodeCool.SeasonalProductDiscounter.Service.Discounts;
using CodeCool.SeasonalProductDiscounter.Service.Products;
using CodeCool.SeasonalProductDiscounter.Ui;

namespace CodeCool.SeasonalProductDiscounter
{
    class Program
    {
        static void Main(string[] args)
        {
            IProductProvider productProvider = new ProductProvider();
            IDiscountProvider discountProvider = new DiscountProvider();
            IDiscounterService discounterService = new DiscounterService();
            SeasonalProductDiscounterUi ui =
                new SeasonalProductDiscounterUi(productProvider, discountProvider, discounterService);
            ui.Run();
        }


    }
}