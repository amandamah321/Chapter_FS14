using Chapter_FS14.Contexts;
using Chapter_FS14.Models;
using Microsoft.Identity.Client;

namespace Chapter_FS14.Repository
{
    public class LivroRepository
    {

        private readonly Sqlcontext _context;
        public LivroRepository(Sqlcontext context)
        {
            _context = context;
        }

        public List<Livro> Listar()
        {
            return _context.Livros.ToList();
        }

    }
}
