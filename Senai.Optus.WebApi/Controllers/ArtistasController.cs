using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Optus.WebApi.Domains;
using Senai.Optus.WebApi.Repository;

namespace Senai.Optus.WebApi.Controllers
{
    public class ArtistasController : ControllerBase
    {
        //repositorio
        ArtistasRepository artistasRepository = new ArtistasRepository();
        //endpoints
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(artistasRepository.Listar());
        }


        [HttpPost]
        public IActionResult Cadastrar(Artistas artista)
        {
            try
            {
                artistasRepository.Cadastrar(artista);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Erro ao cadastrar." + ex.Message });
            }
        }
    }

}
