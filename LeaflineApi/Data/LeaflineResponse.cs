namespace LeaflineApi.Data
{
  public class LeaflineResponse
  {

    public string? Message { get; set; }

    public dynamic? Content { get; set; }

    public bool? isSuccess { get; set; } = false;

  }
}
