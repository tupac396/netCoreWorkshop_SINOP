using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using netCoreWorkshop.Entities;

namespace netCoreWorkshop.API
{
    [Route("/api/articles")]
    [ApiController]
    public class ArticlesApiController : ControllerBase
    {
        //Detalles de 1
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var article = Article.DataSource.Where(a => a.Id == id).FirstOrDefault();

            if (article == null)
            {
                return NotFound();
            }

            return Ok(Article.DataSource.Single(a => a.Id == id));
        }

        //Detalles de todos
        [HttpGet]
        public IActionResult Get() => Ok(Article.DataSource);

        // CREAR
        [HttpPost]
        public IActionResult Create([FromBody]Article article)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newArticle = new Article { Title = article.Title, Id = Article.DataSource.Count() };

            Article.DataSource.Add(newArticle);

            return CreatedAtAction(nameof(Create), new { id = newArticle.Id }, newArticle);
        }

        //Editar 1
        [HttpPut("{id}")]
        public IActionResult Edit(int id, [FromBody]Article article)
        {
            if (id != article.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var currentArticle = Article.DataSource.Where(m => m.Id == id).FirstOrDefault();

            if (currentArticle == null)
            {
                return NotFound();
            }

            currentArticle.Title = article.Title;

            return NoContent();
        }

        // Borrar
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var article = Article.DataSource.Where(m => m.Id == id).FirstOrDefault();

            if (article == null)
            {
                return NotFound();
            }

            Article.DataSource.Remove(article);

            return NoContent();
        }
    }
}

