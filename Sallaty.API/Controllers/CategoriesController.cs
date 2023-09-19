using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sallaty.API.Data;
using Sallaty.API.Models.Domain;
using Sallaty.API.Models.DTO;
using Sallaty.API.Repositories.Interface;

namespace Sallaty.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository catedoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            this.catedoryRepository = categoryRepository;
        }


        [HttpPost]
        public async Task<IActionResult> CreateCategory ([FromBody] CreateCategoryRequestDto request)
        {
            var category = new Category
            {
                Name = request.Name,
                UrlHandle = request.UrlHandle
            };

            await catedoryRepository.CreateAsync(category);

            var response = new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                UrlHandle = category.UrlHandle
            };

            return Ok(response);
        }

        // GET : localhost:7091/api/Categories

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
           var categories = await catedoryRepository.GetAllAsync();

            var response = new List<CategoryDto>();
            foreach (var category in categories)
            {
                response.Add(new CategoryDto
                {
                    Id = category.Id,
                    Name = category.Name,
                    UrlHandle = category.UrlHandle
                });
            }

            return Ok(response);
        }

        //GET : localhost:7091/api/Categories {ID}

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetCategoryById([FromRoute] Guid id)
        {
            var existingCategory = await catedoryRepository.GetById(id);
            if(existingCategory is null)
            {
                return NotFound();
            }
            var response = new CategoryDto
            {
                Id = existingCategory.Id,
                Name = existingCategory.Name,
                UrlHandle = existingCategory.UrlHandle
            };
            return Ok(response);
        }
    }
}
