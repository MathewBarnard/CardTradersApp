using MoviesTutorial.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace MoviesTutorial.Controllers
{
    public class DecksController : Controller
    {
        private CardTradersDBContext db = new CardTradersDBContext();

        // GET: Decks
        public ActionResult Index()
        {
            return View(db.Decks.ToList());
        }

        [HttpPost]
        public JsonResult Save(string deck) {

            var dict = new JavaScriptSerializer().Deserialize<List<string>>(deck);

            Deck deckObject = new Deck();
            deckObject.CreatedOn = DateTime.Now;
            deckObject.Name = "My First Deck";

            foreach (string card in dict) {

                bool cardInDeck = false;

                // Add to the quantity of the card exists in this deck already
                foreach(DeckCard dc in deckObject.Cards) {

                    if (dc.Card.Name == card) {

                        dc.Quantity += 1;
                        cardInDeck = true;
                        break;
                    }
                }

                if (!cardInDeck) {

                    // We haven't found the card, so add it.
                    DeckCard deckCard = new DeckCard();
                    deckCard.Quantity = 1;

                    Card cardToAdd = db.Cards
                                    .Where(b => b.Name == card)
                                    .FirstOrDefault();
                    deckCard.Card = cardToAdd;
                    deckCard.Deck = deckObject;
                    deckObject.Cards.Add(deckCard);
                }
            }

            db.Decks.Add(deckObject);
            db.SaveChanges();

            return new JsonResult();
        }

        public ActionResult DeleteAll() {

            var decks = db.Decks.Include("Cards");

            foreach (var deckToDelete in decks.ToList()) {

                foreach (var cardInDeck in deckToDelete.Cards.ToList()) {
                    deckToDelete.Cards.Remove(cardInDeck);
                }

                db.Decks.Remove(deckToDelete);
            }
            db.SaveChanges();

            return View();
        }
    }
}