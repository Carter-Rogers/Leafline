namespace LeaflineApi.Data
{
  public class LeaflineQuery
  {

    public string? Name {get; set;}

    public string? UniqueId { get; set; }

    public int? Id { get; set; }

    public string? OwnerId { get; set; }

    public DateOnly? CreatedOn { get; set; }

    public DateOnly? ModifiedOn { get; set; }

  }
}
