using StockCommerce.Domain.Entities;
using StockCommerce.Transversal.Common;
using StockCommerce.Domain.Interface;
using StockCommerce.Infraestructure.Interface;
using System.Data;

namespace StockCommerce.Domain.Core
{
    public class CommonDomain:ICommonDomain
    {
        private readonly ICommonRepository<prueba> _pruebaRepo;
        public CommonDomain(ICommonRepository<prueba> prueba) 
        {
           _pruebaRepo = prueba;
        }
        public async Task<Response<dynamic>> GetJhonsitoMeDejo(IDbTransaction transaction, IDbConnection connection, prueba parameters)
        {
            IEnumerable<prueba> prueba = await _pruebaRepo.ListAll(connection);
            return new Response<dynamic>() { success = true, error = false, message = "Efectivamente me dejo solo", result = prueba };
        }
    }
}
