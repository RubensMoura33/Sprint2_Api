using webapi.inlock.code.First.manha.Domains;

namespace webapi.inlock.code.First.manha.Interfaces
{
    public interface IJogoRepository
    {
        List<Jogo> Listar();

        Jogo BuscarPorId(Guid id);
        
        void Cadastrar(Jogo novoJogo);
        
        void Atualizar(Guid id, Jogo jogo);
        
        void Deletar(Guid id);


    }
}
