using CodeCool.SeasonalProductDiscounter.Model.Enums;
namespace CodeCool.SeasonalProductDiscounter.Model.Discounts;
using CodeCool.SeasonalProductDiscounter.Model.Products;
using System;
public class ColorDiscount: IDiscount
{
    public ColorDiscount(int rate, Color color)
    {
        Rate = rate;
        Color = color;
    }

    public override int Rate { get; }

    public Color Color { get; }
    public override string Name => $"Color discount ({Rate}) off";

    public override bool Accepts(Product product, DateTime date)
    {
        return product.Color == Color;
    }

    public override string ToString()
    {
        return $"{nameof(ColorDiscount)}: " +
               $"{nameof(Rate)}={Rate}, " +
               $"{nameof(Color)}={Color}";
    }
}

public class MonthlyDiscount: IDiscount
{
    public MonthlyDiscount(int rate, Month month)
    {
        Rate = rate;
        Month = month;
    }
    public override int Rate { get; }
    public Month Month { get; }
    
    public override string Name => $"Month discount ({Rate}) off";

    public override bool Accepts(Product product, DateTime date)
    {
        return date.Month ==  (int)Month;
    }
        
    public override string ToString()
    {
        return $"{nameof(MonthlyDiscount)}: " +
               $"{nameof(Rate)}={Rate}, " +
               $"{nameof(Month)}={Month}";
    }
    
}