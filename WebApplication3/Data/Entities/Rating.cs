using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication3
{
  [NotMapped]
  public class Rating
  {
    public double? average { get; set; }
  }
}