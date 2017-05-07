using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace MoviesTutorial.Models {
    [Table("Decks")]
    public class Deck {

        public Deck() {
            Cards = new List<DeckCard>();
        }

        [Key]
        public int DeckId { get; set; }
        public string Name { get; set; }
        public DateTime CreatedOn { get; set; }
        public virtual ICollection<DeckCard> Cards { get; set; }
    }
}