using Micro.Entities;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Micro.Models
{
    public class ResponsePropertyType
    {
        public ResponsePropertyType(PropertyType PropertyType)
        {
            id_PropertyType = PropertyType.id_PropertyType;
            Keys = PropertyType.Keys;
            description = PropertyType.description;
        }

    public int id_PropertyType { get; set; }
        public string Keys { get; set; }
        public string description { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<List> Lists { get; set; }
    }
}