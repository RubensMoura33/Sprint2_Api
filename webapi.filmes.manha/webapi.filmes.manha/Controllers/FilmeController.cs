using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.filmes.manha.Domains;
using webapi.filmes.manha.Interfaces;
using webapi.filmes.manha.Repositories;

namespace webapi.filmes.manha.Controllers
{
    //Define que a rota de uma aquisicao serano seguinte formato
    //dominio/api/nomeController
    //Ex: http://localhost:5000/api/genero
    [Route("api/[controller]")]

    //Define que e um controlador de API
    [ApiController]

    //Define que o tipo de resposta da Api sera no formato JSON
    [Produces("application/json")]

    //Metodo controlador que herda da controller base
    //Onde sera criado os Endpoints (rotas)

    public class FilmeController : ControllerBase
    {
        /// <summary>
        /// Objeto _filmeRepository que ira receber todos os metodos definidos na Interface IFilmeRepository
        /// </summary>
        private IFilmeRepository  _filmeRepository { get; set; }

        /// <summary>
        /// Instancia o objeto _filmeRepository para que haja referencia aos metodos no repositorio
        /// </summary>

        public FilmeController()
        {
            _filmeRepository = new FilmeRepository();
        }


        /// <summary>
        /// Endpoint que aciona o metodo ListarTodos
        /// </summary>
        /// <returns>Retorna a resposta para o usuario(fromt-end)</returns>
        [HttpGet]

        public IActionResult Get()
        {
            try
            {
                List<FilmeDomain> ListaFilmes = _filmeRepository.ListarTodos();
                return Ok(ListaFilmes);
            }
            catch (Exception erro)
            {
                //Retorna um status code BadRequest(400) e a mensagem do erro
                return BadRequest(erro.Message);
            }
        }

        [HttpPost]

        public IActionResult Post(FilmeDomain novoFilme)
        {
            try
            {
                _filmeRepository.Cadastrar(novoFilme);
                return StatusCode(201);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

    }
}
