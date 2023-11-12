using StockCommerce.Domain.Entities;
using StockCommerce.Transversal.Common;
using System.Data;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace StockCommerce.Domain.Interface
{
    public interface ICommonDomain
    {
        Task<Response<dynamic>> GetJhonsitoMeDejo(IDbTransaction transaction, IDbConnection connection, prueba parameters);
    }
}
