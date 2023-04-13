using Microsoft.AspNetCore.Mvc;
using Service.Contracts.Base;
using Shared.DataTransferObjects.Categories;

namespace Presentation.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IServiceManager _service;

        public CategoryController(IServiceManager serviceManager)
        {
            this._service = serviceManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _service.categoryService.GetAllCategoriesAsync(trackChanges: false);
            return Ok(categories);
        }

        [HttpGet("{id:guid}" , Name = "CategoryById")]
        public async Task<IActionResult> GetCategory(Guid id)
        {
            var category = await _service.categoryService.GetCategoryByIdAsync(id, trackChanges: false);

            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody]CategoryForCreationDto category)
        {
            if (category == null)
                return BadRequest("CategoryForCreationDto object is null");

            if(!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            var createdCategory = await _service.categoryService.CreateCategoryAsync(category);
            return CreatedAtRoute("CategoryById", new { id = createdCategory.Id }, createdCategory);
        }

        [HttpGet("collection/({ids})" , Name = "CategoryCollection")]
        public async Task<IActionResult> GetCategoryCollectionAsync(IEnumerable<Guid> ids)
        {
            var categories = await _service.categoryService.GetCategoriesByIdsAsync(ids, trackChanges: false);
            return Ok(categories);
        }
    }
}
