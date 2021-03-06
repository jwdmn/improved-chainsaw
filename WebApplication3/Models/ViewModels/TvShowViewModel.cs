﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication3.Models.ViewModels
{
  public class TvShowViewModel : IEnumerable
  {
    public string SearchQuery { get; set; }
    public SearchResultViewModel[] SearchResults { get; set; }

    public IEnumerator GetEnumerator()
    {
      return this.GetEnumerator();
    }
  }
}
