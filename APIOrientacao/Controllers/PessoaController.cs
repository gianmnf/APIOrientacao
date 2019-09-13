using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIOrientacao.Api.Request;
using APIOrientacao.Api.Response;
using APIOrientacao.Data;
using APIOrientacao.Data.Context;
using Microsoft.AspNetCore.Mvc;

namespace APIOrientacao.Controllers
{
    [Route("api/[controller]")]
    public class PessoaController : Controller
    {
        private readonly Contexto contexto;

        public PessoaController(Contexto contexto)
        {
            this.contexto = contexto;
        }

        [HttpPost]
        [ProducesResponseType(typeof(PessoaResponse), 200)]
        [ProducesResponseType(400)]
        public IActionResult Post([FromBody]
            PessoaRequest pessoaRequest)
        {
            //Utilizar contexto para tratar o post
            var pessoa = new Pessoa
            {
               Nome = pessoaRequest.Nome
            };

            contexto.Pessoa.Add(pessoa);
            contexto.SaveChanges();
            var pessoaRetorno = contexto.Pessoa.Where
                (x => x.IdPessoa == pessoa.IdPessoa)
                .FirstOrDefault();

            PessoaResponse response = new PessoaResponse();
            if(pessoaRetorno != null)
            {
                response.IdPessoa = pessoaRetorno.IdPessoa;
                response.Nome = pessoaRetorno.Nome;
            }

            return StatusCode(200, response);
        }
        //Get
        [HttpGet("{idPessoa}")]
        [ProducesResponseType(typeof(PessoaResponse), 200)]
        public IActionResult Get(int idPessoa)
        {
            var pessoa = contexto.Pessoa.FirstOrDefault(
                x => x.IdPessoa == idPessoa);

            return StatusCode(pessoa == null
                ? 404 : 200, new PessoaResponse
                {
                    IdPessoa = pessoa == null ? -1 : pessoa.IdPessoa,
                    Nome = pessoa == null ? "Pessoa não encontrada"
                    : pessoa.Nome
                });

        }
	//Delete
	[HttpDelete("{idPessoa}")]
        [ProducesResponseType(typeof(PessoaResponse), 200)]
        public IActionResult Delete(int idPessoa)
        {
            var pessoa = contexto.Pessoa.FirstOrDefault(
                x => x.IdPessoa == idPessoa);

            PessoaResponse response = new PessoaResponse();

            contexto.Pessoa.Remove(pessoa);
            contexto.SaveChanges();

            if (pessoa == null)
            {
                return NotFound();
            }

            return StatusCode(200, response);
        }

	//Put
        [HttpPut("{idPessoa}")]
        [ProducesResponseType(typeof(PessoaResponse), 200)]
        [ProducesResponseType(400)]
        public IActionResult Put([FromBody]
            PessoaRequest pessoaRequest)
        {
            //Utilizar contexto para tratar o post
            var pessoa = new Pessoa
            {
                Nome = pessoaRequest.Nome
            };

            var pessoaRetorno = contexto.Pessoa.Where
                (x => x.IdPessoa == pessoa.IdPessoa)
                .FirstOrDefault();

            PessoaResponse response = new PessoaResponse();
            if (pessoaRetorno != null)
            {
                NotFound();
            }

            contexto.Pessoa.Update(pessoa);
            contexto.SaveChanges();
            
            return StatusCode(200, response);
        }
    }
}