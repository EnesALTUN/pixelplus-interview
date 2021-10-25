using Microsoft.AspNetCore.Mvc;
using PixelPlusMulakat.Interfaces.Repositories;
using PixelPlusMulakat.Models;

namespace PixelPlusMulakat.Areas.api.v1.Controllers
{
    [Area("api")]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IGenericRepository<Category> _categoryRepository;
        public CategoryController(IGenericRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IActionResult Get()
        {
            return Ok(_categoryRepository.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int? id)
        {
            if (id != null)
            {
                var result = _categoryRepository.GetById(id);

                if (result != null)
                    return Ok(result);
            }
            
            return NotFound();            
        }
    }
}