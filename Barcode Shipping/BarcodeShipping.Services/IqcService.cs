using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using BarcodeShipping.Data;
using BarcodeShipping.Data.Repositories;

namespace BarcodeShipping.Services
{

    public class IqcService
    {
        private readonly IQCDataEntities _context;
        public IqcService()
        {
            _context = new IQCDataEntities();
        }
        private IRepository _repository;

        public IRepository Repository
        {
            get { return _repository ?? (_repository = new IqcRepository()); }
        }

 

        /// <summary>
        /// Get PCB
        /// </summary>
        /// <param name="productionId"></param>
        /// <returns></returns>
        public tbl_test_log GetPcbById(string productionId)
        {
            var param = new SqlParameter()
            {
                ParameterName = "@productionId",
                SqlDbType = SqlDbType.VarChar,
                Value = productionId,
            };
            return _context.Database.SqlQuery<tbl_test_log>("EXEC sp_GetLogByProductionId @productionId", param).FirstOrDefault();
        }

        /// <summary>
        /// Kiểm tra sự tồn tại của Operator
        /// </summary>
        /// <param name="productionId"></param>
        /// <returns></returns>
        public bool CheckPcbExits(string productionId)
        {
            var pcb = GetPcbById(productionId);
            if (pcb != null)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="poNo"></param>
        /// <returns></returns>
        public List<Shipping> GetShippingsByPo(string poNo)
        {
            object[] param =
            {
                new SqlParameter() { ParameterName = "@poNo", Value = poNo, SqlDbType = SqlDbType.VarChar},
                new SqlParameter("@Out_Parameter", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                }
            };
            return _context.Database.SqlQuery<Shipping>("EXEC [sp_GetShippingsByPo] @poNo", param).ToList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="boxId"></param>
        /// <returns></returns>
        public List<Shipping> GetShippingsByBoxId(string boxId)
        {
            object[] param =
            {
                new SqlParameter() { ParameterName = "@boxId", Value = boxId, SqlDbType = SqlDbType.VarChar},
                new SqlParameter("@Out_Parameter", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                }
            };
            return _context.Database.SqlQuery<Shipping>("EXEC [sp_GetShippingsByBoxId] @boxId", param).ToList();
        }

        /// <summary>
        /// Get Shipping By Production ID
        /// </summary>
        /// <param name="productionId"></param>
        /// <returns></returns>
        public Shipping GetShippingById(string productionId)
        {
            object[] param =
            {
                new SqlParameter() { ParameterName = "@productionId", Value = productionId, SqlDbType = SqlDbType.VarChar},
                new SqlParameter("@Out_Parameter", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                }
            };

            return _context.Database.SqlQuery<Shipping>("EXEC [sp_GetShippingById] @productionId", param).FirstOrDefault();
        }

        public Shipping GetShippingByGuiId(Guid id)
        {
            object[] param =
            {
                new SqlParameter() { ParameterName = "@Id", Value = id, SqlDbType = SqlDbType.UniqueIdentifier},
                new SqlParameter("@Out_Parameter", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                }
            };

            return _context.Database.SqlQuery<Shipping>("EXEC [sp_GetShippingByGuiId] @Id", param).FirstOrDefault();
        }

        /// <summary>
        /// Kiểm tra sự tồn tại của PCb vừa nhập đã có trong BOX hiện tại hay chưa
        /// Nếu có thì không cho làm việc
        /// Chưa có thì thực hiện thêm mới vào danh sách
        /// </summary>
        /// <returns></returns>
        public bool CheckPcbExitsOnBoxOrShip(string productId, IEnumerable<Shipping> shippings)
        {
            if (!string.IsNullOrEmpty(productId))
            {
                var shipping = shippings.FirstOrDefault(p => p.ProductID == productId);
                if (shipping != null)
                {
                    return false;
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// Kiểm tra sự tồn tại của Box
        /// </summary>
        /// <param name="boxId"></param>
        /// <returns></returns>
        public bool CheckBoxExits(string boxId)
        {
            if (boxId != null)
            {
                var shippings = GetShippingsByBoxId(boxId).ToList();
                if (shippings.Any(c => c.BoxID == boxId))
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        /// <summary>
        /// Insert to Shipping
        /// </summary>
        /// <param name="operatorCode"></param>
        /// <param name="modelId"></param>
        /// <param name="workingOder"></param>
        /// <param name="quantity"></param>
        /// <param name="poNo"></param>
        /// <param name="boxId"></param>
        /// <param name="productId"></param>
        /// <param name="macAddress"></param>
        public void InsertShipping(
            string operatorCode, 
            string modelId, 
            string workingOder, 
            int quantity,
            string poNo,
            string boxId,
            string productId,
            string macAddress)
        {
            object[] param =
            {
                new SqlParameter() { ParameterName = "@Id", Value = Guid.NewGuid(), SqlDbType = SqlDbType.UniqueIdentifier},
                new SqlParameter() { ParameterName = "@Operator", Value = operatorCode, SqlDbType = SqlDbType.VarChar},
                new SqlParameter() { ParameterName = "@Model", Value = modelId, SqlDbType = SqlDbType.VarChar},
                new SqlParameter() { ParameterName = "@WorkingOder", Value = workingOder, SqlDbType = SqlDbType.VarChar},
                new SqlParameter() { ParameterName = "@Quantity", Value = quantity, SqlDbType = SqlDbType.Int},
                new SqlParameter() { ParameterName = "@BoxID", Value = boxId, SqlDbType = SqlDbType.VarChar},
                new SqlParameter() { ParameterName = "@ProductID", Value = productId, SqlDbType = SqlDbType.VarChar},
                new SqlParameter() { ParameterName = "@DateCheck", Value = DateTime.Now, SqlDbType = SqlDbType.DateTime},
                new SqlParameter() { ParameterName = "@MacAddress", Value = macAddress, SqlDbType = SqlDbType.VarChar},
                new SqlParameter() { ParameterName = "@PO_NO", Value = poNo, SqlDbType = SqlDbType.VarChar},
                new SqlParameter("@Out_Parameter", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                }
            };

            try
            {
                _context.Database.ExecuteSqlCommand("EXEC [sp_InsertShipping] @Id, @Operator, @Model, @WorkingOder, @Quantity, @BoxID, @ProductID, @DateCheck, @MacAddress, @PO_NO", param);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }


        #region Logs

        /// <summary>
        /// Kiểm tra sự tồn tại của PCb vừa nhập đã có trong BOX hiện tại hay chưa
        /// Nếu có thì không cho làm việc
        /// Chưa có thì thực hiện thêm mới vào danh sách
        /// </summary>
        /// <returns></returns>
        public bool CheckPcbExitsOnBox(string productId, IEnumerable<tbl_test_log> logs)
        {
            if (!string.IsNullOrEmpty(productId))
            {
                var log = logs.FirstOrDefault(p => p.ProductionID == productId);
                if (log != null)
                {
                    return false;
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// Insert Log
        /// </summary>
        /// <param name="productionId"></param>
        /// <param name="lineId"></param>
        /// <param name="macAddress"></param>
        /// <param name="boxId"></param>
        /// <param name="modelId"></param>
        /// <param name="workingOder"></param>
        /// <param name="quantity"></param>
        /// <param name="operatorCode"></param>
        /// <param name="qaCheck"></param>
        public void InsertLogs(
            string productionId,
            int lineId,
            string macAddress,
            string boxId,
            string modelId,
            string workingOder,
            int quantity, 
            string operatorCode)
        {
            var log = new tbl_test_log()
            {
                ProductionID = productionId,
                LineID = lineId,
                MacAddress = macAddress,
                BoxID = boxId,
                ModelID = modelId,
                WorkingOder = workingOder,
                DateCheck = DateTime.Now,
                TimeCheck = DateTime.Now.TimeOfDay,
                Quantity = quantity,
                OperatorCode = operatorCode,
                QA_Check = false,
            };

            try
            {
                Repository.Insert(log);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="productionId"></param>
        /// <param name="lineId"></param>
        /// <param name="macAddress"></param>
        /// <param name="boxId"></param>
        /// <param name="modelId"></param>
        /// <param name="workingOder"></param>
        /// <param name="quantity"></param>
        /// <param name="operatorCode"></param>
        public void UpdateLogs(
            string productionId,
            int lineId,
            string macAddress,
            string boxId,
            string modelId,
            string workingOder,
            int quantity, string operatorCode)
        {
            var log = GetPcbById(productionId);

            log.LineID = lineId;
            log.MacAddress = macAddress;
            log.BoxID = boxId;
            log.ModelID = modelId;
            log.WorkingOder = workingOder;
            log.DateCheck = DateTime.Now;
            log.TimeCheck = DateTime.Now.TimeOfDay;
            log.Quantity = quantity;
            log.OperatorCode = operatorCode;

            try
            {
                Repository.Update(log);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Update QA Check
        /// <summary>
        /// 
        /// </summary>
        /// <param name="productionId"></param>
        /// <param name="lineId"></param>
        /// <param name="macAddress"></param>
        /// <param name="boxId"></param>
        /// <param name="modelId"></param>
        /// <param name="workingOder"></param>
        /// <param name="quantity"></param>
        /// <param name="operatorCode"></param>
        public void UpdateQaCheckLogs(
            string productionId,
            int lineId,
            string macAddress,
            string boxId,
            string modelId,
            string workingOder,
            int quantity, string operatorCode)
        {
            var log = GetPcbById(productionId);

            log.LineID = lineId;
            log.MacAddress = macAddress;
            log.BoxID = boxId;
            log.ModelID = modelId;
            log.WorkingOder = workingOder;
            log.DateCheck = DateTime.Now;
            log.TimeCheck = DateTime.Now.TimeOfDay;
            log.Quantity = quantity;
            log.OperatorCode = operatorCode;

            try
            {
                Repository.Update(log);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion



        #region Log Result

        /// <summary>
        /// Get Production ID
        /// </summary>
        /// <param name="productionId"></param>
        /// <param name="operationId"></param>
        /// <returns></returns>
        public tbl_test_result GetResultById(string productionId, int operationId)
        {
            object[] param =
            {
                new SqlParameter() { ParameterName = "@productionId", Value = productionId, SqlDbType = SqlDbType.VarChar},
                new SqlParameter() { ParameterName = "@operationId", Value = operationId, SqlDbType = SqlDbType.Int},
                new SqlParameter("@Out_Parameter", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                }
            };

            return _context.Database.SqlQuery<tbl_test_result>("EXEC [sp_GetLogResultsById] @productionId, @operationId", param).FirstOrDefault();

        }

        /// <summary>
        /// Result check exits
        /// </summary>
        /// <param name="productionId"></param>
        /// <param name="operationId"></param>
        /// <returns></returns>
        public bool CheckResultExits(string productionId, int operationId)
        {
            var pcb = GetResultById(productionId, operationId);
            if (pcb != null)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Xóa Result
        /// </summary>
        /// <param name="productionId"></param>
        /// <param name="operationId"></param>
        public void DeleteResult(string productionId, int operationId)
        {
            var result = GetResultById(productionId, operationId);
            try
            {
                Repository.Delete(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        /// <summary>
        /// Insert Result
        /// </summary>
        /// <param name="productionId"></param>
        /// <param name="operationId"></param>
        /// <param name="judge"></param>
        /// <param name="operatorId"></param>
        public void InsertResult(
            string productionId,
            int operationId,
            bool judge,
            string operatorId)
        {
            var result = new tbl_test_result()
            {
                ProductionID = productionId,
                OperationID = operationId,
                JudgeResult = judge,
                OperatorID = operatorId,
                OperationDate = DateTime.Now
            };
            try
            {
                Repository.Insert(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Update
        /// </summary>
        /// <param name="productionId"></param>
        /// <param name="operationId"></param>
        /// <param name="judge"></param>
        /// <param name="operatorId"></param>
        public void UpdateResult(
            string productionId,
            int operationId,
            bool judge,
            string operatorId)
        {
            var result = GetResultById(productionId, operationId);
            result.JudgeResult = judge;
            result.OperatorID = operatorId;
            result.OperationDate = DateTime.Now;
            
            try
            {
                Repository.Update(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Packing PO

        /// <summary>
        /// Trả về QtyPO và Remains theo workingOder và PoNo
        /// </summary>
        /// <param name="modelNo">Model</param>
        /// <param name="poNo">PO</param>
        public PackingPO GetPackingPoModelAndPoNo(string modelNo, string poNo)
        {
            object[] param =
            {
                new SqlParameter() { ParameterName = "@modelNo", Value = modelNo, SqlDbType = SqlDbType.VarChar},
                new SqlParameter() { ParameterName = "@poNo", Value = poNo, SqlDbType = SqlDbType.VarChar},
                new SqlParameter("@Out_Parameter", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                }
            };

            return _context.Database.SqlQuery<PackingPO>("EXEC [sp_GetPackingPoModelAndPoNo] @modelNo, @poNo", param).FirstOrDefault();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelNo"></param>
        /// <param name="poNo"></param>
        /// <returns></returns>
        public PackingPO GetPoByModelAndPoNo(string modelNo, string poNo)
        {
            object[] param =
            {
                new SqlParameter() { ParameterName = "@modelNo", Value = modelNo, SqlDbType = SqlDbType.VarChar},
                new SqlParameter() { ParameterName = "@poNo", Value = poNo, SqlDbType = SqlDbType.VarChar},
                new SqlParameter("@Out_Parameter", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                }
            };

            return _context.Database.SqlQuery<PackingPO>("EXEC [sp_GetPackingPoModelAndPoNo] @modelNo, @poNo", param).FirstOrDefault();

        }

        /// <summary>
        /// Insert PO
        /// </summary>
        /// <param name="modelId"></param>
        /// <param name="po"></param>
        /// <param name="qtyPo"></param>
        /// <param name="createdBy"></param>
        public void InsertPo(string modelId, string po, int qtyPo, string createdBy)
        {
            var poAdd = new PackingPO()
            {
                ModelID = modelId,
                PO_NO = po,
                QuantityPO = qtyPo,
                QuantityRemain = qtyPo,
                DateCreated = DateTime.Now,
                TimeCreated = DateTime.Now.TimeOfDay,
                CreateBy = createdBy,
            };

            try
            {
                Repository.Insert(poAdd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Update PO
        /// </summary>
        /// <param name="modelId"></param>
        /// <param name="po"></param>
        /// <param name="qtyPo"></param>
        /// <param name="createdBy"></param>
        public void UpdatePo(string modelId, string po, int qtyPo, string createdBy)
        {
            var packingPo = GetPackingPoModelAndPoNo(modelId, po);

            if (packingPo != null)
            {
                packingPo.QuantityPO = packingPo.QuantityPO + qtyPo;
                packingPo.QuantityRemain = qtyPo;
                packingPo.DateCreated = DateTime.Now;
                packingPo.TimeCreated = DateTime.Now.TimeOfDay;
                packingPo.CreateBy = createdBy;

                try
                {
                    Repository.Update(packingPo);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public void DeletePcbById(Guid id)
        {
            var shipping = GetShippingByGuiId(id);
            if (shipping != null)
            {
                try
                {
                    Repository.Delete(shipping);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="poId"></param>
        /// <param name="modelNo"></param>
        /// <param name="remains"></param>
        public void UpdateRemainsForPo(string poId, string modelNo, int remains)
        {
            PackingPO po = GetPoByModelAndPoNo(modelNo, poId);
            if(po!=null)
            {
                object[] param =
                {
                    new SqlParameter() {ParameterName = "@ModelID", Value = modelNo, SqlDbType = SqlDbType.VarChar},
                    new SqlParameter() {ParameterName = "@PO_NO", Value = poId, SqlDbType = SqlDbType.VarChar},
                    new SqlParameter() {ParameterName = "@QuantityRemain", Value = remains, SqlDbType = SqlDbType.Int},
                    new SqlParameter("@Out_Parameter", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    }
                };
                try
                {
                    _context.Database.ExecuteSqlCommand("EXEC [sp_UpdateRemainsForPo] @ModelID, @PO_NO, @QuantityRemain", param);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            
        }

        #endregion
    }
}
