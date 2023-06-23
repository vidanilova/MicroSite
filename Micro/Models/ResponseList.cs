using Micro.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Razor.Tokenizer.Symbols;
using System.Web.UI.WebControls;

namespace Micro.Models
{
    public class ResponseList
    {
        public ResponseList(List List)
        {
            id_micro = List.id_micro;
            id_box = List.id_box;
            id_PropertyType = List.id_PropertyType;
            id_card = List.id_card;
            id_symbol = List.id_symbol;
            cabinet_number = List.cabinet_number;
            floor = List.floor;
        }

        public int id_micro { get; set; }
        public Nullable<int> id_box { get; set; }
        public Nullable<int> id_PropertyType { get; set; }
        public Nullable<int> id_card { get; set; }
        public Nullable<int> id_symbol { get; set; }
        public Nullable<int> cabinet_number { get; set; }
        public string floor { get; set; }

        public virtual Box Box { get; set; }
        public virtual Card Card { get; set; }
        public virtual PropertyType PropertyType { get; set; }
        public virtual Symbol Symbol { get; set; }
    }
}