using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AngularMVC.DB;
using Newtonsoft.Json;
using AngularMVC.Models;

namespace AngularMVC.Controllers
{
    public class ArtistController : Controller
    {
        private MusicContext context = new MusicContext();
        // GET: Artist
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ContentResult GetArtists()
        {
            var artists = context.Artists.Include("Albums.Tracks").ToList();
            var list = JsonConvert.SerializeObject(artists, Formatting.None, new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
            return Content(list, "application/json");
        }

        public string InsertArtist(Artist artist)
        {
            if(artist != null)
            {
                using (context)
                {
                    context.Artists.Add(artist);
                    context.SaveChanges();
                    return "Artist successfully added!";
                }
            }
            else
            {
                return "Error inserting artist. Please try again.";
            }
        }
    }
}