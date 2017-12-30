using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication3.Models.ViewModels
{
  public class SearchResultViewModel
  {
    public float? Score { get; set; }
    public TvShow Show { get; set; }
  }
}
