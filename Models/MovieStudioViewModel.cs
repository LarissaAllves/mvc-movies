using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;


namespace MvcMovie.Models
{
  public class MovieStudioViewModel
  {
    public SelectList? StudioSelectList { get; set; }
    public Movie? Movie { get; set; }
  }
}