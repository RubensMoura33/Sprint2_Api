using System.Data.SqlClient;
using webapi.filmes.manha.Domains;
using webapi.filmes.manha.Interfaces;

namespace webapi.filmes.manha.Repositories
{
    public class FilmeRepository : IFilmeRepository
    {

        /// <summary>
        /// String de conexao com o banco de dados que recebe os seguintes parametros:
        /// Data Source : Nome do Servidor
        /// Initial Catalog : Nome do Bnacco de dados
        /// Autenticacao :
        /// - Windows : Integrated Security = true
        /// -SqlServer : User Id = Login; Pwd = Senha
        /// </summary>

        private string StringConexao = "Data Source = NOTE11-S13; Initial Catalog = Filmes; User Id = sa; Pwd = Senai@134 ";
        public void AtualizarIdCorpo(FilmeDomain filme)
        {
            throw new NotImplementedException();
        }

        public void AtualizarIdUrl(int id, FilmeDomain filme)
        {
            throw new NotImplementedException();
        }

        public FilmeDomain BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(FilmeDomain novoFilme)
        {
            
               using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryInsert = "INSERT INTO FILME (IdGenero, Titulo) VALUES(@IdGenero, @Titulo)";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con)) 
                {
                    con
                    cmd.Parameters.AddWithValue("@IdGenero", novoFilme.IdGenero);
                    cmd.Parameters.AddWithValue("@Titulo", novoFilme.Titulo);
                    //Executa a query(queryInsert)
                    cmd.ExecuteNonQuery();
                }
            }

        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public List<FilmeDomain> ListarTodos()
        {
            //Cria uma lista de objetos do tipo genero
            List<FilmeDomain> listaFilmes = new List<FilmeDomain>();

            //Declara a SqlConnection passando a string de conexao como parametro
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string querySelectAll = "SELECT IdFilme, Filme.IdGenero, Titulo,Genero.Nome AS GeneroNome FROM Filme INNER JOIN Genero ON Genero.IdGenero = Filme.IdGenero";

                //Abre a conexao com banco de dados
                con.Open();

                //Declara o SqlDataReader para percorrer a tabela do banco de dados
                SqlDataReader rdr;

                //Declara o SqlCommand passando a query que sera executada e a conexao com o bd
                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    // Executa a query e armazena os dados no rdr
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        FilmeDomain filme = new FilmeDomain()
                        {
                            //Atribui a propriedade IdFilme o valor recebido no rdr
                            IdFilme = Convert.ToInt32(rdr[0]),

                            IdGenero = Convert.ToInt32(rdr[1]), 

                            //atribui a propriedade Nome o valr recebeido no rdr
                            Titulo = rdr[2].ToString(),

                            Genero = new GeneroDomain()
                            {
                                IdGenero = Convert.ToInt32(rdr[1]),
                                Nome = Convert.ToString(rdr["GeneroNome"])

                            }

                    };
                       
                        //Adiciona cada objeto dentro da lista
                        listaFilmes.Add(filme);
                    }
                }
            }
            //retorna a lista de generos
            return listaFilmes;
        }
    }
}
