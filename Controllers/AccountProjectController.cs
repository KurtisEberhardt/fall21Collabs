using fall21Collabs.Models;
using fall21Collabs.Services;
using Microsoft.AspNetCore.Mvc;

namespace fall21Collabs.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountProjectController : ControllerBase
    {
        private readonly AccountProjectService _service;

        public AccountProjectController(AccountProjectService service)
        {
            _service = service;
        }

        [HttpPost]
        public ActionResult<AccountProject> createAccountProject([FromBody] AccountProject newAP)
        {
            try
            {
                 return Ok(_service.Create(newAP));
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("{id}")]
        public ActionResult<AccountProject> getById(int id)
        {  
            try
            {
            return Ok(_service.getById(id));
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}