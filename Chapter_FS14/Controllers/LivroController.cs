using System.ComponentModel;
using Chapter_FS14.Models;
using Chapter_FS14.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Chapter_FS14.Controllers
{

    [Produces("application/json")]

    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        private readonly LivroRepository _livroRepository;

        public LivroController(LivroRepository livroRepository)
        { 
            _livroRepository = livroRepository;
        }

        [HttpGet]

        public IActionResult listar()
        {
            try  
            {
                return Ok(_livroRepository.Listar());  
            }
            catch (Exception e) 
            {
                throw new Exception(e.Message);
            }
        }

    }
}
