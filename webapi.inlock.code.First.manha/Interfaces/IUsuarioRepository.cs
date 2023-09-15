using webapi.inlock.code.First.manha.Domains;

namespace webapi.inlock.code.First.manha.Interfaces
{
    public interface IUsuarioRepository
    {

        Usuario BuscarUsuario(string email, string senha);
        void Cadastrar(Usuario usuario);

    }
}
