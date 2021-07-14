using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Artists.Models;
using Dapper;

namespace Artists.Data
{
  public class ArtistsRepository
  {
    // REVIEW this connection for further understanding
    private readonly IDbConnection _db;
    public ArtistsRepository(IDbConnection db)
    {
      _db = db;
    }

    //  ----- Heres the sql requests to the database ------
    public List<Artist> GetAll()
    {
      string sql = "SELECT * FROM artists";
      return _db.Query<Artist>(sql).ToList();
    }

    public Artist CreateArtist(Artist artistData)
    {
      var sql = @"
      INSERT INTO artists(name)
      VALUES(@name)
      SELECT_LAST_INSERT_ID();
      ";

      int id = _db.ExecuteScalar<int>(sql, artistData);
      artistData.Id = id;
      return artistData;
    }
  }
}