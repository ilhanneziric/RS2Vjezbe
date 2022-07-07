using eProdaja.Model;
using eProdaja.Model.Requests;
using eProdaja.Model.SearchObjects;
using eProdaja.Services;
using Microsoft.AspNetCore.Mvc;

namespace eProdaja.Controllers
{
    public class JediniceMjereController : BaseCRUDController<JediniceMjere, JediniceMjereSearchObject, JediniceMjereUpsertRequest, JediniceMjereUpsertRequest>
    {

        public JediniceMjereController(IJediniceMjereService service) : base(service)
        {
        }
    }
}
