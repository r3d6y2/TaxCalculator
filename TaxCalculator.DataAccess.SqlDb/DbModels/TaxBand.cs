namespace TaxCalculator.DataAccess.SqlDb.DbModels;

public class TaxBand
{
    public TaxBand()
    {
        
    }

    public TaxBand(int id, string name, int lowRange, int highRange, int range, bool isActive)
    {
        Id = id;
        Name = name;
        LowRange = lowRange;
        HighRange = highRange;
        Range = range;
        IsActive = isActive;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public int LowRange { get; set; }
    public int HighRange { get; set; }
    public int Range { get; set; }
    public bool IsActive { get; set; }
}