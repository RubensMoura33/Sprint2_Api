using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.filmes.manha.Domains;
using webapi.filmes.manha.Interfaces;
using webapi.filmes.manha.Repositories;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
    public class GeneroController : ControllerBase
    {
        /// <summary>
        /// Objeto _generoRepository que ira receber todos os metodos definidos na Interface IGeneroRepository
        /// </summary>
        private IGeneroRepository _generoRepository { get; set; }

        /// <summary>
        /// Instancia o objeto _generoRepository para que haja referencia aos metodos no repositorio
        /// </summary>
        public GeneroController()
        {
            _generoRepository = new GeneroRepository();
        }

        /// <summary>
        /// Endpoint que aciona o metodo ListarTodos no repositorio 
        /// </summary>
        /// <returns>Retorna a resposta para o usuario(fromt-end)</returns>

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                //Cria uma lista que recebe os dados da requisicao
                List<GeneroDomain> ListaGeneros = _generoRepository.ListarTodos();

                //Retorna a lista com status code Ok(200)
                return Ok(ListaGeneros);
            }


            catch (Exception erro)
            {

                //Retorna um status code BadRequest(400) e a mensagem do erro
                return BadRequest(erro.Message);
            }


        }
        /// <summary>
        /// Endpoint que aciona o metodo de cadastro de genero
        /// </summary>
        /// <param name="novoGenero">Objeto recebido na requisicao</param>
        /// <returns>status code 201(created)</returns>
        [HttpPost]

        public IActionResult Post(GeneroDomain novoGenero)
        {
            try
            {
                //Fazendo a chamada para o metodo cadastrar passando o objeto como parametro
                _generoRepository.Cadastrar(novoGenero);

                //Retorna um status code 201 - Created
                return StatusCode(201);


            }
            catch (Exception erro)
            {
                //Retorna um status code 400(BadRequest) e a mensagem do erro
                return BadRequest(erro.Message);

            }
        }


        /// <summary>
        /// Endpoint que aciona o metodo deletar
        /// </summary>
        /// <param name="Id">Id do genero a ser deletado</param>
        /// <returns></returns>

        [HttpDelete("{Id}")]

        public IActionResult Delete(int Id)
            
        {
            try
            {
              _generoRepository.Deletar(Id);

              return StatusCode(204);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Endpoint que aciona o metodo Buscar por Id
        /// </summary>
        /// <param name="Id">Id do genero que vai ser buscado</param>
        /// <returns></returns>
        /// 
        [HttpGet("{Id}")]

        public IActionResult Get(int Id)
        {
            try
            {
                GeneroDomain generoBuscado = _generoRepository.BuscarPorId(Id);

                if (generoBuscado == null)
                {
                    return NotFound("Nenhum genero foi encontrado!");
                }

                return Ok(generoBuscado);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Endpoint que aciona o metodo AtualizarPorUrl
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Genero"></param>
        /// <returns></returns>
        /// 
        [HttpPatch("{id}")]
        public IActionResult Put(int id, GeneroDomain Genero)
        {
            try
            {
                _generoRepository.AtualizarIdUrl(id, Genero);
                return StatusCode(200);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Endpoint que aciona o metodo AtualizarIdCorpo
        /// </summary>
        /// <param name="Genero"></param>
        /// <returns></returns>
        [HttpPut]

        public IActionResult Put(GeneroDomain Genero)
        {
            try
            {
                _generoRepository.AtualizarIdCorpo(Genero);
                return StatusCode(200);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message); 
            }
        }


    }
}
