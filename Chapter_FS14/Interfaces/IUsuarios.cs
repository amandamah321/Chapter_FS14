using Chapter_FS14.Models;
using Chapter_FS14.Interfaces;

namespace Chapter_FS14.Interfaces
{
    public interface IUsuarios
    {

        List<Usuario> Listar();


        Usuario BuscaPorId(int id);
        void Cadastrar(Usuario novoUsuario);

        void Atualizar(int id, Usuario usuario);

        void Deletar (int id);

        Usuario Login(string email, string senha);



            

    }
}
