namespace EfInheritance.Domain;

public class Policy
{
    public int Id { get; set; }

    public string Title { get; set; }

    public DateTime EffectionDate { get; set; }

    public DateTime EndDate { get; set; }

    public decimal CoveringAmount { get; set; }
}
