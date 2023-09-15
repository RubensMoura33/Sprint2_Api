using BCrypt.Net;

namespace webapi.inlock.code.First.manha.Utils
{
    public static class Criptografia
    {
        /// <summary>
        /// Gera um hash a partir de uma senha
        /// </summary>
        /// <param name="senha">Senha que recebra Hash</param>
        /// <returns>Senha criptografada com hash</returns>
        public static string GerarHash(string senha)
        {
            return BCrypt.Net.BCrypt.HashPassword(senha);
        }

        /// <summary>
        /// Verifica se a hash da senha informada e igual a hash salva no banco
        /// </summary>
        /// <param name="senhaForm">Senha informada pelo usuario</param>
        /// <param name="senhaBanco">Senha cadastrada no banco</param>
        /// <returns>True ou False (Senha e verdadeira)</returns>
        public static bool CompararHash (string senhaForm, string senhaBanco)
        
        {
            return BCrypt.Net.BCrypt.Verify(senhaForm, senhaBanco);
        }
    }
}
