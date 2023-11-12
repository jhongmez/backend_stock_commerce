using StockCommerce.Infraestructure.Interface;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Threading.Tasks;
using Dapper;

namespace StockCommerce.Infraestructure.Data
{
    public class CommonRepository<T>:ICommonRepository<T> where T :class
    {
        public async Task Insert(IDbTransaction transaction, T entity)
        {
            string queryPart1 = "INSERT INTO " + typeof(T).Name + " (";
            string queryPart2 = ") VALUES (";
            PropertyInfo[] properties = typeof(T).GetProperties();
            PropertyInfo[] array = properties;
            foreach (PropertyInfo p in array)
            {
                queryPart1 = queryPart1 + " " + p.Name + ",";
                queryPart2 = queryPart2 + " @" + p.Name + ",";
            }

            string query = queryPart1.TrimEnd(',') + " " + queryPart2.TrimEnd(',') + ");";
            await Task.Run(() => transaction.Connection.QueryAsync(query, entity, transaction, null, transaction.Connection.CreateCommand().CommandType));
        }

        public async Task Insert(IDbTransaction transaction, IEnumerable<T> entities)
        {
            foreach (T entity in entities)
            {
                string queryPart1 = "INSERT INTO " + typeof(T).Name + " (";
                string queryPart2 = ") VALUES (";
                PropertyInfo[] properties = typeof(T).GetProperties();
                PropertyInfo[] array = properties;
                foreach (PropertyInfo p in array)
                {
                    queryPart1 = queryPart1 + " " + p.Name + ",";
                    queryPart2 = queryPart2 + " @" + p.Name + ",";
                }

                string query = queryPart1.TrimEnd(',') + " " + queryPart2.TrimEnd(',') + ");";
                await Task.Run(() => transaction.Connection.QueryAsync(query, entity, transaction, null, transaction.Connection.CreateCommand().CommandType));
            }
        }

        public async Task<IEnumerable<T>> ListAll(IDbConnection connection)
        {
            string query = "SELECT * FROM " + typeof(T).Name;
            return await Task.Run(() => connection.QueryAsync<T>(query));
        }

        public async Task<IEnumerable<T>> ListAll(IDbTransaction transaction)
        {
            string query = "SELECT * FROM " + typeof(T).Name;
            return await Task.Run(() => transaction.Connection.QueryAsync<T>(query, null, transaction, null, transaction.Connection.CreateCommand().CommandType));
        }

        public async Task<IEnumerable<T>> ListByWhere(IDbConnection connection, string where, object parameters = null)
        {
            string query = "SELECT * FROM " + typeof(T).Name + " WHERE " + where;
            return await Task.Run(() => connection.QueryAsync<T>(query, parameters));
        }

        public async Task<IEnumerable<T>> ListByWhere(IDbTransaction transaction, string where, object parameters = null)
        {
            string query = "SELECT * FROM " + typeof(T).Name + " WHERE " + where;
            return await Task.Run(() => transaction.Connection.QueryAsync<T>(query, parameters, transaction, null, transaction.Connection.CreateCommand().CommandType));
        }

        public async Task Delete(IDbTransaction transaction, T entity)
        {
            string query = "DELETE FROM " + typeof(T).Name + " WHERE ID = @ID";
            await Task.Run(() => transaction.Connection.QueryAsync(query, entity, transaction, null, transaction.Connection.CreateCommand().CommandType));
        }

        public async Task Delete(IDbTransaction transaction, IEnumerable<T> entities)
        {
            string query = "DELETE FROM " + typeof(T).Name + " WHERE ID = @ID";
            await Task.Run(() => transaction.Connection.QueryAsync(query, entities, transaction, null, transaction.Connection.CreateCommand().CommandType));
        }

        public async Task Update(IDbTransaction transaction, T entity)
        {
            string queryPart1 = "UPDATE " + typeof(T).Name + " SET ";
            string queryPart2 = " WHERE ID = @ID";
            PropertyInfo[] properties = typeof(T).GetProperties();
            PropertyInfo[] array = properties;
            foreach (PropertyInfo p in array)
            {
                if (p.Name != "ID")
                {
                    queryPart1 = queryPart1 + " " + p.Name + " = @" + p.Name + ",";
                }
            }

            string query = queryPart1.TrimEnd(',') + " " + queryPart2;
            await Task.Run(() => transaction.Connection.QueryAsync(query, entity, transaction, null, transaction.Connection.CreateCommand().CommandType));
        }

        public async Task Update(IDbTransaction transaction, IEnumerable<T> entities)
        {
            foreach (T entity in entities)
            {
                string queryPart1 = "UPDATE " + typeof(T).Name + " SET ";
                string queryPart2 = " WHERE ID = @ID";
                PropertyInfo[] properties = typeof(T).GetProperties();
                PropertyInfo[] array = properties;
                foreach (PropertyInfo p in array)
                {
                    if (p.Name != "ID")
                    {
                        queryPart1 = queryPart1 + " " + p.Name + " = @" + p.Name + ",";
                    }
                }

                string query = queryPart1.TrimEnd(',') + " " + queryPart2;
                await Task.Run(() => transaction.Connection.QueryAsync(query, entity, transaction, null, transaction.Connection.CreateCommand().CommandType));
            }
        }

        public async Task<IEnumerable<dynamic>> ExecuteQuery(IDbTransaction transaction, string query, object parameters = null)
        {
            IDbCommand comando = transaction.Connection.CreateCommand();
            return await Task.Run(() => transaction.Connection.QueryAsync<T>(query, parameters, transaction, null, comando.CommandType));
        }

        public async Task<IEnumerable<dynamic>> ExecuteQuery(IDbConnection connection, string query, object parameters = null)
        {
            return await Task.Run(() => connection.QueryAsync<T>(query, parameters));
        }
    }
}
