using StockCommerce.Aplication.Interface;
using StockCommerce.Transversal.Common;
using StockCommerce.Aplication.DTO;
using StockCommerce.Domain.Interface;
using AutoMapper;
using StockCommerce.Domain.Entities;
using System.Diagnostics;
using System.Reflection;
using System.Data;

namespace StockCommerce.Aplication.Main
{
    public class CommonAplication:ICommonAplication
    {
        private readonly ICommonDomain _commonDomain;
        private readonly IMapper _mapper;
        IDbConnection connection = null;
        IDbTransaction transaction = null;
        public CommonAplication(ICommonDomain commonDomain, IMapper mapper)
        { 
            _commonDomain = commonDomain;
            _mapper = mapper;
         }
        public async Task<Response<dynamic>> GetJhonsitoMeDejo(PruebaDTO parameters)
        {
            MethodBase method = await GetMethodInfo(new StackTrace());

            try
            {
                InitializeConnection(true);
                var response = await _commonDomain.GetJhonsitoMeDejo(transaction,connection,_mapper.Map<prueba>(parameters));
               // _dbContext.EndConnection(connection, transaction, response.success);
                return response;
            }
            catch (Exception ex)
            {
               // _dbContext.EndConnection(connection, transaction, false);
                //long errorCode = await _log.InsertLogApi(Codes.this_solution, _helper.GetNameController(method.DeclaringType.Name), method.Name, "POST", paramsDTO, null, null, null, null, ex);
                //return new Response<dynamic>() { success = false, error = true, message = Messages.Msg001 + errorCode };
                return new Response<dynamic>() { success = false, error = true, message ="" };
            }

        }

        #region Private methods
        private async Task<MethodBase> GetMethodInfo(StackTrace method)
        {
            var methodInfo = method.GetFrames().Select(frame => frame.GetMethod()).FirstOrDefault(item => item.DeclaringType == GetType());
            await Task.Yield();
            return methodInfo;
        }

        // inicializadores de conexion Saas
        private void InitializeConnection(bool readOnly)
        {
            //connection = readOnly ? _dbContext.OpenConnection(Codes.cs_onlyRead_dbEducativeCredit) : _dbContext.OpenConnection(Codes.cs_transactional_dbEducativeCredit);
            InitializeTransaction(readOnly);
        }
        private void InitializeTransaction(bool readOnly)
        {
            transaction = readOnly ? transaction : connection.BeginTransaction();
        }

     
        #endregion
    }
}