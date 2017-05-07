using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MoviesTutorial.Models {
    public class Tag {
        
        public int TagId { get; set; }
        public string Description { get; set; }

        public class TagDBContext : DbContext {
            public DbSet<Tag> Tags { get; set; }
        }
    }
}