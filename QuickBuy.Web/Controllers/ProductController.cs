using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuickBuy.Domain.Contracts;
using QuickBuy.Domain.Entities;

namespace QuickBuy.Web.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private IHttpContextAccessor _httpContextAccessor;
        private IHostingEnvironment _hostingEnvironment;

        public ProductController(IProductRepository productRepository,
            IHttpContextAccessor httpContextAccessor, IHostingEnvironment hostingEnvironment)
        {
            _productRepository = productRepository;
            _httpContextAccessor = httpContextAccessor;
            //acesso raíz onde app esta sendo executada
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet("getAll")]
        public IActionResult Get() //Find
        {
            try
            {
                return Json(_productRepository.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        //utiliza para Adicionar e editar
        [HttpPost("register")]
        public IActionResult Post([FromBody]Product product) //Create
        {

            try
            {
                product.Validate();
                if (!product.IsValid)
                {
                    return BadRequest(product.GetValidationMessages());
                }
                if(product.Id > 0)
                {
                    _productRepository.Update(product);
                }else
                {
                    _productRepository.Add(product);                   
                }
                return Created("api/product", product);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        //Não há necessidade de usar o Delete
        [HttpPost("Delete")]
        public IActionResult Delete([FromBody] Product product)
        {
            try
            {
                //Product recebido do FromBody deve ter o Id > 0
                _productRepository.Remove(product);
                return Json(_productRepository.GetAll());
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost("SendFile")]
        public IActionResult SendFile()
        {
            try
            {
                var formFile = _httpContextAccessor.HttpContext.Request.Form.Files["sentFile"];//sendFile do form no service
                var fileName = formFile.FileName;
                //Tranforma nome do arquivo em estrutura
                var extension = fileName.Split(".").Last();
                //Take 10 letras apenas
                string newFileName = GenerateNewName(fileName, extension);
                //WebRootPath = endereço do wwwroot
                var filesFolder = _hostingEnvironment.WebRootPath + "\\Files\\";
                var fullName = filesFolder + newFileName;

                //salva no endereço do stream "\\Files\\"
                using (var fIleStream = new FileStream(fullName, FileMode.Create))
                {
                    //É o formfile que tem o arquivo e copia para um novo endereço
                    formFile.CopyTo(fIleStream);
                }
                return Json(newFileName);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        private static string GenerateNewName(string fileName, string extension)
        {
            var arrayShortName = Path.GetFileNameWithoutExtension(fileName).Take(10).ToArray();
            var newFileName = new string(arrayShortName).Replace(" ", "-");
            newFileName = $"{newFileName}_{DateTime.Now.Year}{DateTime.Now.Month}{DateTime.Now.Day}{DateTime.Now.Hour}{DateTime.Now.Minute}{DateTime.Now.Second}" + "." + extension;
            return newFileName;
        }
    }
}
