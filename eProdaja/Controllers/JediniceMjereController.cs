using eProdaja.Model;
using eProdaja.Services;
using Microsoft.AspNetCore.Mvc;

namespace eProdaja.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JediniceMjereController : ControllerBase
    {
        private readonly IJediniceMjereService _Service;

        public JediniceMjereController(IJediniceMjereService service)
        {
            _Service = service;
        }

        [HttpGet]
        public IEnumerable<JediniceMjere> Get()
        {
            return _Service.Get();
        }


        [HttpGet("{id}")]
        public JediniceMjere GetById(int id)
        {
            return _Service.GetById(id);
        }
    }
}
