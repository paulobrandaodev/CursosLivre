using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using CursosLivre.Dados;
using CursosLivre.Models;

namespace CursosLivre.Controllers
{

    [Route("api/[controller]")]
    public class AreasController : Controller
    {
        Areas area = new Areas();
        readonly CursosLivreContexto contexto;

        public AreasController(CursosLivreContexto contexto){
            this.contexto = contexto;
        }

        [HttpGet]
        public IEnumerable<Areas> Listar(){
            return contexto.Areas.ToList();
        }

        [HttpGet("{id}")]
        public Areas Listar(int id){
            return contexto.Areas.Where( x => x.IdArea == id).FirstOrDefault();
        }

        [HttpPost]
        public void Cadastrar([FromBody] Areas cli){
            contexto.Areas.Add(cli);
            contexto.SaveChanges();
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id,[FromBody] Areas area){
            if(area == null || area.IdArea != id){
                return BadRequest();
            }
            var cli = contexto.Areas.FirstOrDefault(x => x.IdArea == id);
            if(cli == null){
                return NotFound();
            }

            cli.IdArea     = area.IdArea;
            cli.NomeArea   = area.NomeArea;

            contexto.Areas.Update(cli);
            int rs = contexto.SaveChanges();

            if(rs > 0)
            return Ok();
            else
            return BadRequest();

        }

        [HttpDelete("{id}")]
        public IActionResult Apagar(int id){
            var area = contexto.Areas.Where( x => x.IdArea == id).FirstOrDefault();
            if(area == null){
                return NotFound();
            }

            contexto.Areas.Remove(area);    
            int rs = contexto.SaveChanges();

            if(rs > 0)
            return Ok();
            else
            return BadRequest();
        }
        

    }
        
}