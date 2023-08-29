using System.Data.SqlClient;
using webapi.filmes.manha.Domains;
using webapi.filmes.manha.Interfaces;

namespace webapi.filmes.manha.Repositories
{
    public class GeneroRepository : IGeneroRepository
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

        /// <summary>
        /// Atualizar um genero passando seu id pelo corpo da requisicao
        /// </summary>
        /// <param name="Objeto">objeto genero com as novas informacoes</param>
        public void AtualizarIdCorpo(GeneroDomain genero)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryUpdateCorpo = "UPDATE Genero SET Nome = @NovoNome  WHERE IdGenero = @IdGenero";

                using (SqlCommand cmd = new SqlCommand(queryUpdateCorpo, con))
                {
                    //Abre a conexao com banco de dados
                    con.Open();

                    cmd.Parameters.AddWithValue("@IdGenero", genero.IdGenero);
                    cmd.Parameters.AddWithValue("@NovoNome", genero.Nome);
                    //Executa a query(queryUpdateCorpo)
                    cmd.ExecuteNonQuery();

                }
            }
        }

        public void AtualizarIdUrl(int id, GeneroDomain genero)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            { 
                string queryUpdate = "UPDATE Genero SET Nome = @NovoNome  WHERE IdGenero = @IdGenero";

              //Abre a conexao com banco de dados
                     con.Open();


                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {    
                    
                    //Passa o valor do parametro @IdGenero
                    cmd.Parameters.AddWithValue("@IdGenero",id );
                    cmd.Parameters.AddWithValue("novoNome", genero.Nome);
                    //Executa a query(queryUPDATE)
                    cmd.ExecuteNonQuery();

                }

            }
            
            
            
            //sql connection
            //query update nometabela set @novoNome(variavel) where
            //sql cmd (parametros) abrir conexao
            // execute
            
        }

        /// <summary>
        /// Buscar atraves do seu id 
        /// </summary>
        /// <param name="id"> Id do genero a ser buscado</param>
        /// <returns>Objeto buscado ou null caso nao seja encontrado</returns>
        /// <exception cref="NotImplementedException"></exception>
        public GeneroDomain BuscarPorId(int Id)
        {
            //Declara a conexao passando a string de conexao como parametro
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string querySelectId = "SELECT IdGenero, Nome From Genero WHERE IdGenero =@IdGenero";

                //Abre a conexao com banco de dados
                con.Open();

                //Declara o SqlDataReader para percorrer a tabela do banco de dados
                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectId, con))
                {
                    //Passa o valor do parametro @IdGenero
                    cmd.Parameters.AddWithValue("IdGenero", Id);

                    // Executa a query e armazena os dados no rdr
                    rdr = cmd.ExecuteReader(); 

                    if (rdr.Read())
                    {
                        GeneroDomain generoBuscado = new GeneroDomain()
                        {
                            //Atribui a propriedade IdGenero o valor recebido no rdr
                            IdGenero = Convert.ToInt32(rdr["IdGenero"]),

                            //atribui a propriedade Nome o valor recebeido no rdr
                            Nome = rdr["Nome"].ToString()
                        };
                        return generoBuscado;
                    }
                    return null;
                }
                


            }
        }
        
        /// <summary>
        /// Cadastrar um novo genero
        /// </summary>
        /// <param name="novoGenero">Objeto com as informacoes que serao cadastradas</param>
        /// <exception cref="NotImplementedException"></exception>
        public void Cadastrar(GeneroDomain novoGenero)
        {
            //Declara a conexao passando a string de conexao como parametro
            using(SqlConnection con = new SqlConnection(StringConexao))

            { 
            //Declara a query que sera executada
            string queryInsert = "INSERT INTO Genero(Nome) VALUES(@Nome)";

              using (SqlCommand cmd = new SqlCommand(queryInsert, con))

                {
                    //Passa o valor do parametro @Nome
                    cmd.Parameters.AddWithValue("@Nome", novoGenero.Nome);

                    //Abre a conexao com banco de dados
                    con.Open();

                    //Executa a query(queryInsert)
                    cmd.ExecuteNonQuery();
                    
                }
            }
        }

        /// <summary>
        /// Deletar um determinado genero
        /// </summary>
        /// <param name="Id">Id do genero a ser deletado</param>
        public void Deletar(int Id)
        {
            //Declara a conexao passando a string de conexao como parametro
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                //Declara a query que sera executada
                string queryDelete = "DELETE FROM Genero WHERE IdGenero = @IdGenero ";
                
                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {   
                    cmd.Parameters.AddWithValue("IdGenero", Id);
                                        
                    //Abre a conexao com banco de dados
                    con.Open();
              
                    //Executa a query(queryDelete)
                    cmd.ExecuteNonQuery();
                }

            }


        }

        /// <summary>
        /// Listar todos objetos (generos)
        /// </summary>
        /// <returns>Lista de objeto (generos)</returns>
        public List<GeneroDomain> ListarTodos()
        {
            //Cria uma lista de objetos do tipo genero
            List<GeneroDomain> listaGeneros = new List<GeneroDomain>();

            //Declara a SqlConnection passando a string de conexao como parametro
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string querySelectAll = "SELECT IdGenero, Nome FROM Genero";

                //Abre a conexao com banco de dados
                con.Open();

                //Declara o SqlDataReader para percorrer a tabela do banco de dados
                SqlDataReader rdr;

                //Declara o SqlCommand passando a query que sera executada e a conexao com o bd
                using (SqlCommand cmd = new SqlCommand(querySelectAll,con))
                {
                 // Executa a query e armazena os dados no rdr
                 rdr = cmd.ExecuteReader();

                 while (rdr.Read())
                    {
                        GeneroDomain genero = new GeneroDomain()
                        {
                            //Atribui a propriedade IdGenero o valor recebido no rdr
                            IdGenero = Convert.ToInt32(rdr[0]),

                            //atribui a propriedade Nome o valr recebeido no rdr
                            Nome = rdr[1].ToString()
                        };
                        //Adiciona cada objeto dentro da lista
                        listaGeneros.Add(genero);
                    }
                }    
            }
            //retorna a lista de generos
            return listaGeneros;
        }
    }
}
