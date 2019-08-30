using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuickBuy.Domain.Contracts;
using QuickBuy.Domain.Entities;

namespace QuickBuy.Web.Controllers
{
    //rota de acesso pro service
    [Route("api/[Controller]")] //ignora controller do UserController e so entende User
    //endereço fica api/user
    public class UserController : Controller
    {

        //Injeção de dependência feita no startup (faz sem o new...)
        private readonly IUserRepository _userRespository;

        public UserController(IUserRepository userRespository)
        {
            _userRespository = userRespository;
        }


        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }

        //Para verificar se user existe pela senha
        [HttpPost("CheckUser")] //"CheckUser" caminho para chamar essa action
        //FromBody pega do corpo da requisição do service
        public IActionResult CheckUser([FromBody] User user)//preenche user com dados da requisição)
        {
            try
            {
                var userReturn = _userRespository.GetEmailPassword(user.Email, user.Password);
                if (userReturn != null)
                {
                    return Ok(userReturn); //retorna user convertido em json
                }
                return BadRequest("User or password is invalid");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }

        [HttpPost]
        public IActionResult Post()
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }
    }
}