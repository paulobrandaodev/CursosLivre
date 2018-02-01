using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using CursosLivre.Dados;
using CursosLivre.Models;

namespace CursosLivre.Controllers
{

    [Route("api/[controller]")]
    public class CursosController : Controller
    {
        Cursos curso = new Cursos();
        readonly CursosLivreContexto contexto;

        public CursosController(CursosLivreContexto contexto){
            this.contexto = contexto;
        }

        [HttpGet]
        public IEnumerable<Cursos> Listar(){
            return contexto.Cursos.ToList();
        }

        [HttpGet("{id}")]
        public Cursos Listar(int id){
            return contexto.Cursos.Where( x => x.IdCurso == id).FirstOrDefault();
        }

        [HttpPost]
        public void Cadastrar([FromBody] Cursos cli){
            contexto.Cursos.Add(cli);
            contexto.SaveChanges();
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id,[FromBody] Cursos curso){
            if(curso == null || curso.IdCurso != id){
                return BadRequest();
            }
            var cli = contexto.Cursos.FirstOrDefault(x => x.IdCurso == id);
            if(cli == null){
                return NotFound();
            }

            cli.IdCurso  = curso.IdCurso;
            cli.Curso    = curso.Curso;

            contexto.Cursos.Update(cli);
            int rs = contexto.SaveChanges();

            if(rs > 0)
            return Ok();
            else
            return BadRequest();

        }

        [HttpDelete("{id}")]
        public IActionResult Apagar(int id){
            var curso = contexto.Cursos.Where( x => x.IdCurso == id).FirstOrDefault();
            if(curso == null){
                return NotFound();
            }

            contexto.Cursos.Remove(curso);    
            int rs = contexto.SaveChanges();

            if(rs > 0)
            return Ok();
            else
            return BadRequest();
        }
        

    }
        
}