using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using UMC.Entities;

namespace UMC.Services
{
    public class TestLogService : QA_BaseService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="boxId"></param>
        /// <returns></returns>
        public List<tbl_test_log> Get(string boxId)
        {
            using (var connection=GetOpenConnection())
            {
                return connection.Query<tbl_test_log>("SELECT * FROM tbl_test_log WHERE [BoxID] = @boxId ORDER BY [TimeCheck] ASC", new { boxId = boxId }).ToList();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="boardNo"></param>
        /// <returns></returns>
        public tbl_test_log GetSingle(string boardNo)
        {
            using (var connection = GetOpenConnection())
            {
                //string sql = "SELECT * FROM tbl_test_log WHERE [ProductionID] = @boardNo";
                //return connection.Query<tbl_test_log>(sql, new { boardNo = boardNo }).SingleOrDefault();
                return connection.Get<tbl_test_log>(boardNo);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="boxId"></param>
        /// <returns></returns>
        public tbl_test_log GetFirst(string boxId)
        {
            using (var connection = GetOpenConnection())
            {
                return connection.GetList<tbl_test_log>("WHERE ([BoxID] = @boxId)", new { boxId = boxId }).FirstOrDefault();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Insert(tbl_test_log entity)
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
        public bool Update(tbl_test_log entity)
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
        public bool Delete(tbl_test_log entity)
        {
            using (var connection = GetOpenConnection())
            {
                try
                {
                    connection.Delete<tbl_test_log>(entity);
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
