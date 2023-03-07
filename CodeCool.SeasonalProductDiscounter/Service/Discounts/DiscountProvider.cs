using CodeCool.SeasonalProductDiscounter.Model.Discounts;
using CodeCool.SeasonalProductDiscounter.Model.Enums;
using CodeCool.SeasonalProductDiscounter.Model.Products;

namespace CodeCool.SeasonalProductDiscounter.Service.Discounts;

public class DiscountProvider:IDiscountProvider
{
    public IEnumerable<IDiscount> Discounts { get; }

    public DiscountProvider()
    {
        Discounts = new List<IDiscount>
        {
            new OutletDiscount(),
            new BlueWinterDiscount(),
            new SalesDiscount(),
            new WinterSalesDiscount(),
            new BrownAutumnDiscount(),
            new GreenSpringDiscount(),
            new SummerKickoffDiscount(),
            new YellowSummerDiscount(),


        };
    }

     
    public static Season GetSeason(DateTime date)
    {
        if (date.Month is 12 or 1 or 2)
            return Season.Winter;
        if (date.Month is 3 or 4 or 5)
            return Season.Spring;
        if (date.Month is 6 or 7 or 8)
            return Season.Summer;

        return Season.Autumn;

    } 

public class SummerKickoffDiscount : IDiscount
{
    public override bool Accepts(Product product, DateTime date)
    {
        return GetSeason(date) == Season.Summer && product.Season == Season.Summer;
    }

    public string Name => "Summer Kick-off Discount";
    public int Rate => 10;
}
public class WinterSalesDiscount : IDiscount
{
    public override bool Accepts(Product product, DateTime date)
    {
        return GetSeason(date) == Season.Winter && product.Season == Season.Winter;
    }

    public override string Name => "Winter Sale Discount";
    public override int Rate => 10;
}

public class BlueWinterDiscount : IDiscount
{
    public override bool Accepts(Product product, DateTime date)
    {
        return GetSeason(date) == Season.Winter && product.Season == Season.Winter && product.Color==Color.Blue;
    }

    public string Name => "Blue Winter Discount";
    public int Rate => 5;
}

public class GreenSpringDiscount : IDiscount
{
    public override bool Accepts(Product product, DateTime date)
    {
        return GetSeason(date) == Season.Spring && product.Season == Season.Spring && product.Color == Color.Green;
    }

    public override string Name => "Green Spring Discount";
    public override int Rate => 5;
}

public class YellowSummerDiscount : IDiscount
{
    public override bool Accepts(Product product, DateTime date)
    {
        return GetSeason(date) == Season.Summer && product.Season == Season.Summer && product.Color==Color.Yellow;
    }

    public override string Name => "Yellow Summer Discount";
    public override int Rate => 5;
}

public class BrownAutumnDiscount : IDiscount
{
    public override bool Accepts(Product product, DateTime date)
    {
        return GetSeason(date) == Season.Autumn && product.Season == Season.Autumn && product.Color==Color.Brown;
    }

    public override string Name => "Brown Autumn Discount";
    public override int Rate => 5;
    
}

public class SalesDiscount : IDiscount
{
    public Season GetPrevSeason(Season season)
    {
        switch (season)
        {
            case Season.Autumn:
                return Season.Summer;
            case Season.Winter:
                return Season.Autumn;
            case Season.Spring:
                return Season.Winter;
           
        }

        return Season.Spring;
    }
    public override bool Accepts(Product product, DateTime date)
    {
        return GetPrevSeason(GetSeason(date))==product.Season;
    }
    public override string Name => "Sale Discount";
    public override int Rate => 10;
    
}

public class OutletDiscount : IDiscount
{
    public Season GetOutletSeason(Season season)
    {
        switch (season)
        {
            case Season.Autumn:
                return Season.Spring;
            case Season.Winter:
                return Season.Summer;
            case Season.Spring:
                return Season.Autumn;
           
        }

        return Season.Winter;
    }

    public override bool Accepts(Product product, DateTime date)
    {
        return GetOutletSeason(GetSeason(date)) == product.Season;
    }

    public override string Name => "Outlet Discount";
    public override int Rate => 10;
}
}
