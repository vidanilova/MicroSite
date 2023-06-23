using Micro.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

  namespace Micro.Models
  {

     public class ResponseCard
     {

        public ResponseCard(Card Card)
        {
            id_card = Card.id_card;
            name = Card.name;
            symbol_id = Card.symbol_id;
        }

        public int id_card { get; set; }
        public string name { get; set; }
        public Nullable<int> symbol_id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<List> Lists { get; set; }











    }
  }