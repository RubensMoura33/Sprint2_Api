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

        /// <summary>
        /// EndPoint que consulta um filme pelo seu id
        /// </summary>
        /// <param name="id">filme a ser buscado</param>
        /// <returns>status code referente a operação e o objeto resultante da consulta</returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                //retorna a lista resultante da requisição e seu status code de ok
                if (_filmeRepository.BuscarPorId(id) == null)
                {
                    return StatusCode(404, "Objeto não encontrado.");
                }
                return Ok(_filmeRepository.BuscarPorId(id));

            }
            catch (Exception Erro)
            {
                //retorna um status code de erro
                return BadRequest(Erro.Message);
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

        /// <summary>
        /// EndPoint que aciona o metodo AtualizarIdCorpo
        /// </summary>
        /// <param name="filme">filme que sera alterado</param>
        /// <returns>Status code de acordo com o resultado da operação</returns>
        [HttpPut]
        public IActionResult Put(FilmeDomain filme)
        {
            try
            {
                FilmeDomain filmeBuscado = _filmeRepository.BuscarPorId(filme.IdFilme);

                if (filmeBuscado != null)
                {
                    try
                    {
                        _filmeRepository.AtualizarIdCorpo(filme);
                        return Ok();
                    }
                    catch (Exception Erro)
                    {
                        //retorna um status code de erro
                        return BadRequest(Erro.Message);
                    }
                }

                throw new Exception();
            }
            catch
            {
                return NotFound("Filme não encontrado");
            }

        }

        /// <summary>
        /// EndPoint que deleta um filme da tabela filmes
        /// </summary>
        /// <param name="id">id do filme a ser deletado</param>
        /// <returns>status code</returns>
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                _filmeRepository.Deletar(id);

                return StatusCode(202, "Filme deletado com sucesso.");
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }

        }

        /// <summary>
        /// EndPoint que aciona o metodo AtualizarIdUrl
        /// </summary>
        /// <param name="id">Id do filme que sera editado</param>
        /// <param name="filme">Objeto que vai ser editado</param>
        /// <returns>Status code</returns>
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, FilmeDomain filme)
        {
            try
            {
                FilmeDomain filmeBuscado = _filmeRepository.BuscarPorId(id);

                if (filmeBuscado != null)
                {
                    try
                    {
                        _filmeRepository.AtualizarIdUrl(id, filme);
                        return Ok();
                    }
                    catch (Exception Erro)
                    {
                        //retorna um status code de erro
                        return BadRequest(Erro.Message);
                    }
                }

                throw new Exception();
            }
            catch
            {
                return NotFound("Filme não encontrado");
            }
        }

    }
}
