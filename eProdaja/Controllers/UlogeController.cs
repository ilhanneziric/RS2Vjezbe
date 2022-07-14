using eProdaja.Model;
using eProdaja.Model.Requests;
using eProdaja.Model.SearchObjects;
using eProdaja.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eProdaja.Controllers
{
    public class UlogeController : BaseController<Uloge, BaseSearchObject>
    {

        public UlogeController(IService<Uloge, BaseSearchObject> service) : base(service)
        {
        }
    }
}
