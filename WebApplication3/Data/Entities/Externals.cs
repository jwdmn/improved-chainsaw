using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication3
{
  [NotMapped]
  public class Externals
  {
    public string Imdb { get; set; }
    public int? Tvrage { get; set; }
    public int? Thetvdb { get; set; }
  }
}