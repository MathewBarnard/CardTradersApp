using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MoviesTutorial.Models {
    public class DeckCard {

        [Key, Column(Order = 0), ForeignKey("Deck")]
        public int DeckId { get; set; }
        [Key, Column(Order = 1), ForeignKey("Card")]
        public int CardId { get; set; }

        public Card Card { get; set; }
        public Deck Deck { get; set; }
        public int Quantity { get; set; }
    }
}