using StockCommerce.Aplication.DTO;
using StockCommerce.Transversal.Common;
using System.Data;

namespace StockCommerce.Aplication.Interface
{
    public  interface ICommonAplication
    {
        Task<Response<dynamic>> GetJhonsitoMeDejo(PruebaDTO parameters);
    }
}
