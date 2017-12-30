using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication3
{
  [NotMapped]
  public class EmbeddedItems
  {
    public Episode[] Episodes { get; set; }
  }
}