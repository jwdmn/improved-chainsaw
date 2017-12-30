using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication3
{
  public class Episode
  {
    public int? Id { get; set; }
    [NotMapped]
    public Uri Url { get; set; }
    public string Name { get; set; }
    public int Season { get; set; }
    public int Number { get; set; }
    public DateTime? Airdate { get; set; }
    public DateTimeOffset? Airstamp { get; set; }
    public int Runtime { get; set; }
    public Image Image { get; set; }
    public string Summary { get; set; }
  }
}