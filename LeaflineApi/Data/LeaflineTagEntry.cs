namespace LeaflineApi.Data
{
  public class LeaflineTagEntry : LeaflineEntity
  {

    public Guid TagEntryId { get; set; }

    public Guid TaggedObjectId { get; set; }

    public Guid TagId { get; set; }

  }
}