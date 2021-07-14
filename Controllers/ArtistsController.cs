using System;
using System.Collections.Generic;
using Artists.Models;
using Artists.Services;
using Microsoft.AspNetCore.Mvc;

namespace Artists.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ArtistsController : ControllerBase
  {
    private readonly ArtistsService _arts;

    public ArtistsController(ArtistsService arts)
    {
      _arts = arts;
    }


    [HttpGet]
    public ActionResult<List<Artist>> GetArtists()
    {
      try
      {
        List<Artist> artists = _arts.GetAll();
        return Ok(artists);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPost]
    public ActionResult<Artist> CreateArtist([FromBody] Artist artistData)
    {
      try
      {
        var artist = _arts.CreateArtist(artistData);
        return Created($"api/artists/{artist.Id}", artist);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }


  }
}