using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication3
{
  [NotMapped]
  public class Image
  {
    public Uri Medium { get; set; }
    public Uri Original { get; set; }
  }
}