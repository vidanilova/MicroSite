using Micro.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Micro.Models
{
    public class ResponseBox
    {
        public ResponseBox(Box Box)
        {
            id_box = Box.id_box;
            number = Box.number;
            name = Box.name;
          
        }
        public int id_box { get; set; }
        public Nullable<int> number { get; set; }
        public string name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<List> Lists { get; set; }
    }
}