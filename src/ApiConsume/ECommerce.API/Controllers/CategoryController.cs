using ECommerce.BusinessLayer.Abstract;
using ECommerce.EntityLayer.Concrete;
using ECommerce.WebUI.Dtos.CategoryDto;
using ECommerce.WebUI.Dtos.ProductDto;
using ECommerce.WebUI.Models.CategoryWithFile;
using ECommerce.WebUI.Models.ProductWithFile;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public CategoryController(ICategoryService categoryService, IWebHostEnvironment webHostEnvironment)
        {
            _categoryService = categoryService;
            _webHostEnvironment = webHostEnvironment;
        }
        //---------------------------------------------------------
        [HttpGet]
        public IActionResult CategoryList()
        {
            try
            {
                var values = _categoryService.GetAll();
                return Ok(values);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        //---------------------------------------------------------
        [HttpGet("GetAllWithImages")]
        public async Task<IActionResult> GetAllWithImages()
        {
            try
            {
                CtWithFile ctWithFile = new CtWithFile(_webHostEnvironment);
                var categorylist = _categoryService.GetAll();

                if (categorylist != null && categorylist.Count > 0)
                {
                    categorylist.ForEach(item =>
                    {
                        item.CategoryImage = ctWithFile.GetImagebyCategory(item.CategoryImage);
                    });
                    return Ok(categorylist);
                }
                else
                {
                    return Ok(new List<ResultCategoryDto>());
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
        //---------------------------------------------------------
        [HttpGet("{id}")]
        public IActionResult GetCategory(int id)
        {
            try
            {
                var model = _categoryService.GetById(id);
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
        //---------------------------------------------------------
        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            try
            {
                _categoryService.Add(category);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
        //---------------------------------------------------------
        [HttpPut]
        public IActionResult UpdateCategory(Category category)
        {
            try
            {
                _categoryService.Update(category);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
        //---------------------------------------------------------
        [HttpDelete("DeleteCategory/{id}")]
        public IActionResult DeleteCategory(int id)
        {
            try
            {
                var values = _categoryService.GetById(id);
                _categoryService.Destroy(values);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
        //---------------------------------------------------------
        [HttpDelete("DeletedStatusCategory/{id}")]
        public IActionResult DeletedStatusCategory(int id)
        {
            try
            {
                var values = _categoryService.GetById(id);
                _categoryService.Delete(values);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
        //---------------------------------------------------------
        [HttpGet("GetActivesCategory")]
        public IActionResult GetActivesCategory()
        {   
            try
            {
                CtWithFile ctWithFile = new CtWithFile(_webHostEnvironment);
                var categorylist = _categoryService.GetActives();

                if (categorylist != null && categorylist.Count > 0)
                {
                    categorylist.ForEach(item =>
                    {
                        item.CategoryImage = ctWithFile.GetImagebyCategory(item.CategoryImage);
                    });
                    return Ok(categorylist);
                }
                else
                {
                    return Ok(new List<ResultCategoryDto>());
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
        //---------------------------------------------------------
        [HttpGet("GetActiveCategory/{id}")]
        public IActionResult GetActiveCategory(int id)
        {
            try
            {
                var values = _categoryService.GetById(id);
                _categoryService.GetActive(values);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
        //---------------------------------------------------------
        [HttpGet("GetProductsWithCategoryId/{id}")]
        public IActionResult GetProductsWithCategoryId(int id)
        {

            try
            {
                PrWithFile ctWithFile = new PrWithFile(_webHostEnvironment);
                var categorylist = _categoryService.GetProductsWithCategoryId(id);

                if (categorylist != null && categorylist.Count > 0)
                {
                    categorylist.ForEach(item =>
                    {
                        item.ImageFile = ctWithFile.GetImagebyProduct(item.ImageFile);
                    });
                    return Ok(categorylist);
                }
                else
                {
                    return Ok(new List<ResultProductDto>());
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
        //---------------------------------------------------------
    }
}
