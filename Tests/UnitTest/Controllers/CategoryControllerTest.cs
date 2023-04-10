using Microsoft.AspNetCore.Mvc;
using Moq;
using Presentation.Controllers;
using Service.Contracts.Base;
using Shared.DataTransferObjects.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTest.Controllers
{
    public class CategoryControllerTest
    {
        private readonly Mock<IServiceManager> _mockServiceManager;
        private readonly CategoryController _categoryController;

        private readonly List<CategoryDto> categoryDtos = new List<CategoryDto>()
        {
            new CategoryDto() { Id = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200") , Name = ""},
            new CategoryDto() { Id = new Guid("815accac-fd5b-478a-a9d6-f171a2f6ae7f") , Name = ""}
        };

        public CategoryControllerTest()
        {
            _mockServiceManager = new Mock<IServiceManager>();
            _categoryController = new CategoryController(_mockServiceManager.Object);

            _mockServiceManager.Setup(s => s.categoryService.GetAllCategories(false))
                .Returns(categoryDtos);

        }

        [Fact]
        public void GetCategories_ActionExecutes_ReturnOKResult()
        {
            var okResult = _categoryController.GetCategories();
            
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }

        [Fact]
        public void GetCategories_ActionExecutes_ReturnAllItems()
        {
            var okResult = _categoryController.GetCategories() as OkObjectResult;

            var items = Assert.IsType<List<CategoryDto>>(okResult.Value);
            Assert.Equal(2, items.Count);
        }        

        [Fact]
        public void GetCategory_ActionExecutes_ReturnOkResult()
        {
            var okResult = _categoryController.GetCategory(new Guid());
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }

        [Fact]
        public void GetCategory_ExistingGuidPassed_ReturnRightItem()
        {
            var categoryDto = new CategoryDto() { Id = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200"), Name = "category1" };
            _mockServiceManager.Setup( s=> s.categoryService.GetCategoryById(new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200"),false))
                .Returns(categoryDto);

            var result = _categoryController.GetCategory(categoryDto.Id) as OkObjectResult;

            Assert.IsType<CategoryDto>(result?.Value);
            Assert.Equal(categoryDto.Id , (result.Value as CategoryDto)?.Id);
        }

        [Fact]
        public void CreateCategory_ValidObjectPassed_ReturnCreatedResponse()
        {
            CategoryForCreationDto categoryForCreationDto = new CategoryForCreationDto()
            {
                Name = "category1"
            };

            _mockServiceManager.Setup(s => s.categoryService.CreateCategory(categoryForCreationDto))
            .Returns(new CategoryDto() { Name = categoryForCreationDto.Name});

            var createdResponse = _categoryController.CreateCategory(categoryForCreationDto);

            Assert.IsType<CreatedAtRouteResult>(createdResponse);
        }

        [Fact]
        public void CreateCategory_ValidObjectPassed_ReturnedResponseHasCreatedItem()
        {
            _mockServiceManager.Setup(s => s.categoryService.CreateCategory(It.IsAny<CategoryForCreationDto>()))
                .Returns<CategoryForCreationDto>(x => new CategoryDto() { Id = Guid.NewGuid(), Name = x.Name });

            CategoryForCreationDto categoryForCreationDto = new CategoryForCreationDto()
            {
                Name = "category1"
            };
            var createdResponse = _categoryController.CreateCategory(categoryForCreationDto) as CreatedAtRouteResult;

            _mockServiceManager.Verify( x=> x.categoryService.CreateCategory(It.IsNotNull<CategoryForCreationDto>()) , Times.Once());

            var item = createdResponse.Value as CategoryDto;

            Assert.IsType<CategoryDto>(item);
            Assert.Equal(categoryForCreationDto.Name, item.Name);
        }

        [Fact]
        public void CreateCategory_UnvalidObjectPassed_ThrowBadRequestException()
        {
            Assert.IsType<BadRequestObjectResult>(_categoryController.CreateCategory(null));
        }

        
    }
}
