namespace EfInheritance.Domain;

public class Endorsement : Policy
{
    public DateTime EndorsementRegsterDate { get; set; }

    public DateTime EndorsementEffectionDate { get; set; }

    public DateTime EndorsementEndDate { get; set; }

    public decimal EndorsementCoveringAmount { get; set; }
}