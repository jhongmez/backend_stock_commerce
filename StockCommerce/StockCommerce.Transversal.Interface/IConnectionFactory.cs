using System.Data;

namespace StockCommerce.Transversal.Interface
{
    public interface IConnectionFactory
    {
          IDbConnection GetConnection { get; }
    }
}
