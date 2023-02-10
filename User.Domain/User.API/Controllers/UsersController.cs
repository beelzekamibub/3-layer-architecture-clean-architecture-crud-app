using Microsoft.AspNetCore.Mvc;
using User.Application;
using User.Domain;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace User.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _service;

        public UsersController(IUserService service)
        {
            _service = service;
        }
        // GET: api/<MoviessController>
        [HttpGet]
        public ActionResult<List<Userd>> Get()
        {
            var moviesFromService = _service.GetAllUsers();
            return Ok(moviesFromService);
        }
        [HttpPost]
        public ActionResult<Userd> Post(Userd user)
        {
            var res = _service.CreateUser(user);
            return Ok(res);
        }
        [HttpPut]
        public ActionResult<Userd>? Put(Userd user,int id) {
            var res= _service.UpdateUser(user,id);
            if (res is null) return NotFound(res);
            return Ok(res);
        }
        [HttpDelete]
        public ActionResult<List<Userd>>? Delete(int id) { 
            var res=_service.DeleteUser(id);
            if (res is null) return NotFound(res);
            return Ok(res);
        }

    }
}
