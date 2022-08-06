using System;
using System.Collections.Generic;
using System.Text;

namespace eProdaja.Model.Requests
{
    public class NarudzbeInsertRequest
    {
        public List<NarudzbaStavkeInsertRequest> Items { get; set; } = new List<NarudzbaStavkeInsertRequest>();
    }
}
