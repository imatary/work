using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UMC.Entities;

namespace UMC.Services
{
    public class ModelsService : QA_BaseService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Models> Get()
        {
            using (var connection = GetOpenConnection())
            {
                return connection.GetList<Models>().ToList();
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerName"></param>
        /// <returns></returns>
        public List<Models> Get(string customerName)
        {
            using (var connection = GetOpenConnection())
            {
                return connection.GetList<Models>("WHERE ([CustomerName] = @cus) ORDER BY [ModelName] ASC", new { cus = customerName }).ToList();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelName"></param>
        /// <returns></returns>
        public Models GetSingle(string modelName)
        {
            using (var connection=GetOpenConnection())
            {
                return connection.Query<Models>("SELECT * FROM Models WHERE [ModelName]= @modelName", new { modelName = modelName }).SingleOrDefault();

            }
        }
    }
}
