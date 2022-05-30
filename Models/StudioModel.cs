namespace MvcMovie.Models
{
  public class Studio
  {
    public int? StudioID { get; set; }
    public string Name { get; set; }

    public ICollection<Movie>? Movies { get; set; }
  }
}
