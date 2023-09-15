using webapi.inlock.code.First.manha.Context;
using webapi.inlock.code.First.manha.Domains;
using webapi.inlock.code.First.manha.Interfaces;
using webapi.inlock.code.First.manha.Utils;

namespace webapi.inlock.code.First.manha.Repositories
{
  
    public class UsuarioRepository : IUsuarioRepository
    {
        /// <summary>
        /// Variavel privada e somente leitura para armazenar os dados do contexto
        /// </summary>
        private readonly InlockContext ctx;

        /// <summary>
        /// Construtor do repositorio
        /// Toda evz que o repositorio for instanciado,
        /// Ele tera acesso aos dados fornecidos pelo contexto
        /// </summary>
        public UsuarioRepository()
        {
            ctx = new InlockContext();
        }
        public Usuario BuscarUsuario(string email, string senha)
        {
            Usuario usuarioBuscado = ctx.Usuario.FirstOrDefault(u => u.Email == email)!;

            if(usuarioBuscado != null)
            {
                bool confere = Criptografia.CompararHash(senha, usuarioBuscado.Senha!);

                if(confere) 
                {
                return usuarioBuscado;
                }
            }
            return null!;
        }

        public void Cadastrar(Usuario usuario)
        {
            try
            {
                usuario.Senha = Criptografia.GerarHash(usuario.Senha!);

                ctx.Add(usuario);

                ctx.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
