namespace LeaflineApi.Data
{
  public class LeaflineUser : LeaflineEntity
  {
    
    public Guid? UserId { get; set;  }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string PasswordHash { get; set; }

  }
}
