using eProdaja.Model;
using eProdaja.Model.Requests;
using eProdaja.Model.SearchObjects;
using eProdaja.Services;
using Microsoft.AspNetCore.Mvc;

namespace eProdaja.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProizvodiController : BaseCRUDController<Proizvodi, ProizvodiSearchObject, ProizvodiInsertRequest, ProizvodiUpdateRequest>
    {
        public IProizvodiService ProizvodiService { get; set; }
        public ProizvodiController(IProizvodiService proizvodiService) : base(proizvodiService)
        {
            ProizvodiService = proizvodiService;
        }

        [HttpPut("{id}/Activate")]
        public Proizvodi Activate(int id)
        {
            var result = ProizvodiService.Activate(id);
            return result;
            //return ProizvodiService.Activate(id); ovo on nije stavio ali ako budem radio copy paste da ne bi promaklo
        }

        [HttpPut("{id}/AllowedActions")]
        public List<string> AllowedActions(int id)
        {
            var result = ProizvodiService.AllowedActions(id);
            return result;
            //return ProizvodiService.AllowedActions(id); ovo on nije stavio ali ako budem radio copy paste da ne bi promaklo
        }
    }
}
