using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WebApplication3.Models.ViewModels;

namespace WebApplication3
{

  public class ApiHandler
  {
    public SearchResultViewModel[] SearchForShow(string searchString)
    {
      HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://api.tvmaze.com/search/shows?q=" + searchString);
      string responseString = string.Empty;

      try
      {
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        if (response.StatusCode == HttpStatusCode.OK)
        {
          Stream stream = response.GetResponseStream();
          StreamReader reader = new StreamReader(stream);

          responseString = reader.ReadToEnd();
          reader.Close();
          response.Close();
        }
      }
      catch (Exception exception)
      {
        responseString = exception.Message;
        //throw;
      }

      SearchResultViewModel[] searchResults = JsonConvert.DeserializeObject<SearchResultViewModel[]>(responseString);
      return searchResults;
    }

    public Episode[] GetEmbeddedEpisodes(int id)
    {
      HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://api.tvmaze.com/shows/" + id + "/episodes");
      string responseString = string.Empty;

      try
      {
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        if (response.StatusCode == HttpStatusCode.OK)
        {
          Stream stream = response.GetResponseStream();
          StreamReader reader = new StreamReader(stream);

          responseString = reader.ReadToEnd();
          reader.Close();
          response.Close();
        }
      }
      catch (Exception exception)
      {
        responseString = exception.Message;
        //throw;
      }

      Episode[] episodes = JsonConvert.DeserializeObject<Episode[]>(responseString);
      return episodes;
    }

    public Episode[] GetShowsEpisodes(int id)
    {
      HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://api.tvmaze.com/shows/" + id + "/episodes");
      string responseString = string.Empty;

      try
      {
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        if (response.StatusCode == HttpStatusCode.OK)
        {
          Stream stream = response.GetResponseStream();
          StreamReader reader = new StreamReader(stream);

          responseString = reader.ReadToEnd();
          reader.Close();
          response.Close();
        }
      }
      catch (Exception exception)
      {
        responseString = exception.Message;
        //throw;
      }

      Episode[] episodes = JsonConvert.DeserializeObject<Episode[]>(responseString);
      return episodes;

    }

    public TvShow GetTvShowAndEpisodeDetails(int id)
    {
      HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"http://api.tvmaze.com/shows/{id}?embed=episodes");
      string responseString = string.Empty;

      try
      {
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        if (response.StatusCode == HttpStatusCode.OK)
        {
          Stream stream = response.GetResponseStream();
          StreamReader reader = new StreamReader(stream);

          responseString = reader.ReadToEnd();
          reader.Close();
          response.Close();
        }
      }
      catch (Exception exception)
      {
        responseString = exception.Message;
        //throw;
      }

      TvShow tvShow = JsonConvert.DeserializeObject<TvShow>(responseString);
      return tvShow;
    }

    public Episode GetLatestEpisode(int? id)
    {
      HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://api.tvmaze.com/shows/" + id + "/episodes");
      string responseString = string.Empty;

      try
      {
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        if (response.StatusCode == HttpStatusCode.OK)
        {
          Stream stream = response.GetResponseStream();
          StreamReader reader = new StreamReader(stream);

          responseString = reader.ReadToEnd();
          reader.Close();
          response.Close();
        }
      }
      catch (Exception exception)
      {
        responseString = exception.Message;
        //throw;
      }

      Episode[] episodes = JsonConvert.DeserializeObject<Episode[]>(responseString);
      return episodes[episodes.Length - 1];
    }

    public bool CheckIfReleasedToday(int? id)
    {
      Episode e = GetLatestEpisode(id);
      if (e.Airdate.Value.ToShortDateString().Equals(DateTime.Now.ToShortDateString()))
        return true;
      else
        return false;
    }

    public bool CheckIfAnyEpisodeReleasedToday(int? id)
    {
      bool releasedToday = false;
      Episode[] episodes = GetShowsEpisodes((int)id);

      foreach (var episode in episodes)
      {
        if (episode.Airdate.HasValue)
        {

          if (episode.Airdate.Value.ToShortDateString().Equals(DateTime.Now.ToShortDateString()))
            releasedToday = true;
        }
      }

      return releasedToday;
    }
  }
}
