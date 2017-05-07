using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace MoviesTutorial.Models {
    [Table("CardDetails")]
    public class Card {

        public int CardId { get; set; }
        public string Name { get; set; }
        public string EditionCode { get; set; }
        public string Rarity { get; set; }
        public virtual ICollection<DeckCard> Decks { get; set; }
    }
}