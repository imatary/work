using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UMC.Entities;

namespace UMC.Services
{
    public class TestResultService : QA_BaseService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="boardNo"></param>
        /// <param name="operationId"></param>
        /// <returns></returns>
        public tbl_test_result GetSingle(string boardNo, int operationId)
        {
            using (var connection = GetOpenConnection())
            {
                string sql = "SELECT * FROM tbl_test_result WHERE ([ProductionID] = @boardNo) AND ([OperationID] = @operationId)";
                return connection.Query<tbl_test_result>(sql, new { boardNo = boardNo, operationId = operationId }).SingleOrDefault();
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Insert(tbl_test_result entity)
        {
            using (var connection = GetOpenConnection())
            {
                try
                {
                    connection.Insert<string>(entity);
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Update(tbl_test_result entity)
        {
            using (var connection = GetOpenConnection())
            {
                try
                {
                    connection.Update(entity);
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        public bool Delete(tbl_test_result entity)
        {
            using (var connection = GetOpenConnection())
            {
                try
                {
                    connection.Delete<tbl_test_result>(entity);
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

    }
}
