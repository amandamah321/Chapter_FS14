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

        public IActionResult Listar()
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


        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            try
            { 
                Livro livrobuscado = _livroRepository.BuscarPorId(id);
            if (livrobuscado ==  null)
            { 
                return NotFound();
            }
                return Ok(livrobuscado);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        [HttpPost]
        public IActionResult Cadastrar(Livro l)
        {
            try
            {
                _livroRepository.Cadastrar(l);
                
                return StatusCode(201);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                _livroRepository.Deletar(id);

                return Ok("Livro removido com sucesso");

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }



        [HttpPut("{id}")]
        public IActionResult Alterar(int id, Livro l)
        {
            try
            {
                _livroRepository.Alterar(id, l );

                return StatusCode(204);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}
