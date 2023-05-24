using Chapter_FS14.Interfaces;
using Chapter_FS14.Models;
using Chapter_FS14.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Chapter_FS14.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarios _IUsuarios;
        public UsuarioController(IUsuarios IUsuarios)
        {
            _IUsuarios = IUsuarios;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_IUsuarios.Listar());
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
                Usuario usuarioEncontrado = _IUsuarios.BuscaPorId(id);

                if (usuarioEncontrado == null)
                {
                    return NotFound();
                }

                return Ok(usuarioEncontrado);
            }

            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        [HttpPost]

        public IActionResult Cadastrar(Usuario usuario)
        {
            try
            {
                _IUsuarios.Cadastrar(usuario);
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
                _IUsuarios.Deletar(id);
                return Ok("Usuario removido com sucesso");
            }
            catch (Exception e) 
            {
                throw new Exception(e.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Usuario usuario) 
        {
            try 
            {
                _IUsuarios.Atualizar(id, usuario);
                return Ok("Atualizado com sucesso");
            }
            catch (Exception e)
            { 
                throw new Exception(e.Message); 
            }
        }


    }
}

