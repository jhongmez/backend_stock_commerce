using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace StockCommerce.Infraestructure.Interface
{
    public interface ICommonRepository<T> where T : class
    {
        Task Insert(IDbTransaction transaction, T entity);

        Task Insert(IDbTransaction transaction, IEnumerable<T> entities);

        Task Update(IDbTransaction transaction, T entity);

        Task Update(IDbTransaction transaction, IEnumerable<T> entities);

        Task<IEnumerable<T>> ListAll(IDbConnection connection);

        Task<IEnumerable<T>> ListAll(IDbTransaction transaction);

        Task<IEnumerable<T>> ListByWhere(IDbConnection connection, string where, object parameters = null);

        Task<IEnumerable<T>> ListByWhere(IDbTransaction transaction, string where, object parameters = null);

        Task Delete(IDbTransaction transaction, T entity);

        Task Delete(IDbTransaction transaction, IEnumerable<T> entities);

        Task<IEnumerable<dynamic>> ExecuteQuery(IDbTransaction transaction, string query, object parameters = null);

        Task<IEnumerable<dynamic>> ExecuteQuery(IDbConnection connection, string query, object parameters = null);
    }
}
