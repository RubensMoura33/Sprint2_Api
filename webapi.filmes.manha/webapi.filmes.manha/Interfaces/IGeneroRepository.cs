using webapi.filmes.manha.Domains;

namespace webapi.filmes.manha.Interfaces
{
    /// <summary>
    ///  Interface responsavel pelo repositorio GeneroRepository
    ///  Definir os metodos que serao implementados pelo GeneroRepository
    /// </summary>
    public interface IGeneroRepository
    {
        //tipoRetorno  NomeMetodo(tipoParametro nomeParametro)
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="novoGenero"></param>
        void Cadastrar(GeneroDomain novoGenero); 
             
        List<GeneroDomain> ListarTodos();

        /// Atualiza objeto existente passando o seu id pelo corpo da requisicao

        void AtualizarIdCorpo(GeneroDomain genero);

        /// <summary>
        /// Atualizar objeto existente passando o seu id pela Url
        /// </summary>
        /// <param name="id">Id do objeto que sera deletado</param>
        /// <param name="genero"></param>

        void AtualizarIdUrl(int id, GeneroDomain genero);

        /// Deletar um objeto
        void Deletar(int id);
        
        ///Busca um objeto
        GeneroDomain BuscarPorId(int id);
        
        
    }
}
