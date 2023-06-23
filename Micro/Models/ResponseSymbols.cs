using Micro.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Razor.Tokenizer.Symbols;

namespace Micro.Models
{
    public class ResponseSymbols
    {
        public ResponseSymbols(Symbol Symbol)
        {
            id_symbol = Symbol.id_symbol;
            symbol1 = Symbol.symbol1;
            descriprion = Symbol.descriprion;
            unit = Symbol.unit;
            pow10 = Symbol.pow10;
        }
        public int id_symbol { get; set; }
        public string symbol1 { get; set; }
        public string descriprion { get; set; }
        public string unit { get; set; }
        public Nullable<int> pow10 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<List> Lists { get; set; }
    }
}