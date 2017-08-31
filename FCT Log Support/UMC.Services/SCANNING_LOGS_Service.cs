using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UMC.Services
{
    public class SCANNING_LOGS_Service : PVS_BaseService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="boardNo"></param>
        /// <returns></returns>
        public List<SCANNING_LOGS> Get(string boardNo)
        {
            using (var connection= GetOpenConnection())
            {
                return connection.GetList<SCANNING_LOGS>("WHERE (BOARD_NO = @boardNo) ORDER BY [PROCEDURE_INDEX] ASC", new { boardNo = boardNo }).ToList();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="boardNo"></param>
        /// <returns></returns>
        public SCANNING_LOGS GetSingle(string boardNo)
        {
            using (var connection = GetOpenConnection())
            {
                return connection.GetList<SCANNING_LOGS>("WHERE (BOARD_NO = @boardNo)", new { boardNo = boardNo }).FirstOrDefault();
            }
        }
    }
}
