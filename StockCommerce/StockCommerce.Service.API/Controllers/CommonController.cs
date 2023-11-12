using Microsoft.AspNetCore.Mvc;
using StockCommerce.Aplication.DTO;
using StockCommerce.Aplication.Interface;
using StockCommerce.Transversal.Common;
using System.Threading.Tasks;

namespace StockCommerce.Service.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CommonController : ControllerBase
    {
        private readonly ICommonAplication _commonAplication;
        public CommonController(ICommonAplication commonAplication)
        {
            _commonAplication = commonAplication;
        }
        [HttpPost]
        public async Task<Response<dynamic>> postJhonsitoMeDejo(PruebaDTO parameters)
        {
            return await _commonAplication.GetJhonsitoMeDejo(parameters);
        }
    }
}
