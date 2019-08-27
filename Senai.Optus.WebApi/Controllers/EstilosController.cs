using Microsoft.AspNetCore.Mvc;
using Senai.Optus.WebApi.Domains;
using Senai.Optus.WebApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Optus.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class EstilosController : ControllerBase
    {
        EstilosRepository EstilosRepository = new EstilosRepository();
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(EstilosRepository.Listar());
        } 

        [HttpPost]
        public IActionResult Cadastrar (Estilos estilos)
        {
            try
            {
                EstilosRepository.Cadastrar(estilos);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Erro" + ex.Message });
            }
        }

        [HttpPut]
        public IActionResult Atualizar(Estilos estilos)
        {
            try
            {
                // pesquisar uma categoria
                Estilos EstiloBuscado = EstilosRepository.BuscarPorId(estilos.IdEstilo);
                // caso nao encontre, not found
                if (EstiloBuscado == null)
                    return NotFound();
                // caso contrario, se ela for encontrada, eu atualizo pq quero
                EstilosRepository.Atualizar(estilos);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Ah, não. By - Pedro." });
            }
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Estilos Estilos = EstilosRepository.BuscarPorId(id);
            if (Estilos == null)
                return NotFound();
            return Ok(Estilos);
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            EstilosRepository.Deletar(id);
            return Ok();
        }
    }
    }

