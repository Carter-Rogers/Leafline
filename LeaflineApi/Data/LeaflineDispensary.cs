using Microsoft.EntityFrameworkCore;

namespace LeaflineApi.Data
{
  public class LeaflineDispensary : LeaflineEntity
  {

    public Guid DispensaryId { get; set; } //the GUID of the Leafline Dispensary

    public string Name { get; set; }

    public DateOnly JoinDate { get; set; } //The Dispensary's Original Sign-Up Day (Sprout Day!)

    public Guid OwnerId { get; set; } //the GUID of the Leafline user who owns this dispensary.

    public string Address { get; set; }

    public string City { get; set; }

    public string State { get; set; }

    public string Zip { get; set; }

    public string Country { get; set; }




  }
}