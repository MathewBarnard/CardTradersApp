using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MoviesTutorial.Models;
using System.Threading.Tasks;

namespace MoviesTutorial.Controllers
{
    public class CardsController : Controller
    {
        private CardTradersDBContext db = new CardTradersDBContext();

        // GET: Cards
        public ActionResult Index()
        {
            return View(db.Cards.ToList());
        }

        public ActionResult Search(string searchTerm) {

            var cards = from results in db.Cards
                               where results.Name.Contains(searchTerm)
                               select results;
        
            return View(cards);
        }

        public ActionResult GetSearchResults(string searchTerm) {

            var cards = from results in db.Cards
                        where results.Name.Contains(searchTerm)
                        select results;
            return PartialView("SearchResult", cards);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
