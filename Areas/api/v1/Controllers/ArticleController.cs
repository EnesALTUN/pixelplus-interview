using Microsoft.AspNetCore.Mvc;
using PixelPlusMulakat.Interfaces.Repositories;
using PixelPlusMulakat.Models;

namespace PixelPlusMulakat.Areas.api.v1.Controllers
{
    [Area("api")]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IGenericRepository<Article> _articleRepository;
        public ArticleController(IGenericRepository<Article> articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public IActionResult Get()
        {
            return Ok(_articleRepository.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int? id)
        {
            if (id != null)
            {
                var result = _articleRepository.GetById(id);

                if (result != null)
                    return Ok(result);
            }

            return NotFound();
        }
    }
}
