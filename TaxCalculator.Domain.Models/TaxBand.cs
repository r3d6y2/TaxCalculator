namespace TaxCalculator.Domain.Models;

public class TaxBand
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int LowRange { get; set; }
    public int HighRange { get; set; }
    public int Range { get; set; }
    public bool IsActive { get; set; }

    public TaxBand(string name, int lowRange, int highRange, int range)
    {
        Name = name;
        LowRange = lowRange;
        HighRange = highRange;
        Range = range;
    }
}