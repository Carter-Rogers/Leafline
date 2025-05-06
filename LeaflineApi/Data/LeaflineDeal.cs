namespace LeaflineApi.Data
{
  public class LeaflineDeal : LeaflineEntity
  {
    public Guid DealId { get; set; }

    public Guid DealOwner { get; set; } //GUID of the Leafline Dispensary where this deal is located

    public string Description { get; set; }

    public string Title { get; set; }
    
    public DateOnly BeginDate { get; set; }

    public DateOnly EndDate { get; set; }

  }
}
