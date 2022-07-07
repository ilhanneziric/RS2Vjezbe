﻿using eProdaja.Model;
using eProdaja.Model.Requests;
using eProdaja.Model.SearchObjects;
using eProdaja.Services;
using Microsoft.AspNetCore.Mvc;

namespace eProdaja.Controllers
{
    public class VrsteProizvodumController : BaseCRUDController<VrsteProizvodum, VrsteProizvodumSearchObject, VrsteProizvodumUpsertRequest, VrsteProizvodumUpsertRequest>
    {

        public VrsteProizvodumController(IVrsteProizvodumService service) : base(service)
        {
        }
    }
}
