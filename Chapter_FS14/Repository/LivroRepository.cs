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

        public Livro BuscarPorId(int id)
        {
            return _context.Livros.Find(id);
        }

        public void Cadastrar (Livro l)
        {
            _context.Livros.Add(l);
            _context.SaveChanges();

        }

        public void Deletar(int id)
        {
            Livro l =  _context.Livros.Find(id);

            _context.Livros.Remove(l);

            _context.SaveChanges();
        }


        public void Alterar(int id, Livro l)
        {
            Livro livroBuscado = _context.Livros.Find(id);

            if (livroBuscado != null)
            {
                livroBuscado.Titulo = l.Titulo;
                livroBuscado.Disponivel = l.Disponivel;

                _context.Livros.Update(livroBuscado);


                _context.SaveChanges();


            }
            
        }


    }
}
