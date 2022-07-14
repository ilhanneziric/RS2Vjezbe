using System;
using System.Collections.Generic;
using System.Text;

namespace eProdaja.Model.SearchObjects
{
    public class KorisniciSearchObject : BaseSearchObject
    {
        public string KorisnickoIme { get; set; }
        public string NameFTS { get; set; } //GT - gteater than, LT - lower than, LTE - lower than or Equal, FTS - full text search(.contains)
        public string Email { get; set; }
        public bool IncludeRoles { get; set; }
    }
}
