using Microsoft.AspNetCore.Mvc;
using SpeedTest.API.Controllers.DTOs;
using SpeedTest.Context.Models;
using SpeedTest.Repository.Interfaces;

namespace SpeedTest.API.Controllers.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArticleController : ControllerBase
    {
        private readonly ILogger<ArticleController> _logger;
        private readonly IArticleRepository _articleRepository;

        public ArticleController(ILogger<ArticleController> logger,
            IArticleRepository ArticleRepository
            )
        {
            _logger = logger;
            _articleRepository = ArticleRepository;
        }

        [HttpPost]
        public async Task<ActionResult<Article>> AddArticle(ArticleDTO newArticleDTO)
        {
            var newArticle = new Article
            {
                ArticleName = newArticleDTO.ArticleName,
                ArticleContent = newArticleDTO.ArticleContent,
                AuthorId = newArticleDTO.AuthorId
            };

            await _articleRepository.Insert(newArticle);

            return CreatedAtAction(nameof(GetArticle),
                new { id = newArticle.ArticleId },
                ItemToDTO(newArticle));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ArticleDTO>> UpdateArticle(int id, ArticleDTO articleDTO)
        {
            if (id != articleDTO.ArticleId)
            {
                return BadRequest();
            }

            var article = await _articleRepository.GetOne(id);
            article.AuthorId = articleDTO.AuthorId;
            article.ArticleContent = articleDTO.ArticleContent;
            article.ArticleName = articleDTO.ArticleName;

            await _articleRepository.Update(article);

            return ItemToDTO(article);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteArticle(int id)
        {
            await _articleRepository.Delete(id);

            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Article>> GetArticle(int id)
        {
            var Article = await _articleRepository.GetOne(id);
            if(Article == null)
            {
                return NotFound();
            }

            return await _articleRepository.GetOne(id);
        }

        [HttpGet("[action]/{numArticles}")]
        public async Task<IEnumerable<Article>> Top(int numArticles)
        {
            return await _articleRepository.Top(numArticles);
        }

        [HttpGet]
        public async Task<IEnumerable<Article>> Get()
        {
            return await _articleRepository.All();
        }

        private static ArticleDTO ItemToDTO(Article Article) =>
            new ArticleDTO
            {
                ArticleId = Article.ArticleId,
                ArticleName = Article.ArticleName,
                ArticleContent = Article.ArticleContent,
                AuthorId = Article.AuthorId
            };
    }
}
