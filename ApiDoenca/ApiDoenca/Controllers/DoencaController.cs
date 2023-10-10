using ApiDoenca.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiDoenca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoencaController : ControllerBase
    {
        private static List<Doenca> doencalList = 
        new List<Doenca> { new Doenca
        { Id= 1, Nome = "Dor de cabeça", Descricao = "doi a cabeça", Cura = true, Sintomas = {"dor", "ai" } },
            new Doenca
        { Id= 2, Nome = "Febre", Descricao = "calorão", Cura = true, Sintomas = {"mal", "calor"} } }
        ;

        [HttpGet]
        public async Task<IActionResult> allDoencas()
        {
            return Ok(doencalList);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Doenca>> FindById(int id)
        {
            var d = doencalList.FirstOrDefault(x => x.Id == id);
            if (d == null)
            {
                return Ok(d);
            }
            else
            {
                return NotFound(d);
            }
        }


        [HttpPost]
        public async Task<ActionResult<List<Doenca>>> AddDoenca(Doenca a)
        {
            doencalList.Add(a);
            return Ok(a);
        }

        [HttpPut]
        public async Task<ActionResult<List<Doenca>>> atualizaDoenca(Doenca a)
        {
            var doenca = doencalList.FirstOrDefault(b => b.Id == a.Id);
            if (doenca == null) return NotFound("NotFound");
            doenca.Cura = a.Cura;
            doenca.Descricao = a.Descricao;
            doenca.Nome = a.Nome;
            doenca.Sintomas = a.Sintomas;

            return Ok(doenca);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Doenca>> delDoenca(int id)
        {
            var doenca = doencalList.FirstOrDefault(x => x.Id == id);
            if (doenca == null)
            {
                return NotFound(doenca);
            }
            else
            {
                doencalList.Remove(doenca);
                return Ok("Deletado");
            }
        }

        [HttpGet("/cura")]
        public async Task<IActionResult> cura()
        {
            List<Doenca> listaCuras = doencalList.Where(d => d.Cura == true).ToList();

            if (listaCuras == null) return NotFound();
            return Ok(listaCuras);
        }

        [HttpGet("sintomas/{sintoma}")]
        public IActionResult DoencasComSintoma(string sintoma)
        {
            List<Doenca> doencasComSintoma = doencalList.Where(d => d.Sintomas.Contains(sintoma)).ToList();

            if (doencasComSintoma.Count == 0)
            {
                return NotFound();
            }

            return Ok(doencasComSintoma);
        }

    }
}
