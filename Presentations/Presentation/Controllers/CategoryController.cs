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
        public IActionResult GetCategories()
        {
            var categories = _service.categoryService.GetAllCategories(trackChanges: false);
            return Ok(categories);
        }

        [HttpGet("{id:guid}" , Name = "CategoryById")]
        public IActionResult GetCategory(Guid id)
        {
            var category = _service.categoryService.GetCategoryById(id, trackChanges: false);

            return Ok(category);
        }

        [HttpPost]
        public IActionResult CreateCategory([FromBody]CategoryForCreationDto category)
        {
            if (category == null)
                return BadRequest("CategoryForCreationDto object is null");
            var createdCategory = _service.categoryService.CreateCategory(category);
            return CreatedAtRoute("CategoryById", new { id = createdCategory.Id }, createdCategory);
        }

        [HttpGet("collection/({ids})" , Name = "CategoryCollection")]
        public IActionResult GetCategoryCollection(IEnumerable<Guid> ids)
        {
            var categories = _service.categoryService.GetCategoriesByIds(ids, trackChanges: false);
            return Ok(categories);
        }
    }
}
