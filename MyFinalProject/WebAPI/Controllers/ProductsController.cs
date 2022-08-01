using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]//--> Attribute ->>C#|| Annotation ->> Java
    public class ProductsController : ControllerBase
    {
        //Loosely coupled(gevşek bağımlılık)
        //naming convention
        //IoC Container --Z Inversion of Control(Değişimiin kontrolü)
        IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            //Swager
            //Dependency chain(Bağımlılık zinciri) --
            var result = _productService.GetAll();
            if(result.Success)
            {
                return Ok(result); //200 staatus code
            }
            return BadRequest(result);

            //return "Merhaba"; //BreakPoint bırakınca uygulama buraya gelince kırılım noktası oluşur
            // F5 basınca devam eder
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _productService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);
            if(result.Success==true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


    }
}
